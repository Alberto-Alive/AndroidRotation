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
    //[Activity(Label = "RotationUsingFrameLayouts", MainLauncher = true, Icon = "@drawable/launcher")]
    [Activity(Label = "RotationUsingFrameLayouts")]
    public class RotationUsingFrameLayouts : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.rotationUsingFrameLayouts);

            Fragment playsFragment = FragmentManager.FindFragmentById(Resource.Id.playsLayout) as PlaysFragment;
            if (playsFragment == null)
            {
                playsFragment = PlaysFragment.NewInstance();

                FragmentTransaction transaction = FragmentManager.BeginTransaction();
                transaction.Replace(Resource.Id.playsLayout, playsFragment);
                transaction.Commit();
            }

            Fragment quotesFragment = FragmentManager.FindFragmentById(Resource.Id.quotesLayout) as QuotesFragment;
            if (quotesFragment == null)
            {
                quotesFragment = QuotesFragment.NewInstance();
                FragmentTransaction transaction = FragmentManager.BeginTransaction();
                transaction.Replace(Resource.Id.quotesLayout, quotesFragment);
                transaction.Commit();
            }
        }

        private void TitlesListView_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            TextView quoteTextView = FindViewById<TextView>(Resource.Id.quoteTextView);
            quoteTextView.Text = Shakespeare.Dialogue[e.Position];
        }

        protected override void OnResume()
        {
            //Quote and Play Fragments don't have their OnCreate or OnCreateView methods called until
            //Activities OnCreate method has fully completed. Hence inclusion of below code (and code
            //in TitlesListView_ItemClick
            base.OnResume();
            ListView titlesListView = FindViewById<ListView>(Resource.Id.titlesListView);

            titlesListView.ChoiceMode = ChoiceMode.Single;

            titlesListView.Adapter = new ArrayAdapter<String>(this, Android.Resource.Layout.SimpleListItemActivated1, Shakespeare.Titles);

            titlesListView.ItemClick += TitlesListView_ItemClick;
            titlesListView.SetSelection(0);
            //Preselect First item
            TitlesListView_ItemClick(null, new AdapterView.ItemClickEventArgs(null, null, 0, 0));
        }
    }
}