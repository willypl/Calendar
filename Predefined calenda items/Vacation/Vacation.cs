using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Mercury.Model.Calendar;
using WLib;
using WLSql;
using Venus;
using Core.Model.Organisation;

namespace Calendar
{
	[WLInterface( typeof( wVacation ) )]
	[WLAttribute( "Urlop", WLClassTypeEnum.ListTable, WLSecurityTypeEnum.AuthorizationNotRequired)]
	[System.Runtime.InteropServices.GuidAttribute( "7ABD2E63-B8CB-491a-901E-ED894C59C2C9" )]
	public class Vacation: ListTable, ICalendarEvent
	{
		#region Declarations
		private ICalendar oCalendar = null;
		public event EventHandler OpenEvent;
		private IUser oEmployee = null;
		private IUser oOwner = null;
		#endregion

		#region Constructors
		public Vacation(): base( TableName)
		{
			this.Owner = Login.CurrentLogin.User;
			this.StartDate = DateTime.Today;
			this.EndDate = this.StartDate.AddDays( 1 );
		}
		public Vacation( SqlDataReader oReader ): base( TableName, oReader )
		{
		}
		public Vacation( DataRow oRow): base( TableName, oRow )
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
		public static Vacation GetByID( string cID )
		{
			return GetByID<Vacation>( cID );
		}
		public static Vacation GetByShortName( string cShortName )
		{
			return GetWithCondition<Vacation>( new SqlStatementCondition( "SHORT_NAME", cShortName ) );
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
			WList<IListTable> oList = WList<IListTable>.GetWithConditionsNew<Vacation>( oConditions );

			return oList;
		}
		public static WList<IListTable> GetByStartEndDate( DateTime dtStartDate, DateTime dtEndDate )
		{
			SqlStatementConditionCollection oConditions = new SqlStatementConditionCollection();
			oConditions.Add( "END_DATE", dtStartDate, SqlStatementOperator.GreaterThen );
			oConditions.Add( "START_DATE", dtEndDate, SqlStatementOperator.LessThen );

			return WList<IListTable>.GetWithConditionsNew<Vacation>( oConditions );
		}
		#endregion

		#region Properties
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
		public string OwnerName
		{
			get { return this.Owner == null ? string.Empty : this.Owner.Name; }
			set
			{
				if ( !ListTable.CompareEqual( this.Owner, value ) )
					this.Owner = User.GetByID( value );
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
			get { return this.EmployeeName + "\r\n" + this.ShortName; }
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
			get { return true; }
			//set { }
		}
		public IUser Employee
		{
			get
			{
				if ( this.oEmployee == null )
					this.oEmployee = User.GetByID( this.EmployeeId );
				return this.oEmployee;
			}
			set
			{
				this.oEmployee = value;
				this.EmployeeId = this.oEmployee == null ? string.Empty : this.oEmployee.ID;
			}
		}
		public string EmployeeName
		{
			get { return this.Employee == null ? string.Empty : this.Employee.Name; }
			set
			{
				if ( !ListTable.CompareEqual( this.Employee, value ) )
					this.Employee = User.GetByID( value );
			}
		}
		public string EmployeeId
		{
			get { return (string)this.Columns["ASSIGNED_USER_ID"].Value; }
			set { this.Columns[ "ASSIGNED_USER_ID" ].Value = value; }
		}
		public bool Inactive
		{
			get { return false; }
			set { }
		}
		#endregion
	}
}
