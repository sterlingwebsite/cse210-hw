using Microsoft.VisualBasic;

public class Base
{
    static List<Base> goalsList = new List<Base>();

    public string Goal { get; set; }
    public int Points { get; set; }
    public bool IsCompleted { get; set; }
    public bool Eternal { get; set; }
    public int Completions { get; set; }
    public bool Checklist { get; set; }
    public static int Score { get; set; }
    public int ChecklistCounter { get; set; }
    public int BonusPoints { get; set; }
    public bool Negative { get; set; }

    public static void DisplayMenu()
    {
        Console.WriteLine("Welcome to the Main Menu");
        Console.WriteLine($"Your score is {Score}");
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
                LoadScore();
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
        Console.WriteLine("4. Create a new Negative Goal");
        Console.WriteLine("5. Return to Main Menu");

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
                CreateEternalGoal(out string goal2, out int points2, out bool eternal);
                SaveNewGoalToMainListE(goal2, points2, eternal);
                Console.WriteLine("New goal saved!");
                Console.WriteLine();
                DisplayGoalTypeSelectionMenu();
                break;

            case 3:
                Console.WriteLine("\nYou selected to Create a new Checklist Goal");
                CreateChecklistGoal(out string goal3, out int points3, out int completions, out int bonusPoints, out int checklistCounter, out bool checklist);
                SaveNewGoalToMainListC(goal3, points3, completions, bonusPoints, checklistCounter, checklist);
                Console.WriteLine("New goal saved!");
                Console.WriteLine();
                DisplayGoalTypeSelectionMenu();
                break;

            case 4:
                Console.WriteLine("\nYou selected to Create a new Negative Goal");
                CreateNegativeGoal(out string goal4, out int points4, out bool negative);
                SaveNewGoalToMainListN(goal4, points4, negative);
                Console.WriteLine("New goal saved!");
                Console.WriteLine();
                DisplayGoalTypeSelectionMenu();
                break;

            case 5:
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
        Console.Write("Enter your choice (1-5): ");
        int choice;

        while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 5)
        {
            Console.WriteLine("\nInvalid input. Please enter a number between 1 and 5.");
            Console.Write("Enter your choice (1-5): ");
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
            Console.WriteLine($"{counter} Goal: {goal.Goal}, Points: {goal.Points}, Completed: {goal.IsCompleted}, Eternal: {goal.Eternal}, Completions: {goal.Completions}, Bonus Points: {goal.BonusPoints} Checklist Counter: {goal.ChecklistCounter}, Checklist: {goal.Checklist}, Negative: {goal.Negative}");
            counter ++;
        }
    }

    public override string ToString()
    {
        return $"{Goal}|{Points}|{IsCompleted}|{Eternal}|{Completions}|{BonusPoints}|{ChecklistCounter}|{Checklist}|{Negative}";
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
        string fileName2 = "score.txt";
        using (StreamWriter writer2 = new StreamWriter(fileName2))
        {
            writer2.WriteLine(Score);
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
                    if (parts.Length == 9)
                    {
                        string goal = parts[0];
                        int points;
                        if (int.TryParse(parts[1], out points))
                        {
                            bool isCompleted;
                            if (bool.TryParse(parts[2], out isCompleted))
                            {
                                bool eternal;
                                if (bool.TryParse(parts[3], out eternal))
                                {
                                    int completions;
                                    if (int.TryParse(parts[4], out completions))
                                    {
                                        int bonusPoints;
                                        if (int.TryParse(parts[5], out bonusPoints))
                                        {
                                            int checklistCounter;
                                            if (int.TryParse(parts[6], out checklistCounter))
                                            {
                                                bool checklist;
                                                if (bool.TryParse(parts[7], out checklist))
                                                {
                                                    bool negative;
                                                    if (bool.TryParse(parts[8], out negative))
                                                    {
                                                        Base goalObject = new Base { Goal = goal, Points = points, IsCompleted = isCompleted, Eternal = eternal, Completions = completions, BonusPoints = bonusPoints, ChecklistCounter = checklistCounter, Checklist = checklist, Negative = negative };
                                                        goalsList.Add(goalObject);
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            return goalsList;
        }

    static void LoadScore()
    {
        string fileName2 = "score.txt";
        using (StreamReader reader = new StreamReader(fileName2))
        {
            string content = reader.ReadToEnd();

            if (int.TryParse(content, out int score))
            {
                Score = score;
            }
            else
            {
                Console.WriteLine("Error: Unable to parse score from file.");
            }
        }
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
        completedGoalIndex --;
        if (goalsList[completedGoalIndex].Eternal == false && goalsList[completedGoalIndex].Checklist == false && goalsList[completedGoalIndex].Negative == false)
        {
            goalsList[completedGoalIndex].IsCompleted = true;
            Console.WriteLine($"Congratulations! You completed {goalsList[completedGoalIndex].Goal}. You earned {goalsList[completedGoalIndex].Points} points.");
            Score += goalsList[completedGoalIndex].Points;
        }
        else if (goalsList[completedGoalIndex].Eternal == true && goalsList[completedGoalIndex].Checklist == false)
        {
            Console.WriteLine($"Congratulations! You completed {goalsList[completedGoalIndex].Goal}. You earned {goalsList[completedGoalIndex].Points} points.");
            Score += goalsList[completedGoalIndex].Points;
        }
        else if (goalsList[completedGoalIndex].Eternal == false && goalsList[completedGoalIndex].Checklist == true)
        {
            Console.WriteLine($"Congratulations! You completed {goalsList[completedGoalIndex].Goal}. You earned {goalsList[completedGoalIndex].Points} points.");
            Score += goalsList[completedGoalIndex].Points;
            goalsList[completedGoalIndex].ChecklistCounter ++;
            if (goalsList[completedGoalIndex].ChecklistCounter == goalsList[completedGoalIndex].Completions)
            {
                Console.WriteLine($"Congratulations! You completed your {goalsList[completedGoalIndex].Goal} checklist goal and earned {goalsList[completedGoalIndex].BonusPoints} bonus points.");
                Score += goalsList[completedGoalIndex].BonusPoints;
                goalsList[completedGoalIndex].IsCompleted = true;
            }
        }
        else if (goalsList[completedGoalIndex].Eternal == false && goalsList[completedGoalIndex].Checklist == false && goalsList[completedGoalIndex].Negative == true )
        {
            Console.WriteLine($"I'm sorry. You completed {goalsList[completedGoalIndex].Goal}. You lost {goalsList[completedGoalIndex].Points} points.");
            Score -= goalsList[completedGoalIndex].Points;
        }
    }

    static void CreateEternalGoal(out string goal, out int points, out bool eternal)
    {
        Console.Write("What is your goal? ");
        goal = Console.ReadLine();
        Console.Write("How many points is your goal worth? ");
        points = int.Parse(Console.ReadLine());
        eternal = true;
    }

    static void SaveNewGoalToMainListE(string goal, int points, bool eternal)
    {
        Base newGoal = new Base { Goal = goal, Points = points, Eternal = eternal };
        goalsList.Add(newGoal);

    }

    static void CreateChecklistGoal(out string goal, out int points, out int completions, out int bonusPoints, out int checklistCounter, out bool checklist)
    {
        Console.Write("What is your goal? ");
        goal = Console.ReadLine();
        Console.Write("How many points is your goal worth? ");
        points = int.Parse(Console.ReadLine());
        Console.Write("How many completions before your goal is completed? ");
        completions = int.Parse(Console.ReadLine());
        Console.Write("How many bonus points are awarded when your goal is completed? ");
        bonusPoints = int.Parse(Console.ReadLine());
        checklistCounter = 0;
        checklist = true;
    }

    static void SaveNewGoalToMainListC(string goal, int points, int completions, int bonusPoints, int checklistCounter, bool checklist)
    {
        Base newGoal = new Base { Goal = goal, Points = points, Completions = completions, BonusPoints = bonusPoints, ChecklistCounter = checklistCounter, Checklist = checklist};
        goalsList.Add(newGoal);
    }

    static void CreateNegativeGoal(out string goal, out int points, out bool negative)
    {
        Console.Write("What is your goal? ");
        goal = Console.ReadLine();
        Console.Write("How many points is your goal worth? ");
        points = int.Parse(Console.ReadLine());
        negative = true;
    }

    static void SaveNewGoalToMainListN(string goal, int points, bool negative)
    {
        Base newGoal = new Base { Goal = goal, Points = points, Negative = negative };
        goalsList.Add(newGoal);

    }
}