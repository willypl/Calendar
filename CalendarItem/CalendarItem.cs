using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Mercury.Model.Calendar;
using WLib;
using WLSql;
using Venus;

namespace Calendar
{
	[WLInterface( typeof( wCalendarItem ) )]
	[WLAttribute( "Pozycja kalendarza", WLClassTypeEnum.ListTable, WLSecurityTypeEnum.AuthorizationRequired )]
	[System.Runtime.InteropServices.GuidAttribute( "3615EFD4-5387-49FA-BB26-D3BEF5C64B46" )]
	public class CalendarItem: ListTable, ICalendarEvent
	{
		#region Declarations
		private ICalendar oCalendar = null;
		public event EventHandler OpenEvent;
		private User oOwner = null;
		private User oCreateUser = null;
		#endregion

		#region Constructors
		public CalendarItem(): base( TableName)
		{
			this.Owner = this.CreateUser = Login.CurrentLogin.User;
			this.StartDate = DateTime.Today;
			this.EndDate = this.StartDate.AddHours( 1 );
		}
		public CalendarItem( SqlDataReader oReader ): base( TableName, oReader )
		{
		}
		public CalendarItem( DataRow oRow): base( TableName, oRow )
		{
		}
		#endregion
		
		#region Data methods
		public void OnOpen( object sender, EventArgs e )
		{
			if ( this.OpenEvent != null )
				this.OpenEvent( this, null );
		}
		#endregion

		#region Static methods
		public static CalendarItem GetByID( string cID )
		{
			return GetByID<CalendarItem>( cID );
		}
		public static CalendarItem GetByShortName( string cShortName )
		{
			return GetWithCondition<CalendarItem>( new SqlStatementCondition( "SHORT_NAME", cShortName ) );
		}
		public static WList<ICalendarEvent> GetByCalendar( CalendarDefinition oCalendarDefinition )
		{
			return WList<ICalendarEvent>.GetWithConditionsNew( "CALENDAR_DEFINITION_ID", oCalendarDefinition.ID );
		}
		public static WList<IListTable> GetByCalendarStartEndDate( CalendarDefinition oCalendar, DateTime dtStartDate, DateTime dtEndDate )
		{
			SqlStatementConditionCollection oConditions = new SqlStatementConditionCollection();
			oConditions.Add( "CALENDAR_DEFINITION_ID", oCalendar == null ? string.Empty : oCalendar.ID );
			oConditions.Add( "END_DATE", dtStartDate, SqlStatementOperator.GreaterThen );
			oConditions.Add( "START_DATE", dtEndDate, SqlStatementOperator.LessThen );

			WList<IListTable> oList = WList<IListTable>.GetWithConditionsNew<CalendarItem>( oConditions );
			//oList.AddRange( GetCyclicEvents() );

			return oList;
		}
		public static WList<IListTable> GetByStartEndDate( DateTime dtStartDate, DateTime dtEndDate )
		{
			SqlStatementConditionCollection oConditions = new SqlStatementConditionCollection();
			oConditions.Add( "END_DATE", dtStartDate, SqlStatementOperator.GreaterThen );
			oConditions.Add( "START_DATE", dtEndDate, SqlStatementOperator.LessThen );

			return WList<IListTable>.GetWithConditionsNew<CalendarItem>( oConditions );
		}
		private static WList<IListTable> GetCyclicEvents( DateTime dtStartDate, DateTime dtEndDate)
		{
			WList<IListTable> oList = new WList<IListTable>();
			foreach ( CalendarItem oCalendarItem in CalendarItem.GetCyclicEvents() )
			{
			//	oList.AddRange( GetEventsByStartEndDate( oCalendarItem, dtStartDate, dtEndDate ) );
			}

			return oList;
		}
		private static WList<CalendarItem> GetCyclicEvents()
		{
			SqlStatementConditionCollection oConditions = new SqlStatementConditionCollection();
			oConditions.Add( "CYCLE_PERIOD_TYPE", 0, SqlStatementOperator.NotEqual);
			oConditions.Add( "INACTIVE", 0);

			return WList<CalendarItem>.GetWithConditionsNew( oConditions );
		}
		private static WList<CalendarItem> GetEventsByStartEndDate( CalendarItem oCalendarItem, DateTime dtStartDate, DateTime dtEndDate )
		{
			WList<CalendarItem> oList = new WList<CalendarItem>();
			if ( oCalendarItem.CyclePeriodType != CalendarCyclePeriodTypeEnum.NonCyclic )
			{

			}

			return oList;
		}
		#endregion

		#region Properties
		public static string Title
		{
			get { return "Pozycja kalendarza"; }
		}
		public new static string TableName
		{
			get { return "MSCL110"; }
		}
		public ICalendar Calendar
		{
			get
			{
				if ( this.oCalendar == null)
					this.oCalendar = CalendarDefinition.GetByID( (string)this.Columns[ "CALENDAR_DEFINITION_ID" ].Value );
				return this.oCalendar;
			}
			set
			{
				this.oCalendar = value;
				this.Columns[ "CALENDAR_DEFINITION_ID" ].Value = this.oCalendar == null ? string.Empty : this.oCalendar.ID;
			}
		}
		public User Owner
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
		public string OwnerUserName
		{
			get { return this.Owner == null ? string.Empty : this.Owner.Name; }
			set
			{
				if ( !ListTable.CompareEqual( this.Owner, value ) )
					this.Owner = User.GetByID( value );
			}
		}
		public User CreateUser
		{
			get
			{
				if ( this.oCreateUser == null )
					this.oCreateUser = User.GetByID( (string)this.Columns[ "ASSIGNED_USER_ID" ].Value );
				return this.oCreateUser;
			}
			set
			{
				this.oCreateUser = value;
				this.Columns[ "ASSIGNED_USER_ID" ].Value = this.oCreateUser == null ? string.Empty : this.oCreateUser.ID;
			}
		}
		public string CreateUserName
		{
			get { return this.CreateUser == null ? string.Empty : this.CreateUser.Name; }
			set
			{
				if ( !ListTable.CompareEqual( this.CreateUser, value ) )
					this.CreateUser = User.GetByID( value );
			}
		}
		public string Description
		{
			get { return (string)this.Columns["DESCRIPTION"].Value; }
			set { this.Columns["DESCRIPTION"].Value = value; }
		}
		/// <summary>
		/// Description for calendar display
		/// </summary>
		public string CalendarDescription
		{
			get { return this.ShortName + "\r\n" + this.Description; }
		}
		/// <summary>
		/// Starting date/time of calendar item
		/// </summary>
		public DateTime StartDate
		{
			get { return (DateTime)this.Columns["START_DATE"].Value; }
			set 
			{
				this.Columns[ "START_DATE" ].Value = value;
				if ( this.EndDate < this.StartDate )
					this.EndDate = this.StartDate.AddHours( 1 );
			}
		}
		/// <summary>
		/// Ending date/time of calendar item
		/// </summary>
		public DateTime EndDate
		{
			get { return (DateTime)this.Columns[ "END_DATE" ].Value; }
			set { this.Columns[ "END_DATE" ].Value = value; }
		}
		/// <summary>
		/// Is calendar item while day lasting 
		/// </summary>
		public bool WholeDay
		{
			get { return (byte)this.Columns[ "WHOLE_DAY" ].Value == 1; }
			set { this.Columns[ "WHOLE_DAY" ].Value = value ? (byte)1 : (byte)0; }
		}
		public string CalendarItemTypeID
		{
			get { return (string)this.Columns["CALENDAR_ITEM_TYPE_ID"].Value; }
			set { this.Columns["CALENDAR_ITEM_TYPE_ID"].Value = value; }
		}
		public CalendarCyclePeriodTypeEnum CyclePeriodType
		{
			get { return (CalendarCyclePeriodTypeEnum)(byte)this.Columns[ "CYCLE_PERIOD_TYPE" ].Value; }
			set { this.Columns[ "CYCLE_PERIOD_TYPE" ].Value = (byte)value; }
		}
		public int CyclePeriod
		{
			get { return (int)this.Columns[ "CYCLE_PERIOD" ].Value; }
			set { this.Columns[ "CYCLE_PERIOD" ].Value = value; }
		}
		public byte CyclicDays
		{
			get { return (byte)this.Columns[ "CYCLE_DAYS" ].Value; }
			set { this.Columns[ "CYCLE_DAYS" ].Value = value; }
		}
		public DateTime CycleStartDate
		{
			get { return (DateTime)this.Columns[ "CYCLE_START_DATE" ].Value; }
			set { this.Columns[ "CYCLE_START_DATE" ].Value = value; }
		}
		public DateTime CycleEndDate
		{
			get { return (DateTime)this.Columns[ "CYCLE_END_DATE" ].Value; }
			set { this.Columns[ "CYCLE_END_DATE" ].Value = value; }
		}
		public bool Inactive
		{
			get { return (bool)this.Columns[ "INACTIVE" ].Value; }
			set { this.Columns[ "INACTIVE" ].Value = value; } 
		}
		public static LookupInfo LookupInfo
		{
			get
			{
				LookupInfo oLI = new LookupInfo( Title, TableName );
				oLI.Columns.Add( "DATE", 100, "Data pocz." );
				oLI.Columns.Add( "DESCRIPTION", 100, "Opis" );
				oLI.OrderBy = "DATE";

				return oLI;
			}
		}
		#endregion
	}
}
