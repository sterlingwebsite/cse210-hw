public class Activity
{
    protected string activityType;
    protected string activityDescription;
    private int _duration;
    private int _fullDuration;
    public void SetActivityType(string value)
    {
        activityType = value;
    }
    public string GetActivityType()
    {
        return activityType;
    }

    public void SetActivityDescription(string value)
    {
        activityDescription = value;
    }

    public string GetActivityDescription()
    {
        return activityDescription;
    }

    public void OpeningPrompt()
    {
        Console.WriteLine("This is the opening prompt for the activity.");
        Console.ReadLine();
        Console.Clear();
        Console.WriteLine($"Welcome to the {activityType}.");
        Console.WriteLine(activityDescription);
        Console.WriteLine("How long, in seconds, would you like your session?");
        _duration = int.Parse(Console.ReadLine());
        _fullDuration = _duration;
        _duration = (int)(_duration * 0.1);
    }

    public virtual void StartActivity()
    {

    }
}