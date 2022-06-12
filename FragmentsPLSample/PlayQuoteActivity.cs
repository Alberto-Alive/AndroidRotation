using Android.App;
using Android.OS;
using Android.Support.V7.App;

namespace FragmentPLSample
{
    [Activity(Label = "PlayQuoteActivity Activity")]
    public class PlayQuoteActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            var playId = Intent.Extras.GetInt("current_play_id", 0);

            var playQuoteFrag = QuotesJCSFragment.NewInstance(playId);
            FragmentManager.BeginTransaction()
                            .Add(Android.Resource.Id.Content, playQuoteFrag)
                            .Commit();
        }
    }
}
