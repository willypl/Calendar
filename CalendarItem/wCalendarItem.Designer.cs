namespace Calendar
{
	partial class wCalendarItem
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
			this.cbWholeDay = new System.Windows.Forms.CheckBox();
			this.cbCyclePeriod = new System.Windows.Forms.ComboBox();
			this.label4 = new System.Windows.Forms.Label();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tpMainData = new System.Windows.Forms.TabPage();
			this.label7 = new System.Windows.Forms.Label();
			this.cbReminder = new System.Windows.Forms.ComboBox();
			this.tpCyclicEvent = new System.Windows.Forms.TabPage();
			this.cbFriday = new System.Windows.Forms.CheckBox();
			this.cbThursday = new System.Windows.Forms.CheckBox();
			this.cbWednesday = new System.Windows.Forms.CheckBox();
			this.cbSaturday = new System.Windows.Forms.CheckBox();
			this.cbSunday = new System.Windows.Forms.CheckBox();
			this.cbTuesday = new System.Windows.Forms.CheckBox();
			this.cbMonday = new System.Windows.Forms.CheckBox();
			this.dtpCycleStartDate = new Venus.Controls.WLDateTimePicker();
			this.label6 = new System.Windows.Forms.Label();
			this.dtpCycleEndDate = new Venus.Controls.WLDateTimePicker();
			this.label5 = new System.Windows.Forms.Label();
			this.btnUserLookup = new System.Windows.Forms.Button();
			this.tbUser = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.cbInactive = new System.Windows.Forms.CheckBox();
			this.oMainPanel.SuspendLayout();
			( (System.ComponentModel.ISupportInitialize)( this.oBindingSource ) ).BeginInit();
			this.tabControl1.SuspendLayout();
			this.tpMainData.SuspendLayout();
			this.tpCyclicEvent.SuspendLayout();
			this.SuspendLayout();
			// 
			// oMainPanel
			// 
			this.oMainPanel.Controls.Add( this.btnUserLookup );
			this.oMainPanel.Controls.Add( this.tbUser );
			this.oMainPanel.Controls.Add( this.label8 );
			this.oMainPanel.Controls.Add( this.tbDescription );
			this.oMainPanel.Controls.Add( this.tbShortName );
			this.oMainPanel.Controls.Add( this.lblIdentifier );
			this.oMainPanel.Controls.Add( this.label1 );
			this.oMainPanel.Dock = System.Windows.Forms.DockStyle.Top;
			this.oMainPanel.Size = new System.Drawing.Size( 590, 175 );
			this.oMainPanel.TabIndex = 0;
			// 
			// lblIdentifier
			// 
			this.lblIdentifier.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lblIdentifier.Location = new System.Drawing.Point( 74, 30 );
			this.lblIdentifier.Name = "lblIdentifier";
			this.lblIdentifier.Size = new System.Drawing.Size( 91, 21 );
			this.lblIdentifier.TabIndex = 1;
			this.lblIdentifier.Text = "Identyfikator:";
			this.lblIdentifier.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label1
			// 
			this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.label1.Location = new System.Drawing.Point( 74, 85 );
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size( 91, 20 );
			this.label1.TabIndex = 6;
			this.label1.Text = "Opis:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// tbShortName
			// 
			this.tbShortName.Location = new System.Drawing.Point( 165, 31 );
			this.tbShortName.MaxLength = 30;
			this.tbShortName.Name = "tbShortName";
			this.tbShortName.Size = new System.Drawing.Size( 267, 20 );
			this.tbShortName.TabIndex = 0;
			// 
			// tbDescription
			// 
			this.tbDescription.Location = new System.Drawing.Point( 165, 85 );
			this.tbDescription.MaxLength = 512;
			this.tbDescription.Multiline = true;
			this.tbDescription.Name = "tbDescription";
			this.tbDescription.Size = new System.Drawing.Size( 383, 72 );
			this.tbDescription.TabIndex = 5;
			// 
			// label2
			// 
			this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.label2.Location = new System.Drawing.Point( 70, 49 );
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size( 121, 20 );
			this.label2.TabIndex = 2;
			this.label2.Text = "Początek:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// dtpStartDate
			// 
			this.dtpStartDate.CustomFormat = "dd.MM.yyyy HH.mm";
			this.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dtpStartDate.Location = new System.Drawing.Point( 191, 49 );
			this.dtpStartDate.Name = "dtpStartDate";
			this.dtpStartDate.Size = new System.Drawing.Size( 130, 20 );
			this.dtpStartDate.TabIndex = 1;
			// 
			// dtpEndDate
			// 
			this.dtpEndDate.CustomFormat = "dd.MM.yyyy HH.mm";
			this.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dtpEndDate.Location = new System.Drawing.Point( 191, 75 );
			this.dtpEndDate.Name = "dtpEndDate";
			this.dtpEndDate.Size = new System.Drawing.Size( 130, 20 );
			this.dtpEndDate.TabIndex = 3;
			// 
			// label3
			// 
			this.label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.label3.Location = new System.Drawing.Point( 70, 75 );
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size( 121, 20 );
			this.label3.TabIndex = 4;
			this.label3.Text = "Koniec:";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// cbWholeDay
			// 
			this.cbWholeDay.AutoSize = true;
			this.cbWholeDay.Location = new System.Drawing.Point( 70, 29 );
			this.cbWholeDay.Name = "cbWholeDay";
			this.cbWholeDay.Size = new System.Drawing.Size( 76, 17 );
			this.cbWholeDay.TabIndex = 0;
			this.cbWholeDay.Text = "Cały dzień";
			this.cbWholeDay.UseVisualStyleBackColor = true;
			// 
			// cbCyclePeriod
			// 
			this.cbCyclePeriod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbCyclePeriod.FormattingEnabled = true;
			this.cbCyclePeriod.Location = new System.Drawing.Point( 191, 39 );
			this.cbCyclePeriod.Name = "cbCyclePeriod";
			this.cbCyclePeriod.Size = new System.Drawing.Size( 200, 21 );
			this.cbCyclePeriod.TabIndex = 0;
			// 
			// label4
			// 
			this.label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.label4.Location = new System.Drawing.Point( 62, 39 );
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size( 129, 21 );
			this.label4.TabIndex = 1;
			this.label4.Text = "Powtarzaj co:";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add( this.tpMainData );
			this.tabControl1.Controls.Add( this.tpCyclicEvent );
			this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControl1.Location = new System.Drawing.Point( 0, 200 );
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size( 590, 188 );
			this.tabControl1.TabIndex = 1;
			// 
			// tpMainData
			// 
			this.tpMainData.Controls.Add( this.cbInactive );
			this.tpMainData.Controls.Add( this.label7 );
			this.tpMainData.Controls.Add( this.cbReminder );
			this.tpMainData.Controls.Add( this.cbWholeDay );
			this.tpMainData.Controls.Add( this.dtpEndDate );
			this.tpMainData.Controls.Add( this.label2 );
			this.tpMainData.Controls.Add( this.label3 );
			this.tpMainData.Controls.Add( this.dtpStartDate );
			this.tpMainData.Location = new System.Drawing.Point( 4, 22 );
			this.tpMainData.Name = "tpMainData";
			this.tpMainData.Padding = new System.Windows.Forms.Padding( 3 );
			this.tpMainData.Size = new System.Drawing.Size( 582, 162 );
			this.tpMainData.TabIndex = 0;
			this.tpMainData.Text = "Dane glówne";
			this.tpMainData.UseVisualStyleBackColor = true;
			// 
			// label7
			// 
			this.label7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.label7.Location = new System.Drawing.Point( 70, 101 );
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size( 121, 21 );
			this.label7.TabIndex = 6;
			this.label7.Text = "Przypomnienie:";
			this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// cbReminder
			// 
			this.cbReminder.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbReminder.FormattingEnabled = true;
			this.cbReminder.Location = new System.Drawing.Point( 191, 101 );
			this.cbReminder.Name = "cbReminder";
			this.cbReminder.Size = new System.Drawing.Size( 130, 21 );
			this.cbReminder.TabIndex = 5;
			// 
			// tpCyclicEvent
			// 
			this.tpCyclicEvent.Controls.Add( this.cbFriday );
			this.tpCyclicEvent.Controls.Add( this.cbThursday );
			this.tpCyclicEvent.Controls.Add( this.cbWednesday );
			this.tpCyclicEvent.Controls.Add( this.cbSaturday );
			this.tpCyclicEvent.Controls.Add( this.cbSunday );
			this.tpCyclicEvent.Controls.Add( this.cbTuesday );
			this.tpCyclicEvent.Controls.Add( this.cbMonday );
			this.tpCyclicEvent.Controls.Add( this.dtpCycleStartDate );
			this.tpCyclicEvent.Controls.Add( this.label6 );
			this.tpCyclicEvent.Controls.Add( this.dtpCycleEndDate );
			this.tpCyclicEvent.Controls.Add( this.label5 );
			this.tpCyclicEvent.Controls.Add( this.label4 );
			this.tpCyclicEvent.Controls.Add( this.cbCyclePeriod );
			this.tpCyclicEvent.Location = new System.Drawing.Point( 4, 22 );
			this.tpCyclicEvent.Name = "tpCyclicEvent";
			this.tpCyclicEvent.Padding = new System.Windows.Forms.Padding( 3 );
			this.tpCyclicEvent.Size = new System.Drawing.Size( 582, 162 );
			this.tpCyclicEvent.TabIndex = 1;
			this.tpCyclicEvent.Text = "Zdarzenie cykliczne";
			this.tpCyclicEvent.UseVisualStyleBackColor = true;
			// 
			// cbFriday
			// 
			this.cbFriday.AutoSize = true;
			this.cbFriday.Location = new System.Drawing.Point( 379, 73 );
			this.cbFriday.Name = "cbFriday";
			this.cbFriday.Size = new System.Drawing.Size( 36, 17 );
			this.cbFriday.TabIndex = 6;
			this.cbFriday.Text = "Pt";
			this.cbFriday.UseVisualStyleBackColor = true;
			// 
			// cbThursday
			// 
			this.cbThursday.AutoSize = true;
			this.cbThursday.Location = new System.Drawing.Point( 332, 73 );
			this.cbThursday.Name = "cbThursday";
			this.cbThursday.Size = new System.Drawing.Size( 38, 17 );
			this.cbThursday.TabIndex = 5;
			this.cbThursday.Text = "Cz";
			this.cbThursday.UseVisualStyleBackColor = true;
			// 
			// cbWednesday
			// 
			this.cbWednesday.AutoSize = true;
			this.cbWednesday.Location = new System.Drawing.Point( 285, 73 );
			this.cbWednesday.Name = "cbWednesday";
			this.cbWednesday.Size = new System.Drawing.Size( 36, 17 );
			this.cbWednesday.TabIndex = 4;
			this.cbWednesday.Text = "Śr";
			this.cbWednesday.UseVisualStyleBackColor = true;
			// 
			// cbSaturday
			// 
			this.cbSaturday.AutoSize = true;
			this.cbSaturday.Location = new System.Drawing.Point( 426, 73 );
			this.cbSaturday.Name = "cbSaturday";
			this.cbSaturday.Size = new System.Drawing.Size( 39, 17 );
			this.cbSaturday.TabIndex = 7;
			this.cbSaturday.Text = "So";
			this.cbSaturday.UseVisualStyleBackColor = true;
			// 
			// cbSunday
			// 
			this.cbSunday.AutoSize = true;
			this.cbSunday.Location = new System.Drawing.Point( 473, 73 );
			this.cbSunday.Name = "cbSunday";
			this.cbSunday.Size = new System.Drawing.Size( 40, 17 );
			this.cbSunday.TabIndex = 8;
			this.cbSunday.Text = "Nd";
			this.cbSunday.UseVisualStyleBackColor = true;
			// 
			// cbTuesday
			// 
			this.cbTuesday.AutoSize = true;
			this.cbTuesday.Location = new System.Drawing.Point( 238, 73 );
			this.cbTuesday.Name = "cbTuesday";
			this.cbTuesday.Size = new System.Drawing.Size( 40, 17 );
			this.cbTuesday.TabIndex = 3;
			this.cbTuesday.Text = "Wt";
			this.cbTuesday.UseVisualStyleBackColor = true;
			// 
			// cbMonday
			// 
			this.cbMonday.AutoSize = true;
			this.cbMonday.Location = new System.Drawing.Point( 191, 73 );
			this.cbMonday.Name = "cbMonday";
			this.cbMonday.Size = new System.Drawing.Size( 39, 17 );
			this.cbMonday.TabIndex = 2;
			this.cbMonday.Text = "Pn";
			this.cbMonday.UseVisualStyleBackColor = true;
			// 
			// dtpCycleStartDate
			// 
			this.dtpCycleStartDate.CustomFormat = "yyyy.MM.dd";
			this.dtpCycleStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dtpCycleStartDate.Location = new System.Drawing.Point( 191, 102 );
			this.dtpCycleStartDate.Name = "dtpCycleStartDate";
			this.dtpCycleStartDate.ShowCheckBox = true;
			this.dtpCycleStartDate.ShowWeekNumbers = false;
			this.dtpCycleStartDate.Size = new System.Drawing.Size( 111, 20 );
			this.dtpCycleStartDate.TabIndex = 9;
			this.dtpCycleStartDate.TimeVisible = false;
			this.dtpCycleStartDate.Value = new System.DateTime( 2012, 7, 9, 9, 3, 16, 233 );
			// 
			// label6
			// 
			this.label6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.label6.Location = new System.Drawing.Point( 62, 102 );
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size( 129, 22 );
			this.label6.TabIndex = 10;
			this.label6.Text = "Data początkowa:";
			this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// dtpCycleEndDate
			// 
			this.dtpCycleEndDate.CustomFormat = "yyyy.MM.dd";
			this.dtpCycleEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dtpCycleEndDate.Location = new System.Drawing.Point( 434, 101 );
			this.dtpCycleEndDate.Name = "dtpCycleEndDate";
			this.dtpCycleEndDate.ShowCheckBox = true;
			this.dtpCycleEndDate.ShowWeekNumbers = false;
			this.dtpCycleEndDate.Size = new System.Drawing.Size( 111, 20 );
			this.dtpCycleEndDate.TabIndex = 11;
			this.dtpCycleEndDate.TimeVisible = false;
			this.dtpCycleEndDate.Value = new System.DateTime( 2012, 7, 9, 9, 3, 16, 233 );
			// 
			// label5
			// 
			this.label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.label5.Location = new System.Drawing.Point( 305, 101 );
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size( 129, 22 );
			this.label5.TabIndex = 12;
			this.label5.Text = "Data zakończenia:";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// btnUserLookup
			// 
			this.btnUserLookup.Location = new System.Drawing.Point( 408, 56 );
			this.btnUserLookup.Name = "btnUserLookup";
			this.btnUserLookup.Size = new System.Drawing.Size( 24, 23 );
			this.btnUserLookup.TabIndex = 3;
			this.btnUserLookup.Text = "...";
			this.btnUserLookup.UseVisualStyleBackColor = true;
			this.btnUserLookup.Click += new System.EventHandler( this.UserHandler );
			// 
			// tbUser
			// 
			this.tbUser.Location = new System.Drawing.Point( 165, 57 );
			this.tbUser.MaxLength = 30;
			this.tbUser.Name = "tbUser";
			this.tbUser.Size = new System.Drawing.Size( 243, 20 );
			this.tbUser.TabIndex = 2;
			this.tbUser.Leave += new System.EventHandler( this.UserHandler );
			// 
			// label8
			// 
			this.label8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.label8.Location = new System.Drawing.Point( 74, 56 );
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size( 91, 21 );
			this.label8.TabIndex = 4;
			this.label8.Text = "Przypisanoo do:";
			this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// cbInactive
			// 
			this.cbInactive.AutoSize = true;
			this.cbInactive.Location = new System.Drawing.Point( 8, 137 );
			this.cbInactive.Name = "cbInactive";
			this.cbInactive.Size = new System.Drawing.Size( 82, 17 );
			this.cbInactive.TabIndex = 7;
			this.cbInactive.Text = "Nieaktywne";
			this.cbInactive.UseVisualStyleBackColor = true;
			// 
			// wCalendarItem
			// 
			this.AddNewButtonVisible = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size( 590, 413 );
			this.Controls.Add( this.tabControl1 );
			this.DeleteButtonVisible = true;
			this.Location = new System.Drawing.Point( 0, 0 );
			this.Name = "wCalendarItem";
			this.RecordMovementControlVisible = true;
			this.RefreshButtonVisible = true;
			this.Text = "Pozycja kalendarza";
			this.Title = "Pozycja kalendarza";
			this.ToolStripVisible = true;
			this.Controls.SetChildIndex( this.oMainPanel, 0 );
			this.Controls.SetChildIndex( this.tabControl1, 0 );
			this.oMainPanel.ResumeLayout( false );
			this.oMainPanel.PerformLayout();
			( (System.ComponentModel.ISupportInitialize)( this.oBindingSource ) ).EndInit();
			this.tabControl1.ResumeLayout( false );
			this.tpMainData.ResumeLayout( false );
			this.tpMainData.PerformLayout();
			this.tpCyclicEvent.ResumeLayout( false );
			this.tpCyclicEvent.PerformLayout();
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
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.ComboBox cbCyclePeriod;
		private System.Windows.Forms.CheckBox cbWholeDay;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tpMainData;
		private System.Windows.Forms.TabPage tpCyclicEvent;
		private System.Windows.Forms.Label label5;
		private Venus.Controls.WLDateTimePicker dtpCycleStartDate;
		private System.Windows.Forms.Label label6;
		private Venus.Controls.WLDateTimePicker dtpCycleEndDate;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.ComboBox cbReminder;
		private System.Windows.Forms.CheckBox cbMonday;
		private System.Windows.Forms.CheckBox cbFriday;
		private System.Windows.Forms.CheckBox cbThursday;
		private System.Windows.Forms.CheckBox cbWednesday;
		private System.Windows.Forms.CheckBox cbSaturday;
		private System.Windows.Forms.CheckBox cbSunday;
		private System.Windows.Forms.CheckBox cbTuesday;
		private System.Windows.Forms.Button btnUserLookup;
		private System.Windows.Forms.TextBox tbUser;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.CheckBox cbInactive;
	}
}