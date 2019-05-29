//using System;
//using System.Windows.Forms;
//using System.Drawing;

//namespace Calendar
//{
//    /// <summary>
//    /// Summary description for ResourcesHeader.
//    /// </summary>
//    internal class ResourcesHeader :Control
//    {
//        #region Declarations
//        private const int DEFAULT_RESOURCES_HEADER_HEIGHT = 15;
//        private WLCalendar oWLCalendar = null;
//        private SolidBrush oBrush = new SolidBrush( Color.Empty);
//        private Pen oPen = new Pen( Color.Empty);
//        private Font oFont = new Font( "Tahoma", 8, FontStyle.Regular);
//        StringFormat oFormat = new StringFormat();
//        private FillStyle oFillStyle = FillStyle.VGradient;
//        #region Colors
//        private Color oGradientColor1 = Color.White;
//        private Color oGradientColor2 = Color.LimeGreen;
//        private Color oBottomBorderColor = Color.Gray;
//        #endregion
//        #endregion

//        #region Constructor
//        public ResourcesHeader( WLCalendar oWLCalendar)
//        {
//            //double-buffering
//            SetStyle( ControlStyles.AllPaintingInWmPaint | ControlStyles.DoubleBuffer | ControlStyles.UserPaint | ControlStyles.ResizeRedraw, true );

//            this.oWLCalendar = oWLCalendar;

//            this.Size = new Size( 100, DEFAULT_RESOURCES_HEADER_HEIGHT);

//            this.Paint += new PaintEventHandler(ColumnsHeader_Paint);
//            this.MouseDown += new MouseEventHandler(ResourcesHeader_MouseDown);
//        }
//        #endregion

//        #region Draw methods
//        private void RedrawControl( Graphics g)
//        {
//            // draw control with background
//            this.DrawBackground( g);

//            // draw columns headers
//            this.DrawLines( g);

//            // draw columns headers
//            this.DrawTexts( g);
//        }
//        private void DrawBackground( Graphics g)
//        {
//            // draw background of control
//            if ( this.oFillStyle == FillStyle.Flat)
//                FillTool.DrawFlat( g, this.oWLCalendar.BackColor, this.Width, this.Height);
//            else if ( this.oFillStyle == FillStyle.VGradient)
//                FillTool.DrawVGradient( g, this.oGradientColor1, this.oGradientColor2, this.Width, this.Height);
//            else if ( this.oFillStyle == FillStyle.HGradient)
//                FillTool.DrawHGradient( g, this.oGradientColor1, this.oGradientColor2, this.Width, this.Height);
//        }
//        private void DrawLines( Graphics g)
//        {
//            if ( this.oWLCalendar.Grid != null)
//            {
//                // draw vertical lines between columns
//                this.oPen.Color = this.oWLCalendar.LinesColor;
//                for( int nI = 0; nI < this.oWLCalendar.Grid.Columns; nI++)
//                {
//                    g.DrawLine( this.oPen, ( nI + 1) * this.oWLCalendar.Grid.ColumnWidth - 1, 0, ( nI + 1) * this.oWLCalendar.Grid.ColumnWidth - 1, this.Height);
////					foreach( Resource oResource in this.oWLCalendar.Resources)
//                }
//                g.DrawLine( this.oPen, 0, this.Height - 1, this.Width, this.Height - 1);
//            }
//        }
//        private void DrawTexts( Graphics g)
//        {
//            int nResourceX, nResourceY, nResourceWidth, nResourceHeight;
//            RectangleF oRectF;

//            oFormat.Alignment = StringAlignment.Center;
//            this.oBrush.Color = this.oWLCalendar.ForeColor;
//            // for each column draw resource names
//            for( int nI = 0; nI < this.oWLCalendar.Grid.Columns; nI++)
//            {
//                nResourceY = ( this.Height - this.oFont.Height) / 2;
//                nResourceWidth = this.oWLCalendar.Resources.Count == 0 ? this.oWLCalendar.Grid.ColumnWidth : this.oWLCalendar.Grid.ColumnWidth / this.oWLCalendar.Resources.Count;
//                nResourceHeight = this.Height;
//                string cFormat = this.oWLCalendar.ColumnFormat[ (int)this.oWLCalendar.Style];
//                for( int nJ = 0; nJ < this.oWLCalendar.Resources.Count; nJ++)
//                {
//                    nResourceX = nI * this.oWLCalendar.Grid.ColumnWidth + nJ * nResourceWidth;
//                    oRectF = new RectangleF( nResourceX, nResourceY, nResourceWidth, nResourceHeight);
//                    g.DrawString( ( (CalendarResource)this.oWLCalendar.Resources[nJ] ).ID, this.oFont, this.oBrush, oRectF, oFormat );
//                }
//            }
//        }
//        #endregion

//        #region Event methods
//        private void ColumnsHeader_Paint(object sender, PaintEventArgs e)
//        {
//            this.RedrawControl( e.Graphics);
//        }
//        #endregion

//        #region GET/SET methods
//        public Color GradientColor1
//        {
//            get { return this.oGradientColor1;}
//            set
//            {
//                this.oGradientColor1 = value;
//                this.Refresh();
//            }
//        }
//        public Color GradientColor2
//        {
//            get { return this.oGradientColor2;}
//            set
//            {
//                this.oGradientColor2 = value;
//                this.Refresh();
//            }
//        }
//        public Color BottomBorderColor
//        {
//            get { return this.oBottomBorderColor;}
//            set
//            {
//                this.oBottomBorderColor = value;
//                this.Refresh();
//            }
//        }
//        public FillStyle FillStyle
//        {
//            get { return this.oFillStyle;}
//            set
//            {
//                this.oFillStyle = value;
//                this.Refresh();
//            }
//        }
//        #endregion

//        private void ResourcesHeader_MouseDown(object sender, MouseEventArgs e)
//        {
//            if ( e.Button == MouseButtons.Right)
//            {
////				this.oWLCalendar.ContextMenu.MenuItems.AddRange(.Clear();
////				this.oWLCalendar.ContextMenu.MenuItems.Add( "OK");
//            }
//        }
//    }
//}
