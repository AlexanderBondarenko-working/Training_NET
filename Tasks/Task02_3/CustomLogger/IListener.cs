using System;

namespace CustomLogger
{
    public interface IListener
    {
        public void Write(object obj);
    }
}
