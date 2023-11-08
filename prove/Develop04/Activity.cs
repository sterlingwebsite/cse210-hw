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
    public string GetActivityType()
    {
        return _activityType;
    }

    public void SetActivityDescription(string value)
    {
        _activityDescription = value;
    }

    public string GetActivityDescription()
    {
        return _activityDescription;
    }

    public void OpeningPrompt()
    {
        //Console.WriteLine("This is the opening prompt for the activity.");
        //Console.ReadLine();
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

    private void RunSpinner(int _durationInSeconds)
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

    //public Activity(int _duration)
    //{
        //this._duration = _duration;
    //}

    public virtual void StartActivity()
    {

    }
}