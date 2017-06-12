using System;
using System.Collections.Generic;
using System.Linq;
using Android;
using Android.App;
using Android.Views;
using Android.Widget;
using StickyListHeaders;

namespace StickyHeaderListView.Droid
{
	public class CustomListViewAdapter : BaseAdapter<Employee>, IStickyListHeadersAdapter, ISectionIndexer
	{
		Activity context;
		TextView textview;

		// -- ISectionIndexer --
		string[] sections;
		Java.Lang.Object[] sectionsObjects;
		Dictionary<string, int> alphaIndex;

		IList<Employee> tableItems = new List<Employee>();

		public IEnumerable<Employee> Items
		{
			set
			{
				tableItems = value.ToList();
			}
		}

		public CustomListViewAdapter(Activity context, CustomListView view) : base()
		{
			this.context = context;
			//inflater = LayoutInflater.From(context);
			this.context = context;
			var res = view.Items.ToList();
			tableItems = res.OrderBy(o => o.FirstName).ToList();
			alphaIndex = new Dictionary<string, int>();
			for (int i = 0; i < tableItems.Count; i++)
			{
				var item = tableItems[i];
				var key = item.FirstName.Substring(0, 1);
				if (!alphaIndex.ContainsKey(key))
					alphaIndex.Add(key, i);
			}
			sections = new string[alphaIndex.Keys.Count];
			alphaIndex.Keys.CopyTo(sections, 0);
			sectionsObjects = new Java.Lang.Object[sections.Length];
			for (int i = 0; i < sections.Length; i++)
			{
				sectionsObjects[i] = new Java.Lang.String(sections[i]);
			}
		}

		public override Employee this[int position]
		{
			get
			{
				return tableItems[position];
			}
		}

		public override int Count
		{
			get { return tableItems.Count; }
		}

		public long GetHeaderId(int position)
		{
			return tableItems[position].FirstName.ToString().Substring(0, 1)[0];
		}

		public View GetHeaderView(int position, View convertView, ViewGroup parent)
		{
			ViewHolder holder;

			if (convertView == null)
			{
				holder = new ViewHolder();
				convertView = context.LayoutInflater.Inflate(Resource.Layout.StickyListHeader, null);
				holder.text = convertView.FindViewById<TextView>(Resource.Id.text1);
				convertView.Tag = holder;
			}
			else
			{
				holder = (ViewHolder)convertView.Tag;
			}

			// set header text as first char in name
			var headerChar = tableItems[position].FirstName.ToString().Substring(0, 1);
			holder.text.Text = headerChar;

			return convertView;
		}

		public override long GetItemId(int position)
		{
			return position;
		}

		public int GetPositionForSection(int sectionIndex)
		{
			return alphaIndex[sections[sectionIndex]];
		}

		public int GetSectionForPosition(int position)
		{
			int prevSection = 0;

			for (int i = 0; i < sections.Length; i++)
			{
				if (GetPositionForSection(i) > position)
				{
					break;
				}

				prevSection = i;
			}

			return prevSection;
		}

		public Java.Lang.Object[] GetSections()
		{
			return sectionsObjects;
		}

		public override View GetView(int position, View convertView, ViewGroup parent)
		{
			var item = tableItems[position];

			View view = convertView;
			if (view == null) // no view to re-use, create new
				view = context.LayoutInflater.Inflate(Resource.Layout.ListViewCell, null);
			view.FindViewById<TextView>(Resource.Id.txtName).Text = item.FullName;
			view.FindViewById<TextView>(Resource.Id.txtDept).Text = item.Department;

			return view;
		}

		private class ViewHolder : Java.Lang.Object
		{
			public TextView text;

		}
	}
}
