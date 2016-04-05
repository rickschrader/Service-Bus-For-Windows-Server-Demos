using System;

namespace NotificationAgent
{
    [Serializable]
    public class NotificationMessage
    {
        private DateTime _date;
        private string _body;

        public DateTime Date
        {
            get { return _date; }
            set { _date = value; }
        }

        public string Body
        {
            get { return _body; }
            set { _body = value; }
        }
    }
}