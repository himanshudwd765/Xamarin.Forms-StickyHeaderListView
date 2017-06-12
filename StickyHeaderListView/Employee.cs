using System;
namespace StickyHeaderListView
{
    public class Employee
    {
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string FullName { get { return FirstName + " " + LastName; } }
		public string Department { get; set; }
    }
}
