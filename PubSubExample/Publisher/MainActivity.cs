using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using PubSubInterfaces;
using PubSubImpl;

namespace Publisher
{
    [Activity(Label = "Publisher", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        int count = 1;
        public IAppPublisher appPublisherTC;
        public IAppPublisher appPublisherPK;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it
            Button button = FindViewById<Button>(Resource.Id.MyButton);
            Button button1 = FindViewById<Button>(Resource.Id.MyButton1);

            button.Click += delegate { PublishMessageTimecard(); };
            button1.Click += delegate { PublishMessagePackages(); };

        }

        void PublishMessageTimecard()
        {
            appPublisherTC = new AppPublisher();
            appPublisherTC.PublishEvent("application1_1.broadcast", "application1_1 broadcast data");
        }
        void PublishMessagePackages()
        {
            appPublisherPK = new AppPublisher();
            appPublisherPK.PublishEvent("application1_2.broadcast", "application1_2 broadcast data");
        }
    }
}

