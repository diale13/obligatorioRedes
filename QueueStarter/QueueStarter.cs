using System.Messaging;
using System;
using System.Configuration;

namespace QueueStarter
{
    public class QueueStarter
    {
        public static void Main(string[] args)
        {
            string queuePath = ConfigurationManager.AppSettings["PATH"];
            PATH.QueuePath = queuePath;
            if (!MessageQueue.Exists(queuePath))
            {
                MessageQueue.Create(queuePath);
            }
        }

    }
}
