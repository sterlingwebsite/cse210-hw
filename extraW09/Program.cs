class Program
{
    private const int CreateNewGoals = 1;
    private const int ListGoals = 2;
    private const int SaveGoals = 3;
    private const int LoadGoals = 4;
    private const int RecordEvent = 5;
    private const int Quit = 6;
    static void Main(string[] args)
    {
        string _menuChoice;

        // Display the menu to the user
        DisplayMenu();

        // Get the user's menu choice
        _menuChoice = Console.ReadLine();

        if (int.TryParse(_menuChoice, out int _choiceNumber))
        {
            // Check if the choice number is within the valid range
            if (_choiceNumber >= CreateNewGoals && _choiceNumber <= Quit)
            {
                // Handle the user's menu choice
                HandleMenuOption(_choiceNumber);
            }
            else
            {
                // Display an error message for an invalid menu choice
                Console.WriteLine("Invalid menu choice. Please select a number between 1 and 6.");
            }
        }
        else
        {
            // Display an error message for invalid input
            Console.WriteLine("Invalid input. Please enter a valid number.");
        }
    }

    static void DisplayMenu()
    {
        // Display the user's current points
        Console.WriteLine("\nYou have 0 points.\n");

        // Display the menu options
        Console.WriteLine("Menu Options");
        Console.WriteLine("     1. Create New Goals");
        Console.WriteLine("     2. List Goals");
        Console.WriteLine("     3. Save Goals");
        Console.WriteLine("     4. Load Goals");
        Console.WriteLine("     5. Record Event");
        Console.WriteLine("     6. Quit");
        Console.Write("Select a choice from the menu: ");
    }

    /// <summary>
    /// Handles the user's menu choice and executes the corresponding action.
    /// </summary>
    /// <param name="_choiceNumber">The user's menu choice.</param>
    static void HandleMenuOption(int _choiceNumber)
    {
        switch (_choiceNumber)
        {
            case CreateNewGoals:
                // TODO: Implement creating a new goal using base class and extra class (if necessary)
                // Example: CreateNewGoalsHandler.Handle();
                break;
            case ListGoals:
                // TODO: Implement creating list goals using base class and extra class
                // Example: GoalsListHandler.Display();
                break;
            case SaveGoals:
                try
                {
                    // TODO: Implement saving goals to a file using base class, first extra class, and a third extra class
                    // Example: GoalsSaver.Save();
                    Console.WriteLine("Goals saved successfully!");
                }
                catch (IOException ioEx)
                {
                    Console.WriteLine($"Failed to save goals due to an IO error: {ioEx.Message}");
                    Console.WriteLine($"Stack Trace: {ioEx.StackTrace}");
                }
                catch (Exception ex)
                {
                    HandleException(ex, "Failed to save goals due to an unexpected error");
                }
                break;

            case LoadGoals:
                try
                {
                    // TODO: Implement loading goals from a file using base class and fourth extra class
                    // Example: GoalsLoader.Load();
                    Console.WriteLine("Goals loaded successfully!");
                }
                catch (IOException ioEx)
                {
                    Console.WriteLine($"Failed to load goals due to an IO error: {ioEx.Message}");
                    Console.WriteLine($"Stack Trace: {ioEx.StackTrace}");
                }
                catch (Exception ex)
                {
                    HandleException(ex, "Failed to load goals due to an unexpected error");
                }
                break;
                
            case RecordEvent:
                // TODO: Implement creating record an event using base class and fifth extra class
                // Example: EventRecorder.Record();
                break;
            case Quit:
                // TODO: Implement creating quit the program (add cleanup code if necessary)
                // Example: QuitHandler.PerformCleanup();
                break;
            default:
                Console.WriteLine("Invalid menu choice. Please select a number between 1 and 6."); //this checks if the user entered a number within 1 and 6
                break;
        }
    }

    static void HandleException(Exception ex, string errorMessage)
    {
        // Print to console
        Console.WriteLine($"{errorMessage}: {ex.Message}");
        Console.WriteLine($"Stack Trace: {ex.StackTrace}");

        // Log to a file using System.Diagnostics
        LogExceptionToFile(ex, errorMessage);
    }

    static void LogExceptionToFile(Exception ex, string errorMessage)
    {
        string logFilePath = "error.log"; // Adjust the file path as needed

        try
        {
            using (StreamWriter writer = new StreamWriter(logFilePath, true))
            {
                writer.WriteLine($"[{DateTime.Now}] {errorMessage}: {ex.Message}");
                writer.WriteLine($"Stack Trace: {ex.StackTrace}");
                writer.WriteLine(new string('-', 40)); // Separation between log entries
            }
        }
        catch (IOException ioEx)
        {
            // If logging fails, print the error to the console
            Console.WriteLine($"Error logging exception to file: {ioEx.Message}");
            Console.WriteLine($"Original Exception: {errorMessage}: {ex.Message}");
            Console.WriteLine($"Stack Trace: {ex.StackTrace}");
        }
    }
}