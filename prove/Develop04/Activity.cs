class Activity
{
    protected string _activityName;
    protected string _description;
    protected int _duration;

    public Activity(string name, string desc)
    {
        _activityName = name;
        _description = desc;
    }

    public void SetDuration(int seconds)
    {
        _duration = seconds;
    }

    public virtual void StartActivity()
    {
        Console.WriteLine($"Starting {_activityName}: {_description}");
        Console.WriteLine("Prepare to begin the activity...");

        // Code specific to the activity can be added here
    }

    public virtual void EndActivity()
    {
        Console.WriteLine($"Congratulations! You've completed {_activityName}.");
        Console.WriteLine($"Total duration: {_duration} seconds.");
    }
}