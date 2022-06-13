using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace FragmentPLSample
{
    //[Activity(Label = "RotationNoFragment", MainLauncher = true, Icon = "@drawable/launcher")]
    [Activity(Label = "RotationNoFragment")]
    public class RotationNoFragments : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.test1);

            ListView titlesListView = FindViewById<ListView>(Resource.Id.titlesListView);
            titlesListView.ChoiceMode = ChoiceMode.Single;

            titlesListView.Adapter = new ArrayAdapter<String>(this, Android.Resource.Layout.SimpleListItemActivated1, Shakespeare.Titles);
                       
            titlesListView.ItemClick += TitlesListView_ItemClick;
            titlesListView.SetSelection(0);
            //Preselect First item
            TitlesListView_ItemClick(null, new AdapterView.ItemClickEventArgs(null, null, 0, 0));
        }

        private void TitlesListView_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            TextView quoteTextView = FindViewById<TextView>(Resource.Id.quoteTextView);
            quoteTextView.Text = Shakespeare.Dialogue[e.Position]; 
        }
    }
}