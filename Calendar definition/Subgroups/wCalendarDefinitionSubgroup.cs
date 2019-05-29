using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Venus.WLReportViewer;
using Merkury;
using MercuryResource;
using MercuryDocument;
using MercuryPurchase;
using MercuryService;
using Mercury.Model.Calendar;
using MSLib;
using WLib;
using System.IO;
using Sun;
using Venus;
using System.Reflection;

namespace Calendar
{
	public partial class wCalendarDefinitionSubgroup :wCalendarDefinitionSubgroupGeneric
	{
		#region Declarations
		private ModuleEnum oModule;
		#endregion

		#region Constructors
		public wCalendarDefinitionSubgroup()
		{
			InitializeComponent();
			//this.InitializeControls();
		}
		public wCalendarDefinitionSubgroup( CalendarDefinitionSubgroup oCalendarDefinitionSubgroup) : this()
		{
			this.Subgroup = oCalendarDefinitionSubgroup;
		}
		#endregion

		#region Initialize methods
		public override void InitializeControls()
		{
			if ( this.Subgroup.CalendarDefinition != null && this.Subgroup.CalendarDefinition.RelatedType != null )
			{
				ComboSource csProperties = new ComboSource();
				foreach ( PropertyInfo oPropertyInfo in this.Subgroup.CalendarDefinition.RelatedType.GetProperties() )
					csProperties.Add( oPropertyInfo.Name, oPropertyInfo.Name );
				ComboSource.BindComboBox( this.cbProperty, csProperties);
			}
			this.SetHandles();
		}
		#endregion

		#region Display methods
		public override void DisplayItem()
		{
			try
			{
				if ( !this.Disposing )
				{
					this.cbProperty.SelectedValue = this.Subgroup.PropertyName;
					base.DisplayItem();
				}
			}
			catch ( Exception e )
			{
				ErrorBox.Show( e, CalendarDefinitionSubgroup.Title );
			}
		}
		#endregion

		#region Data methods
		public override void StoreValues()
		{
			this.Subgroup.PropertyName = this.cbProperty.SelectedValue == null ? string.Empty : (string)this.cbProperty.SelectedValue;
		}
		public void SetHandles()
		{
			//this.tbDesription.Leave += new System.EventHandler( this.StoreValues );
		}
		public void UnsetHandles()
		{
			//this.tbDesription.Leave -= new System.EventHandler( this.StoreValues );
		}
		#endregion

		#region Event methods
		#endregion

		#region Properties
		public CalendarDefinitionSubgroup Subgroup
		{
			get { return this.ListItem; }
			set { this.ListItem = value; }
		}
		#endregion
	}
}
