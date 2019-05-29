using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using Mercury.Model.Calendar;
using Sun;
using WLib;
using WLSql;
using Venus;
using System.Reflection;
using Core.Model.Organisation;

namespace Calendar
{
	public enum CalendarCyclePeriodTypeEnum: byte { NonCyclic, Day, Week, Decade, Month, Quarter, Halfyear, Year }
	[WLInterface( typeof( wCalendarDefinition))]
	[WLAttribute( "Definicja kalendarza", WLClassTypeEnum.ListTable, WLSecurityTypeEnum.AuthorizationRequired )]
	[System.Runtime.InteropServices.GuidAttribute( "C31A3319-DC90-497f-9681-678E2B8D89CF" )]
	public class CalendarDefinition: ListTable, ICalendar
	{
		#region Declarations
		private IUser oOwner = null;
		//private WList<ICalendarEvent> oItems = null;
		private WList<Authorization> oAuthorizations = null;
		private Type oRelatedType = null;
		private WList<CalendarDefinitionSubgroup> oSubgroups = null;
		public struct ConfigSettings
		{
		}
		public struct Messages
		{
		}
		#endregion

		#region Constructors
		public CalendarDefinition()
			: base( TableName )
		{
			this.Owner = Login.CurrentLogin.User;
		}
		public CalendarDefinition( SqlDataReader oReader )
			: base( TableName, oReader )
		{
			//this.Owner = Login.CurrentLogin.User;
		}
		public CalendarDefinition( DataRow oRow )
			: base( TableName, oRow )
		{
			//this.Owner = Login.CurrentLogin.User;
		}
		#endregion

		#region Initialize methods
		#endregion

		#region Data methods
		public override bool Validate()
		{
			bool lOK = false;
			//CalendarDefinition oCalendarDefinition = null;

			if ( this.ShortName == string.Empty )
				throw new Exception( "Brak identyfikatora" );
			else if ( this.CheckSameShortNameExists( this))
				throw new Exception( "Kalendarz o podanym identyfikatorze już został zdefiniowany" );
			else
				lOK = base.Validate();

			return lOK;
		}
		public CalendarDefinitionSubgroup CreateNewSubgroup()
		{
			return this.CreateChildDataItem<CalendarDefinitionSubgroup>( this.Subgroups );
		}
		public WList<IListTable> GetEvents( DateTime dtStartDate, DateTime dtEndDate )
		{
			WList<IListTable> oEvents = new WList<IListTable>();
			if ( this.RelatedType != null )
			{
				MethodInfo oGetMethodInfo = this.RelatedType.GetMethod( "GetByCalendarStartEndDate", BindingFlags.Public | BindingFlags.Static );
				if ( oGetMethodInfo != null )
					oEvents.AddRange( (WList<IListTable>)oGetMethodInfo.Invoke( null, new object[] { this, dtStartDate, dtEndDate } ) );
				else if ( ( oGetMethodInfo = this.RelatedType.GetMethod( "GetByStartEndDate", BindingFlags.Public | BindingFlags.Static )) != null)
					oEvents.AddRange( (WList<IListTable>)oGetMethodInfo.Invoke( null, new object[] { dtStartDate, dtEndDate } ) );
			}
			return oEvents;
		}
		public Authorization CreateNewAuthorization()
		{
			Authorization oAuthorization = this.CreateChildDataItem<Authorization>( this.Authorizations );
			oAuthorization.SecuredDataItem = this;
			return oAuthorization;
		}
		public override string ToString()
		{
			return this.ShortName;
		}
		#endregion

		#region Static methods
		public static CalendarDefinition GetByID( string cID )
		{
			return GetByID<CalendarDefinition>( cID );
		}
		public static CalendarDefinition GetByShortName( string cShortName )
		{
			return GetByShortName<CalendarDefinition>( "SHORT_NAME", cShortName );
		}
		public static WList<CalendarDefinition> GetListByOwner( User oOwner )
		{
			return WList<CalendarDefinition>.GetWithConditionsNew( "OWNER_ID", oOwner.ID );
		}
		public static WList<ICalendar> GetAll()
		{
			return WList<ICalendar>.GetWithConditionsNew<CalendarDefinition>( null);
		}
		public static string GetCyclePeriodName( CalendarCyclePeriodTypeEnum oPeriodType )
		{
			string cName = string.Empty;
			switch ( oPeriodType )
			{
				case CalendarCyclePeriodTypeEnum.NonCyclic:
					cName = "bez powtórzeń";
					break;
				case CalendarCyclePeriodTypeEnum.Day:
					cName = "codziennie";
					break;
				case CalendarCyclePeriodTypeEnum.Week:
					cName = "co tydzień";
					break;
				case CalendarCyclePeriodTypeEnum.Decade:
					cName = "co dekadę";
					break;
				case CalendarCyclePeriodTypeEnum.Month:
					cName = "co miesiąc";
					break;
				case CalendarCyclePeriodTypeEnum.Quarter:
					cName = "co kwartał";
					break;
				case CalendarCyclePeriodTypeEnum.Halfyear:
					cName = "co pół roku";
					break;
				case CalendarCyclePeriodTypeEnum.Year:
					cName = "co rok";
					break;
			}

			return cName;
		}
		#endregion

		#region Events
		private void OpenEvent( object sender, EventArgs e )
		{
			RuntimeManager.OpenForm( (IListTable)sender );
		}
		#endregion

		#region Properties
		public static string Title
		{
			get { return "Definicja kalendarza"; }
		}
		public new static string TableName
		{
			get { return "MSCL100"; }
		}
		public string Description
		{
			get { return (string)this.Columns[ "DESCRIPTION" ].Value; }
			set { this.Columns[ "DESCRIPTION"].Value = value; }
		}
		public IUser Owner
		{
			get
			{
				if ( this.oOwner == null )
					this.oOwner = User.GetByID( (string)this.Columns[ "OWNER_ID" ].Value );
				return this.oOwner;
			}
			set
			{
				this.oOwner = value;
				this.Columns[ "OWNER_ID" ].Value = this.oOwner == null ? string.Empty : this.oOwner.ID;
			}
		}
		public Type RelatedType
		{
			get
			{
				if ( this.oRelatedType == null )
					this.oRelatedType = RuntimeManager.GetTypeByClassID( (string)this.Columns[ "RELATED_CLASS_ID" ].Value );
				return this.oRelatedType;
			}
			set
			{
				this.oRelatedType = value;
				this.Columns[ "RELATED_CLASS_ID" ].Value = this.oRelatedType == null ? string.Empty : this.oRelatedType.GUID.ToString();
			}
		}
		public Color DisplayColor
		{
			get { return this.Columns[ "DISPLAY_COLOR" ].Value == string.Empty ? Color.Black : Color.FromArgb( (int)this.Columns[ "DISPLAY_COLOR" ].Value ); }
			set { this.Columns[ "DISPLAY_COLOR"].Value = value.ToArgb(); }
		}
		//public WList<ICalendarEvent> Items
		//{
		//    get
		//    {
		//        if ( this.oItems == null )
		//            this.oItems = CalendarItem.GetByCalendar( this );
		//        return this.oItems;
		//    }
		//}
		public IListTable RelatedParameterTypes
		{
			get { return null; }
			set { }
		}
		public int DefaultEventLength
		{
			get { return (int)this.Columns[ "DEFAULT_EVENT_LENGTH" ].Value; }
			set { this.Columns[ "DEFAULT_EVENT_LENGTH" ].Value = value; }
		}
		public WList<CalendarDefinitionSubgroup> Subgroups
		{
			get 
			{
				if ( this.oSubgroups == null )
					this.oSubgroups = CalendarDefinitionSubgroup.GetListByCalendarDefinition( this );
				return this.oSubgroups; 
			}
		}
		public static LookupInfo LookupInfo
		{
			get
			{
				LookupInfo oLookupInfo = new LookupInfo( Title, TableName);
				oLookupInfo.Columns.Add( ShortNameColumnName, 130, "Identyfikator" );

				return oLookupInfo;
			}
		}
		public static ListFormInfo ListFormInfo
		{
			get
			{
				ListFormInfo oListFormInfo = new ListFormInfo( typeof( CalendarDefinition ) );
				oListFormInfo.Columns.Add( "Identyfikator", ShortNameColumnName, 130 );
				oListFormInfo.Columns.Add( "Nazwa", "NAME", 120 );
				oListFormInfo.Columns.Add( "Nr rejestracyjny", "REGISTRATION_NUMBER", 120 );
				oListFormInfo.Columns.Add( "Nr nazdwozia", "BODY_NUMBER", 120 );
				//oListFormInfo.IDColumnName = InventoryItem.IDColumnName;

				return oListFormInfo;
			}
		}
		public WList<Authorization> Authorizations
		{
			get
			{
				if ( this.oAuthorizations == null)
					this.oAuthorizations = Authorization.GetListBySecuredObject( this);
				return this.oAuthorizations;
			}
		}
		#endregion
	}
}
