using System;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Views;
using Android.Widget;


namespace FragmentPLSample
{
    public class PlaysJCSFragment : ListFragment
    {
        int selectedPlayId;
        bool showingTwoFragments;

        public PlaysJCSFragment()
        {
            // Being explicit about the requirement for a default constructor.
        }

        public override void OnActivityCreated(Bundle savedInstanceState)
        {
            base.OnActivityCreated(savedInstanceState);
            ListAdapter = new ArrayAdapter<String>(Activity, Android.Resource.Layout.SimpleListItemActivated1, Shakespeare.Titles);

            if (savedInstanceState != null)
            {
                selectedPlayId = savedInstanceState.GetInt("current_play_id", 0);
            }

            //var quoteContainer = Activity.FindViewById(Resource.Id.quotesJCSLayout);
            //showingTwoFragments = quoteContainer != null &&
            //                      quoteContainer.Visibility == ViewStates.Visible;
            //if (showingTwoFragments)
            //{
                ListView.ChoiceMode = ChoiceMode.Single;
                ShowQuote(selectedPlayId);
            //}
        }

        public override void OnSaveInstanceState(Bundle outState)
        {
            base.OnSaveInstanceState(outState);
            outState.PutInt("current_play_id", selectedPlayId);
        }

        public override void OnListItemClick(ListView l, View v, int position, long id)
        {
            ShowQuote(position);
        }

        void ShowQuote(int playId)
        {
            selectedPlayId = playId;

            //Note: As far as I can tell some devices (with larger screens) tend to always be in landscape mode
            //Consequently rotating them has no effect
            if (Resources.Configuration.Orientation == Android.Content.Res.Orientation.Landscape)
            {
                ListView.SetItemChecked(selectedPlayId, true);

                var playQuoteFragment = FragmentManager.FindFragmentById(Resource.Id.quotesJCSLayout) as QuotesJCSFragment;

                if (playQuoteFragment == null || playQuoteFragment.PlayId != playId)
                {
                    var container = Activity.FindViewById(Resource.Id.quotesJCSLayout);
                    var quoteFrag = QuotesJCSFragment.NewInstance(selectedPlayId);

                    FragmentTransaction ft = FragmentManager.BeginTransaction();
                    ft.Replace(Resource.Id.quotesJCSLayout, quoteFrag);
                    ft.Commit();
                }
            }
            else
            {
                var intent = new Intent(Activity, typeof(PlayQuoteActivity));
                intent.PutExtra("current_play_id", playId);
                StartActivity(intent);
            }
        }
    }
}
