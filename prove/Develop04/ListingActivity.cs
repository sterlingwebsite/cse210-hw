class ListingActivity : Activity
{
    private string _prompt;
    public ListingActivity() : base("Listing Activity", "Encourages listing positive things in your life.")
    {
        // Constructor for specific prompts related to listing activity
        _prompt = "Think of positive things in your life and start listing them:";
    }

    public override void StartActivity()
    {
        Console.WriteLine($"Starting {_activityName}: {_description}");
        Console.WriteLine("Prepare to begin listing positive things...");

        Console.WriteLine(_prompt);

        List<string> positiveThings = new List<string>();
        bool isListing = true;

        while (isListing)
        {
            string input = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(input)) // Check if the input is empty
            {
                isListing = false;
            }
            else
            {
                positiveThings.Add(input);
            }
        }

        Console.WriteLine($"You've listed {positiveThings.Count} positive things in your life:");
        foreach (var item in positiveThings)
        {
            Console.WriteLine("- " + item);
        }

        Console.WriteLine($"Congratulations! You've completed {_activityName}.");
    }

    public override void EndActivity()
    {
        // Implement common ending message if needed
        base.EndActivity();
    }
}