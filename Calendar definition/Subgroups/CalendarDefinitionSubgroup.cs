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

namespace Calendar
{
	[WLInterface( typeof( wCalendarDefinitionSubgroup ) )]
	[WLAttribute( "Definicja kalendarza - podgrupa", WLClassTypeEnum.ListTable, WLSecurityTypeEnum.AuthorizationRequired )]
	[System.Runtime.InteropServices.GuidAttribute( "C31A3319-DC90-497f-9681-678E2B8D89CF" )]
	public class CalendarDefinitionSubgroup: ListTable
	{
		#region Declarations
		private CalendarDefinition oCalendarDefinition = null;
		public struct ConfigSettings
		{
		}
		public struct Messages
		{
		}
		#endregion

		#region Constructors
		public CalendarDefinitionSubgroup()
			: base( TableName )
		{
		}
		public CalendarDefinitionSubgroup( SqlDataReader oReader )
			: base( TableName, oReader )
		{
		}
		public CalendarDefinitionSubgroup( DataRow oRow )
			: base( TableName, oRow )
		{
		}
		#endregion

		#region Initialize methods
		#endregion

		#region Data methods
		public override bool Validate()
		{
			bool lOK = false;

			if ( this.ShortName == string.Empty )
				throw new Exception( "Brak identyfikatora" );
			else if ( this.CheckSameShortNameExists( this ) )
				throw new Exception( "Kalendarz o podanym identyfikatorze już został zdefiniowany" );
			else
				lOK = base.Validate();

			return lOK;
		}
		#endregion

		#region Static methods
		public static CalendarDefinitionSubgroup GetByID( string cID )
		{
			return GetByID<CalendarDefinitionSubgroup>( cID );
		}
		public static WList<CalendarDefinitionSubgroup> GetListByCalendarDefinition( CalendarDefinition oCalendarDefinition )
		{
			return WList<CalendarDefinitionSubgroup>.GetWithConditionsNew( "CALENDAR_DEFINITION_ID", oCalendarDefinition.ID );
		}
		#endregion

		#region Events
		#endregion

		#region Properties
		public new static string TableName
		{
			get { return "MSCL130"; }
		}
		public CalendarDefinition CalendarDefinition
		{
			get
			{
				if ( this.oCalendarDefinition == null )
					this.oCalendarDefinition = CalendarDefinition.GetByID( (string)this.Columns[ "CALENDAR_DEFINITION_ID" ].Value );
				return this.oCalendarDefinition;
			}
			set
			{
				this.oCalendarDefinition = value;
				this.Columns[ "CALENDAR_DEFINITION_ID" ].Value = this.oCalendarDefinition == null ? string.Empty : this.oCalendarDefinition.ID;
			}
		}
		public string PropertyName
		{
			get { return (string)this.Columns[ "PROPERTY_NAME" ].Value; }
			set { this.Columns[ "PROPERTY_NAME" ].Value = value; }
		}
		#endregion
	}
}
