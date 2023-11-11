public class Program
{
    static void Main(string[] args)
    {
        MenuOptionHandler optionHandler = new MenuOptionHandler();
        MenuDisplay menuDisplay = new MenuDisplay();
        MenuHandler menuHandler = new MenuHandler(optionHandler, menuDisplay);
        menuHandler.Run();
    }
}

public class MenuHandler
{
    private readonly MenuOptionHandler optionHandler;
    private readonly MenuDisplay menuDisplay;

    public MenuHandler(MenuOptionHandler optionHandler, MenuDisplay menuDisplay)
    {
        this.optionHandler = optionHandler;
        this.menuDisplay = menuDisplay;
    }

    public void Run()
    {
        while (true)
        {
            menuDisplay.Display();
            if (int.TryParse(Console.ReadLine(), out int choiceNumber))
            {
                if (IsValidChoice(choiceNumber))
                {
                    ExecuteMenuOption(choiceNumber);
                }
                else
                {
                    menuDisplay.DisplayInvalidChoiceMessage();
                }
            }
            else
            {
                menuDisplay.DisplayInvalidInputMessage();
            }
        }
    }

    private bool IsValidChoice(int choiceNumber)
    {
        return choiceNumber >= 1 && choiceNumber <= 6;
    }

    private void ExecuteMenuOption(int choiceNumber)
    {
        switch (choiceNumber)
        {
            case 1:
                optionHandler.HandleCreateNewGoals();
                break;
            case 2:
                optionHandler.HandleListGoals();
                break;
            case 3:
                optionHandler.HandleSaveGoals();
                break;
            case 4:
                optionHandler.HandleLoadGoals();
                break;
            case 5:
                optionHandler.HandleRecordEvent();
                break;
            case 6:
                optionHandler.HandleQuit();
                break;
            default:
                DisplayInvalidChoiceMessage();
                break;
        }
    }

    private void DisplayInvalidChoiceMessage()
    {
        Console.WriteLine("Invalid menu choice. Please select a number between 1 and 6.");
    }
}

public class MenuDisplay
{
    public void Display()
    {
        Console.WriteLine("\nYou have 0 points.\n");
        Console.WriteLine("Menu Options");
        Console.WriteLine("     1. Create New Goals");
        Console.WriteLine("     2. List Goals");
        Console.WriteLine("     3. Save Goals");
        Console.WriteLine("     4. Load Goals");
        Console.WriteLine("     5. Record Event");
        Console.WriteLine("     6. Quit");
        Console.Write("Select a choice from the menu: ");
    }

    public void DisplayInvalidChoiceMessage()
    {
        Console.WriteLine("Invalid menu choice. Please select a number between 1 and 6.");
    }

    public void DisplayInvalidInputMessage()
    {
        Console.WriteLine("Invalid input. Please enter a valid number.");
    }
}

public class MenuOptionHandler
{
    public void HandleCreateNewGoals()
    {
        // TODO: Implement creating a new goal using base class and extra class
        // Example: CreateNewGoalsHandler.Handle();

        // More details:
        // You can create a class named CreateNewGoalsHandler that contains the logic
        // for creating a new goal. Consider using a base class for common functionality
        // and an extra class for specialized or additional features related to goal creation.
}

    public void HandleListGoals()
    {
        // TODO: Implement creating list goals using base class and extra class
        // Example: GoalsListHandler.Display();
    }

    public void HandleSaveGoals()
    {
        try
        {
            // TODO: Implement saving goals to a file using base class, first extra class, and a third extra class
            // Example: GoalsSaver.Save();
            Console.WriteLine("Goals saved successfully!");
        }
        catch (IOException ioEx)
        {
            HandleIOException(ioEx, "Error saving goals");
        }
        catch (Exception ex)
        {
            HandleException(ex, "Error saving goals");
        }
    }

    public void HandleLoadGoals()
    {
        try
        {
            // TODO: Implement loading goals from a file using base class and fourth extra class
            // Example: GoalsLoader.Load();
            Console.WriteLine("Goals loaded successfully!");
        }
        catch (IOException ioEx)
        {
            HandleIOException(ioEx, "Error loading goals");
        }
        catch (Exception ex)
        {
            HandleException(ex, "Error loading goals");
        }
    }

    public void HandleRecordEvent()
    {
        // TODO: Implement creating record an event using base class and fifth extra class
        // Example: EventRecorder.Record();
    }

    public void HandleQuit()
    {
        // TODO: Implement creating quit the program (add cleanup code if necessary)
        // Example: QuitHandler.PerformCleanup();
    }

    private void HandleIOException(IOException ioEx, string errorMessage)
    {
        Console.WriteLine($"{errorMessage}: {ioEx.Message}");
        Console.WriteLine($"Stack Trace: {ioEx.StackTrace}");
    }

    private void HandleException(Exception ex, string errorMessage)
    {
        Console.WriteLine($"{errorMessage}: {ex.Message}");
        Console.WriteLine($"Stack Trace: {ex.StackTrace}");
    }
}