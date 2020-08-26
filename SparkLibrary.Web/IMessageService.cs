using System;

namespace SparkLibrary.Web
{
    public delegate void SendNotice(Object sender, EventArgs args);
    public interface IMessageService
    {
        void SendMessage();
        void ReceiveMessage();

        event SendNotice MessageSent;
    }
}