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
    class  HScore {
        public string Score { get; set; }

    public HScore(string score)
    {
        Score = score;
    }

    public override string ToString()
    {
        return Score + " was the most correct previously!";
    }
}
}