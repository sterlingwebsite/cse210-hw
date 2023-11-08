public class ReflectingActivity : Activity
{
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
        ReflectionActivityMainPrompt();
        ReflectionActivityThirdPrompt();
    }
}