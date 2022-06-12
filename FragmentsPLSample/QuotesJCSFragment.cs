using System;

using Android.App;
using Android.OS;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace FragmentPLSample
{
    class QuotesJCSFragment : Fragment
    {
        public int PlayId => Arguments.GetInt("current_play_id", 0);

        public static QuotesJCSFragment NewInstance(int playId)
        {
            var bundle = new Bundle();
            bundle.PutInt("current_play_id", playId);
            return new QuotesJCSFragment { Arguments = bundle };
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            if (container == null)
            {
                // Currently in a layout without a container, so no reason to create our view.
                return null;
            }

            var textView = new TextView(Activity);
            var padding = Convert.ToInt32(TypedValue.ApplyDimension(ComplexUnitType.Dip, 4, Activity.Resources.DisplayMetrics));
            textView.SetPadding(padding, padding, padding, padding);
            textView.TextSize = 24;
            textView.Text = Shakespeare.Dialogue[PlayId];

            var scroller = new ScrollView(Activity);
            scroller.AddView(textView);

            return scroller;
        }
    }
}
