namespace Calendar
{
	partial class wCalendarDefinition
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose( bool disposing )
		{
			if ( disposing && ( components != null ) )
			{
				components.Dispose();
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.tpDeparture = new System.Windows.Forms.TabPage();
			this.tbShortName = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.btnCarLookup = new System.Windows.Forms.Button();
			this.lblIdentifier = new System.Windows.Forms.Label();
			this.tbDesription = new System.Windows.Forms.TextBox();
			this.tpDistance = new System.Windows.Forms.TabPage();
			this.lvDistance = new Venus.WListView();
			this.label7 = new System.Windows.Forms.Label();
			this.cbRelatedType = new System.Windows.Forms.ComboBox();
			this.label3 = new System.Windows.Forms.Label();
			this.oTabControl = new System.Windows.Forms.TabControl();
			this.tpAccess = new System.Windows.Forms.TabPage();
			this.lvAccess = new Venus.WListView();
			this.tpSubgroups = new System.Windows.Forms.TabPage();
			this.lvSubgroups = new Venus.WListView();
			this.oItemsToolbar = new Venus.StandardItemTool();
			this.label2 = new System.Windows.Forms.Label();
			this.tbOwner = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.btnColorLookup = new System.Windows.Forms.Button();
			this.lblColor = new System.Windows.Forms.Label();
			this.btnOwnerLookup = new System.Windows.Forms.Button();
			this.oMainPanel.SuspendLayout();
			( (System.ComponentModel.ISupportInitialize)( this.oBindingSource ) ).BeginInit();
			this.tpDistance.SuspendLayout();
			this.oTabControl.SuspendLayout();
			this.tpAccess.SuspendLayout();
			this.tpSubgroups.SuspendLayout();
			this.SuspendLayout();
			// 
			// oMainPanel
			// 
			this.oMainPanel.Controls.Add( this.btnOwnerLookup );
			this.oMainPanel.Controls.Add( this.lblColor );
			this.oMainPanel.Controls.Add( this.label4 );
			this.oMainPanel.Controls.Add( this.btnColorLookup );
			this.oMainPanel.Controls.Add( this.label2 );
			this.oMainPanel.Controls.Add( this.tbOwner );
			this.oMainPanel.Controls.Add( this.lblIdentifier );
			this.oMainPanel.Controls.Add( this.tbDesription );
			this.oMainPanel.Controls.Add( this.cbRelatedType );
			this.oMainPanel.Controls.Add( this.btnCarLookup );
			this.oMainPanel.Controls.Add( this.tbShortName );
			this.oMainPanel.Controls.Add( this.label1 );
			this.oMainPanel.Controls.Add( this.label3 );
			this.oMainPanel.Dock = System.Windows.Forms.DockStyle.Top;
			this.oMainPanel.Size = new System.Drawing.Size( 592, 231 );
			this.oMainPanel.TabIndex = 0;
			// 
			// tpDeparture
			// 
			this.tpDeparture.Location = new System.Drawing.Point( 4, 22 );
			this.tpDeparture.Name = "tpDeparture";
			this.tpDeparture.Padding = new System.Windows.Forms.Padding( 3 );
			this.tpDeparture.Size = new System.Drawing.Size( 498, 212 );
			this.tpDeparture.TabIndex = 1;
			this.tpDeparture.Text = "Przebieg";
			this.tpDeparture.UseVisualStyleBackColor = true;
			// 
			// tbShortName
			// 
			this.tbShortName.Location = new System.Drawing.Point( 167, 45 );
			this.tbShortName.MaxLength = 30;
			this.tbShortName.Name = "tbShortName";
			this.tbShortName.Size = new System.Drawing.Size( 197, 20 );
			this.tbShortName.TabIndex = 0;
			// 
			// label1
			// 
			this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.label1.Location = new System.Drawing.Point( 46, 72 );
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size( 121, 20 );
			this.label1.TabIndex = 4;
			this.label1.Text = "Opis:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// btnCarLookup
			// 
			this.btnCarLookup.Location = new System.Drawing.Point( 363, 44 );
			this.btnCarLookup.Name = "btnCarLookup";
			this.btnCarLookup.Size = new System.Drawing.Size( 24, 23 );
			this.btnCarLookup.TabIndex = 1;
			this.btnCarLookup.Text = "...";
			// 
			// lblIdentifier
			// 
			this.lblIdentifier.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lblIdentifier.Location = new System.Drawing.Point( 46, 45 );
			this.lblIdentifier.Name = "lblIdentifier";
			this.lblIdentifier.Size = new System.Drawing.Size( 121, 21 );
			this.lblIdentifier.TabIndex = 2;
			this.lblIdentifier.Text = "Identyfikator:";
			this.lblIdentifier.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// tbDesription
			// 
			this.tbDesription.Location = new System.Drawing.Point( 167, 72 );
			this.tbDesription.MaxLength = 255;
			this.tbDesription.Multiline = true;
			this.tbDesription.Name = "tbDesription";
			this.tbDesription.Size = new System.Drawing.Size( 375, 42 );
			this.tbDesription.TabIndex = 3;
			// 
			// tpDistance
			// 
			this.tpDistance.Controls.Add( this.lvDistance );
			this.tpDistance.Location = new System.Drawing.Point( 4, 22 );
			this.tpDistance.Name = "tpDistance";
			this.tpDistance.Padding = new System.Windows.Forms.Padding( 3 );
			this.tpDistance.Size = new System.Drawing.Size( 498, 212 );
			this.tpDistance.TabIndex = 1;
			this.tpDistance.Text = "Przebieg";
			this.tpDistance.UseVisualStyleBackColor = true;
			// 
			// lvDistance
			// 
			this.lvDistance.AllowColumnReorder = true;
			this.lvDistance.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lvDistance.FullRowSelect = true;
			this.lvDistance.HorizontalScrollPos = 0;
			this.lvDistance.Location = new System.Drawing.Point( 3, 3 );
			this.lvDistance.Name = "lvDistance";
			this.lvDistance.SelectRows = true;
			this.lvDistance.Size = new System.Drawing.Size( 492, 206 );
			this.lvDistance.TabIndex = 0;
			this.lvDistance.UseCompatibleStateImageBehavior = false;
			this.lvDistance.View = System.Windows.Forms.View.Details;
			// 
			// label7
			// 
			this.label7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.label7.Location = new System.Drawing.Point( 35, 28 );
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size( 88, 20 );
			this.label7.TabIndex = 2;
			this.label7.Text = "Identyfikator:";
			this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// cbRelatedType
			// 
			this.cbRelatedType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbRelatedType.FormattingEnabled = true;
			this.cbRelatedType.Location = new System.Drawing.Point( 167, 146 );
			this.cbRelatedType.Name = "cbRelatedType";
			this.cbRelatedType.Size = new System.Drawing.Size( 375, 21 );
			this.cbRelatedType.TabIndex = 8;
			// 
			// label3
			// 
			this.label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.label3.Location = new System.Drawing.Point( 46, 146 );
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size( 121, 21 );
			this.label3.TabIndex = 9;
			this.label3.Text = "Powi¹zany obiekt:";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// oTabControl
			// 
			this.oTabControl.Controls.Add( this.tpAccess );
			this.oTabControl.Controls.Add( this.tpSubgroups );
			this.oTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
			this.oTabControl.Location = new System.Drawing.Point( 0, 256 );
			this.oTabControl.Name = "oTabControl";
			this.oTabControl.SelectedIndex = 0;
			this.oTabControl.Size = new System.Drawing.Size( 592, 196 );
			this.oTabControl.TabIndex = 1;
			// 
			// tpAccess
			// 
			this.tpAccess.Controls.Add( this.lvAccess );
			this.tpAccess.Location = new System.Drawing.Point( 4, 22 );
			this.tpAccess.Name = "tpAccess";
			this.tpAccess.Padding = new System.Windows.Forms.Padding( 3 );
			this.tpAccess.Size = new System.Drawing.Size( 584, 170 );
			this.tpAccess.TabIndex = 0;
			this.tpAccess.Text = "Udostêpnianie";
			this.tpAccess.UseVisualStyleBackColor = true;
			// 
			// lvAccess
			// 
			this.lvAccess.AllowColumnReorder = true;
			this.lvAccess.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lvAccess.FullRowSelect = true;
			this.lvAccess.GridLines = true;
			this.lvAccess.HorizontalScrollPos = 0;
			this.lvAccess.Location = new System.Drawing.Point( 3, 3 );
			this.lvAccess.Name = "lvAccess";
			this.lvAccess.SelectRows = true;
			this.lvAccess.Size = new System.Drawing.Size( 578, 164 );
			this.lvAccess.TabIndex = 0;
			this.lvAccess.UseCompatibleStateImageBehavior = false;
			this.lvAccess.View = System.Windows.Forms.View.Details;
			// 
			// tpSubgroups
			// 
			this.tpSubgroups.Controls.Add( this.lvSubgroups );
			this.tpSubgroups.Location = new System.Drawing.Point( 4, 22 );
			this.tpSubgroups.Name = "tpSubgroups";
			this.tpSubgroups.Size = new System.Drawing.Size( 584, 170 );
			this.tpSubgroups.TabIndex = 1;
			this.tpSubgroups.Text = "Podgrupy";
			this.tpSubgroups.UseVisualStyleBackColor = true;
			// 
			// lvSubgroups
			// 
			this.lvSubgroups.AllowColumnReorder = true;
			this.lvSubgroups.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lvSubgroups.FullRowSelect = true;
			this.lvSubgroups.GridLines = true;
			this.lvSubgroups.HorizontalScrollPos = 0;
			this.lvSubgroups.Location = new System.Drawing.Point( 0, 0 );
			this.lvSubgroups.Name = "lvSubgroups";
			this.lvSubgroups.SelectRows = true;
			this.lvSubgroups.Size = new System.Drawing.Size( 584, 170 );
			this.lvSubgroups.TabIndex = 1;
			this.lvSubgroups.UseCompatibleStateImageBehavior = false;
			this.lvSubgroups.View = System.Windows.Forms.View.Details;
			// 
			// oItemsToolbar
			// 
			this.oItemsToolbar.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.oItemsToolbar.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.oItemsToolbar.Location = new System.Drawing.Point( 0, 452 );
			this.oItemsToolbar.Name = "oItemsToolbar";
			this.oItemsToolbar.Size = new System.Drawing.Size( 592, 25 );
			this.oItemsToolbar.TabIndex = 2;
			this.oItemsToolbar.Text = "standardItemTool1";
			// 
			// label2
			// 
			this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.label2.Location = new System.Drawing.Point( 46, 120 );
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size( 121, 21 );
			this.label2.TabIndex = 7;
			this.label2.Text = "W³aœciciel:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// tbOwner
			// 
			this.tbOwner.Location = new System.Drawing.Point( 167, 120 );
			this.tbOwner.MaxLength = 30;
			this.tbOwner.Name = "tbOwner";
			this.tbOwner.ReadOnly = true;
			this.tbOwner.Size = new System.Drawing.Size( 351, 20 );
			this.tbOwner.TabIndex = 5;
			// 
			// label4
			// 
			this.label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.label4.Location = new System.Drawing.Point( 46, 173 );
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size( 121, 21 );
			this.label4.TabIndex = 12;
			this.label4.Text = "Kolor wyœwietlany:";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// btnColorLookup
			// 
			this.btnColorLookup.Location = new System.Drawing.Point( 240, 172 );
			this.btnColorLookup.Name = "btnColorLookup";
			this.btnColorLookup.Size = new System.Drawing.Size( 24, 23 );
			this.btnColorLookup.TabIndex = 11;
			this.btnColorLookup.Text = "...";
			this.btnColorLookup.Click += new System.EventHandler( this.ColorHandler );
			// 
			// lblColor
			// 
			this.lblColor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lblColor.Location = new System.Drawing.Point( 167, 173 );
			this.lblColor.Name = "lblColor";
			this.lblColor.Size = new System.Drawing.Size( 74, 21 );
			this.lblColor.TabIndex = 10;
			this.lblColor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// btnOwnerLookup
			// 
			this.btnOwnerLookup.Location = new System.Drawing.Point( 519, 118 );
			this.btnOwnerLookup.Name = "btnOwnerLookup";
			this.btnOwnerLookup.Size = new System.Drawing.Size( 24, 23 );
			this.btnOwnerLookup.TabIndex = 6;
			this.btnOwnerLookup.Text = "...";
			this.btnOwnerLookup.Click += new System.EventHandler( this.OwnerHandler );
			// 
			// wCalendarDefinition
			// 
			this.AddNewButtonVisible = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size( 592, 502 );
			this.Controls.Add( this.oTabControl );
			this.Controls.Add( this.oItemsToolbar );
			this.DeleteButtonVisible = true;
			this.Location = new System.Drawing.Point( 0, 0 );
			this.Name = "wCalendarDefinition";
			this.RecordMovementControlVisible = true;
			this.RefreshButtonVisible = true;
			this.Text = "Definicja kalendarza";
			this.Title = "Definicja kalendarza";
			this.ToolStripVisible = true;
			this.Controls.SetChildIndex( this.oItemsToolbar, 0 );
			this.Controls.SetChildIndex( this.oMainPanel, 0 );
			this.Controls.SetChildIndex( this.oTabControl, 0 );
			this.oMainPanel.ResumeLayout( false );
			this.oMainPanel.PerformLayout();
			( (System.ComponentModel.ISupportInitialize)( this.oBindingSource ) ).EndInit();
			this.tpDistance.ResumeLayout( false );
			this.oTabControl.ResumeLayout( false );
			this.tpAccess.ResumeLayout( false );
			this.tpSubgroups.ResumeLayout( false );
			this.ResumeLayout( false );
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TabPage tpDeparture;
		private System.Windows.Forms.TextBox tbShortName;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btnCarLookup;
		private System.Windows.Forms.Label lblIdentifier;
		private System.Windows.Forms.TextBox tbDesription;
		private Venus.WListView lvDistance;
		private System.Windows.Forms.TabPage tpDistance;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.ComboBox cbRelatedType;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TabControl oTabControl;
		private System.Windows.Forms.TabPage tpAccess;
		private Venus.StandardItemTool oItemsToolbar;
		private Venus.WListView lvAccess;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox tbOwner;
		private System.Windows.Forms.Label lblColor;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Button btnColorLookup;
		private System.Windows.Forms.TabPage tpSubgroups;
		private Venus.WListView lvSubgroups;
		private System.Windows.Forms.Button btnOwnerLookup;
	}
}