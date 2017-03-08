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

namespace PubSubInterfaces
{
    public interface IAppSubscriber
    {
        event EventHandler<IntentEventArgs> IntentReceivedBySub;
        void SubscribeAppEvent(string appevent);

        void UnSubscribeAll();
    }
}