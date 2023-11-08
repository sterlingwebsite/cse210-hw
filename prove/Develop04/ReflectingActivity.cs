public class ReflectingActivity : Activity
{
    private List<string> _specialPrompts;
    private List<string> _interestingQuestions;
    private string _specialPrompt;
    private string _interestingQuestion;

    public ReflectingActivity()
    {
        _specialPrompts = new List<string>
        {
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you did something truly selfless."
        };

        _interestingQuestions = new List<string>
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
        _specialPrompt = GetRandomItem(_specialPrompts);
        Console.WriteLine($"--- {_specialPrompt} ---");
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
        _interestingQuestion = GetRandomItem(_interestingQuestions);
        Console.WriteLine($"{_interestingQuestion}");
    }

    private void RunSpinner(int _durationInSeconds)
    {
        string[] _spinner = { "-", "\\", "|", "/" };
        int _index = 0;
        for (int i = 0; i < _durationInSeconds * 10; i++) // Assuming each spin takes 0.1 seconds
        {
            Console.Write($"\r{_spinner[_index]}");
            Thread.Sleep(100); // Wait for 0.1 seconds
            _index = (_index + 1) % _spinner.Length;
        }
        Console.WriteLine(); // Move to the next line after the _spinner is done
    }

    private void RunCountdown5(int _durationInSeconds)
    {
        string[] _countdown = { "5", "4", "3", "2", "1" };
        int _index = 0;
        for (int i = 0; i < _durationInSeconds; i++)
        {
            Console.Write($"\r{_countdown[_index]}");
            Thread.Sleep(1000);
            _index = (_index + 1) % _countdown.Length;
        }
        Console.WriteLine();
    }

    private string GetRandomItem(List<string> list)
    {
        Random _random = new Random();
        int _index = _random.Next(0, list.Count);
        string item = list[_index];
        list.RemoveAt(_index); // Remove the selected item to prevent repetition
        return item;
    }

    public override void StartActivity()
    {
        ReflectionActivityMainPrompt();
        ReflectionActivityThirdPrompt();
    }
}