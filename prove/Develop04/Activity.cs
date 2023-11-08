public class Activity
{
    protected string _activityType;
    protected string _activityDescription;
    protected int _duration;
    protected int _originalDuration;
    public void SetActivityType(string value)
    {
        _activityType = value;
    }

    public void SetActivityDescription(string value)
    {
        _activityDescription = value;
    }

    public void OpeningPrompt()
    {
        Console.Clear();
        Console.WriteLine($"Welcome to the {_activityType}.");
        Console.WriteLine(_activityDescription);
        Console.WriteLine("How long, in seconds, would you like your session?");
        _duration = int.Parse(Console.ReadLine());
        _originalDuration = _duration;
    }

    public void SecondPrompt()
    {
        Console.WriteLine("Get ready...");
        RunSpinner(3);
        Console.Clear();
    }

    public void CompletedPrompt()
    {
        Console.WriteLine("Well done!");
        RunSpinner(2);
        Console.WriteLine($"You have completed {_originalDuration} seconds of the Breathing Activity.");
        RunSpinner(2);
    }

    protected void RunSpinner(int _durationInSeconds)
    {
        string[] _spinner = { "-", "\\", "|", "/" };
        int _index = 0;
        for (int i = 0; i < _durationInSeconds * 10; i++) // Assuming each spin takes 0.1 seconds
        {
            Console.Write($"\r{_spinner[_index]}"); // Use \r to overwrite the _spinner in the same line
            Thread.Sleep(100); // Wait for 0.1 seconds
            _index = (_index + 1) % _spinner.Length; // Move to the next _spinner character
        }
        Console.WriteLine(); // Move to the next line after the _spinner is done
    }

    protected void RunCountdown6(int _durationInSeconds2)
    {
        string[] _countdown = { "6", "5", "4", "3", "2", "1"};
        int _index = 0;
        for (int i = 0; i < _durationInSeconds2; i++)
        {
            Console.Write($"\r{_countdown[_index]}");
            Thread.Sleep(1000);
            _index = (_index + 1) % _countdown.Length;
        }
    }

    protected void RunCountdown5(int _durationInSeconds)
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

    protected void RunCountdown4(int _durationInSeconds2)
    {
        string[] _countdown = { "4", "3", "2", "1"};
        int _index = 0;
        for (int i = 0; i < _durationInSeconds2; i++)
        {
            Console.Write($"\r{_countdown[_index]}");
            Thread.Sleep(1000);
            _index = (_index + 1) % _countdown.Length;
        }
    }

protected string GetRandomItem(List<string> list)
    {
        Random _random = new Random();
        int _index = _random.Next(0, list.Count);
        string item = list[_index];
        list.RemoveAt(_index); // Remove the selected item to prevent repetition
        return item;
    }

    public virtual void StartActivity()
    {

    }
}