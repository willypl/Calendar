namespace Calendar
{
	partial class wVacation
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
			this.lblIdentifier = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.tbShortName = new System.Windows.Forms.TextBox();
			this.tbDescription = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
			this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
			this.label3 = new System.Windows.Forms.Label();
			this.btnEmployeeLookup = new System.Windows.Forms.Button();
			this.tbEmployee = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.tbCreateUser = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.oMainPanel.SuspendLayout();
			( (System.ComponentModel.ISupportInitialize)( this.oBindingSource ) ).BeginInit();
			this.SuspendLayout();
			// 
			// oMainPanel
			// 
			this.oMainPanel.Controls.Add( this.tbCreateUser );
			this.oMainPanel.Controls.Add( this.label5 );
			this.oMainPanel.Controls.Add( this.btnEmployeeLookup );
			this.oMainPanel.Controls.Add( this.tbEmployee );
			this.oMainPanel.Controls.Add( this.label4 );
			this.oMainPanel.Controls.Add( this.tbDescription );
			this.oMainPanel.Controls.Add( this.dtpEndDate );
			this.oMainPanel.Controls.Add( this.tbShortName );
			this.oMainPanel.Controls.Add( this.label2 );
			this.oMainPanel.Controls.Add( this.lblIdentifier );
			this.oMainPanel.Controls.Add( this.label3 );
			this.oMainPanel.Controls.Add( this.label1 );
			this.oMainPanel.Controls.Add( this.dtpStartDate );
			this.oMainPanel.Size = new System.Drawing.Size( 535, 232 );
			this.oMainPanel.TabIndex = 0;
			// 
			// lblIdentifier
			// 
			this.lblIdentifier.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lblIdentifier.Location = new System.Drawing.Point( 66, 73 );
			this.lblIdentifier.Name = "lblIdentifier";
			this.lblIdentifier.Size = new System.Drawing.Size( 129, 21 );
			this.lblIdentifier.TabIndex = 4;
			this.lblIdentifier.Text = "Opis:";
			this.lblIdentifier.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label1
			// 
			this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.label1.Location = new System.Drawing.Point( 66, 147 );
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size( 129, 20 );
			this.label1.TabIndex = 10;
			this.label1.Text = "Informacje dodatkowe:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// tbShortName
			// 
			this.tbShortName.Location = new System.Drawing.Point( 195, 74 );
			this.tbShortName.MaxLength = 30;
			this.tbShortName.Name = "tbShortName";
			this.tbShortName.Size = new System.Drawing.Size( 267, 20 );
			this.tbShortName.TabIndex = 3;
			// 
			// tbDescription
			// 
			this.tbDescription.Location = new System.Drawing.Point( 195, 147 );
			this.tbDescription.MaxLength = 60;
			this.tbDescription.Multiline = true;
			this.tbDescription.Name = "tbDescription";
			this.tbDescription.Size = new System.Drawing.Size( 267, 46 );
			this.tbDescription.TabIndex = 9;
			// 
			// label2
			// 
			this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.label2.Location = new System.Drawing.Point( 66, 98 );
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size( 129, 20 );
			this.label2.TabIndex = 6;
			this.label2.Text = "Początek:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// dtpStartDate
			// 
			this.dtpStartDate.CustomFormat = "dd.MM.yyyy HH.mm";
			this.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dtpStartDate.Location = new System.Drawing.Point( 195, 98 );
			this.dtpStartDate.Name = "dtpStartDate";
			this.dtpStartDate.Size = new System.Drawing.Size( 130, 20 );
			this.dtpStartDate.TabIndex = 5;
			// 
			// dtpEndDate
			// 
			this.dtpEndDate.CustomFormat = "dd.MM.yyyy HH.mm";
			this.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dtpEndDate.Location = new System.Drawing.Point( 195, 124 );
			this.dtpEndDate.Name = "dtpEndDate";
			this.dtpEndDate.Size = new System.Drawing.Size( 130, 20 );
			this.dtpEndDate.TabIndex = 7;
			// 
			// label3
			// 
			this.label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.label3.Location = new System.Drawing.Point( 66, 124 );
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size( 129, 20 );
			this.label3.TabIndex = 8;
			this.label3.Text = "Koniec:";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// btnEmployeeLookup
			// 
			this.btnEmployeeLookup.Location = new System.Drawing.Point( 438, 45 );
			this.btnEmployeeLookup.Name = "btnEmployeeLookup";
			this.btnEmployeeLookup.Size = new System.Drawing.Size( 24, 23 );
			this.btnEmployeeLookup.TabIndex = 1;
			this.btnEmployeeLookup.Text = "...";
			this.btnEmployeeLookup.UseVisualStyleBackColor = true;
			this.btnEmployeeLookup.Click += new System.EventHandler( this.UserHandler );
			// 
			// tbEmployee
			// 
			this.tbEmployee.Location = new System.Drawing.Point( 195, 46 );
			this.tbEmployee.MaxLength = 30;
			this.tbEmployee.Name = "tbEmployee";
			this.tbEmployee.Size = new System.Drawing.Size( 243, 20 );
			this.tbEmployee.TabIndex = 0;
			this.tbEmployee.Leave += new System.EventHandler( this.UserHandler );
			// 
			// label4
			// 
			this.label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.label4.Location = new System.Drawing.Point( 66, 45 );
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size( 129, 21 );
			this.label4.TabIndex = 2;
			this.label4.Text = "Pracownik:";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// tbCreateUser
			// 
			this.tbCreateUser.Location = new System.Drawing.Point( 195, 199 );
			this.tbCreateUser.MaxLength = 30;
			this.tbCreateUser.Name = "tbCreateUser";
			this.tbCreateUser.ReadOnly = true;
			this.tbCreateUser.Size = new System.Drawing.Size( 267, 20 );
			this.tbCreateUser.TabIndex = 11;
			// 
			// label5
			// 
			this.label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.label5.Location = new System.Drawing.Point( 66, 198 );
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size( 129, 21 );
			this.label5.TabIndex = 12;
			this.label5.Text = "Wpisał:";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// wVacation
			// 
			this.AddNewButtonVisible = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size( 535, 282 );
			this.DeleteButtonVisible = true;
			this.Location = new System.Drawing.Point( 0, 0 );
			this.Name = "wVacation";
			this.RecordMovementControlVisible = true;
			this.RefreshButtonVisible = true;
			this.Text = "Pozycja kalendarza";
			this.Title = "Pozycja kalendarza";
			this.ToolStripVisible = true;
			this.oMainPanel.ResumeLayout( false );
			this.oMainPanel.PerformLayout();
			( (System.ComponentModel.ISupportInitialize)( this.oBindingSource ) ).EndInit();
			this.ResumeLayout( false );
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label lblIdentifier;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.DateTimePicker dtpEndDate;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.DateTimePicker dtpStartDate;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox tbDescription;
		private System.Windows.Forms.TextBox tbShortName;
		private System.Windows.Forms.Button btnEmployeeLookup;
		private System.Windows.Forms.TextBox tbEmployee;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox tbCreateUser;
		private System.Windows.Forms.Label label5;
	}
}