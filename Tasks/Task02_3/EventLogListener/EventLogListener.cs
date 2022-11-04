using System;

namespace EventLogListener
{
    public class EventLogListener : CustomLogger.IListener
    {
        public void Write(object obj)
        {
            throw new NotImplementedException();
        }
    }
}
