//using System;
//using System.Collections;
//using WLib;

//namespace Calendar
//{
//    /// <summary>
//    /// Summary description for ResourceCollection.
//    /// </summary>
//    public class ResourceCollection: ArrayList
//    {
//        #region Declarations
//        public event EventHandler CountChanged;
//        public event EventHandler ObjectChanged;
//        private WLCalendar oCalendar = null;
//        #endregion

//        #region Constructor
//        public ResourceCollection( WLCalendar oCalendar)
//        {
//            this.oCalendar = oCalendar;
//        }
//        #endregion

//        #region Item manipulation methods
//        public int Add( CalendarResource oResource )
//        {
//            int nRetVal;
//            oResource.ObjectChanged += new ObjectChanged( oResource_ObjectChanged);
//            foreach ( CalendarEvent oResourceEvent in oResource.Events )
//            {
//                oResourceEvent.Calendar = this.oCalendar;
//                oResourceEvent.ObjectChanged += new ObjectChanged( oEvent_ObjectChanged);
//            }

//            nRetVal = base.Add( oResource);

//            this.OnCountChanged( oResource, new ObjectEventArgs( EventType.Added));
			
//            return nRetVal;
//        }
//        #endregion

//        private void OnCountChanged( CalendarResource oResource, ObjectEventArgs oObjectEventArgs )
//        {
//            if ( this.CountChanged != null)
//                this.CountChanged( oResource, oObjectEventArgs);
//        }
//        private void OnChanged( CalendarResource oResource, ObjectEventArgs oObjectEventArgs )
//        {
//            if ( this.CountChanged != null)
//                this.CountChanged( oResource, oObjectEventArgs);
//        }
		
//        #region GET?SET methods
//        public WLCalendar Calendar
//        {
//            get { return this.oCalendar;}
//            set { this.oCalendar = value;}
//        }
//        #endregion

//        private void oResource_ObjectChanged(object oObject, ObjectEventArgs oEventArgs)
//        {
//            if ( this.ObjectChanged != null)
//                this.ObjectChanged( oObject, oEventArgs);
//        }

//        private void oEvent_ObjectChanged(object oObject, ObjectEventArgs oEventArgs)
//        {
//            if ( this.ObjectChanged != null)
//                this.ObjectChanged( oObject, oEventArgs);
//        }
//    }
//}
