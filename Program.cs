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
                    Console.WriteLine("Enter Ticket ID.");
                    // id = Console.ReadLine();
                    Console.WriteLine("Enter summary.");
                    // summary = Console.ReadLine();
                    Console.WriteLine("Enter status.");
                    // status = Console.ReadLine();
                    Console.WriteLine("Enter priority.");
                    // priority = Console.ReadLine();
                    Console.WriteLine("Enter name of submitter");
                    // submitter = Console.ReadLine();
                    Console.WriteLine("Enter names of assigned people.");
                    // assigned = Console.ReadLine();
                    Console.WriteLine("Enter watchers.");
                    // watchers = Console.ReadLine();

                    // sw.WriteLine(id + "," + summary + "," + status + "," + priority + "," 
                    // + submitter + "," + assigned + "," + watchers + "\n");


                    sw.Close();
                    Console.WriteLine();
                }
            } while (choice == "1" || choice == "2");
        }
    }
}
