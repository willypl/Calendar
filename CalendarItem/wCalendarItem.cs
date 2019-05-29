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
	enum DaysEnum
	{
		Monday = 1 << 0,
		Tuesday = 1 << 1,
		Wednesday = 1 << 2,
		Thursday = 1 << 3,
		Friday = 1 << 4,
		Saturday = 1 << 5,
		Sunday = 1 << 6
	}
	public partial class wCalendarItem: wCalendarItemGeneric
	{
		#region Constructors
		public wCalendarItem()
		{
			InitializeComponent();
			this.InitializeControls();
		}
		#endregion

		#region Initialize methods
		public void InitializeControls()
		{
			ComboSourceNew<CalendarCyclePeriodTypeEnum>.BindComboBox( this.cbCyclePeriod, CalendarDefinition.GetCyclePeriodName );
			if ( !Environment.MachineName.Equals( "WLDELL" ) )
				this.tabControl1.TabPages.Remove( this.tpCyclicEvent );
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
					this.tbShortName.Text = this.CalendarItem.ShortName;
					this.tbDescription.Text = this.CalendarItem.Description;
					this.tbUser.Text = this.CalendarItem.Owner == null ? string.Empty : this.CalendarItem.Owner.Name;
					this.cbWholeDay.Checked = this.CalendarItem.WholeDay;
					this.dtpStartDate.Value = this.CalendarItem.StartDate;
					this.dtpEndDate.Value = this.CalendarItem.EndDate;
					this.cbCyclePeriod.SelectedValue = this.CalendarItem.CyclePeriodType;
					this.cbMonday.Checked = ( this.CalendarItem.CyclePeriod & (int)DaysEnum.Monday ) > 0;
					this.cbTuesday.Checked = ( this.CalendarItem.CyclePeriod & (int)DaysEnum.Tuesday ) > 0;
					this.cbWednesday.Checked = ( this.CalendarItem.CyclePeriod & (int)DaysEnum.Wednesday ) > 0;
					this.cbThursday.Checked = ( this.CalendarItem.CyclePeriod & (int)DaysEnum.Thursday ) > 0;
					this.cbFriday.Checked = ( this.CalendarItem.CyclePeriod & (int)DaysEnum.Friday ) > 0;
					this.cbSaturday.Checked = ( this.CalendarItem.CyclePeriod & (int)DaysEnum.Saturday ) > 0;
					this.cbSunday.Checked = ( this.CalendarItem.CyclePeriod & (int)DaysEnum.Sunday ) > 0;
					this.cbInactive.Checked = this.CalendarItem.Inactive;
					base.DisplayItem();
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
			this.cbMonday.Enabled = this.cbTuesday.Enabled = this.cbWednesday.Enabled = this.cbThursday.Enabled = this.cbFriday.Enabled = this.cbSaturday.Enabled = this.cbSunday.Enabled = (CalendarCyclePeriodTypeEnum)this.cbCyclePeriod.SelectedValue != CalendarCyclePeriodTypeEnum.NonCyclic;
			this.dtpStartDate.Enabled = this.dtpEndDate.Enabled = ! this.CalendarItem.WholeDay;
			base.SetControls();
		}
		private void SetHandlers()
		{
			this.tbShortName.Leave += this.StoreValues;
			this.dtpStartDate.ValueChanged += this.StoreValuesAndDisplayItem;
			this.dtpEndDate.ValueChanged += this.StoreValuesAndDisplayItem;
			this.cbCyclePeriod.SelectedValueChanged += this.StoreValuesAndDisplayItem;
			this.cbWholeDay.CheckedChanged += this.StoreValuesAndDisplayItem;
		}
		private void UnsetHandlers()
		{
			this.tbShortName.Leave -= this.StoreValues;
			this.dtpStartDate.ValueChanged -= this.StoreValuesAndDisplayItem;
			this.dtpEndDate.ValueChanged -= this.StoreValuesAndDisplayItem;
			this.cbCyclePeriod.SelectedValueChanged -= this.StoreValuesAndDisplayItem;
			this.cbWholeDay.CheckedChanged -= this.StoreValuesAndDisplayItem;
		}
		#endregion

		#region Data methods
		public override void StoreValues()
		{
			if ( !this.Disposing )
			{
				this.CalendarItem.ShortName = this.tbShortName.Text;
				this.CalendarItem.Description = this.tbDescription.Text;
				this.CalendarItem.WholeDay = this.cbWholeDay.Checked;
				this.CalendarItem.StartDate = this.dtpStartDate.Value;
				this.CalendarItem.EndDate = this.dtpEndDate.Value;
				this.CalendarItem.CyclePeriodType = (CalendarCyclePeriodTypeEnum)this.cbCyclePeriod.SelectedValue;
				this.CalendarItem.CyclePeriod = ( this.cbMonday.Checked ? (int)DaysEnum.Monday : 0 ) 
					| ( this.cbTuesday.Checked ? (int)DaysEnum.Tuesday : 0 ) 
					| ( this.cbWednesday.Checked ? (int)DaysEnum.Wednesday : 0 ) 
					| ( this.cbThursday.Checked ? (int)DaysEnum.Thursday : 0 ) 
					| ( this.cbFriday.Checked ? (int)DaysEnum.Friday : 0 ) 
					| ( this.cbSaturday.Checked ? (int)DaysEnum.Saturday : 0 ) 
					| ( this.cbSunday.Checked ? (int)DaysEnum.Sunday : 0 );//this.GetCyclePeriod( false, this.cbMonday.Checked, this.cbTuesday.Checked, this.cbWednesday.Checked, this.cbThursday.Checked, this.cbFriday.Checked, this.cbSunday.Checked, this.cbSunday.Checked );
				this.CalendarItem.CycleStartDate = this.dtpCycleStartDate.Value;
				this.CalendarItem.CycleEndDate = this.dtpCycleEndDate.Value;
				this.CalendarItem.Inactive = this.cbInactive.Checked;
			}
			base.StoreValues();
		}
		public byte GetCyclePeriod( bool b1, bool b2, bool b3, bool b4, bool b5, bool b6, bool b7, bool b8)
		{

			return (byte)( GetBit( b1) <<8 | GetBit( b2) << 7 | GetBit( b3) << 6 | GetBit( b4) << 5 | GetBit( b5) << 4 | GetBit( b6) << 3 | GetBit( b7) << 2 | GetBit( b8) << 1 );
			//byte nOne = 1;
			//return nOne << 6;
		}
		private static byte GetBit( bool lBit )
		{
			return lBit ? (byte)1 : (byte)0;
		}
		#endregion

		#region Events
		private void UserHandler( object sender, System.EventArgs e )
		{
			try
			{
				if ( sender.Equals( this.tbUser ) )
					this.CalendarItem.OwnerUserName = this.tbUser.Text;
				else if ( sender.Equals( this.btnUserLookup ) )
				{
					User oUser = wLookup<User>.Lookup( User.DivisionAllLookupInfo );
					if ( oUser != null )
					{
						this.CalendarItem.Owner = oUser;
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
		public CalendarItem CalendarItem
		{
			get { return this.ListItem; }
			set { this.ListItem = value; }
		}
		#endregion
	}
}
