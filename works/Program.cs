class Program
{
    private static string GetUserInput(string prompt, Func<string, bool> validationFunc = null)
    {
        Console.WriteLine(prompt);
        string userInput = Console.ReadLine();

        // Validate the user input based on the provided validation function (if any)
        while (string.IsNullOrWhiteSpace(userInput) || (validationFunc != null && !validationFunc(userInput)))
        {
            Console.WriteLine("Invalid input. Please provide a valid response:");
            userInput = Console.ReadLine();
        }

        return userInput;
    }
    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("Select an activity:");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflection Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Exit");

            // Read user input
            if (int.TryParse(Console.ReadLine(), out int choice))
            {
                Activity selectedActivity = null;
                int duration = 0;

                switch (choice)
                {
                    case 1:
                        selectedActivity = new BreathingActivity();
                        break;
                    case 2:
                        // Ask for duration for ReflectionActivity
                        Console.WriteLine("Enter the duration of the activity in seconds:");
                        if (int.TryParse(Console.ReadLine(), out duration) && duration > 0)
                        {
                            selectedActivity = new ReflectionActivity(duration);
                        }
                        else
                        {
                            Console.WriteLine("Invalid duration. Please enter a positive integer.");
                            continue; // Restart the loop if the duration is invalid
                        }
                        break;
                    case 3:
                        selectedActivity = new ListingActivity();
                        break;
                    case 4:
                        Environment.Exit(0); // Exit the program
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        continue;
                }

                selectedActivity.StartActivity(); // Start the selected activity

                selectedActivity.EndActivity(); // Display ending message
            }
            else
            {
                Console.WriteLine("Invalid choice. Please try again.");
            }
        }
    }
}