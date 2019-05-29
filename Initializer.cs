using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Merkury;
using WLib;
using Venus;

namespace Calendar
{
	//[WLMenu( null, new string[] { "&Kalendarz", "Kalendarz nowy"}, typeof( MerkuryCalendar.wCalendar))]
	//[WLMenu( typeof( CalendarDefinition), new string[] { "&Ustawienia", "Kalendarz", "Definicje kalendarzy" } )]
	public class Initializer
	{
		public static void Initialize( wMercuryService oMercuryForm )
		{
			oMercuryForm.RegisterMenuItem( new string[] { "&Kalendarz", "&Mój kalendarz" }, typeof( Calendar.wCalendar ));
			oMercuryForm.RegisterMenuItem( new string[] { "&Ustawienia", "&Kalendarz", "&Definicje kalendarzy" }, typeof( CalendarDefinition ));
			ToolStripButton tsbCalendar = new ToolStripButton();
			tsbCalendar.Image = global::Calendar.Properties.Resources.Scheduler;
			tsbCalendar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			tsbCalendar.ImageTransparentColor = System.Drawing.Color.Magenta;
			tsbCalendar.Name = "tsbScheduler";
			tsbCalendar.Size = new System.Drawing.Size( 109, 52 );
			tsbCalendar.Text = "Kalendarz";
			tsbCalendar.Click += delegate
			{
				RuntimeManager.OpenForm( typeof( wCalendar) );
			};
			oMercuryForm.Toolbar.Items.Insert( 4, tsbCalendar );
		}
	}
}
