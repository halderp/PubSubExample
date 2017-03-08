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

    public class Subscriber : IAppSubscriber
    {
        public AppBroadCastReceiver appEventReciever;
        private bool eventSubscribed = false;

        public event EventHandler<IntentEventArgs> IntentReceivedBySub;

        public Subscriber()
        {
            appEventReciever = new AppBroadCastReceiver();
        }

        public void SubscribeAppEvent(string appevent)
        {
            IntentFilter filter = new IntentFilter(appevent);

            if (!eventSubscribed)
            {
                appEventReciever.IntentReceived += this.IntentReceived;
                eventSubscribed = true;
            }
            Application.Context.RegisterReceiver(appEventReciever, filter);
        }

        private void IntentReceived(object sender, IntentEventArgs e)
        {
            Console.WriteLine("Subscriber : Intent Recieved.....{0} - {1}", e.publisherApplication, e.publisherApplicationData);
            IntentReceivedBySub?.Invoke(this, e);
        }

        public void UnSubscribeAll()
        {
            appEventReciever.IntentReceived -= this.IntentReceived;
            Application.Context.UnregisterReceiver(appEventReciever);

        }
    }
}