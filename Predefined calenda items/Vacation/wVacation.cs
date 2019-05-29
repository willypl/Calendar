using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Venus;

namespace Calendar
{
	public partial class wVacation: wVacationGeneric
	{
		#region Constructors
		public wVacation()
		{
			InitializeComponent();
			this.InitializeControls();
		}
		#endregion

		#region Initialize methods
		public void InitializeControls()
		{
			this.RecordMovementControlVisible = false;
		}
		#endregion

		#region Display methods
		public override void DisplayItem()
		{
			try
			{
				this.UnsetHandlers();
				if ( !this.Disposing )
				{
					this.tbShortName.Text = this.Vacation.ShortName;
					this.tbDescription.Text = this.Vacation.Description;
					this.tbEmployee.Text = this.Vacation.EmployeeName;
					this.dtpStartDate.Value = this.Vacation.StartDate;
					this.dtpEndDate.Value = this.Vacation.EndDate;
					this.tbCreateUser.Text = this.Vacation.OwnerName;
				}
			}
			finally
			{
				this.SetHandlers();
			}

			base.DisplayItem();
		}
		public override void SetControls()
		{
			base.SetControls();
		}
		private void SetHandlers()
		{
			this.tbShortName.Leave += this.StoreValues;
			this.dtpStartDate.ValueChanged += this.StoreValuesAndDisplayItem;
			this.dtpEndDate.ValueChanged += this.StoreValuesAndDisplayItem;
		}
		private void UnsetHandlers()
		{
			this.tbShortName.Leave -= this.StoreValues;
			this.dtpStartDate.ValueChanged -= this.StoreValuesAndDisplayItem;
			this.dtpEndDate.ValueChanged -= this.StoreValuesAndDisplayItem;
		}
		#endregion

		#region Data methods
		public override void StoreValues()
		{
			if ( !this.Disposing )
			{
				this.Vacation.ShortName = this.tbShortName.Text;
				this.Vacation.Description = this.tbDescription.Text;
				this.Vacation.StartDate = this.dtpStartDate.Value;
				this.Vacation.EndDate = this.dtpEndDate.Value;
			}
			base.StoreValues();
		}
		#endregion

		#region Events
		private void UserHandler( object sender, System.EventArgs e )
		{
			try
			{
				if ( sender.Equals( this.tbEmployee ) )
					this.Vacation.EmployeeName = this.tbEmployee.Text;
				else if ( sender.Equals( this.btnEmployeeLookup ) )
				{
					User oUser = wLookup<User>.Lookup( User.DivisionAllLookupInfo );
					if ( oUser != null )
					{
						this.Vacation.Employee = oUser;
						this.DisplayItem();
					}
				}
			}
			catch ( Exception ex )
			{
				ErrorBox.Show( ex, User.Title );
			}
		}
		#endregion

		#region Propertes
		public Vacation Vacation
		{
			get { return this.ListItem; }
			set { this.ListItem = value; }
		}
		#endregion
	}
}
