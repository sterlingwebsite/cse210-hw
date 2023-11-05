class ReflectionActivity : Activity
{
    private readonly Func<string, bool> _getUserInputFunc;
    protected List<string> _reflectionPrompts;
    private bool _completed; // Flag to track if the activity has been completed

    public ReflectionActivity(int duration) : base("Reflection Activity", "Helps you reflect on your experiences.")
    {
        SetDuration(duration);
        _reflectionPrompts = new List<string>
        {
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you did something truly selfless."
        };
        _completed = false; // Initialize the flag
    }

    private string GetUserInput(string prompt)
    {
        Console.WriteLine(prompt);
        string userInput = Console.ReadLine();

        // Validate the user input
        while (string.IsNullOrWhiteSpace(userInput))
        {
            Console.WriteLine("Invalid input. Please provide a valid response:");
            userInput = Console.ReadLine();
        }

        return userInput;
    }
    public override void StartActivity()
    {
        Console.WriteLine($"Starting {_activityName}: {_description}");
        Console.WriteLine("Prepare to begin reflection...");

        foreach (var prompt in _reflectionPrompts)
        {
            Console.WriteLine(prompt);
            System.Threading.Thread.Sleep(2000); // Pause for 2 seconds (2000 milliseconds)
            Console.WriteLine("Take your time to reflect...");
            System.Threading.Thread.Sleep(5000); // Pause for 5 seconds (5000 milliseconds)

            if (_duration <= 0)
            {
                _completed = true; // Set the flag to indicate activity completion
                break; // Exit the loop if the duration is exhausted
            }

            AskReflectionQuestions(); // Ask reflection questions after each prompt
        }

        if (!_completed)
        {
            Console.WriteLine($"Congratulations! You've completed {_activityName}. Total duration: {_duration} seconds.");
        }
    }

    private void AskReflectionQuestions()
{
    List<string> _reflectionQuestions = new List<string>
    {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?,",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
        };

        foreach (var question in _reflectionQuestions)
        {
            if (_reflectionPrompts.Count <= 0)
            {
                break; // Break the loop if there are no more prompts
            }

            string userResponse = GetUserInput(question);

            // Allow the user to reflect on the question here (you can read user input if needed)
            System.Threading.Thread.Sleep(3000); // Pause for 3 seconds (3000 milliseconds)
            _reflectionPrompts.RemoveAt(0); // Remove the used prompt
        }
    }

    public override void EndActivity()
    {
        // Implement common ending message if needed
        base.EndActivity();
    }
}