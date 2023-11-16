class Program
{
    private static object _points;
    private static string _choice;

    static void Main(string[] args)
    {
        Console.WriteLine();
        Console.WriteLine($"You have {_points} points.");
        Console.WriteLine();
        Console.WriteLine("Menu Options");
        Console.WriteLine("     1. Create New Goals");
        Console.WriteLine("     2. List Goals");
        Console.WriteLine("     3. Save Goals");
        Console.WriteLine("     4. Load Goals");
        Console.WriteLine("     5. Record Event");
        Console.WriteLine("     6. Quit");
        Console.Write("Select a choice from the menu: ");
        _choice = Console.ReadLine();

        int _choiceInt =int.Parse(_choice);

        if (_choiceInt == 1)
        {
            // Offer to create a new goal for the user. the new goal is saved temporarily in a list called _goals.
        }
        else if (_choiceInt == 2)
        {
            // Offer to list the goals created by the user, saved in the list: _goals
        }
        else if (_choiceInt == 3)
        {
            // Offer to save the list of goals in a file. Ask for the filname
        }
        else if (_choiceInt == 4)
        {
            // Offer to load goals from a file and save them to the _goals list. Ask for the filename, and load the goals.
        }
        else if (_choiceInt == 5)
        {
            // Offer to record an event for the user. Compare the event to the list of _goals and adjust the list accordingly.
        }
        else if (_choiceInt == 6)
        {
            // Quit the program
        }
    }
}