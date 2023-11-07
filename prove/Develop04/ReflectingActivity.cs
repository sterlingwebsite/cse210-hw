public class ReflectingActivity : Activity
{
    private int _duration;
    private int originalDuration;
    private List<string> specialPrompts;
    private List<string> interestingQuestions;
    private string specialPrompt;
    private string interestingQuestion;

    public ReflectingActivity()
    {
        specialPrompts = new List<string>
        {
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you did something truly selfless."
        };

        interestingQuestions = new List<string>
        {
            "Why was this experience meaningful to you?",
            "Have you ever done anything like this before?",
            "How did you get started?",
            "How did you feel when it was complete?",
            "What made this time different than other times when you were not as successful?",
            "What is your favorite thing about this experience?",
            "What could you learn from this experience that applies to other situations?",
            "What did you learn about yourself through this experience?",
            "How can you keep this experience in mind in the future?"
        };
    }

    public void ReflectionActivityOpeningPrompt()
    {
        Console.Clear();
        Console.WriteLine("Welcome to the Reflecting Activity.");
        Console.WriteLine("This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.");
        Console.WriteLine("How long, in seconds, would you like your session?");
        originalDuration = _duration = int.Parse(Console.ReadLine());
    }

    public void ReflectionActivitySecondPrompt()
    {
        Console.Clear();
        Console.WriteLine("Get ready...");
        RunSpinner(4);
    }

    public void ReflectionActivityMainPrompt()
    {
        Console.Clear();
        Console.WriteLine("Consider the following prompt:");
        specialPrompt = GetRandomItem(specialPrompts);
        Console.WriteLine($"--- {specialPrompt} ---");
        Console.WriteLine("When you have something in mind, press enter to continue.");
        Console.ReadLine();
    }

    public void ReflectionActivityThirdPrompt()
    {
        Console.WriteLine("Now ponder on each of the following questions as they relate to this experience.");
        Console.WriteLine("You may begin in:");
        RunCountdown5(5);
        while (_duration > 0)
        {
            ReflectionActivityInterestingQuestion();
            RunSpinner(11);
            _duration -= 11;
        }
    }

    public void ReflectionActivityInterestingQuestion()
    {
        interestingQuestion = GetRandomItem(interestingQuestions);
        Console.WriteLine($"{interestingQuestion}");
    }

    public void ReflectionActivityClosingPrompt()
    {
        Console.WriteLine("Well done!!");
        RunSpinner(3);
    }

    public void ReflectionActivityClosingPromptTwo()
    {
        Console.WriteLine($"You have completed {originalDuration} seconds of the Reflecting Activity.");
        RunSpinner(3);
    }

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

    private string GetRandomItem(List<string> list)
    {
        Random random = new Random();
        int index = random.Next(0, list.Count);
        string item = list[index];
        list.RemoveAt(index); // Remove the selected item to prevent repetition
        return item;
    }

    public override void StartActivity()
    {
        ReflectionActivityOpeningPrompt();
        ReflectionActivitySecondPrompt();
        ReflectionActivityMainPrompt();
        ReflectionActivityThirdPrompt();
        ReflectionActivityClosingPrompt();
        ReflectionActivityClosingPromptTwo();
    }
}