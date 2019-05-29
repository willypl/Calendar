using System;
using System.Collections;
using System.Windows.Forms;
using System.Drawing;
using Mercury.Model.Calendar;

namespace Calendar
{
	internal class EventBox :Control
	{
		#region Declarations
		private ICalendarEvent oEvent = null;
		private Pen oPen = new Pen( Color.Empty );
		private SolidBrush oBrush = new SolidBrush( Color.Empty);
		private Color oBorderColor = Color.DarkViolet;
		private Color oTextHeaderColor = Color.Black;
		private Color oDescriptionColor = Color.Black;
		private int nBorderWidth = 1;
		Font oFont = new Font( "Tahoma", 8, FontStyle.Bold);
		StringFormat oStringFormat = null;
		ToolTip oTT = new ToolTip();
		#endregion

		#region Constructor
		public EventBox( ICalendarEvent oEvent )
		{
			//double-buffering
			SetStyle( ControlStyles.AllPaintingInWmPaint | ControlStyles.DoubleBuffer | ControlStyles.UserPaint | ControlStyles.ResizeRedraw, true );

			this.oEvent = oEvent;
			this.BackColor = Color.LightYellow;
			//if ( oEvent.Calendar.DisplayColor != Color.Empty)
			//	this.BorderColor = oEvent.Calendar.DisplayColor;
			this.oStringFormat = new StringFormat();
			oStringFormat.Alignment = StringAlignment.Near;
			this.oTT.InitialDelay = 0;
			this.oTT.AutoPopDelay = Int16.MaxValue;
			this.oTT.ReshowDelay = 0;
			this.oTT.ShowAlways = true;

			this.Paint += new PaintEventHandler(Event_Paint);
			this.ContextMenuStrip = new ContextMenuStrip();
			this.MouseDown += new MouseEventHandler( ContextMenuStrip_MouseDown );
		}
		private void ContextMenuStrip_MouseDown( object sender, MouseEventArgs e )
		{
			this.ContextMenuStrip.Items.Clear();
			//this.ContextMenuStrip.Items.Add( "&Otwórz", null, new EventHandler( this.oEvent.OnOpen));
		}
		#endregion

		#region Draw methods
		private void RedrawEvent( Graphics g)
		{
			// paint body with backcolor
			this.oBrush.Color = this.BackColor;
			g.FillRectangle( this.oBrush, 0, 0, this.Width, this.Height);
			
			// draw border
			oPen.Color = this.oBorderColor;
			this.oPen.Width = this.nBorderWidth;
			g.DrawRectangle( this.oPen, 0, 0, this.Width - this.nBorderWidth, this.Height - this.nBorderWidth);
			this.oPen.Width = 5;
			oPen.Color = this.oBorderColor;// Color.Red;
			g.DrawLine( this.oPen, 0, 0, 0, this.Height);
			
			// draw start time
			this.oBrush.Color = this.oTextHeaderColor;
			Rectangle oRect = new Rectangle( 2, 2, this.Width, this.oFont.Height);
			g.DrawString( this.oEvent.StartDate.ToString( "hh:mm"), this.oFont, this.oBrush, oRect);

			// draw event titla
			this.oBrush.Color = this.oDescriptionColor;
			oRect = new Rectangle( 2, this.oFont.Height, this.Width, this.oFont.Height);
			g.DrawString( this.oEvent.CalendarDescription, this.oFont, this.oBrush, oRect);
		}
		#endregion

		#region Event methods
		private void Event_Paint( object sender, PaintEventArgs e )
		{
			this.RedrawEvent( e.Graphics);
		}
		protected override void OnMouseEnter( EventArgs e )
		{
			base.OnMouseEnter( e );
			if ( this.oEvent.CalendarDescription != string.Empty )
			{
				this.oTT.InitialDelay = 0;
				//this.oTT.AutoPopDelay = 5000;
				this.oTT.SetToolTip( this, this.oEvent.CalendarDescription );
			}
		}
		//protected override void OnMouseDown( MouseEventArgs e )
		//{
		//    base.OnMouseDown( e );
		//    if ( this.o
		//}
		//protected override void OnMouseMove( MouseEventArgs e )
		//{
		//    base.OnMouseMove( e );
		//}
		#endregion
		
		#region Properties
		public Color BorderColor
		{
			get { return this.oBorderColor;}
			set { this.oBorderColor = value;}
		}
		public ICalendarEvent Event
		{
			get { return this.oEvent;}
			set { this.oEvent = value;}
		}
		#endregion
	}
}
