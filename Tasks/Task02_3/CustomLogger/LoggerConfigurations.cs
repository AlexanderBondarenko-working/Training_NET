﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CustomLogger
{
    public class LoggerConfigurations
    {
        public LoggingLevel MinLoggingLevel { get; private set; } = LoggingLevel.Debug;
        public List<ListenerConfiguration> ListenerConfigurations;
    }
}
