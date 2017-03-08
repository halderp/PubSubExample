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
    public class AppPublisher: IAppPublisher
    {
        public void PublishEvent(string action, string data)
        {
            Console.WriteLine("Publisher: Publishing Intent :{0}", action);
            var intent = new Intent(action);
            intent.PutExtra("SampleData", data);
            Application.Context.SendBroadcast(intent);
            intent = null;
            Console.WriteLine("Publisher: Published Intent : {0}", action);

        }
    }
}