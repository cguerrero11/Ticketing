using System;
using System.IO;

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
                Console.WriteLine("1) Read data from the file.");
                Console.WriteLine("2) Create a new new record.");
                Console.WriteLine("Enter any other key to exit.");
                choice = Console.ReadLine();

                if (choice == "1")
                {
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
                else if (choice == "2")
                {
                    // create file from data
                    StreamWriter sw = new StreamWriter(file, true);
                    Ticket ticket = new Ticket();
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
                    ticket.assigned = Console.ReadLine();
                    Console.WriteLine("Enter watchers.");
                    ticket.watchers = Console.ReadLine();

                    sw.WriteLine(ticket.id + "," + ticket.summary + "," + ticket.status + "," + ticket.priority + "," 
                    + ticket.submitter + "," + ticket.assigned + "," + ticket.watchers + "\n");


                    sw.Close();
                    Console.WriteLine();
                }
            } while (choice == "1" || choice == "2");
        }
    }
}
