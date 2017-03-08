using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using PubSubInterfaces;
using PubSubImpl;

namespace AnotherPublisher
{
    [Activity(Label = "AnotherPublisher", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        int count = 1;
        public IAppPublisher appPublisherSORT;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it
            Button button = FindViewById<Button>(Resource.Id.MyButton);

            button.Click += delegate { PublishMessageSortApp();  };
        }

        private void PublishMessageSortApp()
        {
            appPublisherSORT = new AppPublisher();
            appPublisherSORT.PublishEvent("application2_1.broadcast", "application2_1 broadcast data");
        }
    }
}

