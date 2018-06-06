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

namespace MathGame_Abanken.Resources.layout
{
    [Activity(Label = "GameActivity")]
    public class GameActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.gameScreen);


            TextView number1 = FindViewById<TextView>(Resource.Id.number1);
            TextView number2 = FindViewById<TextView>(Resource.Id.number2);
            TextView operatorSign = FindViewById<TextView>(Resource.Id.operatorSign);
            Button answerBtn = FindViewById<Button>(Resource.Id.answerBtn);
            Button ScoreBtn = FindViewById<Button>(Resource.Id.ScoreBtn);
            Button NewGameBtn = FindViewById<Button>(Resource.Id.NewGameBtn);
            EditText answer = FindViewById<EditText>(Resource.Id.answer);
            TextView incorrectAnswers = FindViewById<TextView>(Resource.Id.incorrectAnswers);
            TextView scores = FindViewById<TextView>(Resource.Id.score);


            Random rnd = new Random();
            int start1 = rnd.Next(1, 15);
            int start2 = rnd.Next(1, 15);
            double sum;
            int strike = 0;
            int score = 0;
            var c = 0;
            number1.Text = "" + start1;
            number2.Text = "" + start2;

            operatorSign.Text = "+";

            answerBtn.Click += (s, e) =>
            {
                if (answer.Length() <= 0)
                {
                    //EditText is empty
                    string toast = string.Format("Input error, Answer Field empty");
                    Toast.MakeText(this, toast, ToastLength.Short).Show();
                    answer.SetText("", TextView.BufferType.Editable);
               }
                else 
                {
                    //EditText is not empty
                    answerBtn.Text = "Submit Answer";
                    double ansED = Double.Parse(answer.Text);
                    double snum = Double.Parse(incorrectAnswers.Text);


                    if (snum < 4)
                    {
                        if (c == 0)
                        {
                            sum = start1 + start2;
                            if (ansED == sum)
                            {
                                string toast = string.Format("correct");
                                Toast.MakeText(this, toast, ToastLength.Short).Show();
                                score++;

                                scores.Text = "" + score;
                                answer.SetText("", TextView.BufferType.Editable);
                            }
                            else
                            {
                                string toast = string.Format("wrong: " + sum);
                                Toast.MakeText(this, toast, ToastLength.Short).Show();
                                strike++;
                                incorrectAnswers.Text = "" + strike;
                                answer.SetText("", TextView.BufferType.Editable);
                            }
                            c++;
                            operatorSign.Text = "-";
                        }
                        else if (c == 1)
                        {
                            sum = start2 - start1;
                            if (ansED == sum)
                            {
                                string toast = string.Format("correct");
                                Toast.MakeText(this, toast, ToastLength.Short).Show();
                                score++;
                                scores.Text = "" + score;
                                answer.SetText("", TextView.BufferType.Editable);
                            }
                            else
                            {
                                string toast = string.Format("wrong: " + sum);
                                Toast.MakeText(this, toast, ToastLength.Short).Show();
                                strike++;
                                incorrectAnswers.Text = "" + strike;
                                answer.SetText("", TextView.BufferType.Editable);
                            }
                            c++;
                            operatorSign.Text = "*";
                        }
                        else if (c == 2)
                        {
                            sum = start1 * start2;
                            if (ansED == sum)
                            {
                                string toast = string.Format("correct");
                                Toast.MakeText(this, toast, ToastLength.Short).Show();
                                score++;
                                scores.Text = "" + score;
                                answer.SetText("", TextView.BufferType.Editable);
                            }
                            else
                            {
                                string toast = string.Format("wrong: " + sum);
                                Toast.MakeText(this, toast, ToastLength.Short).Show();
                                strike++;
                                incorrectAnswers.Text = "" + strike;
                                answer.SetText("", TextView.BufferType.Editable);
                            }
                            c = 0;
                            operatorSign.Text = "+";
                        }
                        start1 = rnd.Next(1, 15);
                        start2 = rnd.Next(1, 15);
                        number2.Text = "" + start1;
                        number1.Text = "" + start2;

                        answerBtn.Visibility = ViewStates.Visible;
                        NewGameBtn.Enabled = false;
                    }
                    else
                    {
                        string toast = string.Format("You lose");
                        Toast.MakeText(this, toast, ToastLength.Long).Show();
                        answerBtn.Enabled = false;
                        NewGameBtn.Enabled = true;
                        NewGameBtn.Visibility = ViewStates.Visible;
                        answerBtn.Visibility = ViewStates.Invisible;

                        var highscores = Application.Context.GetSharedPreferences("High Scores", FileCreationMode.Private);
                        var scoreEdit = highscores.Edit();
                        string sscore = score.ToString();
                        scoreEdit.PutString("Score", sscore);
                        scoreEdit.Commit();

                    }
                }
                };

                NewGameBtn.Click += (s, e) =>
                {
                    answerBtn.Enabled = true;
                    answerBtn.Visibility = ViewStates.Visible;
                    NewGameBtn.Visibility = ViewStates.Invisible;
                    start1 = rnd.Next(1, 15);
                    start2 = rnd.Next(1, 15);
                    number2.Text = "" + start1;
                    number1.Text = "" + start2;
                    c = 0;
                    strike = 0;
                    sum = 0;
                    incorrectAnswers.Text = "" + strike;
                    score = 0;
                    scores.Text = "" + score;

                };

                ScoreBtn.Click += (s, e) =>
                {
                    var intent = new Intent(this, typeof(ScoreActivity));
                    StartActivity(intent);
                };
            
            }
    }
}
