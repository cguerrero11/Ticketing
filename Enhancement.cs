using System;
using System.Collections.Generic;

namespace Ticketing
{
    public class Enhancement : Ticket
    {
        public string software {get; set;}
        public string cost {get; set;}
        public string reason {get; set;}
        public string estimate {get; set;}
    }
}