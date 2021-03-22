using System;
using System.Collections.Generic;

namespace Ticketing
{
    public class Task : Ticket
    {
        public string projectName {get; set;}
        public string dueDate {get; set;}
    }
}