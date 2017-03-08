using System;

namespace PubSubInterfaces
{
    public class IntentEventArgs : EventArgs
    {
        public string publisherApplication { get; set; }
        public string publisherApplicationData { get; set; }
    }
}