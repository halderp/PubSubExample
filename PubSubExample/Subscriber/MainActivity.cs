using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using PubSubInterfaces;
using PubSubImpl;

namespace Subscriber
{
    [Activity(Label = "Subscriber", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        int count = 1;
        public IAppSubscriber appSubscriber;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it
            Button button = FindViewById<Button>(Resource.Id.MyButton);

            button.Click += delegate { SubscribeToEvents(); };
        }

        

        private void SubscribeToEvents()
        {
            appSubscriber = new PubSubImpl.Subscriber();

            appSubscriber.IntentReceivedBySub += this.IntentRecievedByApp;

            appSubscriber.SubscribeAppEvent("application1_1.broadcast");
            appSubscriber.SubscribeAppEvent("application1_2.broadcast");
            appSubscriber.SubscribeAppEvent("application2_1.broadcast");
        }

        private void IntentRecievedByApp(object sender, IntentEventArgs e)
        {
            Toast toast = Toast.MakeText(this, String.Format("Subscriber App Recieved {0} : {1}", e.publisherApplication, e.publisherApplicationData), ToastLength.Short);
            toast.Show();
            Console.WriteLine("Subscriber App Recieved {0} : {1}", e.publisherApplication, e.publisherApplicationData);
        }
    }
}

