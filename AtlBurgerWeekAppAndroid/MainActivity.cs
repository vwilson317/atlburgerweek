using Android.App;
using Android.Widget;
using Android.OS;
using System.Collections.Generic;

namespace AtlBurgerWeekAppAndroid
{
    [Activity(Label = "AtlBurgerWeekAppAndroid", MainLauncher = true, Icon = "@mipmap/icon")]
    public class MainActivity : Activity
    {
        //int count = 1;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it
            ExpandableListView listView = FindViewById<ExpandableListView>(Resource.Id.expandableListView);

            var arrayList = new Java.Util.ArrayList();
            var dict = new Dictionary<Java.Lang.String, Java.Util.ArrayList>();
            //dict.Add
            var listAdapter = new ExpandableListAdapter(this, new List<Java.Lang.String>(), dict);

            listView.SetAdapter(listAdapter);

            //button.Click += delegate { button.Text = string.Format("{0} clicks!", count++); };
        }
    }
}

