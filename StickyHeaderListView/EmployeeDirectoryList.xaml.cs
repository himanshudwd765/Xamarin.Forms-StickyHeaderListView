using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Forms;
namespace StickyHeaderListView
{
    public partial class EmployeeDirectoryList : ContentPage
    {
        public EmployeeDirectoryList()
        {
            InitializeComponent();

            if (Device.RuntimePlatform == Device.Android)
				customListView.Items = DataSource.GetList();

			else if (Device.RuntimePlatform == Device.iOS)
			{
				var empList = DataSource.GetList();

				var groupedData =
					empList.OrderBy(e => e.FirstName)
						.GroupBy(e => e.FirstName[0].ToString())
						.Select(e => new ObservableGroupCollection<string, Employee>(e))
						.ToList();

				BindingContext = new ObservableCollection<ObservableGroupCollection<string, Employee>>(groupedData);
			}
        }
    }
}
