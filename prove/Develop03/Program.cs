using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Scripture> scriptures = new List<Scripture>
        {
            new Scripture("John", 3, 16, 16, "For God so loved the world, that he gave his only begotten Son, that whosoever believeth in him should not perish, but have everlasting life."),
        };

        try
        {
            foreach (var scripture in scriptures)
            {
                do
                {
                    scripture.Display();
                    Console.WriteLine("Press Enter to continue or type 'quit' to exit.");
                    string userInput = Console.ReadLine().ToLower();

                    if (userInput == "quit")
                    {
                        return;
                    }
                    scripture.HideRandomWords(5);
                    Console.Clear();

                } while (!scripture.AllWordsHidden());
            }

            Console.WriteLine("All words in the scriptures are hidden. Program ended.");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Error: Invalid input - {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
