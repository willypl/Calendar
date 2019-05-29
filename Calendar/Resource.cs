//using System;
//using WLib;

//namespace Calendar
//{
//    /// <summary>
//    /// Summary description for Resource.
//    /// </summary>
//    public class CalendarResource: ListTable
//    {
//        #region Declarations
//        public event ObjectChanged ObjectChanged;
//        private object oTag = null;
//        private string cID = string.Empty;
//        private string cName = string.Empty;
//        private CalendarEventCollection oEvents = new CalendarEventCollection();
//        #endregion

//        #region Constructors
//        public CalendarResource()
//        {

//        }
//        public CalendarResource( string cID )
//        {
//            this.cID = cID;
//        }
//        #endregion
		
//        #region Data methods
//        //public override bool Save()
//        //{
//        //    return base.Save()
//        //}
//        #endregion

//        #region Event methods
//        #region Event raise methods
//        private void OnChange()
//        {
//            if ( this.ObjectChanged != null )
//                this.ObjectChanged( this, null );
//        }
//        #endregion
//        #endregion

//        #region GET/SET methods
//        public object Tag
//        {
//            get { return this.oTag;}
//            set { this.oTag = value;}
//        }
//        public new string ID
//        {
//            get { return this.cID; }
//            set { this.cID = value; }
//        }
//        public string Name
//        {
//            get { return this.cName; }
//            set { this.cName = value; }
//        }
//        public CalendarEventCollection Events
//        {
//            get { return this.oEvents;}
//            set { this.oEvents = value;}
//        }
//        #endregion
//    }
//}
