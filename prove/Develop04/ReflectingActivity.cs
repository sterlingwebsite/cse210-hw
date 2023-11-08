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

    public override void StartActivity()
    {
        ReflectionActivityMainPrompt();
        ReflectionActivityThirdPrompt();
    }
}