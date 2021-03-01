using System;

namespace Ticketing
{
    public class Ticket
    {
        public string id {get; set;}
        public string summary {get; set;}
        public string status {get; set;}
        public string priority {get; set;}
        public string submitter {get; set;}
        public string assigned {get; set;}
        public string watchers {get; set;}
    }
}