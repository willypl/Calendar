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
	public partial class wCalendar: Form
	{
		#region Declarations
		private const string EVENT_DATETIME_FORMAT = "yyyy.MM.dd HH:mm";
		private Color oInitialBackColor = Color.Empty;
		private struct ConfigSettings
		{
			public const string CalendarStyle = "CalendarStyle";
		}
		#endregion

		#region Constructors
		public wCalendar()
		{
			InitializeComponent();
			this.InitializeCalendar();
		}
		#endregion

		#region Initialize Calendar
		private void InitializeCalendar()
		{
			this.InitializeCalendarStyles();
			this.oCalendar.CurrentDate = this.dtpDate.Value;
			this.oCalendar.OnAfterSelectedCalendarChanged += delegate { this.RefillCalendarDefinitions(); };
			this.RefillCalendarDefinitions();
			this.lvCalendars.ContextMenuStrip = new ContextMenuStrip();
			this.lvCalendars.MouseDown += this.MouseDownHandler;
			this.oInitialBackColor = this.lvCalendars.BackColor;
			this.lvCalendars.Columns.Add( "Kalendarz", this.lvCalendars.Width - 4 );
			this.lvCalendars.ItemCheck += new ItemCheckEventHandler( lbCalendars_ItemCheck );
			this.oCalendar.MouseDown += new MouseEventHandler( MouseDownHandler );

			this.cbStyle.SelectedIndexChanged += new System.EventHandler( this.cbStyle_SelectedIndexChanged );
			this.cbStyle.SelectedValue = (Venus.CalendarStyle)Config.GetSettingValue<int>( ConfigSettings.CalendarStyle, Login.CurrentLogin.User.ID );
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
				//TreeNode oNode = null;
				//if ( ( oNode = this.GetNodeByCalendarDisplayed( oCalendarDefinition)) == null)
				//{
				//    oNode = new TreeNode( oCalendarDefinition.ShortName );
				//    oNode.Tag = oCalendarDefinition;
				//    oNode.ToolTipText = oCalendarDefinition.Description;
				//    //this.tvCalendars.Nodes.Add( oNode );
				//}
				//if ( this.oCalendar.Calendars.ContainsID( oCalendarDefinition.ID ) )
				//    oNode.BackColor = oCalendarDefinition.DisplayColor;
				//else
				//    oNode.BackColor = Color.White;
				if ( ListTable.CompareEqual( oCalendarDefinition.Owner, Login.CurrentLogin.User)
					|| Authorization.CheckAuthorization( oCalendarDefinition, Login.CurrentLogin.User, AuthorizationCode.Select ) )
				{
					ListViewItem lvItem = new ListViewItem( oCalendarDefinition.ShortName );
					lvItem.Tag = oCalendarDefinition;
					this.lvCalendars.Items.Add( lvItem );
				}
			}
		}
		//private TreeNode GetNodeByCalendarDisplayed( CalendarDefinition oCalenderDefinition )
		//{
		//    TreeNode oCalendarNode = null;
		//    foreach ( TreeNode oNode in this.tvCalendars.Nodes )
		//    {
		//        if ( ListTable.CompareEqual( oCalenderDefinition, oNode.Tag as CalendarDefinition ) )
		//        {
		//            oCalendarNode = oNode;
		//            break;
		//        }
		//    }

		//    return oCalendarNode;
		//}
		private void RefillCalendar()
		{
			if ( this.oCalendar.UseNewEvents )
				this.oCalendar.Refresh();
			else
				this.oCalendar.DisplayEvents();
		}
		#endregion

		#region Event methods
		private void wCalendar_Load( object sender, EventArgs e )
		{
			this.Icon = this.MdiParent.Icon;
			// center window
			this.Location = new Point( Convert.ToInt32( ( this.MdiParent.Bounds.Width - this.Bounds.Width ) / 2 ), Convert.ToInt32( ( this.MdiParent.Bounds.Height - this.Bounds.Height ) / 2 ) - 50 );
		}
		private void lbCalendars_ItemCheck( object sender, ItemCheckEventArgs e )
		{
			ListViewItem lvItem = this.lvCalendars.Items[ e.Index ];
			CalendarDefinition oCalendarDefinition = (CalendarDefinition)lvItem.Tag;
			if ( e.NewValue == CheckState.Checked )
			{
				lvItem.BackColor = oCalendarDefinition.DisplayColor;
				if ( !this.oCalendar.Calendars.ContainsID( oCalendarDefinition.ID ) )
					this.oCalendar.Calendars.Add( oCalendarDefinition );
			}
			else
			{
				lvItem.BackColor = this.oInitialBackColor;
				if ( this.oCalendar.Calendars.ContainsID( oCalendarDefinition.ID ) )
					this.oCalendar.Calendars.RemoveID( oCalendarDefinition.ID );
			}
		}
		private void MouseDownHandler( object sender, MouseEventArgs e )
		{
			try
			{
				ListViewItem oClickedItem = this.lvCalendars.GetItemAt( e.X, e.Y );
				if ( e.Button == MouseButtons.Right )
				{
					if ( sender.Equals( this.lvCalendars ) )
					{
						this.lvCalendars.ContextMenuStrip.Items.Clear();
						{
							if ( oClickedItem != null )
							{
								if ( oClickedItem.Checked)
									this.lvCalendars.ContextMenuStrip.Items.Add( "Usuń zaznaczenie", null, delegate { oClickedItem.Checked = false; } );
								else
									this.lvCalendars.ContextMenuStrip.Items.Add( "Zaznacz", null, delegate { oClickedItem.Checked = true; } );
								if ( ((ICalendar)oClickedItem.Tag).Authorizations.Find( oAutorization => ListTable.CompareEqual( oAutorization.User, Login.CurrentLogin.User)) != null)
									this.lvCalendars.ContextMenuStrip.Items.Add( "&Edytuj", null, delegate 
									{
										RuntimeManager.OpenForm( (ICalendar)oClickedItem.Tag, delegate { oCalendar.Refresh(); } );
									} 
									);
							}
						}
					}
					else if ( sender.Equals( this.oCalendar ) )
					{
						this.oCalendar.ContextMenuStrip.Items.Clear();
						foreach ( CalendarDefinition oCalendarDefinition in this.oCalendar.Calendars )
						{
							if ( oCalendarDefinition.RelatedType != null )
							{
								Type oRelatedType = oCalendarDefinition.RelatedType;
								IListTable oDataItem = this.oCalendar.GetItemAt( e.X, e.Y);
								if ( Authorization.CheckAuthorization( oCalendarDefinition, Login.CurrentLogin.User, AuthorizationCode.Insert))
									this.oCalendar.ContextMenuStrip.Items.Add( "&Dodaj: " + ListTable.GetListClassTitle( oRelatedType ) + " " + oCalendarDefinition.ShortName, null, delegate( object oObject, EventArgs ex )
									{
										ICalendarEvent oNewCalendarItem = Locator.CreateNew( oRelatedType ) as ICalendarEvent;
										oNewCalendarItem.Calendar = oCalendarDefinition;
										oNewCalendarItem.StartDate = this.oCalendar.CurrentDate;
										oNewCalendarItem.EndDate = oNewCalendarItem.StartDate.AddHours( 1 );
										RuntimeManager.OpenForm( oNewCalendarItem, delegate
										{
											if ( this.oCalendar.UseNewEvents )
												this.oCalendar.Refresh();
											else
												this.oCalendar.DisplayEvents();
										}
										);
									}
									);
								if ( oDataItem != null && Authorization.CheckAuthorization( oCalendarDefinition, Login.CurrentLogin.User, AuthorizationCode.Update) )
								{
									this.oCalendar.ContextMenuStrip.Items.Add( "&Otwórz: " + ListTable.GetListClassTitle( oRelatedType ) + " " + oCalendarDefinition.ShortName, null, delegate( object oObject, EventArgs ex )
									{
										RuntimeManager.OpenForm( oObject as IListTable, delegate
										{
											this.oCalendar.Refresh();
										}
										);
									}
									);
								}
								if ( Authorization.CheckAuthorization( oCalendarDefinition, Login.CurrentLogin.User, AuthorizationCode.Delete ) )
								{
									this.oCalendar.ContextMenuStrip.Items.Add( "-" );
									this.oCalendar.ContextMenuStrip.Items.Add( "&Usuń: " + ListTable.GetListClassTitle( oRelatedType ) + " " + oCalendarDefinition.ShortName, null, delegate( object oObject, EventArgs ex )
									{
										//if ( wQuestion.Show( Messages.QuestionDelete, WLAttribute.GetTitle( oRelatedType)))

									}
									);
								}
							}
						}
						if ( this.oCalendar.ContextMenuStrip.Items.Count > 0)
							this.oCalendar.ContextMenuStrip.Items.Add( "-" );
						this.oCalendar.ContextMenuStrip.Items.Add( "Odśwież", null, new EventHandler( RefreshCalendar ) );
					}
				}
				else if ( e.Clicks == 2 )
				{
					if ( oClickedItem == null || oClickedItem.Tag == null )
					{
						CalendarDefinition oCalendarDefinition = this.oCalendar.Calendars.Count > 0 ? this.oCalendar.Calendars[ 0 ] : null;
						if ( oCalendarDefinition != null && oCalendarDefinition.RelatedType != null)
						{
							ICalendarEvent oNewCalendarItem = Locator.CreateNew( oCalendarDefinition.RelatedType) as ICalendarEvent;
							oNewCalendarItem.Calendar = oCalendarDefinition;
							oNewCalendarItem.StartDate = this.oCalendar.CurrentDate;
							oNewCalendarItem.EndDate = oNewCalendarItem.StartDate.AddHours( 1 );
							RuntimeManager.OpenForm( oNewCalendarItem, delegate
							{
								if ( this.oCalendar.UseNewEvents )
									this.oCalendar.Refresh();
								else
									this.oCalendar.DisplayEvents();
							}
							);
						}
					}
					else
						RuntimeManager.OpenForm( (ICalendar)oClickedItem.Tag, delegate { oCalendar.Refresh(); } );
				}
			}
			catch ( Exception ex )
			{
				ErrorBox.Show( ex, this.Text );
			}
		}
		private void cbStyle_SelectedIndexChanged( object sender, System.EventArgs e )
		{
			Config.SetSettingValue( ConfigSettings.CalendarStyle, Login.CurrentLogin.User.ID, ((int)(Venus.CalendarStyle)this.cbStyle.SelectedValue).ToString() ).Save();
			this.oCalendar.Style = (Calendar.CalendarStyle)this.cbStyle.SelectedValue;
			this.RefillCalendar();
			this.oCalendar.RefreshAll();
		}
		private void DateChangeHandler( object sender, System.EventArgs e )
		{
			if ( sender.Equals( this.dtpDate))
				this.oCalendar.CurrentDate = this.dtpDate.Value;
			else if ( sender.Equals( this.btnPrevDay ) )
			{
				if ( this.oCalendar.Style == Calendar.CalendarStyle.Dayly )
					this.dtpDate.Value = this.oCalendar.CurrentDate.AddDays( -1 );
				else if ( this.oCalendar.Style == Calendar.CalendarStyle.Weekly )
					this.dtpDate.Value = this.oCalendar.CurrentDate.AddDays( -7 );
				else if ( this.oCalendar.Style == Calendar.CalendarStyle.Monthly )
					this.dtpDate.Value = this.oCalendar.CurrentDate.AddMonths( -1 );
			}
			else if ( sender.Equals( this.btnNextDay ) )
			{
				if ( this.oCalendar.Style == Calendar.CalendarStyle.Dayly )
					this.dtpDate.Value = this.oCalendar.CurrentDate.AddDays( 1 );
				else if ( this.oCalendar.Style == Calendar.CalendarStyle.Weekly )
					this.dtpDate.Value = this.oCalendar.CurrentDate.AddDays( 7 );
				else if ( this.oCalendar.Style == Calendar.CalendarStyle.Monthly )
					this.dtpDate.Value = this.oCalendar.CurrentDate.AddMonths( 1 );
			}
			else if ( sender.Equals( this.btnToday))
				this.dtpDate.Value = DateTime.Today;
		}
		private void oCalendar_AfterCurrentDateChangeEvent()
		{
		}
		private void RefreshCalendar( object sender, System.EventArgs e )
		{
			this.RefillCalendar();
		}
		#endregion
	}
}
