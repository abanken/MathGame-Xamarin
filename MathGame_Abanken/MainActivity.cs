using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content;
using MathGame_Abanken.Resources.layout;

namespace MathGame_Abanken
{
    [Activity(Theme = "@android:style/Theme.NoTitleBar", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Title);

            var btngame = FindViewById<Button>(Resource.Id.newGame);
            var btnscore = FindViewById<Button>(Resource.Id.scoreBut);
            btngame.Click += (s, e) =>
            {
                Intent nextActivity = new Intent(this, typeof(GameActivity));
                StartActivity(nextActivity);
            };

            btnscore.Click += (s, e) =>
            {
                Intent nextActivity = new Intent(this, typeof(ScoreActivity));
                StartActivity(nextActivity);
            };


        }
    }
}


