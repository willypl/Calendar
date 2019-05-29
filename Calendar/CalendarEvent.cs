//using System;
//using System.Drawing;
//using WLib;

//namespace Calendar
//{
//    /// <summary>
//    /// Summary description for Event.
//    /// </summary>
//    public class CalendarEvent
//    {
//        #region Declarations
//        public event EventHandler OpenEvent;
//        private ObjectEventArgs oObjectEventArgs;
//        public event ObjectChanged ObjectChanged;
//        private WLCalendar oCalendar = null;
//        private DateTime dtPlannedStart;
//        private DateTime dtPlannedEnd;
//        private DateTime dtStart;
//        private DateTime dtEnd;
//        private string cTitle = string.Empty;
//        private string cDescription = string.Empty;
//        private bool lBroadcastAllowed = false;
//        private ListTable oItem = null;
//        private Color oColor = Color.Empty;
//        #endregion

//        #region Constructor
//        public CalendarEvent()
//        {
//            //
//            // TODO: Add constructor logic here
//            //
//        }
//        #endregion
//        public void OnOpen( object sender, EventArgs e )
//        {
//            if ( this.OpenEvent != null )
//                this.OpenEvent( this, null );
//        }

//        #region Raise events methods
//        public void RaiseObjectChanged()
//        {
//            if ( this.lBroadcastAllowed && this.ObjectChanged != null)
//                this.ObjectChanged( this, this.oObjectEventArgs);
//        }
//        #endregion

//        #region Broadcast methods
//        public void SuspendBroadcast()
//        {
//            this.lBroadcastAllowed = false;
//        }
//        public void ResetBroadcast()
//        {
//            this.lBroadcastAllowed = true;
//        }
//        #endregion

//        #region Properties
//        public string Title
//        {
//            get { return this.cTitle;}
//            set
//            {
//                this.cTitle = value;
//                this.RaiseObjectChanged();
//            }
//        }
//        public ListTable Item
//        {
//            get { return this.oItem; }
//            set
//            {
//                this.oItem = value;
//                this.RaiseObjectChanged();
//            }
//        }
//        public string Description
//        {
//            get { return this.cDescription;}
//            set 
//            {
//                this.cDescription = value;
//                this.RaiseObjectChanged();
//            }
//        }
//        public DateTime PlannedStart
//        {
//            get { return this.dtPlannedStart;}
//            set 
//            {
//                this.dtPlannedStart = value;
//                this.RaiseObjectChanged();
//            }
//        }
//        public DateTime PlannedEnd
//        {
//            get { return this.dtPlannedEnd;}
//            set 
//            {
//                this.dtPlannedEnd = value;
//                this.RaiseObjectChanged();
//            }
//        }
//        public DateTime Start
//        {
//            get { return this.dtStart;}
//            set 
//            { 
//                this.dtStart = value;
//                this.RaiseObjectChanged();
//            }
//        }
//        public DateTime End
//        {
//            get { return this.dtEnd;}
//            set 
//            {
//                this.dtEnd = value;
//                this.RaiseObjectChanged();
//            }
//        }
//        public WLCalendar Calendar
//        {
//            get { return this.oCalendar;}
//            set
//            {
//                this.oCalendar = value;
//                this.RaiseObjectChanged();
//            }
//        }
//        public ObjectEventArgs ObjectEventArgs
//        {
//            get { return this.oObjectEventArgs;}
//            set { this.oObjectEventArgs = value;}
//        }
//        public Color Color
//        {
//            get { return this.oColor; }
//            set
//            {
//                this.oColor = value;
//                this.RaiseObjectChanged();
//            }
//        }
//        #endregion
//    }
//}
