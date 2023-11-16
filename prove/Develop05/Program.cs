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

        }
    }
}