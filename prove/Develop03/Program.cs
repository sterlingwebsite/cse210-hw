using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Create a list of Scriptures
        List<Scripture> scriptures = new List<Scripture>
        {
            new Scripture("John", 3, 16, 16, "For God so loved the world..."),
            // Add more scriptures if needed
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

                    // Logic to hide random words in the scripture
                    scripture.HideRandomWords(5); // Change 5 to the number of words you want to hide
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
