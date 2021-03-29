using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Ticketing
{
    public abstract class TicketFile
    {
        public string filePath { get; set; }
        public List<Ticket> Tickets {get; set;}

    }

    public class BugDefectFile : TicketFile
    {
        public BugDefectFile(string path){
            filePath = path;
            StreamReader sr = new StreamReader(filePath);
            while (!sr.EndOfStream)
            {
                BugDefect ticket = new BugDefect();
                string line = sr.ReadLine();
                string[] ticketDetails = line.Split(',');
                ticket.id = ticketDetails[0];
                ticket.summary = ticketDetails[1];
                ticket.status = ticketDetails[2];
                ticket.priority = ticketDetails[3];
                ticket.submitter = ticketDetails[4];
                ticket.assigned = ticketDetails[5].Split("|").ToList();
                ticket.watchers = ticketDetails[6].Split("|").ToList();

                ticket.severity = ticketDetails[7];
            }

        }

    }

    public class TaskFile : TicketFile
    {
        public TaskFile(string path){
            filePath = path;
            StreamReader sr = new StreamReader(filePath);
            Task ticket = new Task();
                string line = sr.ReadLine();
                string[] ticketDetails = line.Split(',');
                ticket.id = ticketDetails[0];
                ticket.summary = ticketDetails[1];
                ticket.status = ticketDetails[2];
                ticket.priority = ticketDetails[3];
                ticket.submitter = ticketDetails[4];
                ticket.assigned = ticketDetails[5].Split("|").ToList();
                ticket.watchers = ticketDetails[6].Split("|").ToList();

                ticket.projectName = ticketDetails[7];
                ticket.dueDate = ticketDetails[8];

        }


    }
    public class EnhancementFile : TicketFile
    {
        public EnhancementFile(string path){
            filePath = path;
            StreamReader sr = new StreamReader(filePath);
            Enhancement ticket = new Enhancement();
                string line = sr.ReadLine();
                string[] ticketDetails = line.Split(',');

                ticket.id = ticketDetails[0];
                ticket.summary = ticketDetails[1];
                ticket.status = ticketDetails[2];
                ticket.priority = ticketDetails[3];
                ticket.submitter = ticketDetails[4];
                ticket.assigned = ticketDetails[5].Split("|").ToList();
                ticket.watchers = ticketDetails[6].Split("|").ToList();

                ticket.software = ticketDetails[7];
                ticket.cost = ""  + ticketDetails[8];
                ticket.reason = ticketDetails[9];
                ticket.estimate = ticketDetails[10];
                
        }
    }
}

