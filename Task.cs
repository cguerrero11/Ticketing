using System;
using System.Collections.Generic;

namespace Ticketing
{
    public class Task : Ticket
    {
        public string projectName {get; set;}
        public DateTime dueDate {get; set;}
    }
}