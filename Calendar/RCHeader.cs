using System;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Calendar
{
	/// <summary>
	/// Summary description for RCHeader.
	/// </summary>
	internal class RCHeader: Control
	{
		#region Declarations
		private WLCalendar oWLCalendar = null;
		private SolidBrush oBrush = new SolidBrush( Color.Empty );
		//private Font oFont = new Font( "Tahoma", 8, FontStyle.Bold );
		StringFormat oFormat = new StringFormat();
		//private Point oLocation = new Point( 0, 0 );
		//private string cText = string.Empty;
		#endregion

		#region Constructor
		public RCHeader( WLCalendar oWLCalendar )
		{
			//double-buffering
			SetStyle( ControlStyles.AllPaintingInWmPaint | ControlStyles.DoubleBuffer | ControlStyles.UserPaint | ControlStyles.ResizeRedraw, true );

			this.oWLCalendar = oWLCalendar;

			this.Paint += new PaintEventHandler( RCHeader_Paint );
		}
		#endregion

		#region Draw methods
		private void DrawBackground( Graphics g )
		{
			if ( this.oWLCalendar.RCHeaderFillStyle == FillStyle.Flat )
				FillTool.DrawFlat( g, this.oWLCalendar.RCHeaderBackColor, this.Width, this.Height );
			else if ( this.oWLCalendar.RCHeaderFillStyle == FillStyle.VGradient )
				FillTool.DrawVGradient( g, this.oWLCalendar.RCHeaderGradientColor1, this.oWLCalendar.RCHeaderGradientColor2, this.Width, this.Height );
			else if ( this.oWLCalendar.RCHeaderFillStyle == FillStyle.HGradient )
				FillTool.DrawHGradient( g, this.oWLCalendar.RCHeaderGradientColor1, this.oWLCalendar.RCHeaderGradientColor2, this.Width, this.Height );
		}
		private void DrawTexts( Graphics g )
		{
			oFormat.Alignment = StringAlignment.Center;
			this.oBrush.Color = this.oWLCalendar.RCHeaderFontColor;
			int nVShift = ( this.oWLCalendar.ColumnsHeader.Height - this.oWLCalendar.Font.Height ) / 2;
			RectangleF oRectF = new RectangleF( 0, nVShift, this.Width, this.Height );
			g.DrawString( this.Text, this.oWLCalendar.Font, this.oBrush, oRectF, oFormat );
		}
		#endregion

		#region Event methods
		private void RCHeader_Paint( object sender, PaintEventArgs e )
		{
			// draw control with background
			this.DrawBackground( e.Graphics );

			// draw rows headers
			this.DrawTexts( e.Graphics );
		}
		#endregion

		#region Properties
		//public Point Location
		//{
		//    get { return this.oLocation; }
		//    set { this.oLocation = value; }
		//}
		//public string Text
		//{
		//    get { return this.cText; }
		//    set { this.cText = value; }
		//}
		#endregion
	}
}
