namespace Calendar
{
	partial class wCalendar
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
			this.panel1 = new System.Windows.Forms.Panel();
			this.cbStyle = new System.Windows.Forms.ComboBox();
			this.btnRefresh = new System.Windows.Forms.Button();
			this.label6 = new System.Windows.Forms.Label();
			this.btnToday = new System.Windows.Forms.Button();
			this.dtpDate = new System.Windows.Forms.DateTimePicker();
			this.label1 = new System.Windows.Forms.Label();
			this.btnNextDay = new System.Windows.Forms.Button();
			this.btnPrevDay = new System.Windows.Forms.Button();
			this.panel2 = new System.Windows.Forms.Panel();
			this.lvCalendars = new System.Windows.Forms.ListView();
			this.label2 = new System.Windows.Forms.Label();
			this.oCalendar = new Calendar.WLCalendar();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Controls.Add( this.cbStyle );
			this.panel1.Controls.Add( this.btnRefresh );
			this.panel1.Controls.Add( this.label6 );
			this.panel1.Controls.Add( this.btnToday );
			this.panel1.Controls.Add( this.dtpDate );
			this.panel1.Controls.Add( this.label1 );
			this.panel1.Controls.Add( this.btnNextDay );
			this.panel1.Controls.Add( this.btnPrevDay );
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.Location = new System.Drawing.Point( 0, 0 );
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size( 1205, 38 );
			this.panel1.TabIndex = 26;
			// 
			// cbStyle
			// 
			this.cbStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbStyle.Location = new System.Drawing.Point( 267, 7 );
			this.cbStyle.Name = "cbStyle";
			this.cbStyle.Size = new System.Drawing.Size( 88, 21 );
			this.cbStyle.TabIndex = 10;
			// 
			// btnRefresh
			// 
			this.btnRefresh.Font = new System.Drawing.Font( "Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte)( 238 ) ) );
			this.btnRefresh.Location = new System.Drawing.Point( 611, 7 );
			this.btnRefresh.Name = "btnRefresh";
			this.btnRefresh.Size = new System.Drawing.Size( 64, 23 );
			this.btnRefresh.TabIndex = 24;
			this.btnRefresh.Text = "Odśwież";
			this.btnRefresh.Click += new System.EventHandler( this.RefreshCalendar );
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point( 235, 7 );
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size( 32, 23 );
			this.label6.TabIndex = 11;
			this.label6.Text = "Styl:";
			this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// btnToday
			// 
			this.btnToday.Font = new System.Drawing.Font( "Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte)( 238 ) ) );
			this.btnToday.Location = new System.Drawing.Point( 691, 7 );
			this.btnToday.Name = "btnToday";
			this.btnToday.Size = new System.Drawing.Size( 64, 23 );
			this.btnToday.TabIndex = 23;
			this.btnToday.Text = "Dziś";
			this.btnToday.Click += new System.EventHandler( this.DateChangeHandler );
			// 
			// dtpDate
			// 
			this.dtpDate.Location = new System.Drawing.Point( 411, 7 );
			this.dtpDate.Name = "dtpDate";
			this.dtpDate.Size = new System.Drawing.Size( 136, 20 );
			this.dtpDate.TabIndex = 15;
			this.dtpDate.ValueChanged += new System.EventHandler( this.DateChangeHandler );
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point( 371, 7 );
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size( 40, 23 );
			this.label1.TabIndex = 16;
			this.label1.Text = "Data:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// btnNextDay
			// 
			this.btnNextDay.Font = new System.Drawing.Font( "Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ( (byte)( 238 ) ) );
			this.btnNextDay.Location = new System.Drawing.Point( 803, 7 );
			this.btnNextDay.Name = "btnNextDay";
			this.btnNextDay.Size = new System.Drawing.Size( 40, 23 );
			this.btnNextDay.TabIndex = 17;
			this.btnNextDay.Text = "»";
			this.btnNextDay.Click += new System.EventHandler( this.DateChangeHandler );
			// 
			// btnPrevDay
			// 
			this.btnPrevDay.Font = new System.Drawing.Font( "Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ( (byte)( 238 ) ) );
			this.btnPrevDay.Location = new System.Drawing.Point( 763, 7 );
			this.btnPrevDay.Name = "btnPrevDay";
			this.btnPrevDay.Size = new System.Drawing.Size( 40, 23 );
			this.btnPrevDay.TabIndex = 18;
			this.btnPrevDay.Text = "«";
			this.btnPrevDay.Click += new System.EventHandler( this.DateChangeHandler );
			// 
			// panel2
			// 
			this.panel2.Controls.Add( this.lvCalendars );
			this.panel2.Controls.Add( this.label2 );
			this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
			this.panel2.Location = new System.Drawing.Point( 0, 38 );
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size( 200, 659 );
			this.panel2.TabIndex = 27;
			// 
			// lvCalendars
			// 
			this.lvCalendars.CheckBoxes = true;
			this.lvCalendars.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lvCalendars.Location = new System.Drawing.Point( 0, 23 );
			this.lvCalendars.Name = "lvCalendars";
			this.lvCalendars.Size = new System.Drawing.Size( 200, 636 );
			this.lvCalendars.TabIndex = 29;
			this.lvCalendars.UseCompatibleStateImageBehavior = false;
			this.lvCalendars.View = System.Windows.Forms.View.Details;
			// 
			// label2
			// 
			this.label2.Dock = System.Windows.Forms.DockStyle.Top;
			this.label2.Location = new System.Drawing.Point( 0, 0 );
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size( 200, 23 );
			this.label2.TabIndex = 20;
			this.label2.Text = "Zaznacz pozycje do pokazania:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// oCalendar
			// 
			this.oCalendar.BackColor = System.Drawing.Color.White;
			this.oCalendar.ClickedDate = new System.DateTime( ( (long)( 0 ) ) );
			this.oCalendar.ColumnFormat = new string[] {
        "dddd dd.MM.yyyy",
        "ddd dd",
        "dddd"};
			this.oCalendar.CultureInfo = new System.Globalization.CultureInfo( "pl-PL" );
			this.oCalendar.CurrentDate = new System.DateTime( 2012, 6, 21, 0, 0, 0, 0 );
			this.oCalendar.Dock = System.Windows.Forms.DockStyle.Fill;
			this.oCalendar.EndVisibleHour = 0;
			this.oCalendar.FirstDisplayedDate = new System.DateTime( 2012, 6, 21, 0, 0, 0, 0 );
			this.oCalendar.LinesColor = System.Drawing.Color.LightGray;
			this.oCalendar.Location = new System.Drawing.Point( 200, 38 );
			this.oCalendar.Name = "oCalendar";
			this.oCalendar.RCHeaderBackColor = System.Drawing.Color.White;
			this.oCalendar.RCHeaderFillStyle = Calendar.FillStyle.VGradient;
			this.oCalendar.RCHeaderFontColor = System.Drawing.Color.Black;
			this.oCalendar.RCHeaderGradientColor1 = System.Drawing.Color.LightYellow;
			this.oCalendar.RCHeaderGradientColor2 = System.Drawing.Color.White;
			this.oCalendar.Size = new System.Drawing.Size( 1005, 659 );
			this.oCalendar.Style = Calendar.CalendarStyle.Dayly;
			this.oCalendar.TabIndex = 28;
			this.oCalendar.TodayBackColor = System.Drawing.Color.LightYellow;
			// 
			// wCalendar
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size( 1205, 697 );
			this.Controls.Add( this.oCalendar );
			this.Controls.Add( this.panel2 );
			this.Controls.Add( this.panel1 );
			this.Name = "wCalendar";
			this.Text = "Kalendarz";
			this.Load += new System.EventHandler( this.wCalendar_Load );
			this.panel1.ResumeLayout( false );
			this.panel2.ResumeLayout( false );
			this.ResumeLayout( false );

		}

		#endregion

		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.ComboBox cbStyle;
		private System.Windows.Forms.Button btnRefresh;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Button btnToday;
		private System.Windows.Forms.DateTimePicker dtpDate;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btnNextDay;
		private System.Windows.Forms.Button btnPrevDay;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Label label2;
		private WLCalendar oCalendar;
		private System.Windows.Forms.ListView lvCalendars;
	}
}