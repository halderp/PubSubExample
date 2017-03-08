using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace PubSubInterfaces
{
    public interface IAppPublisher
    {
        void PublishEvent(string action,string data);
    }
}