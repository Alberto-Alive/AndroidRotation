using System;

using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Util;
using Android.Widget;
using FragmentPLSample;

namespace FragmentPLSample
{
    [Activity(Label = "@string/app_name", MainLauncher = true, Icon = "@drawable/launcher")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.main);

            Button rotationNoFragmentsButton = FindViewById<Button>(Resource.Id.rotationNoFragmentsButton);
            Button rotationUsingFragmentsButton = FindViewById<Button>(Resource.Id.rotationUsingFragmentsButton);
            Button rotationUsingFrameLayoutsButton = FindViewById<Button>(Resource.Id.rotationUsingFrameLayoutsButton);
            Button rotationUsingJustCSharpButton = FindViewById<Button>(Resource.Id.rotationUsingJustCSharpButton);

            rotationNoFragmentsButton.Click += (sender, args) =>
            {
                StartActivity(typeof(RotationNoFragments));
            };

            rotationUsingFragmentsButton.Click += (sender, args) =>
            {
                StartActivity(typeof(RotationUsingFragments));
            };

            rotationUsingFrameLayoutsButton.Click += (sender, args) =>
            {
                StartActivity(typeof(RotationUsingFrameLayouts));
            };

            rotationUsingJustCSharpButton.Click += (sender, args) =>
            {
                StartActivity(typeof(RotationUsingFragmentsJustCSharp));
            };
        }
    }
}
