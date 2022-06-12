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

namespace FragmentPLSample
{
    public class PlaysFragment : Fragment
    {

        public static PlaysFragment NewInstance()
        {
            var bundle = new Bundle();
            return new PlaysFragment();
        }

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            View view =   inflater.Inflate(Resource.Layout.playsFragment, null);

            //return base.OnCreateView(inflater, container, savedInstanceState);

            return view;
        }
    }
}