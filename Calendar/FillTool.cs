using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Calendar
{
	/// <summary>
	/// Summary description for FillTool.
	/// </summary>
	public class FillTool
	{
		public static void Draw( Graphics g, FillStyle oFillStyle, Color oColor, Color oGradientColor1, Color oGradientColor2, int nWidth, int nHeight)
		{
			if ( oFillStyle == FillStyle.Flat)
				FillTool.DrawFlat( g, oColor, nWidth, nHeight);
			else if ( oFillStyle == FillStyle.VGradient)
				// draw rectangle as  vertical gradient
				FillTool.DrawVGradient( g, oGradientColor1, oGradientColor2, nWidth, nHeight);
			else if ( oFillStyle == FillStyle.HGradient)
				// draw rectangle as horizontal gradient
				FillTool.DrawHGradient( g, oGradientColor1, oGradientColor2, nWidth, nHeight);
		}
		public static void DrawFlat( Graphics g, Color oColor, int nWidth, int nHeight)
		{
			g.FillRectangle( new SolidBrush( oColor), 0, 0, nWidth, nHeight);
		}
		public static void DrawVGradient( Graphics g, Color oColor1, Color oColor2, int nWidth, int nHeight)
		{
			// draw rectangle as  vertical gradient
			Rectangle oRect = new Rectangle( 0, 0, nWidth, nHeight);
			LinearGradientBrush oLGB = new LinearGradientBrush( oRect, oColor1, oColor2, LinearGradientMode.Vertical);
			g.FillRectangle( oLGB, 0, 0, nWidth, nHeight / 2);
			oLGB = new LinearGradientBrush( oRect, oColor2, oColor1, LinearGradientMode.Vertical);
			g.FillRectangle( oLGB, 0, nHeight / 2, nWidth, nHeight / 2);
		}
		public static void DrawHGradient( Graphics g, Color oColor1, Color oColor2, int nWidth, int nHeight)
		{
			// draw rectangle as horizontal gradient
			Rectangle oRect = new Rectangle( 0, 0, nWidth, nHeight);
			LinearGradientBrush oLGB = new LinearGradientBrush( oRect, oColor1, oColor2, LinearGradientMode.Horizontal);
			g.FillRectangle( oLGB, 0, 0, nWidth / 2, nHeight);
			oLGB = new LinearGradientBrush( oRect, oColor2, oColor1, LinearGradientMode.Horizontal);
			g.FillRectangle( oLGB, nWidth / 2, 0, nWidth / 2, nHeight);
		}
	}
}
