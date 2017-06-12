using System;
using Android;
using System.Collections.Generic;
using Android.Views;
using Android.Content;
using StickyListHeaders;
using Xamarin.Forms;
using Android.Widget;
using Xamarin.Forms.Platform.Android;
using StickyHeaderListView.Droid;
using StickyHeaderListView;

[assembly: ExportRenderer(typeof(CustomListView), typeof(CustomListViewRenderer))]
namespace StickyHeaderListView.Droid
{
	public class CustomListViewRenderer : ViewRenderer<CustomListView, Android.Views.View>
	{
		Dictionary<string, int> mapIndex;
		StickyListHeadersListView SlistView;

		protected override void OnElementChanged(ElementChangedEventArgs<CustomListView> e)
		{
			base.OnElementChanged(e);
			LayoutInflater inflater = (LayoutInflater)Context.GetSystemService(Context.LayoutInflaterService);

			Android.Views.View v = inflater.Inflate(Resource.Layout.customListView, null, false);

			//this.AddView(v);

			if (Control == null)
			{
				SlistView = v.FindViewById<StickyListHeadersListView>(Resource.Id.list_employee);
				SetNativeControl(v);

			}
			if (e.OldElement != null)
			{
				// unsubscribe
				//Control.ItemClick -= OnItemClick;
			}

			if (e.NewElement != null)
			{
				// subscribe
				SlistView.Adapter = new CustomListViewAdapter(Forms.Context as Android.App.Activity, e.NewElement as CustomListView);
			}
		}

		protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
		{
			//base.OnElementPropertyChanged(sender, e);
		}

		void OnItemClick(object sender, Android.Widget.AdapterView.ItemClickEventArgs e)
		{
			//((CustomListView)Element).NotifyItemSelected(((CustomListView)Element).Items.ToList()[e.Position - 1]);
		}
	}
}
