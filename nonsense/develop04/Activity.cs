class Activity
{
    protected string _activityName;
    protected string _description;
    protected int _duration;

    public Activity(string name, string description)
    {
        _activityName = name;
        _description = description;
    }

    public virtual void StartActivity()
    {
        Console.WriteLine($"Starting {_activityName}: {_description}");
        Console.WriteLine("Prepare to begin the activity...");
        DateTime endTime = DateTime.Now.AddSeconds(_duration);

        while (DateTime.Now < endTime)
        {
            // Add logic for animations or prompts if needed
        }
    }

    public virtual void EndActivity()
    {
        Console.WriteLine($"Congratulations! You've completed {_activityName}.");
        Console.WriteLine($"Total duration: {_duration} seconds.");
    }
}
