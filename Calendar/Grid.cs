using System;
using System.Windows.Forms;
using System.Drawing;

namespace Calendar
{
	/// <summary>
	/// Summary description for Matrix.
	/// </summary>
	internal class Grid: Control
	{
		#region Declarations
		#region Constants
		private const int DEFAULT_WIDTH = 100;
		private const int DEFAULT_HEIGHT = 400;
		#endregion
		#region Events
		public event RowCountChangeDelegate RowCountChange;
		public event RowHeightChangeDelegate RowHeightChange;
		public event ColumnCountChangeDelegate ColumnCountChange;
		public event ColumnWidthChangeDelegate ColumnWidthChange;
		#endregion
		private Color DEFAULT_BACK_COLOR = Color.LightYellow;
		private WLCalendar oCalendar = null;
		private SolidBrush oBrush = new SolidBrush( Color.Empty);
		private Pen oPen = null;
		private int nRows = 0;
		private int nColumns = 0;
		private int nRowHeight = 20;
		private int nColumnWidth = 0;
		//private Color oLinesColor = Color.LightGray;
		private Cell[,] oCells;
		#endregion

		#region Constructor
		public Grid( WLCalendar oCalendar)
		{
			//double-buffering
			SetStyle( ControlStyles.AllPaintingInWmPaint | ControlStyles.DoubleBuffer | ControlStyles.UserPaint | ControlStyles.ResizeRedraw, true );

			this.oCalendar = oCalendar;

			this.BackColor = DEFAULT_BACK_COLOR;
			this.Size = new Size( DEFAULT_WIDTH, DEFAULT_HEIGHT);
//			this.nRowHeight = this.nRowHeight;
			this.oPen = new Pen( this.oCalendar.LinesColor);
			//oPen.Color = this.oCalendar.LinesColor;

			this.Paint += new PaintEventHandler(Matrix_Paint);
			this.RowCountChange += new RowCountChangeDelegate(Grid_RowCountChangeEvent);
			this.ColumnCountChange += new ColumnCountChangeDelegate(Grid_ColumnCountChangeEvent);
			this.Resize += new EventHandler(Grid_Resize);
		}
		#endregion

		#region Set controls
		private void SetControls()
		{
//			this.oCells = new Cell[ this.nRows, this.nColumns];
			this.nColumnWidth = ( this.nColumns == 0 ? 0 : this.Width / this.nColumns);
			this.nRowHeight = ( this.nRows == 0 ? 0 : this.Height / this.nRows);

			this.Refresh();
		}
		#endregion

		#region Repaint methods
		private void RepaintGrid( Graphics g)
		{
			this.oPen.Color = this.oCalendar.LinesColor;
			// paint back color
			this.oBrush.Color = this.BackColor;
			g.FillRectangle( this.oBrush, 0, 0, this.Width, this.Height);

			// draw vertical lines for columns
			for( int nI = 0; nI < this.nColumns; nI++)
				g.DrawLine( this.oPen, ( nI + 1) * this.nColumnWidth - 1, 0, ( nI + 1) * this.nColumnWidth - 1, this.Height);

			// draw horizontal lines for rows
			for( int nI = 0; nI < this.nRows; nI++)
				g.DrawLine( this.oPen, 0, ( nI + 1) * this.nRowHeight - 1, this.Width, ( nI + 1) * this.nRowHeight - 1);

			// draw cells if not empty
			for( int nRow = 0; nRow < this.oCells.GetLength( 0); nRow++)
				for( int nCol = 0; nCol < this.oCells.GetLength( 1); nCol++)
				{
					Cell oCell = this.oCells[ nRow, nCol];
					if ( oCell != null)
						this.DrawCell( oCell, g, nRow, nCol);
				}
		}
		private void Matrix_Paint( object sender, PaintEventArgs e)
		{
			this.RepaintGrid( e.Graphics);
		}
		private void DrawCell( Cell oCell, Graphics g, int nRow, int nCol)
		{
			// draw background
			if ( oCell.BackColor != this.BackColor)
			{
				this.oBrush.Color = oCell.BackColor;
				g.FillRectangle( this.oBrush, nCol * this.nColumnWidth, nRow * this.nRowHeight, this.nColumnWidth - 1, this.nRowHeight - 1);
			}
			// draw text
			if ( oCell.Text != string.Empty)
			{
				oBrush.Color = oCell.ForeColor;
				RectangleF oRectF = new RectangleF( nCol * this.nColumnWidth, nRow * this.nRowHeight, this.nColumnWidth - 1, this.nRowHeight);
				g.DrawString( oCell.Text, this.Font, this.oBrush, oRectF, oCell.StringFormat);
			}
		}
		#endregion

		#region Rebuild cells
		private void RebuildCells()
		{
			if ( this.oCells == null || this.oCells.GetLength( 0) != this.nRows || this.oCells.GetLength( 1) != this.nColumns)
			{
				this.oCells = new Cell[ this.nRows, this.nColumns];
				for( int nRow = 0; nRow < this.oCells.GetLength( 0); nRow++)
					for ( int nCol = 0; nCol < this.oCells.GetLength( 1); nCol++)
					{
						if ( this.oCells[ nRow, nCol] == null)
						{
							Cell oCell = new Cell();
							oCell.BackColor = this.BackColor;
							oCell.Location = new Point( nRow, nCol);
							this.oCells[ nRow, nCol] = oCell;
						}
					}
			}
		}

		#endregion

		internal Cell GetCellAtPoint( int nX, int nY)
		{
			int nRow = Convert.ToInt32( nY / this.nRowHeight);
			int nCol = Convert.ToInt32( nX / this.nColumnWidth);

			return this.oCells[ nRow, nCol];
		}

		#region Event raise methods
		public void RaiseRowCountChangeEvent()
		{
			if ( this.RowCountChange != null)
				this.RowCountChange();
		}
		public void RaiseRowHeightChangeEvent()
		{
			if ( this.RowHeightChange != null)
				this.RowHeightChange();
		}
		public void RaiseColumnCountChangeEvent()
		{
			if ( this.ColumnCountChange != null)
				this.ColumnCountChange();
		}
		public void RaiseColumnWidthChangeEvent()
		{
			if ( this.ColumnWidthChange != null)
				this.ColumnCountChange();
		}
		#endregion

		#region Event methods
		private void Grid_RowCountChangeEvent()
		{
			this.RebuildCells();
			this.SetControls();
		}
		private void Grid_ColumnCountChangeEvent()
		{
			this.RebuildCells();
			this.SetControls();
		}
		private void Grid_Resize(object sender, EventArgs e)
		{
			this.SetControls();
			this.RebuildCells();
		}
		protected override void OnPaint( PaintEventArgs e )
		{
			base.OnPaint( e );
			//this.RepaintGrid( e.Graphics );
		}
		#endregion

		#region GET/SET methods
		public int Rows
		{
			get { return this.nRows;}
			set
			{
				this.nRows = value;
				this.RaiseRowCountChangeEvent();
				this.Refresh();
			}
		}
		public int Columns
		{
			get { return this.nColumns;}
			set
			{
				this.nColumns = value;
				this.RaiseRowCountChangeEvent();
				this.Refresh();
			}
		}
		public int RowHeight
		{
			get { return this.nRowHeight;}
			set
			{
				this.nRowHeight = value;
				this.RaiseRowHeightChangeEvent();
				this.Height = this.nRowHeight * this.nRows;
				this.Refresh();
			}
		}
		public int ColumnWidth
		{
			get { return this.nColumnWidth;}
			set
			{
				this.nColumnWidth = value;
				this.RaiseColumnWidthChangeEvent();
				this.Width = this.nColumnWidth * this.nColumns;
				this.Refresh();
			}
		}
		internal Cell[,] Cells
		{
			get { return this.oCells;}
			set { this.oCells = value;}
		}
		//public Color LinesColor
		//{
		//    get { return this.oLinesColor;}
		//    set
		//    {
		//        this.oLinesColor = value;
		//        this.Refresh();
		//    }
		//}

		#endregion
	}
}
