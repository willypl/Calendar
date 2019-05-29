using System;
using System.Windows.Forms;
using System.Drawing;

namespace Calendar
{
	/// <summary>
	/// Summary description for Cell.
	/// </summary>
	internal class Cell: Control
	{
		StringFormat oSF = new StringFormat();
		public Cell()
		{
			this.Paint += new PaintEventHandler( Cell_Paint);
		}
		private void Cell_Paint(object sender, PaintEventArgs e)
		{
			e.Graphics.FillRectangle( new SolidBrush( this.BackColor), 0, 0, this.Width, this.Height);
		}

		public StringFormat StringFormat
		{
			get { return this.oSF;}
			set { this.oSF = value;}
		}
	}
}
