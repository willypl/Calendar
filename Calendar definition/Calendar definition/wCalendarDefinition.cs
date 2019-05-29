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

namespace Calendar
{
	public partial class wCalendarDefinition :wCalendarDefinitionGeneric
	{
		#region Declarations
		private ModuleEnum oModule;
		#endregion

		#region Constructors
		public wCalendarDefinition()
		{
			InitializeComponent();
			this.InitializeControls();
		}
		public wCalendarDefinition( CalendarDefinition oCalendarDefinition) : this()
		{
			this.CalendarDefinition = oCalendarDefinition;
		}
		public wCalendarDefinition( object[] oModules )
		{
			this.oModule = (ModuleEnum)oModules[0];
			InitializeComponent();
			this.InitializeControls();
		}
		#endregion

		#region Initialize methods
		private new void InitializeControls()
		{
			ComboSource csCalendarEvents = new ComboSource();
			foreach ( Type oType in RuntimeManager.GetSubtypesOf( typeof( ICalendarEvent ) ) )
				csCalendarEvents.Add( ListTable.GetListClassTitle( oType), oType.GUID.ToString() );
			ComboSource.BindComboBox( this.cbRelatedType, csCalendarEvents, true );
			this.oItemsToolbar.InitializeStandardContextMenuListItems( this.ItemAdd, this.ItemOpen, this.ItemDelete );
			this.InitializeAuthorizationsListView();
			this.InitializeSubgroupListView();
			this.SetHandlers();
		}
		private void InitializeAuthorizationsListView()
		{
			this.lvAccess.Tag = typeof( Authorization );
			this.lvAccess.InitializeStandardContextMenuListItems( this.ItemAdd, this.ItemOpen, this.ItemDelete );
			this.lvAccess.Columns.Add( "Uzytkownik", this.lvAccess.Width- 4 );
		}
		private void InitializeSubgroupListView()
		{
			this.lvSubgroups.Tag = typeof( CalendarDefinitionSubgroup );
			this.lvSubgroups.InitializeStandardContextMenuListItems( this.ItemAdd, null, this.ItemDelete );
			this.lvSubgroups.Columns.Add( "Nazwa", this.lvSubgroups.Width - 4 );
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
					this.tbShortName.Text = this.CalendarDefinition.ShortName;
					this.tbDesription.Text = this.CalendarDefinition.Description;
					this.tbOwner.Text = this.CalendarDefinition.Owner == null ? string.Empty : this.CalendarDefinition.Owner.Name;
					this.cbRelatedType.SelectedValue = this.CalendarDefinition.RelatedType == null ? string.Empty : this.CalendarDefinition.RelatedType.GUID.ToString();
					this.lblColor.BackColor = this.CalendarDefinition.DisplayColor;
					this.RefillUsersList();

					base.DisplayItem();
				}
			}
			catch ( Exception e )
			{
				ErrorBox.Show( e, CalendarDefinition.Title );
			}
			finally
			{
				this.SetHandlers();
			}
		}
		private void RefillUsersList()
		{
			try
			{
				this.lvAccess.SuspendLayout();
				this.lvAccess.Items.Clear();
				foreach ( Authorization oAuthorization in this.CalendarDefinition.Authorizations )
				{
					if ( !oAuthorization.Deleted )
					{
						if ( oAuthorization.User == null )
						{
							oAuthorization.Delete();
							continue;
						}
						ListViewItem lvUser = new ListViewItem( oAuthorization.User.Name );
						lvUser.Tag = oAuthorization.ID;
						this.lvAccess.Items.Add( lvUser );
					}
				}
			}
			catch ( Exception e )
			{
				ErrorBox.Show( e, CalendarDefinition.Title );
			}
			finally
			{
				this.lvAccess.ResumeLayout();
			}
		}
		public override void SetControls()
		{
			this.btnOwnerLookup.Enabled = ListTable.CompareEqual( this.CalendarDefinition.Owner, Login.CurrentLogin.User) || this.CalendarDefinition.Owner == null;
			base.SetControls();
		}
		private void SetHandlers()
		{
			this.tbDesription.Leave += new System.EventHandler( this.StoreValues );
			this.cbRelatedType.SelectedIndexChanged += this.StoreValuesAndDisplayItem;
		}
		private void UnsetHandlers()
		{
			this.tbDesription.Leave -= new System.EventHandler( this.StoreValues );
			this.cbRelatedType.SelectedIndexChanged -= this.StoreValuesAndDisplayItem;
		}
		#endregion

		#region Data methods
		public override void StoreValues()
		{
			this.CalendarDefinition.ShortName = this.tbShortName.Text;
			this.CalendarDefinition.Description = this.tbDesription.Text;
			this.CalendarDefinition.RelatedType = this.cbRelatedType.SelectedValue == string.Empty ? null : RuntimeManager.GetTypeByClassID( (string)this.cbRelatedType.SelectedValue);
		}
		//private void ItemAdd()
		//{
		//    User oUser = wLookup<User>.Lookup( User.LookupInfoAll);
		//    if ( oUser != null )
		//    {
		//        this.CalendarDefinition.Save();
		//        Authorization oAuthorizatio = this.CalendarDefinition.CreateChildDataItem<Authorization>( this.CalendarDefinition.Authorizations, false );
		//        oAuthorizatio.User = oUser;
		//        oAuthorizatio.AuthorizationCode = AuthorizationCode.Insert | AuthorizationCode.Select | AuthorizationCode.Update | AuthorizationCode.Delete;
		//        oAuthorizatio.Save();
		//        this.RefillUsersList();
		//        //this.CalendarDefinition.Authorizations.Add( oAuthorizatio );
		//    }
		//}
		private void ItemDelete()
		{
			if ( this.lvAccess.SelectedItems.Count > 0 && wQuestion.Show( Messages.QuestionDelete, Authorization.Title ) )
			{
				foreach ( ListViewItem lvItem in this.lvAccess.SelectedItems )
					( (Authorization)lvItem.Tag ).Delete();
				this.RefillUsersList();
			}
		}
		#endregion

		#region Event methods
		private void CalendarHandler( object sender, EventArgs e )
		{
			try
			{
				if ( sender.Equals( this.btnCarLookup ) )
				{
					LookupInfo oLI = CalendarDefinition.LookupInfo;
					CalendarDefinition oCar = wLookup < CalendarDefinition>.Lookup( oLI );
					if ( oCar != null )
					{
						this.CalendarDefinition = oCar;
						this.DisplayItem();
					}
				}
				else if ( sender.Equals( this.tbShortName ) )
				{
					this.CalendarDefinition = GetByTextBoxLeave<CalendarDefinition>( this.CalendarDefinition, this.tbShortName, false );
					this.DisplayItem();
				}
			}
			catch ( Exception ex )
			{
				ErrorBox.Show( ex, CalendarDefinition.Title );
			}
		}
		private void tcCar_TabIndexChanged( object sender, EventArgs e )
		{
			this.StoreValues();
			this.DisplayItem();
		}
		private void ItemAdd( object sender, EventArgs e )
		{
			if ( this.oTabControl.SelectedTab.Equals( this.tpAccess ) )
				OpenForm<Authorization>( this.CalendarDefinition.CreateNewAuthorization());//this.ItemAdd();
			else
				RuntimeManager.OpenForm( CalendarDefinition.CreateNewSubgroup());
		}
		private void ItemOpen( object sender, EventArgs e )
		{
			base.ItemOpen( this.lvAccess );
		}
		private void ItemDelete( object sender, EventArgs e )
		{
			//this.ItemDelete();
			base.ItemDelete<Authorization>( this.lvAccess, this.CalendarDefinition.Authorizations);
		}
		private void ColorHandler( object sender, EventArgs e )
		{
			try
			{
				ColorDialog oForm = new ColorDialog();
				oForm.AllowFullOpen = true;
				oForm.ShowHelp = true;
				if ( oForm.ShowDialog() == DialogResult.OK )
				{
					if ( sender.Equals( this.btnColorLookup ) )
						this.CalendarDefinition.DisplayColor = oForm.Color;
					this.DisplayItem();
				}
			}
			catch ( Exception ex )
			{
				ErrorBox.Show( ex, CalendarDefinition.Title );
			}
		}
		private void OwnerHandler( object sender, EventArgs e )
		{
			User oUser = wLookup<User>.Lookup( User.LookupInfoAll );
			if ( oUser != null )
			{
				this.CalendarDefinition.Owner = oUser;
				this.DisplayItem();
			}
		}
		#endregion

		#region Properties
		public CalendarDefinition CalendarDefinition
		{
			get { return this.ListItem; }
			set { this.ListItem = value; }
		}
		#endregion
	}
}
