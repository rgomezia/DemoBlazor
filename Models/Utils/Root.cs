﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoBlazor.Shared.Utils
{
    public class Message
    {
        public string lang { get; set; }
        public string value { get; set; }
    }

    public class Error
    {
        public int code { get; set; }
        public Message message { get; set; }
    }

    public class Root
    {
        public Error error { get; set; }
    }
}
