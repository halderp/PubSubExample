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
using PubSubInterfaces;

namespace PubSubImpl
{
    public class AppBroadCastReceiver : BroadcastReceiver
    {
        public event EventHandler<IntentEventArgs> IntentReceived;
        public override void OnReceive(Context context, Intent intent)
        {
            Console.WriteLine("Recieved Intent");
            Console.WriteLine(intent.GetStringExtra("SampleData"));

            OnIntentReceived(intent.Action, intent.GetStringExtra("SampleData"));
        }

        protected virtual void OnIntentReceived(string pubApp, string pubAppData)
        {
            var intentEventArgs = new IntentEventArgs { publisherApplication = pubApp, publisherApplicationData= pubAppData };
            IntentReceived?.Invoke(this, intentEventArgs);
        }
    }
}