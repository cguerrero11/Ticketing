using System;
using System.Collections.Generic;

namespace Ticketing
{
    public abstract class Ticket
    {
        public string id {get; set;}
        public string summary {get; set;}
        public string status {get; set;}
        public string priority {get; set;}
        public string submitter {get; set;}
        public List<string> assigned {get; set;}
        public List<string> watchers {get; set;}
        public string severity {get; set;}
    }
}