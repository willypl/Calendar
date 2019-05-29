using System;
using System.Windows.Forms;
using System.Drawing;

namespace Calendar
{
	/// <summary>
	/// Summary description for RowsHeader.
	/// </summary>
	internal class RowsHeader :Control
	{
		#region Declarations
		private const int DEFAULT_ROWS_HEADER_WIDTH = 40;
		private WLCalendar oWLCalendar = null;
		private SolidBrush oBrush = new SolidBrush( Color.Empty);
		//private Font oFont = new Font( "Tahoma", 8, FontStyle.Bold);
		StringFormat oFormat = new StringFormat();
		private FillStyle oFillStyle = FillStyle.HGradient;
		#region Colors
		private Color oGradientColor1 = Color.LightYellow;//Color.FromArgb( 215,238, 255);
		private Color oGradientColor2 = Color.White;
		#endregion
		#endregion

		#region Constructor
		public RowsHeader( WLCalendar oWLCalendar)
		{
			//double-buffering
			SetStyle( ControlStyles.AllPaintingInWmPaint | ControlStyles.DoubleBuffer | ControlStyles.UserPaint | ControlStyles.ResizeRedraw, true );

			this.oWLCalendar = oWLCalendar;

			this.Size = new Size( DEFAULT_ROWS_HEADER_WIDTH, 100);

			this.Paint += new PaintEventHandler(RowsHeader_Paint);
		}
		#endregion

		private void SetSize()
		{
			this.Height = this.oWLCalendar.Grid.Rows * this.oWLCalendar.Grid.RowHeight;
		}

		#region Draw methods
		private void RedrawControl( Graphics g)
		{
			this.SetSize();

			// draw control with background
			this.DrawBackground( g);

			// draw rows headers
			this.DrawTexts( g);
		}
		private void DrawBackground( Graphics g)
		{
			if ( this.oFillStyle == FillStyle.Flat)
				FillTool.DrawFlat( g, this.BackColor, this.Width, this.Height);
			else if ( this.oFillStyle == FillStyle.VGradient)
				FillTool.DrawVGradient( g, this.oGradientColor1, this.oGradientColor2, this.Width, this.Height);
			else if ( this.oFillStyle == FillStyle.HGradient)
				FillTool.DrawHGradient( g, this.oGradientColor1, this.oGradientColor2, this.Width, this.Height);
		}
		private void DrawTexts( Graphics g)
		{
			oFormat.Alignment = StringAlignment.Far;
			this.oBrush.Color = this.ForeColor;
			for( int nI = 0; nI < this.oWLCalendar.Grid.Rows; nI++)
			{
				int nVShift = ( this.oWLCalendar.Grid.RowHeight - this.oWLCalendar.Font.Height) / 2;
				RectangleF oRectF = new RectangleF( 0, nVShift + nI * this.oWLCalendar.Grid.RowHeight, this.Width, this.oWLCalendar.Grid.RowHeight);
				if ( this.oWLCalendar.Style == CalendarStyle.Monthly)
				{
					int nWeekNumber = this.oWLCalendar.CultureInfo.DateTimeFormat.Calendar.GetWeekOfYear( this.oWLCalendar.FirstDisplayedDate, System.Globalization.CalendarWeekRule.FirstDay, this.oWLCalendar.CultureInfo.DateTimeFormat.FirstDayOfWeek) + nI;
					g.DrawString( nWeekNumber.ToString(), this.oWLCalendar.Font, this.oBrush, oRectF, oFormat );
				}
				else
					g.DrawString( String.Format( "{0}:00", nI ), this.oWLCalendar.Font, this.oBrush, oRectF, oFormat );
			}
		}
		#endregion

		#region Event methods
		private void RowsHeader_Paint(object sender, PaintEventArgs e)
		{
			this.RedrawControl( e.Graphics);
		}
		#endregion

		#region GET/SET methods
		public Color GradientColor1
		{
			get { return this.oGradientColor1;}
			set
			{
				this.oGradientColor1 = value;
				this.Refresh();
			}
		}
		public Color GradientColor2
		{
			get { return this.oGradientColor2;}
			set
			{
				this.oGradientColor2 = value;
				this.Refresh();
			}
		}
		public FillStyle FillStyle
		{
			get { return this.oFillStyle;}
			set
			{
				this.oFillStyle = value;
				this.Refresh();
			}
		}
		#endregion
	}
}
