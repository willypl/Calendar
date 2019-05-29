using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using System.Globalization;
using Mercury.Model.Calendar;
using WLib;
using Venus;

namespace Calendar
{
	/// <summary>
	/// Summary description for UserControl1.
	/// </summary>
	public class WLCalendar : UserControl
	{
		#region Declarations
		#region Constants
		private const int DEFAULT_ROWS_HEADER_WIDTH = 40;
		private const int DEFAULT_HOURS_DISPLAYED = 24;
		#endregion
		#region Events
		public event CalendarStyleChangeDelegate CalendarStyleChangeEvent;
		public event BeforeCurrentDateChangeDelegate BeforeCurrentDateChangeEvent;
		public event AfterCurrentDateChangeDelegate AfterCurrentDateChangeEvent;
		public event ObjectChangeEventHandler OnBeforeSelectedCalendarChanged;
		public event ObjectEventHandler OnAfterSelectedCalendarChanged;
		//		public event EventDoubleClick EventDoubleClick;
		#endregion
		#region Calendar
		private System.ComponentModel.Container components = null;
		private CalendarStyle oStyle;
		private CultureInfo oCultureInfo = new CultureInfo( "PL-pl");// System.Globalization.CultureInfo.CurrentCulture;
		private DateTime dtCurrent = DateTime.Today;
		private DateTime dtFirstDisplayedDate;
		private string[] aColumnFormat = new string[]{ "dddd dd.MM.yyyy", "ddd dd", "dddd"};
		private int nDaysInWeek = 7;
		private int nDaysDisplayed = 0;
		private VScrollBar oVScroll = null;
		private WList<ICalendarEvent> oCalendarEvents = null;
		private Color oTodayBackColor = Color.LightYellow;//LavenderBlush;
		private Font oMonthTextFont = new Font( "Tahoma", 6, FontStyle.Bold);
		//private ResourceCollection oResources = null;
		//private WList<CalendarDefinition> oSelectedCalendars = null;
		private WList<CalendarDefinition> oCalendars = null;
		#region Column/Row header
		private RCHeader oRCHeader = null;
		private Color oRCHeaderBackColor = Color.White;
		private Color oRCHeaderFontColor = Color.Black;
		private Color oRCHeaderGradientColor1 = Color.LightYellow;
		private Color oRCHeaderGradientColor2 = Color.White;
		private FillStyle oRCHeaderFillStyle = FillStyle.VGradient;
		#endregion
		#endregion
		#region Controls
		private RowsHeader oRowsHeader = null;
		private ColumnsHeader oColumnsHeader = null;
		private Grid oGrid = null;
		#endregion
		#region Events
		private SolidBrush oEventsBrush = new SolidBrush( Color.Empty );
		private Pen oEventsPen = new Pen( Color.Empty );
		private Color oEventsBorderColor;
		private Color oEventsBackColor;
		private int nEventsBorderWidth = 1;
		private Color oEventsTextHeaderColor = Color.Black;
		private Font oEventsFont = new Font( "Tahoma", 8, FontStyle.Bold );
		private Color oEventsDescriptionColor = Color.Black;
		#endregion
		#endregion
		public bool UseNewEvents = false;//Environment.MachineName.Equals( "WLDELL");
		#region Constructor
		public WLCalendar()
		{
			// create default controls components
			InitializeComponent();
			this.HoursDisplayed = DEFAULT_HOURS_DISPLAYED;
			this.BackColor = Color.White;

			// initialize events
			this.oEventsBackColor = Color.LightYellow;

			//this.oResources = new ResourceCollection( this);

			// crate vertical scroll bar
			this.oVScroll = new VScrollBar();
			//			this.oVScroll.Dock = DockStyle.Right;
			this.Controls.Add( this.oVScroll);

			// create Rows/Columns header
			this.oRCHeader = new RCHeader( this);
			this.oRCHeader.Location = new Point( 0, 0);
			//this.oRCHeader.Text = this.dtCurrent.Year.ToString();
			this.Controls.Add( this.oRCHeader);

			// create columns header
			this.oColumnsHeader = new ColumnsHeader( this);
			this.Controls.Add( this.oColumnsHeader);

			// create resources header
			//this.oResourcesHeader = new ResourcesHeader( this);
			//this.Controls.Add( this.oResourcesHeader);

			// create rows header
			this.oRowsHeader = new RowsHeader( this);
			this.Controls.Add( this.oRowsHeader);

			// create body control
			this.oGrid = new Grid( this);
			this.Controls.Add( this.oGrid);

			this.Style = CalendarStyle.Dayly;

			this.CalendarStyleChangeEvent += new CalendarStyleChangeDelegate( WLCalendar_CalendarStyleChangeEvent);
			this.oGrid.ContextMenuStrip = new ContextMenuStrip();
			this.oGrid.MouseDown += new MouseEventHandler(oGrid_MouseDown);
			this.Calendars.OnAfterListChanged += new ObjectEventHandler( this.DisplayEvents);
		}
		#endregion

		#region System methods
		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if( components != null )
					components.Dispose();
			}
			base.Dispose( disposing );
		}
		#endregion

		#region Component Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			// 
			// WLCalendar
			// 
			this.Name = "WLCalendar";
			this.Size = new System.Drawing.Size(480, 336);
			this.Load += new System.EventHandler(this.WLCalendar_Load);

		}
		#endregion

		#region Set controls
		private void SetControls()
		{
			this.SuspendLayout();

			this.dtFirstDisplayedDate = this.GetFirstDisplayedDate( this.dtCurrent.Date);

			// set vertical scroll bar layout
			this.SetVScrollBar();

			// set columns header layout
			this.SetColumnsHeader();

			// set proper count of rows and columns
			this.SetGrid();

			// set Rows/Columns layout
			this.SetRCHeader();

			// set resources header layout
			//this.SetResourcesHeader();

			// set rows header layout
			this.SetRowsHeader();

			// set events layout
			if ( UseNewEvents )
				this.Refresh();
			else
				this.DisplayEvents();

			// refresh every control
			this.ResumeLayout();

			// refresh all controls
			this.Refresh();
		}
		private void SetRCHeader()
		{
			this.oRCHeader.Location = new Point( 0, 0);
			this.oRCHeader.Size = new Size( this.oRowsHeader.Width, this.oColumnsHeader.Height);
		}
		private void SetGrid()
		{
			DateTime dtDate = this.dtFirstDisplayedDate;
			int nI = 0;

			this.SetGridRCCounts();

			int nY = this.oColumnsHeader.Height;
			// add height of resurces header ( if visible)
			//if ( this.oResourcesHeader.Visible)
			//    nY += this.oResourcesHeader.Height;
			// adjust 
			if ( this.oVScroll.Visible)
				nY -= this.oVScroll.Value;

			// set grid location and size
			this.oGrid.Location = new Point( this.oRowsHeader.Width, nY);
			this.oGrid.Size = new Size( this.Width - this.oRowsHeader.Width - ( this.oVScroll.Visible ? this.oVScroll.Width : 0), this.Height - this.oColumnsHeader.Height);//this.oGrid.Rows * this.Grid.RowHeight);
			this.oGrid.BackColor = this.BackColor;

			// set date as cell text
			if ( this.oStyle == CalendarStyle.Monthly)
				foreach( Cell oCell in this.oGrid.Cells)
				{
					oCell.Font = this.oMonthTextFont;
					oCell.StringFormat.Alignment = StringAlignment.Far;
					oCell.Text = dtDate.AddDays( nI).ToString( "dd");
					if ( dtDate.AddDays( nI).Month == this.dtCurrent.Month)
					{
						oCell.ForeColor = Color.Black;
						oCell.BackColor = this.oGrid.BackColor;
					}
					else
					{
						oCell.ForeColor = Color.Gray;
						oCell.BackColor = Color.LightGray;
					}
					nI++;
				}
		}
		private void SetColumnsHeader()
		{
			this.oColumnsHeader.Location = new Point( this.oRowsHeader.Width, 0);
			this.oColumnsHeader.Size = new Size( this.Width - this.oRowsHeader.Width, this.oColumnsHeader.Height);
		}
		//private void SetResourcesHeader()
		//{
		//    this.oResourcesHeader.Location = new Point( this.oRowsHeader.Width, this.oColumnsHeader.Height);
		//    this.oResourcesHeader.Size = new Size( this.Width - this.oRowsHeader.Width - ( this.oVScroll.Visible ? this.oVScroll.Width : 0), this.oResourcesHeader.Height);
		//}
		private void SetRowsHeader()
		{
			int nY = this.oColumnsHeader.Height;
			// add height of resurces header ( if visible)
			//if ( this.oResourcesHeader.Visible)
			//    nY += this.oResourcesHeader.Height;
			// adjust 
			if ( this.oVScroll.Visible)
				nY -= this.oVScroll.Value;
			this.oRowsHeader.Location = new Point( 0, nY);
			this.oRowsHeader.Size = new Size( this.oRowsHeader.Width, this.oGrid.Rows * this.Grid.RowHeight);
		}
		private void SetGridRCCounts()
		{
			if ( this.oStyle == CalendarStyle.Dayly)
			{
				this.oGrid.Rows = this.HoursDisplayed;
				this.oGrid.Columns = 1;
				this.nDaysDisplayed = 1;
			}
			else if ( this.oStyle == CalendarStyle.Weekly)
			{
				this.oGrid.Rows = this.HoursDisplayed;
				this.oGrid.Columns  = 7;
				this.nDaysDisplayed = 7;
			}
			else if ( this.oStyle == CalendarStyle.Monthly)
			{
				this.oGrid.Rows = 5;
				this.oGrid.Columns  = 7;
				this.nDaysDisplayed = 35;
			}
		}
		private void SetVScrollBar()
		{
			if ( this.oVScroll.Visible = ( this.oGrid.Height > this.Height - this.oColumnsHeader.Height))
			{
				this.oVScroll.Size = new Size( this.oVScroll.Width, this.Height - this.oColumnsHeader.Height);
				this.oVScroll.Location = new Point( this.Width - this.oVScroll.Width, this.oColumnsHeader.Height);
			
				this.oVScroll.Minimum = 0;
				this.oVScroll.Maximum = this.oGrid.Height;
//				this.oVScroll.Value = 0;
				this.oVScroll.SmallChange = this.oGrid.RowHeight/2;
				this.oVScroll.LargeChange = this.Height - this.oColumnsHeader.Height;
			}
		}
		#endregion

		#region Display events
		public void DisplayEvents()
		{
			this.oGrid.SuspendLayout();
			this.oGrid.Controls.Clear();

			DateTime dtStart = this.dtFirstDisplayedDate;
			DateTime dtEnd = this.dtFirstDisplayedDate.AddDays( this.nDaysDisplayed ).AddTicks( -1 );
			{
				foreach ( CalendarDefinition oCalendar in this.Calendars )
				{
					if ( ListTable.CompareEqual( oCalendar.Owner, Login.CurrentLogin.User )
						|| Authorization.CheckAuthorization( oCalendar, Login.CurrentLogin.User, AuthorizationCode.Select ) )
					{
						int nResourceIndex = 0;
						int nOverlapShift = 10;
						DateTime dtLastDate = dtStart;
						foreach ( ICalendarEvent oCalendarItem in oCalendar.GetEvents( dtStart, dtEnd ) )
						{
							EventBox oEventBox = new EventBox( oCalendarItem );
							if ( oCalendarItem.StartDate.Date.Equals( dtLastDate ) )
								nResourceIndex++;
							else
								nResourceIndex = 0;
							if ( this.oStyle == CalendarStyle.Dayly )
							{
								int nColumnWidth = ( this.Calendars.Count == 0 ? 0 : this.Grid.Width / this.Calendars.Count );
								oEventBox.Location = new Point( nResourceIndex * nColumnWidth, Time2Pixel( this.oGrid, oCalendarItem.StartDate.TimeOfDay ) );
								oEventBox.Size = new Size( nColumnWidth - 1, Time2Pixel( this.oGrid, oCalendarItem.EndDate - oCalendarItem.StartDate ) - 1 );
							}
							else if ( this.oStyle == CalendarStyle.Weekly )
							{
								int nColumnWidth = ( this.Calendars.Count == 0 ? 0 : this.oGrid.ColumnWidth / this.Calendars.Count );
								oEventBox.Location = new Point( this.GetDayOfWeekNo( oCalendarItem.StartDate ) * this.oGrid.ColumnWidth + nResourceIndex * nColumnWidth, Time2Pixel( this.oGrid, oCalendarItem.StartDate.TimeOfDay ) );
								oEventBox.Size = new Size( nColumnWidth - 1, Time2Pixel( this.oGrid, oCalendarItem.EndDate - oCalendarItem.StartDate ) - 1 );
							}
							else if ( this.oStyle == CalendarStyle.Monthly )
							{
								int nColumnWidth = ( this.Calendars.Count == 0 ? 0 : this.oGrid.ColumnWidth / this.Calendars.Count );
								int nDayOfWeek = this.GetDayOfWeekNo( oCalendarItem.StartDate );
								int nWeekOfMonth = this.GetWeekOfMonth( oCalendarItem.StartDate, this.dtCurrent.Month );
								int nHShift = nResourceIndex * nOverlapShift;
								int nVShift = (int)Math.Floor( (decimal)( (this.oGrid.RowHeight - this.oMonthTextFont.Height - 2 ) * oCalendarItem.StartDate.Hour / 24 ) );
								oEventBox.Location = new Point( nDayOfWeek * this.oGrid.ColumnWidth + nHShift, ( nWeekOfMonth * this.oGrid.RowHeight + this.oMonthTextFont.Height + 2 ) + nVShift );
								oEventBox.Size = new Size( nColumnWidth - 1 - nHShift, this.oGrid.RowHeight - this.oMonthTextFont.Height - 2 - nVShift);
							}
							oEventBox.BorderColor = oCalendar.DisplayColor;
							oEventBox.MouseDoubleClick += delegate( object sender, MouseEventArgs e )
							{
								if ( sender is EventBox )
								{
									EventBox oOpenEventBox = (EventBox)sender;
									if ( oOpenEventBox.Event != null
										&& oOpenEventBox.Event is IListTable
										&& ( ListTable.CompareEqual( oCalendar.Owner, Login.CurrentLogin.User )
											|| Authorization.CheckAuthorization( oCalendar, Login.CurrentLogin.User, AuthorizationCode.Update ) ) )
										RuntimeManager.OpenForm( (IListTable)oOpenEventBox.Event, this.DisplayEvents );
								}
							};
							this.oGrid.Controls.Add( oEventBox );
							oEventBox.BringToFront();
							dtLastDate = oCalendarItem.StartDate.Date;
						}
					}
				}
			}

			this.oGrid.ResumeLayout();
			this.Refresh();
		}
		public void DrawEvents( Graphics g)
		{
			this.oGrid.SuspendLayout();
			this.oGrid.Controls.Clear();

			DateTime dtStart = this.dtFirstDisplayedDate;
			DateTime dtEnd = this.dtFirstDisplayedDate.AddDays( this.nDaysDisplayed ).AddTicks( -1 );
			{
				foreach ( CalendarDefinition oCalendar in this.Calendars )
				{
					if ( ListTable.CompareEqual( oCalendar.Owner, Login.CurrentLogin.User )
						|| Authorization.CheckAuthorization( oCalendar, Login.CurrentLogin.User, AuthorizationCode.Select ) )
					{
						int nResourceIndex = 0;
						foreach ( ICalendarEvent oCalendarItem in oCalendar.GetEvents( dtStart, dtEnd ) )
						{
							EventBox oEventBox = new EventBox( oCalendarItem );
							if ( this.oStyle == CalendarStyle.Dayly )
							{
								int nColumnWidth = ( this.Calendars.Count == 0 ? 0 : this.Grid.Width / this.Calendars.Count );
								oEventBox.Location = new Point( nResourceIndex * nColumnWidth, Time2Pixel( this.oGrid, oCalendarItem.StartDate.TimeOfDay ) );
								oEventBox.Size = new Size( nColumnWidth - 1, Time2Pixel( this.oGrid, oCalendarItem.EndDate - oCalendarItem.StartDate ) - 1 );
							}
							else if ( this.oStyle == CalendarStyle.Weekly )
							{
								int nColumnWidth = ( this.Calendars.Count == 0 ? 0 : this.oGrid.ColumnWidth / this.Calendars.Count );
								oEventBox.Location = new Point( this.GetDayOfWeekNo( oCalendarItem.StartDate ) * this.oGrid.ColumnWidth + nResourceIndex * nColumnWidth, Time2Pixel( this.oGrid, oCalendarItem.StartDate.TimeOfDay ) );
								oEventBox.Size = new Size( nColumnWidth - 1, Time2Pixel( this.oGrid, oCalendarItem.EndDate - oCalendarItem.StartDate ) - 1 );
							}
							else if ( this.oStyle == CalendarStyle.Monthly )
							{
								int nColumnWidth = ( this.Calendars.Count == 0 ? 0 : this.oGrid.ColumnWidth / this.Calendars.Count );
								int nDayOfWeek = this.GetDayOfWeekNo( oCalendarItem.StartDate );
								int nWeekOfMonth = this.GetWeekOfMonth( oCalendarItem.StartDate, this.dtCurrent.Month );
								//oEventBox.Location = new Point( nDayOfWeek * this.oGrid.ColumnWidth + nResourceIndex * nColumnWidth, nWeekOfMonth * this.oGrid.RowHeight + this.oMonthTextFont.Height + 2 );
								//oEventBox.Size = new Size( nColumnWidth - 1, this.oGrid.RowHeight - this.oMonthTextFont.Height - 2 );
								this.DrawEvent( g, oCalendarItem );
							}
							//oEventBox.BorderColor = oCalendar.DisplayColor;
							//oEventBox.MouseDoubleClick += delegate( object sender, MouseEventArgs e )
							//{
							//    if ( sender is EventBox )
							//    {
							//        EventBox oOpenEventBox = (EventBox)sender;
							//        if ( oOpenEventBox.Event != null
							//            && oOpenEventBox.Event is IListTable
							//            && ( ListTable.CompareEqual( oCalendar.Owner, Login.CurrentLogin.User )
							//                || Authorization.CheckAuthorization( oCalendar, Login.CurrentLogin.User, AuthorizationCode.Update ) ) )
							//            RuntimeManager.OpenForm( (IListTable)oOpenEventBox.Event, this.DisplayEvents );
							//    }
							//};
							//this.oGrid.Controls.Add( oEventBox );
						}
					}
				}
			}

			this.oGrid.ResumeLayout();
			this.Refresh();
		}
		private void DrawEvent( Graphics g, ICalendarEvent oCalendarItem )
		{
			// paint body with backcolor
			this.oEventsBrush.Color = this.BackColor;
			g.FillRectangle( this.oEventsBrush, 0, 0, this.Width, this.Height );

			// draw border
			this.oEventsPen.Color = this.oEventsBorderColor;
			this.oEventsPen.Width = this.nEventsBorderWidth;
			g.DrawRectangle( this.oEventsPen, 0, 0, this.Width - this.nEventsBorderWidth, this.Height - this.nEventsBorderWidth );
			this.oEventsPen.Width = 5;
			this.oEventsPen.Color = this.oEventsBorderColor;// Color.Red;
			g.DrawLine( this.oEventsPen, 0, 0, 0, this.Height );

			// draw start time
			this.oEventsBrush.Color = this.oEventsTextHeaderColor;
			Rectangle oRect = new Rectangle( 2, 2, this.Width, this.oEventsFont.Height );
			g.DrawString( oCalendarItem.StartDate.ToString( "hh:mm" ), this.oEventsFont, this.oEventsBrush, oRect );

			// draw event titla
			this.oEventsBrush.Color = this.oEventsDescriptionColor;
			oRect = new Rectangle( 2, this.oEventsFont.Height, this.Width, this.oEventsFont.Height );
			g.DrawString( oCalendarItem.CalendarDescription, this.oEventsFont, this.oEventsBrush, oRect );
		}
		#endregion

		#region Selected calendar methods
		//public void SelectCalendar( CalendarDefinition oCalendar )
		//{
		//    if ( this.Calendars.ContainsID( oCalendar.ID )
		//        && !this.Calendars.ContainsID( oCalendar.ID ) )
		//    {
		//        if ( this.OnBeforeSelectedCalendarChanged != null )
		//            this.OnBeforeSelectedCalendarChanged( this, null );
		//        this.Calendars.Add( oCalendar );
		//        if ( this.OnAfterSelectedCalendarChanged != null )
		//            this.OnAfterSelectedCalendarChanged( this, null );
		//    }
		//}
		//public void RemoveCalendar( CalendarDefinition oCalendar )
		//{
		//    if ( this.Calendars.ContainsID( oCalendar.ID )
		//        && this.Calendars.ContainsID( oCalendar.ID ) )
		//    {
		//        if ( this.OnBeforeSelectedCalendarChanged != null )
		//            this.OnBeforeSelectedCalendarChanged( this, null );
		//        this.Calendars.Remove( oCalendar );
		//        if ( this.OnAfterSelectedCalendarChanged != null )
		//            this.OnAfterSelectedCalendarChanged( this, null );
		//    }
		//}
		#endregion

		#region Refresh methods
		public void RefreshAll()
		{
			this.SetControls();
		}
		#endregion

		#region Paint today methods
		private void PaintToday()
		{
			this.oGrid.SuspendLayout();

			if ( this.oStyle == CalendarStyle.Dayly)
				for( int nI = 0; nI < this.oGrid.Rows; nI++)
					this.oGrid.Cells[ nI, 0].BackColor = this.oTodayBackColor;
			else if ( this.oStyle == CalendarStyle.Weekly)
				for( int nI = 0; nI < this.oGrid.Rows; nI++)
					this.oGrid.Cells[ nI, this.GetDayOfWeekNo( this.dtCurrent)].BackColor = this.oTodayBackColor;
			else if ( this.oStyle == CalendarStyle.Monthly)
			{
				int nRow = this.GetWeekOfMonth( this.dtCurrent, this.dtCurrent.Month);
				int nCol = this.GetDayOfWeekNo( this.dtCurrent);
				this.oGrid.Cells[ nRow, nCol].BackColor = this.oTodayBackColor;
			}

			this.oGrid.ResumeLayout();

			this.oGrid.Refresh();
		}
		private void UnPaintToday()
		{
			if ( this.oStyle == CalendarStyle.Dayly)
				for( int nI = 0; nI < this.oGrid.Rows; nI++)
					this.oGrid.Cells[ nI, 0].BackColor = this.BackColor;
			else if ( this.oStyle == CalendarStyle.Weekly)
				for( int nI = 0; nI < this.oGrid.Rows; nI++)
					this.oGrid.Cells[ nI, this.GetDayOfWeekNo( this.dtCurrent)].BackColor = this.BackColor;
			else if ( this.oStyle == CalendarStyle.Monthly)
				if ( this.oGrid.Cells.Length > 0)
				{
					int nRow = this.GetWeekOfMonth( this.dtCurrent, this.dtCurrent.Month);
					int nCol = this.GetDayOfWeekNo( this.dtCurrent);
					this.oGrid.Cells[ nRow, nCol].BackColor = this.BackColor;
				}
		}
		#endregion

		#region Date manipulation methods
		private DateTime GetFirstDisplayedDate( DateTime dtDate)
		{
			DateTime dtFirst = dtDate;

			if ( this.oStyle == CalendarStyle.Weekly)
				dtFirst = this.GetFirstDayOfWeek( dtDate);
			else if ( this.oStyle == CalendarStyle.Monthly)
				dtFirst = this.GetFirstDayOfWeek( new DateTime( dtDate.Year, dtDate.Month, 1));

			return dtFirst;
		}
		private DateTime GetFirstDayOfWeek( DateTime dDay)
		{
			DateTime dtDate;
			for( dtDate = dDay; dtDate.DayOfWeek != this.oCultureInfo.DateTimeFormat.FirstDayOfWeek; )
				dtDate = dtDate.AddDays( -1);
			return dtDate;
		}
		private int GetDayOfWeekNo( DateTime dtDate)
		{
			int nI = 0;
			DayOfWeek oDayOfWeek = this.oCultureInfo.DateTimeFormat.FirstDayOfWeek;
			for( DateTime dtTemp = dtDate; dtTemp.DayOfWeek != this.oCultureInfo.DateTimeFormat.FirstDayOfWeek; dtTemp = dtTemp.AddDays( -1))
				nI++;

			return nI;
		}
		private int GetWeekOfMonth( DateTime dtDate, int nMonth)
		{
			int nWeekOfMonth = 0;
			if ( dtDate.Month < nMonth)
				nWeekOfMonth = 0;
			else
			{
				DateTime dtFirstDay = this.GetFirstDisplayedDate( dtDate);
				int nDateWeekOfYear = this.GetWeekOfYear( dtDate);
				int nFirstDayWeekOfYear = ( dtFirstDay.Year < dtDate.Year ? 0 : this.GetWeekOfYear( dtFirstDay));
				nWeekOfMonth = Math.Max( nDateWeekOfYear - nFirstDayWeekOfYear, 0);
			}
			return nWeekOfMonth;
		}
		private int GetWeekOfYear( DateTime dtDate)
		{
			return this.oCultureInfo.DateTimeFormat.Calendar.GetWeekOfYear( dtDate, this.oCultureInfo.DateTimeFormat.CalendarWeekRule, this.oCultureInfo.DateTimeFormat.FirstDayOfWeek);
		}
		#endregion
		
		#region Data methods
		public IListTable GetItemAt( int nX, int nY )
		{
			IListTable oDataItem = null;
			foreach ( Control oControl in this.Controls )
			{
				if ( oControl is EventBox 
					&& oControl.Location.X <= nX && ( oControl.Location.X + oControl.Size.Width) >= nX 
					&& oControl.Location.Y <= nY && ( oControl.Location.Y + oControl.Size.Height) >= nY)
				{
					EventBox oOpenEventBox = (EventBox)oControl;
					if ( oOpenEventBox.Event != null && oOpenEventBox.Event is IListTable )
						oDataItem = oOpenEventBox.Event as IListTable;
				}
			}

			return oDataItem;
		}
		#endregion

		#region Raise event methods
		private void RaiseEvent_CalendarStyle_Change()
		{
			if ( this.CalendarStyleChangeEvent != null)
				this.CalendarStyleChangeEvent();
		}
		private void RaiseBeforeCurrentDateChangeEvent()
		{
			if ( this.BeforeCurrentDateChangeEvent != null)
				this.BeforeCurrentDateChangeEvent();
		}
		private void RaiseAfterCurrentDateChangeEvent()
		{
			if ( this.AfterCurrentDateChangeEvent != null)
				this.AfterCurrentDateChangeEvent();
		}
		#endregion

		#region Static
		private static int Time2Pixel( Grid oGrid, TimeSpan dtTime )
		{
			int nMinutes = (int)dtTime.TotalMinutes;
			return nMinutes * oGrid.Height / 1440;
		}
		//private static DateTime Pixel2Time( Grid oGrid, Point oPoint)
		//{
		//    return new DateTime( oPoint.Y * 100 / oGrid.Height );
		//}
		#endregion
		
		#region Event methods
		private void WLCalendar_Load(object sender, System.EventArgs e)
		{
			this.oGrid.RowCountChange += new RowCountChangeDelegate( oGrid_RowCountChange);
			this.oGrid.RowHeightChange += new RowHeightChangeDelegate(oGrid_RowHeightChange);
			//			this.oGrid.ColumnCountChange += new ColumnCountChangeDelegate( oGrid_Change);
			this.Resize += new EventHandler(WLCalendar_Resize);
			this.BeforeCurrentDateChangeEvent += new BeforeCurrentDateChangeDelegate( WLCalendar_BeforeCurrentDateChangeEvent);
			this.AfterCurrentDateChangeEvent += new AfterCurrentDateChangeDelegate( WLCalendar_AfterCurrentDateChangeEvent);
			this.oVScroll.ValueChanged += new EventHandler( oVScroll_ValueChanged);
			//this.oResources.CountChanged += new EventHandler( WLCalendar_CalendarCountChanged);
			//this.oResources.ObjectChanged += new EventHandler( WLCalendar_ObjectChanged);
			//this.Paint += new PaintEventHandler(WLCalendar_Paint);
			if ( UseNewEvents)
				this.Paint += new PaintEventHandler( Event_Paint );

			this.SetControls();
			this.PaintToday();
		}
		private void WLCalendar_Resize(object sender, EventArgs e)
		{
			this.SetControls();
			//			this.oRowsHeader.Refresh();
		}
		private void WLCalendar_CalendarStyleChangeEvent()
		{
			this.SetControls();
			this.PaintToday();
		}
		private void oGrid_RowCountChange()
		{
			if ( this.oRowsHeader != null)
			{
				this.SetRowsHeader();
				this.oRowsHeader.Refresh();
			}
		}
		private void oGrid_RowHeightChange()
		{
			if ( this.oRowsHeader != null)
			{
				this.SetRowsHeader();
				this.oRowsHeader.Refresh();
			}
		}
		private void WLCalendar_BeforeCurrentDateChangeEvent()
		{
			this.UnPaintToday();
		}
		private void WLCalendar_AfterCurrentDateChangeEvent()
		{
			this.SetControls();
			this.PaintToday();
		}
		private void oVScroll_ValueChanged(object sender, EventArgs e)
		{
			this.SetGrid();
			this.SetRowsHeader();
		}
		private void Events_EventCountChange( object oObject, ObjectEventArgs oObjectEventArgs )
		{
			// adjust size and location of all controls
			this.SetControls();
		}
		private void oGrid_MouseDown(object sender, MouseEventArgs e)
		{
			Cell oCell = this.oGrid.GetCellAtPoint( e.X, e.Y );
			if ( oCell != null )
			{
				if ( this.Style == CalendarStyle.Monthly )
				{
					this.ClickedDate = this.dtFirstDisplayedDate.AddDays( oCell.Location.X * this.nDaysInWeek + oCell.Location.Y );
					if ( e.Button == MouseButtons.Left )
						this.CurrentDate = this.ClickedDate;
				}
				else if ( this.Style == CalendarStyle.Weekly )
				{
					this.ClickedDate = this.dtFirstDisplayedDate.AddDays( oCell.Location.Y ).AddMinutes( e.Y * 1440 / oGrid.Height );
					if ( e.Button == MouseButtons.Left )
						this.CurrentDate = this.ClickedDate;
				}
			}
			this.OnMouseDown( e);
		}
		private void WLCalendar_CalendarCountChanged( object sender, EventArgs e)
		{
			this.SetControls();
		}
		private void WLCalendar_ObjectChanged( object sender, EventArgs e)
		{
			this.SetControls();
		}
		public void DisplayEvents( object sender, EventArgs e )
		{
			this.DisplayEvents();
		}
		private void Event_Paint( object sender, PaintEventArgs e )
		{
			this.DrawEvents( e.Graphics );
		}
		#endregion

		#region Properties
		public DateTime CurrentDate
		{
			get { return this.dtCurrent;}
			set
			{
				this.RaiseBeforeCurrentDateChangeEvent();
				this.dtCurrent = value;
				this.RaiseAfterCurrentDateChangeEvent();
				// set all calendar controls
//				this.SetControls();
			}
		}
		public DateTime FirstDisplayedDate
		{
			get { return this.dtFirstDisplayedDate;}
			set { this.dtFirstDisplayedDate = value;}
		}
		public int DaysDisplayed
		{
			get { return this.nDaysDisplayed;}
			//set { this.nDaysDisplayed = value;}
		}
		internal Grid Grid
		{
			get { return this.oGrid;}
			set { this.oGrid = value;}
		}
		#region RC header
		public Color RCHeaderBackColor
		{
			get { return this.oRCHeaderBackColor;}
			set
			{
				this.oRCHeaderBackColor = value;
				this.oRCHeader.Refresh();
			}
		}
		public Color RCHeaderFontColor
		{
			get { return this.oRCHeaderFontColor;}
			set
			{
				this.oRCHeaderFontColor = value;
				this.oRCHeader.Refresh();
			}
		}
		public Color RCHeaderGradientColor1
		{
			get { return this.oRCHeaderGradientColor1;}
			set
			{
				this.oRCHeaderGradientColor1 = value;
				this.oRCHeader.Refresh();
			}
		}
		public Color RCHeaderGradientColor2
		{
			get { return this.oRCHeaderGradientColor2;}
			set
			{
				this.oRCHeaderGradientColor2 = value;
				this.oRCHeader.Refresh();
			}
		}
		public FillStyle RCHeaderFillStyle
		{
			get { return this.oRCHeaderFillStyle;}
			set
			{
				this.oRCHeaderFillStyle = value;
				this.oRCHeader.Refresh();
			}
		}
		#endregion
		internal RowsHeader RowsHeader
		{
			get { return this.oRowsHeader;}
			set { this.oRowsHeader = value;}
		}
		internal new WList<ICalendarEvent> Events
		{
			get 
			{
				if ( this.oCalendarEvents == null )
					this.oCalendarEvents = new WList<ICalendarEvent>();
				return this.oCalendarEvents; 

			}
			set { this.oCalendarEvents = value; }
		}
		internal ColumnsHeader ColumnsHeader
		{
			get { return this.oColumnsHeader;}
			set { this.oColumnsHeader = value;}
		}
		public CalendarStyle Style
		{
			get { return this.oStyle;}
			set
			{
				this.oStyle = value;
				this.RaiseEvent_CalendarStyle_Change();
			}
		}
		public string[] ColumnFormat
		{
			get { return this.aColumnFormat;}
			set { this.aColumnFormat = value;}
		}
		public CultureInfo CultureInfo
		{
			get { return this.oCultureInfo;}
			set { this.oCultureInfo = value;}
		}
		public Color TodayBackColor
		{
			get { return this.oTodayBackColor;}
			set
			{
				this.UnPaintToday();
				this.oTodayBackColor = value;
				this.PaintToday();
			}
		}
		//public ResourceCollection Resources
		//{
		//    get { return this.oResources;}
		//    set { this.oResources = value;}
		//}
		public new ContextMenuStrip ContextMenuStrip
		{
			get { return this.oGrid.ContextMenuStrip; }
			set { this.oGrid.ContextMenuStrip = value; }
		}
		private Color oLinesColor = Color.LightGray;
		public Color LinesColor
		{
			get { return this.oLinesColor; }
			set 
			{
				this.oLinesColor = value;
				this.Invalidate();
				//this.oGrid.Invalidate();
			}
		}
		private new void Invalidate()
		{
			this.oRCHeader.Invalidate();
			this.oColumnsHeader.Invalidate();
			this.oRowsHeader.Invalidate();
			this.oGrid.Invalidate();
			base.Invalidate();
		}
		[System.ComponentModel.DefaultValue( 0 )]
		public int StartVisibleHour { get; set;}
		[System.ComponentModel.DefaultValue( 23 )]
		public int EndVisibleHour { get; set; }
		[System.ComponentModel.DefaultValue( DEFAULT_HOURS_DISPLAYED)]
		private int HoursDisplayed { get;set;}
		public DateTime ClickedDate { get; set; }
		//public WList<CalendarDefinition> Calendars
		//{
		//    get
		//    {
		//        if ( this.oCalendars == null )
		//        {
		//            //this.oCalendars = CalendarDefinition.GetAll();
		//            this.oCalendars = new WList<CalendarDefinition>();
		//            oCalendars.AddRange( CalendarDefinition.GetListByOwner( Login.CurrentLogin.User ) );
		//            foreach ( Authorization oAuthorization in Authorization.GetListByUser( Login.CurrentLogin.User ) )
		//                if ( oCalendars.Find( oCalendar => ListTable.CompareEqual( oCalendar, oAuthorization.SecuredDataItem ) ) == null )
		//                    this.oCalendars.Add( oAuthorization.SecuredDataItem as CalendarDefinition );
		//        }
		//        return this.oCalendars;
		//    }
		//}
		public WList<CalendarDefinition> Calendars
		{
			get
			{
				if ( this.oCalendars == null )
					this.oCalendars = new WList<CalendarDefinition>();
				return this.oCalendars;
			}
			set
			{
				this.oCalendars = value;
			}
		}
		#endregion

//		private void Events_EventChange(Event oEvent)
//		{
//			this.SetEvents();
		//		}
	}
}
