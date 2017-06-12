using System;
using System.Collections.Generic;

namespace StickyHeaderListView
{
    public class DataSource
    {
		public static List<Employee> GetList()
		{
			var l = new List<Employee>();

			l.Add(new Employee() { FirstName = "Anderson", LastName = "Martin", Department = "Developer Evangelist" });
			l.Add(new Employee() { FirstName = "Adam", LastName = "Dev", Department = "Web Developer" });
			l.Add(new Employee() { FirstName = "Bob", LastName = "Harry", Department = "Customer Success Engineer" });
			l.Add(new Employee() { FirstName = "Brooke", LastName = "Clancy", Department = "Marketing" });
			l.Add(new Employee() { FirstName = "Bella", LastName = "Jo", Department = "Developer Evangelist" });
			l.Add(new Employee() { FirstName = "Charlie", LastName = "James", Department = "Director of Education" });
			l.Add(new Employee() { FirstName = "Carla", LastName = "Buckner", Department = "Product Manager" });
			l.Add(new Employee() { FirstName = "Dev", LastName = "Anand", Department = "CTO" });
			l.Add(new Employee() { FirstName = "Fried", LastName = "Hardy", Department = "CEO" });
			l.Add(new Employee() { FirstName = "Harry", LastName = "Jacob", Department = "COO" });
			l.Add(new Employee() { FirstName = "Hannah", LastName = "Icaza", Department = "Support" });
			l.Add(new Employee() { FirstName = "Michael", LastName = "Nikon", Department = "Database" });
			l.Add(new Employee() { FirstName = "Maria", LastName = "Shara", Department = "HR" });
			l.Add(new Employee() { FirstName = "Orla", LastName = "Jackson", Department = "Designer" });
			l.Add(new Employee() { FirstName = "Perry", LastName = "Butler", Department = "HR" });
			l.Add(new Employee() { FirstName = "Simons", LastName = "Foster", Department = "Developer" });
			l.Add(new Employee() { FirstName = "Timmy", LastName = "Niklas", Department = "Designer" });
			l.Add(new Employee() { FirstName = "Utham", LastName = "Nigam", Department = "Accounts" });
			l.Add(new Employee() { FirstName = "Valerie", LastName = "Xander", Department = "Developer" });
			l.Add(new Employee() { FirstName = "Zaccheus", LastName = "Bing", Department = "Testing" });

			return l;
		}
    }
}
