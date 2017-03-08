using PubSubInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace PubSubInterfaces
{
    public interface IAppSubscriber
    {
        event EventHandler<IntentEventArgs> IntentReceivedBySub;
        void SubscribeAppEvent(string appevent);

        void UnSubscribeAll();
    }
}