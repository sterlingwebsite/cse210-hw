using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        // Example usage of the classes
        Scripture scripture = new Scripture("John 3:16", "For God so loved the world...");
        
        do
        {
            scripture.Display();
            Console.WriteLine("Press Enter to continue or type 'quit' to exit.");
            string userInput = Console.ReadLine().ToLower();

            if (userInput == "quit")
            {
                break;
            }

            scripture.HideRandomWords();
            Console.Clear();
        } while (!scripture.AllWordsHidden());

        Console.WriteLine("All words in the scripture are hidden. Program ended.");
    }
}