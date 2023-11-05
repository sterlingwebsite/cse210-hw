class BreathingActivity : Activity
{
    public BreathingActivity() : base("Breathing Activity", "Helps you relax by focusing on breathing.")
    {
        // Constructor for specific prompts related to breathing activity
    }

    public override void StartActivity()
    {
        Console.WriteLine($"Starting {_activityName}: {_description}");
        Console.WriteLine("Prepare to begin breathing exercise...");

        for (int i = 1; i <= _duration; i++)
        {
            Console.WriteLine(i + ". Breathe in...");
            System.Threading.Thread.Sleep(1000); // Pause for 1 second (1000 milliseconds)
            Console.WriteLine(i + ". Breathe out...");
            System.Threading.Thread.Sleep(1000); // Pause for 1 second (1000 milliseconds)
        }

        Console.WriteLine($"Congratulations! You've completed {_activityName}.");
    }

    public override void EndActivity()
    {
        base.EndActivity();
    }
}