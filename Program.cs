using System;
using System.IO;
using System.Linq;

namespace Ticketing
{
    class Program
    {
        static void Main(string[] args)
        {
            string file = "Ticket.csv";


            string choice;
            do
            {
                Console.WriteLine("1) Read Bug/Defect tickets.");
                Console.WriteLine("2) Create a Bug/Defect ticket.");
                Console.WriteLine("3) Read Enhancement tickets.");
                Console.WriteLine("4) Create an Enhancment ticket.");
                Console.WriteLine("5) Read Task tickets.");
                Console.WriteLine("6) Create a Task ticket.");
                Console.WriteLine("7) Search tickets.");
                Console.WriteLine("Enter any other key to exit.");
                choice = Console.ReadLine();

                if (choice == "1" || choice == "3" || choice == "5")
                {
                    if(choice == "3"){
                        file = "Enhancements.csv";
                    } 
                    else if (choice == "5"){
                        file = "Task.csv";
                    } else if (choice == "1"){
                        file = "Ticket.csv";
                    }
                    try {
                    StreamReader sr = new StreamReader(file);
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        Console.WriteLine(line);
                    }
                        sr.Close();
                    } catch (Exception e){
                        Console.WriteLine(e);
                    }
                    
                }
                else if (choice == "2" || choice == "4"  || choice == "6")
                {
                    // create file from data
                    
                    Ticket ticket = new BugDefect();
                    Console.WriteLine("Enter Ticket ID.");
                    ticket.id = Console.ReadLine();
                    Console.WriteLine("Enter summary.");
                    ticket.summary = Console.ReadLine();
                    Console.WriteLine("Enter status.");
                    ticket.status = Console.ReadLine();
                    Console.WriteLine("Enter priority.");
                    ticket.priority = Console.ReadLine();
                    Console.WriteLine("Enter name of submitter");
                    ticket.submitter = Console.ReadLine();
                    Console.WriteLine("Enter names of assigned people.");
                    string input;
                        do
                        {
                            Console.WriteLine("Enter genre (or done to quit)");
                            input = Console.ReadLine();
                            if (input != "done" && input.Length > 0)
                            {
                                ticket.assigned.Add(input);
                            }
                        } while (input != "done");
                        if (ticket.assigned.Count == 0)
                        {
                            ticket.assigned.Add("(no one assigned)");
                        }
                    Console.WriteLine("Enter watchers.");
                    do
                        {
                            Console.WriteLine("Enter genre (or done to quit)");
                            input = Console.ReadLine();
                            if (input != "done" && input.Length > 0)
                            {
                                ticket.watchers.Add(input);
                            }
                        } while (input != "done");

                        if (ticket.watchers.Count == 0)
                        {
                            ticket.watchers.Add("(no watchers)");
                        }

                        if(choice == "2"){
                            BugDefect bug = (BugDefect)ticket;
                            getTicketInfo(bug, file);
                        } 
                        else if (choice == "4"){
                            file = "Enhancements.csv";
                            Enhancement enhancement = (Enhancement)ticket;
                            getEnhancementInfo(enhancement, "file");
                        }
                        else if (choice == "6"){
                            file = "Task.csv";
                            Task task = (Task)ticket;
                            getTaskInfo(task, file);
                        }

                    // sw.WriteLine(ticket.id + "," + ticket.summary + "," + ticket.status + "," + ticket.priority + "," 
                    // + ticket.submitter + "," + assigned + "," + watchers + "\n");


                    
                    Console.WriteLine();
                } else if(choice == "7"){
                    //search tickets by status, priority, and submitter
                    //search all ticket, task, and enhancement
                    BugDefectFile ticketFile = new BugDefectFile(file);
                    TaskFile taskFile = new TaskFile("Task.csv");
                    EnhancementFile enhancementFile = new EnhancementFile("Enhancements.csv");

                    Console.WriteLine("1) Search by Status");
                    Console.WriteLine("2) Search by Priority");
                    Console.WriteLine("3) Search by Submitter");
                    string input = Console.ReadLine().ToString();

                    if(input == "1"){
                        //status
                        Console.Write("Search by Status: ");
                        input = Console.ReadLine();

                        var searchCount = ticketFile.Tickets.Where(t => t.status.Contains(input)).Count() + taskFile.Tickets.Where(t => t.status.Contains(input)).Count() + enhancementFile.Tickets.Where(t => t.status.Contains(input)).Count();                  
                        Console.Write(searchCount + " Tickets matching.");

                        var ticketSearch = ticketFile.Tickets.Where(t => t.status.Contains(input)).Select(m => m.summary);
                        foreach(string t in ticketSearch)
                        {
                            Console.WriteLine($"  {t}");
                        }

                    } else if (input == "2"){
                        //priority
                        Console.Write("Search by Priorty: ");
                        input = Console.ReadLine();

                    } else if (input == "3"){
                        //submitter
                        Console.Write("Search Submitters: ");
                        input = Console.ReadLine();

                    }

                }
            } while (choice == "1" || choice == "2" || choice == "3" || choice == "4" || choice == "5" || choice == "6" || choice == "7");
        }
        public static void getTicketInfo(BugDefect ticket, string file){
            StreamWriter sw = new StreamWriter(file, true);
            Console.WriteLine("Enter severity");
            ticket.severity = Console.ReadLine();

            string assigned = String.Join("|", ticket.assigned);
            string watchers = String.Join("|", ticket.watchers);
            sw.WriteLine(ticket.id + "," + ticket.summary + "," + ticket.status + "," + ticket.priority + "," 
                    + ticket.submitter + "," + assigned + "," + watchers + "," + ticket.severity + "\n");

            sw.Close();
            Console.WriteLine("Successfully added.");
        }
        public static void getTaskInfo(Task ticket, string file){
            StreamWriter sw = new StreamWriter(file, true);
            Console.WriteLine("Enter name of project");
            ticket.submitter = Console.ReadLine();
            Console.WriteLine("Enter due date");
            ticket.submitter = Console.ReadLine();

            string assigned = String.Join("|", ticket.assigned);
            string watchers = String.Join("|", ticket.watchers);
            sw.WriteLine(ticket.id + "," + ticket.summary + "," + ticket.status + "," + ticket.priority + "," 
                    + ticket.submitter + "," + assigned + "," + watchers + "," + ticket.projectName + "," + ticket.dueDate + "\n");
            sw.Close();
            Console.WriteLine("Successfully added.");

        }
        public static void getEnhancementInfo(Enhancement ticket, string file){
            StreamWriter sw = new StreamWriter(file, true);
            Console.WriteLine("Enter name of software");
            ticket.submitter = Console.ReadLine();
            Console.WriteLine("Enter cost");
            ticket.submitter = Console.ReadLine();
            Console.WriteLine("Enter reason");
            ticket.submitter = Console.ReadLine();
            Console.WriteLine("Enter estimate");
            ticket.submitter = Console.ReadLine();

            string assigned = String.Join("|", ticket.assigned);
            string watchers = String.Join("|", ticket.watchers);
            sw.WriteLine(ticket.id + "," + ticket.summary + "," + ticket.status + "," + ticket.priority + "," 
                    + ticket.submitter + "," + assigned + "," + watchers + "," + ticket.software + ",$" + ticket.cost + "," + ticket.reason + "," + ticket.estimate + "\n");
        
            sw.Close();
            Console.WriteLine("Successfully added.");
        }
    }

    
}
