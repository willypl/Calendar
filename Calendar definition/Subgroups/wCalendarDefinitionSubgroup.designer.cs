namespace Calendar
{
	partial class wCalendarDefinitionSubgroup
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
			this.tpDistance = new System.Windows.Forms.TabPage();
			this.lvDistance = new Venus.WListView();
			this.label7 = new System.Windows.Forms.Label();
			this.cbProperty = new System.Windows.Forms.ComboBox();
			this.label3 = new System.Windows.Forms.Label();
			this.oMainPanel.SuspendLayout();
			( (System.ComponentModel.ISupportInitialize)( this.oBindingSource ) ).BeginInit();
			this.tpDistance.SuspendLayout();
			this.SuspendLayout();
			// 
			// oMainPanel
			// 
			this.oMainPanel.Controls.Add( this.cbProperty );
			this.oMainPanel.Controls.Add( this.label3 );
			this.oMainPanel.Size = new System.Drawing.Size( 592, 102 );
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
			// cbProperty
			// 
			this.cbProperty.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbProperty.FormattingEnabled = true;
			this.cbProperty.Location = new System.Drawing.Point( 165, 45 );
			this.cbProperty.Name = "cbProperty";
			this.cbProperty.Size = new System.Drawing.Size( 375, 21 );
			this.cbProperty.TabIndex = 7;
			// 
			// label3
			// 
			this.label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.label3.Location = new System.Drawing.Point( 44, 45 );
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size( 121, 21 );
			this.label3.TabIndex = 8;
			this.label3.Text = "Cecha:";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// wCalendarDefinitionSubgroup
			// 
			this.AddNewButtonVisible = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size( 592, 152 );
			this.DeleteButtonVisible = true;
			this.Location = new System.Drawing.Point( 0, 0 );
			this.Name = "wCalendarDefinitionSubgroup";
			this.RecordMovementControlVisible = true;
			this.RefreshButtonVisible = true;
			this.ToolStripVisible = true;
			this.oMainPanel.ResumeLayout( false );
			( (System.ComponentModel.ISupportInitialize)( this.oBindingSource ) ).EndInit();
			this.tpDistance.ResumeLayout( false );
			this.ResumeLayout( false );
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TabPage tpDeparture;
		private Venus.WListView lvDistance;
		private System.Windows.Forms.TabPage tpDistance;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.ComboBox cbProperty;
		private System.Windows.Forms.Label label3;
	}
}