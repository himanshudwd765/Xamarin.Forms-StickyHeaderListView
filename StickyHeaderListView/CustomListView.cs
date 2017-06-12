using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace StickyHeaderListView
{
	public class CustomListView : ListView
	{
		public static readonly BindableProperty ItemsProperty =
			BindableProperty.Create("Items", typeof(IEnumerable<Employee>), typeof(CustomListView), new List<Employee>());

		public IEnumerable<Employee> Items
		{
			get { return (IEnumerable<Employee>)GetValue(ItemsProperty); }
			set { SetValue(ItemsProperty, value); }
		}
	}
}
