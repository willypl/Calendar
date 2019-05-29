using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using WLib;

namespace Calendar
{
	[AttributeUsage( AttributeTargets.Class, AllowMultiple = true, Inherited = true )]
	public class WLCalendarEvent : Attribute
	{
		#region Declarations
		private Type oClassType = null;
		private string cGetClassItemsMethodName = string.Empty;
		private string cGetCalendarEventsMethodName = string.Empty;
		private string cStartDateColumnName = "StartDate";
		private string cEndDateColumnName = "EndDate";
		//public delegate IEnumerable GetClassItemsDelegate();
		#endregion

		#region Constructors
		public WLCalendarEvent( )
		{
		}
		public WLCalendarEvent( Type ClassType, string GetClassItemsMethodName, string GetCalendarEventsMethodName )
		{
			this.oClassType = ClassType;
			this.cGetClassItemsMethodName = GetClassItemsMethodName;
			//this.cGetCalendarEventsMethodName = cGetCalendarEventsMethodName;
		}
		//public WLCalendarEvent( Type ClassType, GetClassItemsDelegate GetClassItems, string GetClassItemsMethodName, string GetCalendarEventsMethodName, string PlannedStartDateColumnName, string PlannedEndDateColumnName )
		//{
		//    this.oClassType = ClassType;
		//    this.cGetClassItemsMethodName = GetClassItemsMethodName;
		//    this.cGetCalendarEventsMethodName = cGetCalendarEventsMethodName;
		//}
		#endregion

		#region Data methods

		#endregion

		#region Static methods
		public static string GetGetClassitemsMethodName( Type oClassType )
		{
			string cGetMethodName = string.Empty;
			foreach ( WLCalendarEvent oCalendarEventAttribute in oClassType.GetCustomAttributes( typeof( WLCalendarEvent ), true ) )
				if ( oCalendarEventAttribute.ClassType.Equals( oClassType ) )
				{
					cGetMethodName = oCalendarEventAttribute.GetClassItemsMethodName;
					break;
				}
			return cGetMethodName;
		}
		public static string GetGetEventsMethodName( Type oClassType )
		{
			string cGetMethodName = string.Empty;
			foreach( WLCalendarEvent oCalendarEventAttribute in oClassType.GetCustomAttributes( typeof( WLCalendarEvent), true))
				if ( oCalendarEventAttribute.ClassType.Equals( oClassType))
					cGetMethodName = oCalendarEventAttribute.GetCalendarEventsMethodName;
			return cGetMethodName;
		}
		public static Dictionary<WLCalendarEvent, Type> GetAllCalendarAttributes()
		{
			Dictionary<WLCalendarEvent, Type> oCalendarAttributes = new Dictionary<WLCalendarEvent, Type>();
			object[] aCalendarAttributes = null;
			foreach ( Type oType in RuntimeManager.ProgramTypes )
				if ( ( aCalendarAttributes = oType.GetCustomAttributes( typeof( WLCalendarEvent), true)).Length > 0)
					foreach( WLCalendarEvent oCalendarAttribute in aCalendarAttributes)
						oCalendarAttributes.Add( oCalendarAttribute, oType );
			return oCalendarAttributes;
		}
		#endregion

		#region Properties
		public Type ClassType
		{
			get { return this.oClassType; }
			set { this.oClassType = value; }
		}
		public string GetCalendarEventsMethodName
		{
			get { return this.cGetCalendarEventsMethodName; }
			set { this.cGetCalendarEventsMethodName = value; }
		}
		public string GetClassItemsMethodName
		{
			get { return this.cGetClassItemsMethodName; }
			set { this.cGetClassItemsMethodName = value; }
		}
		public string StartDateColumnName
		{
			get { return this.cStartDateColumnName; }
			set { this.cStartDateColumnName = value; }
		}
		public string EndDateColumnName
		{
			get { return this.cEndDateColumnName; }
			set { this.cEndDateColumnName = value; }
		}
		//public GetClassItemsDelegate GetClassItems
		//{
		//    get;
		//    set;
		//}
		#endregion
	}
}