//using System;
//using System.Collections;
//using WLib;

//namespace Calendar
//{
//    /// <summary>
//    /// Collection of events
//    /// </summary>
//    public class CalendarEventCollection:ArrayList
//    {
//        #region Declarations
//        public event EventCountChangeDelegate EventCountChange;
//        public event EventChange EventChange;
//        private WLCalendar oCalendar;
//        //		private ObjectEventArgs oObjectEventArgs;
//        #endregion

//        #region Constructor
//        public CalendarEventCollection()
//        {
//        }
//        public CalendarEventCollection( WLCalendar oCalendar )
//        {
//            this.oCalendar = oCalendar;
//        }
//        #endregion

//        #region Add method
//        public int Add( CalendarEvent oEvent )
//        {
//            int nRetVal;
			
//            oEvent.SuspendBroadcast();
//            oEvent.Calendar = this.oCalendar;
//            oEvent.ObjectChanged += new ObjectChanged(oEvent_ObjectChanged);
//            oEvent.ResetBroadcast();
//            nRetVal = base.Add( oEvent);
//            this.RaiseEventCountChangeEvent( oEvent, new ObjectEventArgs( EventType.Added));

//            return nRetVal;
//        }
//        public new void Clear()
//        {
//            base.Clear();
//            this.RaiseEventCountChangeEvent( null, new ObjectEventArgs( EventType.Cleared));
//        }
//        //		public void Remove( EventBox oEventBox)
//        //		{
//        //			if ( this.Contains( oEventBox))
//        //			{
//        //				int nIndex = this.IndexOf( oEventBox);
//        //				base.RemoveAt( nIndex);
//        //				this.RaiseEventCountChangeEvent( oEventBox, new ObjectEventArgs( EventType.Removed, nIndex));
//        //			}
//        //		}
//        #endregion

//        #region Static methods
//        public CalendarEventCollection GetBetweenPlannedDates( DateTime dtStart, DateTime dtEnd )
//        {
//            CalendarEventCollection oEvents = new CalendarEventCollection( this.oCalendar );
//            foreach ( CalendarEvent oEvent in this )
//                if ( oEvent.PlannedEnd >= dtStart && oEvent.PlannedEnd <= dtEnd || oEvent.PlannedStart >= dtStart && oEvent.PlannedStart <= dtEnd)
//                    oEvents.Add( oEvent);

//            return oEvents;
//        }
//        #endregion

//        #region Raise event methods
//        private void RaiseEventCountChangeEvent( CalendarEvent oEvent, ObjectEventArgs oObjectEventArgs )
//        {
//            if ( this.EventCountChange != null)
//                this.EventCountChange( oEvent, oObjectEventArgs);
//        }
//        #endregion

//        #region GET/SET methods
//        //		public ObjectEventArgs ObjectEventArgs
//        //		{
//        //			get { return this.oObjectEventArgs;}
//        //		}
//        #endregion

//        private void oEvent_ObjectChanged(object oObject, ObjectEventArgs oEventArgs)
//        {
//            if ( this.EventChange != null)
//                this.EventChange( (CalendarEvent)oObject );
//        }
//    }
//}
