using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Mercury.Model.Calendar;
using Sun;
using WLib;
using MercuryService;
using Merkury;
using Venus;

namespace Calendar
{
	public partial class wCalendar_: Form
	{
		#region Declarations
		private const string EVENT_DATETIME_FORMAT = "yyyy.MM.dd HH:mm";
		#endregion

		#region Constructors
		public wCalendar_()
		{
			InitializeComponent();
			this.InitializeCalendar();
		}
		#endregion

		#region Initialize Calendar
		private void InitializeCalendar()
		{
			this.InitializeCalendarStyles();
			this.cbStyle.SelectedValue = Venus.CalendarStyle.Dayly;
			this.oCalendar.CurrentDate = this.dtpDate.Value;
			this.oCalendar.OnAfterSelectedCalendarChanged += delegate { this.RefillCalendarDefinitions(); };
			this.RefillCalendarDefinitions();
			this.tvCalendars.MouseDown += new MouseEventHandler( MouseDownHandler );
			this.oCalendar.MouseDown += new MouseEventHandler( MouseDownHandler );

			this.cbStyle.SelectedIndexChanged += new System.EventHandler( this.cbStyle_SelectedIndexChanged );
			this.oCalendar.AfterCurrentDateChangeEvent += new Calendar.AfterCurrentDateChangeDelegate( oCalendar_AfterCurrentDateChangeEvent );
		}
		private void InitializeCalendarStyles()
		{
			ComboSource oStyleSource = new ComboSource();
			oStyleSource.Add( "Dzienny", Venus.CalendarStyle.Dayly );
			oStyleSource.Add( "Tygodniowy", Venus.CalendarStyle.Weekly );
			oStyleSource.Add( "Miesięczny", Venus.CalendarStyle.Monthly );
			this.cbStyle.DataSource = oStyleSource;
			this.cbStyle.DisplayMember = "Display";
			this.cbStyle.ValueMember = "Value";
		}
		#endregion

		#region Refill calendar
		private void RefillCalendarDefinitions()
		{
			foreach ( CalendarDefinition oCalendarDefinition in CalendarDefinition.GetAll())//this.oCalendar.Calendars )
			{
				TreeNode oNode = null;
				if ( ( oNode = this.GetNodeByCalendarDisplayed( oCalendarDefinition)) == null)
				{
					oNode = new TreeNode( oCalendarDefinition.ShortName );
					oNode.Tag = oCalendarDefinition;
					oNode.ToolTipText = oCalendarDefinition.Description;
					this.tvCalendars.Nodes.Add( oNode );
				}
				if ( this.oCalendar.Calendars.ContainsID( oCalendarDefinition.ID ) )
					oNode.BackColor = oCalendarDefinition.DisplayColor;
				else
					oNode.BackColor = Color.White;
			}
		}
		private TreeNode GetNodeByCalendarDisplayed( CalendarDefinition oCalenderDefinition )
		{
			TreeNode oCalendarNode = null;
			foreach ( TreeNode oNode in this.tvCalendars.Nodes )
			{
				if ( ListTable.CompareEqual( oCalenderDefinition, oNode.Tag as CalendarDefinition ) )
				{
					oCalendarNode = oNode;
					break;
				}
			}

			return oCalendarNode;
		}
		private void RefillCalendar()
		{
			//this.oCalendar.Resources.Clear();

			//// add selected object to calendar resources
			//foreach( ComboSourceItem cbsItem in this.lbUsers.SelectedItems)
			//{
			//    // if user selected User add it to calendar resources
			//    if ( cbsItem.Value is User)
			//    {
			//        User oUser = (User)cbsItem.Value;
			//        CalendarResource oResource = new CalendarResource( oUser.Name );
			//        oResource.Tag = oUser;
			//        foreach ( ErandAct oAct in ErandActCollection.GetByUserStartEndDate( oUser, this.oCalendar.FirstDisplayedDate, this.oCalendar.FirstDisplayedDate.AddDays( this.oCalendar.DaysDisplayed).AddMilliseconds( -1)))
			//        {
			//            CalendarEvent oEvent = new CalendarEvent();
			//            oEvent.PlannedStart = oAct.StartDate;
			//            oEvent.PlannedEnd = oAct.EndDate;
			//            oEvent.Start = oAct.StartDate;
			//            oEvent.End = oAct.EndDate;
			//            oEvent.Title = oAct.Erand.Number;
			//            oEvent.Description = "Zlecenie: " + oAct.Erand.Number + "\r\n"
			//                + "Start: " + oAct.StartDate.ToString( EVENT_DATETIME_FORMAT) + "\r\n"
			//                + "Koniec: " + oAct.EndDate.ToString( EVENT_DATETIME_FORMAT) + "\r\n"
			//                + ( oAct.Erand.Vehicle == null ? string.Empty : Vehicle.Title + ": " + oAct.Erand.Vehicle.ShortName + "\r\n")
			//                + ( oAct.Erand.Customer == null ? string.Empty : "Klient: " + oAct.Erand.Customer.ShortName );
			//            oEvent.Item = oAct.Erand;
			//            oEvent.OpenEvent += new EventHandler( this.OpenErand );
			//            oResource.Events.Add( oEvent);
			//        }
			//        this.oCalendar.Resources.Add( oResource);
			//    }
			//    else if ( cbsItem.Value is Station)
			//    {
			//        // if user selected station add it to calendar resources
			//        Station oStation = (Station)cbsItem.Value;
			//        CalendarResource oResource = new CalendarResource( oStation.Name );
			//        oResource.Tag = oStation;
			//        foreach ( ErandAct oAct in ErandActCollection.GetByStationStartEndDate( oStation, this.oCalendar.FirstDisplayedDate, this.oCalendar.FirstDisplayedDate.AddDays( this.oCalendar.DaysDisplayed - 1 ) ) )
			//        {
			//            CalendarEvent oEvent = new CalendarEvent();
			//            oEvent.PlannedStart = oAct.StartDate;
			//            oEvent.PlannedEnd = oAct.EndDate;
			//            oEvent.Start = oAct.StartDate;
			//            oEvent.End = oAct.EndDate;
			//            oEvent.Title = oAct.Erand.Number;
			//            oEvent.Description = oAct.Description;
			//            oResource.Events.Add( oEvent);
			//        }
			//        this.oCalendar.Resources.Add( oResource);
			//    }
			//    else if ( cbsItem.Value is string && cbsItem.Display == "Zlecenia" )
			//    {
			//        CalendarResource oResource = new CalendarResource( "Zlecenia");
			//        foreach ( Erand oErand in ErandCollection.GetByStartEndDate( this.oCalendar.FirstDisplayedDate, this.oCalendar.FirstDisplayedDate.AddDays( this.oCalendar.DaysDisplayed - 1 ) ) )
			//        {
			//            CalendarEvent oEvent = new CalendarEvent();
			//            oEvent.PlannedStart = oErand.StartDate;
			//            oEvent.PlannedEnd = oErand.EndDate;
			//            oEvent.Start = oErand.StartDate;
			//            oEvent.End = oErand.EndDate;
			//            oEvent.Title = oErand.Number;
			//            oEvent.Description = oErand.Description;
			//            oEvent.Item = oErand;
			//            oEvent.OpenEvent += new EventHandler( this.OpenErand );
			//            oResource.Events.Add( oEvent );
			//        }
			//        this.oCalendar.Resources.Add( oResource );
			//    }
			//}
			//CalendarDefinition oCalendarDefinition = (CalendarDefinition)this.tvCalendars.SelectedNode.Tag;

			//foreach( ICalendarEvent oCalendarEvent in oCalendarDefinition.GetEvents( this.oCalendar.FirstDisplayedDate, this.oCalendar.FirstDisplayedDate.AddDays( this.oCalendar.DaysDisplayed ).AddMilliseconds( -1 )))
			//{
			//    //oCalendarEvent.OpenEvent += new EventHandler( this.OpenErand );
			//    this.oCalendar.Events.Add( oCalendarEvent );
			//}
			//this.oCalendar.Resources.Add( oResource );
			this.oCalendar.DisplayEvents();
		}
		#endregion

		#region Event methods
		private void wCalendar_Load( object sender, System.EventArgs e )
		{
			this.InitializeCalendar();

			this.Icon = this.MdiParent.Icon;
			// center window
			this.Location = new Point( Convert.ToInt32( ( this.MdiParent.Bounds.Width - this.Bounds.Width ) / 2 ), Convert.ToInt32( ( this.MdiParent.Bounds.Height - this.Bounds.Height ) / 2 ) - 50 );

			// refill caendar events
			//this.RefillCalendar();

			// refresh calendar
			this.oCalendar.DisplayEvents();
		}
		private void cbStyle_SelectedIndexChanged( object sender, System.EventArgs e )
		{
			this.oCalendar.Style = (Calendar.CalendarStyle)this.cbStyle.SelectedValue;
			this.RefillCalendar();
			this.oCalendar.RefreshAll();
		}
		private void btnPrevDay_Click( object sender, System.EventArgs e )
		{
			if ( this.oCalendar.Style == Calendar.CalendarStyle.Dayly )
				this.dtpDate.Value = this.oCalendar.CurrentDate.AddDays( -1 );
			else if ( this.oCalendar.Style == Calendar.CalendarStyle.Weekly )
				this.dtpDate.Value = this.oCalendar.CurrentDate.AddDays( -7 );
			else if ( this.oCalendar.Style == Calendar.CalendarStyle.Monthly )
				this.dtpDate.Value = this.oCalendar.CurrentDate.AddMonths( -1 );
		}
		private void btnNextDay_Click( object sender, System.EventArgs e )
		{
			if ( this.oCalendar.Style == Calendar.CalendarStyle.Dayly )
				this.dtpDate.Value = this.oCalendar.CurrentDate.AddDays( 1 );
			else if ( this.oCalendar.Style == Calendar.CalendarStyle.Weekly )
				this.dtpDate.Value = this.oCalendar.CurrentDate.AddDays( 7 );
			else if ( this.oCalendar.Style == Calendar.CalendarStyle.Monthly )
				this.dtpDate.Value = this.oCalendar.CurrentDate.AddMonths( 1 );
		}
		private void dtbDate_ValueChanged( object sender, System.EventArgs e )
		{
			this.oCalendar.CurrentDate = this.dtpDate.Value;
		}
		private void oCalendar_AfterCurrentDateChangeEvent()
		{
		}
		private void MouseDownHandler( object sender, MouseEventArgs e )
		{
			try
			{
				if ( sender.Equals( this.tvCalendars ) )
				{
					if ( e.Button == MouseButtons.Left )
					{
						TreeNode oClickedNode = this.tvCalendars.GetNodeAt( e.X, e.Y );
						if ( oClickedNode != null )
						{
							CalendarDefinition oCalendarDefinition = (CalendarDefinition)( oClickedNode ).Tag;
							if ( this.oCalendar.Calendars.ContainsID( oCalendarDefinition.ID ) )
								this.oCalendar.Calendars.RemoveID( oCalendarDefinition.ID );
							else
								this.oCalendar.Calendars.Add( oCalendarDefinition );
						}
					}
				}
				else if ( sender.Equals( this.oCalendar ) )
				{
					if ( e.Button == MouseButtons.Right )
					{
						this.oCalendar.ContextMenuStrip.Items.Clear();
						foreach ( CalendarDefinition oCalendarDefinition in this.oCalendar.Calendars )
						{
							if ( oCalendarDefinition.RelatedType != null )
							{
								Type oRelatedType = oCalendarDefinition.RelatedType;
								this.oCalendar.ContextMenuStrip.Items.Add( "Dodaj: " + ListTable.GetListClassTitle( oRelatedType ), null, delegate
								{
									IListTable oNewCalendarItem = Locator.CreateNew( oRelatedType );
									RuntimeManager.OpenForm( oNewCalendarItem, delegate
									{
										this.oCalendar.DisplayEvents();
									}
									);
								}
								);
							}
						}
						this.oCalendar.ContextMenuStrip.Items.Add( "-" );
						this.oCalendar.ContextMenuStrip.Items.Add( "Odśwież", null, new EventHandler( RefreshCalendar ) );
					}
				}
			}
			catch ( Exception ex )
			{
				ErrorBox.Show( ex, this.Text );
			}
		}
		private void btnToday_Click( object sender, System.EventArgs e )
		{
			this.dtpDate.Value = DateTime.Today;
		}
		private void RefreshCalendar( object sender, System.EventArgs e )
		{
			this.RefillCalendar();
		}
		#endregion

	}
}
