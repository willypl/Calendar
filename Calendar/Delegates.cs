using System;
using WLib;
using Venus;

namespace Calendar
{
	public delegate void CalendarStyleChangeDelegate();
	public delegate void BeforeCurrentDateChangeDelegate();
	public delegate void AfterCurrentDateChangeDelegate();
	public delegate void RowCountChangeDelegate();
	public delegate void RowHeightChangeDelegate();
	public delegate void ColumnCountChangeDelegate();
	public delegate void ColumnWidthChangeDelegate();
	public delegate void EventCountChangeDelegate( object oObject, ObjectEventArgs oEventArgs);
	public delegate void EventDoubleClick( CalendarEvent oEvent );
	public delegate void EventChange( CalendarEvent oEvent );
	public delegate void ObjectChanged( object oObject, ObjectEventArgs oEventArgs);
	//public enum EventType{ UnChanged, Changed, Added, Removed, Delete, Cleared, Saved, Settled}

	//public class ObjectEventArgs: EventArgs
	//{
	//    #region Declarations
	//    private EventType oEventType = EventType.UnChanged;
	//    private int nIndex = -1;
	//    #endregion

	//    #region Constructors
	//    public ObjectEventArgs( EventType oEventType) 
	//    {
	//        this.oEventType = oEventType;
	//    }
	//    public ObjectEventArgs( EventType oEventType, int nIndex) 
	//    {
	//        this.oEventType = oEventType;
	//        this.nIndex = nIndex;
	//    }
	//    #endregion

	//    #region GET/SET methods
	//    public EventType EventType
	//    {
	//        get { return this.oEventType;}
	//        set { this.oEventType = value;}
	//    }
	//    public int Index
	//    {
	//        get { return this.nIndex;}
	//        set { this.nIndex = value;}
	//    }
	//    #endregion
	//}
}
