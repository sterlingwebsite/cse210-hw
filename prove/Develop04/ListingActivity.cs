public class ListingActivity : Activity
{
    private int _duration;
    private int originalDuration;
    private string specialPrompt;
    private List<string> specialPrompts;
    private int numberOfAnswers;

    public ListingActivity()
    {
        specialPrompts = new List<string>
        {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?"
        };
    }

    public void ListingActivityOpeningPrompt()
    {
            Console.Clear();
            Console.WriteLine("Welcome to the Listing Activity");
            Console.WriteLine("This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.");
            Console.WriteLine("How long, in seconds, would you like for your session?");
            originalDuration = _duration = int.Parse(Console.ReadLine());

    }
    public void ListingActivitySecondPrompt()
    {
        Console.Clear();
        Console.WriteLine("Get ready...");
        RunSpinner(4);
    }

    public void ListingActivityMainPrompt()
    {
        Console.Clear();
        Console.WriteLine("List as many responses as you can to the following prompt:");
        specialPrompt = GetRandomItem(specialPrompts);
        Console.WriteLine($"--- {specialPrompt} ---");
        Console.WriteLine("You may begin in:");
        RunCountdown5(5);
        // Collect user responses within the specified duration
        DateTime endTime = DateTime.Now.AddSeconds(_duration);
        numberOfAnswers = 0;

        while (DateTime.Now < endTime)
        {
            string userInput = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(userInput))
            {
                numberOfAnswers++;
            }
        }

        Console.WriteLine($"You listed {numberOfAnswers} items!");
        Console.WriteLine(); // Output a blank line
    }

    public void ListingActivityClosingPrompt()
    {
        Console.WriteLine("Well done!");
        RunSpinner(5);
    }

    public void ListingActivityClosingPromptTwo()
    {
        Console.WriteLine($"You have completed {originalDuration} seconds of the Listing Activity");
        RunSpinner(3);
    }

    // program is complete

    private void RunSpinner(int durationInSeconds)
    {
        string[] spinner = { "-", "\\", "|", "/" };
        int index = 0;
        for (int i = 0; i < durationInSeconds * 10; i++) // Assuming each spin takes 0.1 seconds
        {
            Console.Write($"\r{spinner[index]}");
            Thread.Sleep(100); // Wait for 0.1 seconds
            index = (index + 1) % spinner.Length;
        }
        Console.WriteLine(); // Move to the next line after the spinner is done
    }

    private string GetRandomItem(List<string> list)
    {
        Random random = new Random();
        int index = random.Next(0, list.Count);
        string item = list[index];
        list.RemoveAt(index); // Remove the selected item to prevent repetition
        return item;
    }

    private void RunCountdown5(int durationInSeconds)
    {
        string[] countdown = { "5", "4", "3", "2", "1" };
        int index = 0;
        for (int i = 0; i < durationInSeconds; i++)
        {
            Console.Write($"\r{countdown[index]}");
            Thread.Sleep(1000);
            index = (index + 1) % countdown.Length;
        }
        Console.WriteLine();
    }

    public override void StartActivity()
    {
        ListingActivityOpeningPrompt();
        ListingActivitySecondPrompt();
        ListingActivityMainPrompt();
        ListingActivityClosingPrompt();
        ListingActivityClosingPromptTwo();
    }
}
