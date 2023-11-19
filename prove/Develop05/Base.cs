using Microsoft.VisualBasic;

public class Base
{
    static List<Base> goalsList = new List<Base>();
    public string Goal { get; set; }
    public int Points { get; set; }
    public bool IsCompleted { get; set; }

    public static void DisplayMenu()
    {
        Console.WriteLine("Welcome to the Main Menu");
        Console.WriteLine("1. Create a New Goal");
        Console.WriteLine("2. Show the List of Recorded Goals");
        Console.WriteLine("3. Save the List of Recorded Goals to a File");
        Console.WriteLine("4. Load a List of Recorded Goals from a File");
        Console.WriteLine("5. Record Completion of a Goal");
        Console.WriteLine("6. Exit");

        int choice = GetUserChoice();

        switch (choice)
        {
            case 1:
                Console.WriteLine("\nYou selected to Create a New Goal");
                DisplayGoalTypeSelectionMenu();
                break;

            case 2:
                Console.WriteLine("\nYou selected to Show the List of Recorded Goals");
                ShowRecordedGoals();
                Console.WriteLine();
                DisplayMenu();
                break;

            case 3:
                Console.WriteLine("\nYou selected to Save the List of Recorded Goals to a File");
                SaveGoalsToFile();
                Console.WriteLine();
                DisplayMenu();
                break;

            case 4:
                Console.WriteLine("\nYou selected to Load a List of Recorded Goals from a File");
                LoadGoalsFromFile();
                Console.WriteLine();
                DisplayMenu();
                break;

            case 5:
                Console.WriteLine("\nYou selected to Record Completion of a Goal");
                RecordGoalCompletion();
                Console.WriteLine();
                DisplayMenu();
                break;

            case 6:
                Console.WriteLine("\nYou selected to Exit");
                break;

            default:
                Console.WriteLine("\nInvalid choice. Please try again.");
                DisplayMenu();
                break;
        }
    }

    static int GetUserChoice()
    {
        Console.Write("Enter your choice (1-6): ");
        int choice;

        while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 6)
        {
            Console.WriteLine("\nInvalid input. Please enter a number between 1 and 6.");
            Console.Write("Enter your choice (1-6): ");
        }

        return choice;
    }

    static void DisplayGoalTypeSelectionMenu()
    {
        Console.WriteLine("Welcome to the Goal Type Selection Menu");
        Console.WriteLine("1. Create a new Simple Goal");
        Console.WriteLine("2. Create a new Eternal Goal");
        Console.WriteLine("3. Create a new Checklist Goal");
        Console.WriteLine("4. Return to Main Menu");

        int choice = GetUserChoice2();

        switch (choice)
        {
            case 1:
                Console.WriteLine("\nYou selected to Create a new Simple Goal");
                CreateNewSimpleGoal(out string goal, out int points);
                SaveNewGoalToMainList(goal, points);
                Console.WriteLine("New goal saved!");
                Console.WriteLine();
                DisplayGoalTypeSelectionMenu();
                break;

            case 2:
                Console.WriteLine("\nYou selected to Create a new Eternal Goal");
                // Add code for Option 2
                break;

            case 3:
                Console.WriteLine("\nYou selected to Create a new Checklist Goal");
                // Add code for Option 3
                break;

            case 4:
                Console.WriteLine("\nYou selected to Return to Main Menu");
                DisplayMenu();
                break;

            default:
                Console.WriteLine("\nInvalid choice. Please try again.");
                DisplayGoalTypeSelectionMenu();
                break;
        }
    }

    static int GetUserChoice2()
    {
        Console.Write("Enter your choice (1-4): ");
        int choice;

        while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 4)
        {
            Console.WriteLine("\nInvalid input. Please enter a number between 1 and 4.");
            Console.Write("Enter your choice (1-4): ");
        }

        return choice;
    }

    static void CreateNewSimpleGoal(out string goal, out int points)
    {
        Console.Write("What is your goal? ");
        goal = Console.ReadLine();
        Console.Write("How many points is your goal worth? ");
        points = int.Parse(Console.ReadLine());
    }

    static void SaveNewGoalToMainList(string goal, int points)
    {
        Base newGoal = new Base { Goal = goal, Points = points };
        goalsList.Add(newGoal);

    }

    static void ShowRecordedGoals()
    {
        int counter = 1;
        foreach (var goal in goalsList)
        {
            Console.WriteLine($"{counter} Goal: {goal.Goal}, Points: {goal.Points} Completed: {goal.IsCompleted}");
            counter ++;
        }
    }

    public override string ToString()
    {
        return $"{Goal}|{Points}|{IsCompleted}";
    }

    static void SaveGoalsToFile()
    {
        string fileName = "goals.txt";
        List<string> goalsListStrings = goalsList.ConvertAll(obj => obj.ToString());
        using (StreamWriter writer = new StreamWriter(fileName))
        {
            foreach (string goal in goalsListStrings)
            {
                writer.WriteLine(goal);
            }
        }
    }

    static List<Base> LoadGoalsFromFile()
        {
            string fileName = "goals.txt";

            if (File.Exists(fileName))
            {
                string[] lines = File.ReadAllLines(fileName);

                foreach (string line in lines)
                {
                    string[] parts = line.Split('|');
                    if (parts.Length == 3)
                    {
                        string goal = parts[0];
                        int points;
                        if (int.TryParse(parts[1], out points))
                        {
                            bool isCompleted;
                            if (bool.TryParse(parts[2], out isCompleted))
                            {
                                Base goalObject = new Base { Goal = goal, Points = points, IsCompleted = isCompleted };
                                goalsList.Add(goalObject);
                            }
                        }
                    }
                }
            }
            return goalsList;
        }

    static void RecordGoalCompletion()
    {
        Console.WriteLine("Which one of the goals did you complete? ");
        ShowRecordedGoals();
        int completedGoalIndex;
        while (true)
        {
            if (int.TryParse(Console.ReadLine(), out completedGoalIndex) && completedGoalIndex >= 1 && completedGoalIndex <= goalsList.Count)
            {
                break;
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid goal number.");
            }
        }
        goalsList[completedGoalIndex - 1].IsCompleted = true;
        Console.WriteLine(goalsList);
    }
}