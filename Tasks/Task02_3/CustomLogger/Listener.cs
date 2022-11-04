using System;

namespace CustomLogger
{
    public interface Listener
    {
        public void Write(object obj);
    }
}
