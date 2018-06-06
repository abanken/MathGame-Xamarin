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

namespace MathGame_Abanken
{
    [Activity(Label = "High Score")]
    public class ScoreActivity : ListActivity
    {

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            var highscores = Application.Context.GetSharedPreferences("High Scores", FileCreationMode.Private);
            string score = highscores.GetString("Score", null);

            HScore myscore = new HScore(score);

            HScore[] scorelist = { myscore };

            ListAdapter = new ArrayAdapter<HScore>(this, Android.Resource.Layout.SimpleListItem1, scorelist);
        }
    }
}