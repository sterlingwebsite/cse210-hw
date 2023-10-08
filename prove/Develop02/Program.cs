using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the Journal Program!");
        string userResponse = "";
        Journal journal = new Journal();
        do
        {
            Console.WriteLine("Please select one of the following choices:");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Load");
            Console.WriteLine("4. Save");
            Console.WriteLine("5. Quit");
            Console.Write("What would you like to do? ");
            userResponse = Console.ReadLine();
            if (userResponse == "1")
            {
               journal.AddEntry();
            }
            else if (userResponse == "2")
            {
                journal.DisplayJournal();
            }
            else if (userResponse == "3")
            {
                journal.LoadJournal();                
            }
            else if (userResponse == "4")
            {
                journal.SaveJournal();
            }
            else if (userResponse == "5")
            {
            }
            else
            {
                Console.WriteLine("Please type a valid number.");
            }
            Console.WriteLine();
        }
        while(userResponse != "5");
    }
}