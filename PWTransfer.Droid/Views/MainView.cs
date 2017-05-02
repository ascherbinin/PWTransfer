using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using Android.Support.V7.App;
using Android.Support.V4.Widget;
using PWTransfer.Droid.Views.Fragments;
using MvvmCross.Droid.Support.V7.AppCompat;
using PWTransfer.Core.ViewModels;

namespace PWTransfer.Droid.Views
{
	[Activity(
		NoHistory = true
	)]
	public class MainView : MvxCachingFragmentCompatActivity<MainViewModel>
	{
		ActionBarDrawerToggle _drawerToggle;

		ListView _drawerListView;

		DrawerLayout _drawerLayout;

		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			SetContentView(Resource.Layout.MainView);

			//var toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
			//SetSupportActionBar(toolbar);
			SupportActionBar.SetDisplayHomeAsUpEnabled(true);

			_drawerListView = FindViewById<ListView>(Resource.Id.drawerListView);
			_drawerListView.ItemClick += (s, e) => ShowFragmentAt(e.Position);
			_drawerListView.Adapter = new ArrayAdapter<string>(this, global::Android.Resource.Layout.SimpleListItem1, ViewModel.MenuItems.ToArray());

			_drawerLayout = FindViewById<DrawerLayout>(Resource.Id.drawerLayout);

			_drawerToggle = new ActionBarDrawerToggle(
				this,
				_drawerLayout,
				Resource.String.OpenDrawerString,
				Resource.String.CloseDrawerString);

			_drawerLayout.AddDrawerListener(_drawerToggle);



			ShowFragmentAt(0);
		}

		void ShowFragmentAt(int position)
		{
			ViewModel.NavigateTo(position);

			Title = ViewModel.MenuItems.ElementAt(position);

			_drawerLayout.CloseDrawer(_drawerListView);
		}

		protected override void OnPostCreate(Bundle savedInstanceState)
		{
			_drawerToggle.SyncState();

			base.OnPostCreate(savedInstanceState);
		}

		public override bool OnOptionsItemSelected(IMenuItem item)
		{
			if (_drawerToggle.OnOptionsItemSelected(item))
				return true;

			return base.OnOptionsItemSelected(item);
		}
	}

}