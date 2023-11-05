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

        DateTime endTime = DateTime.Now.AddSeconds(_duration); // Calculate the end time based on duration

        int breathCount = 1;
        while (DateTime.Now < endTime)
        {
            Console.WriteLine($"{breathCount}. Breathe in...");
            System.Threading.Thread.Sleep(1000); // Pause for 1 second (1000 milliseconds)
            Console.WriteLine($"{breathCount}. Breathe out...");
            System.Threading.Thread.Sleep(1000); // Pause for 1 second (1000 milliseconds)

            breathCount++;

            // Optional: You can add more animations or logic here if needed
        }

        Console.WriteLine($"Congratulations! You've completed {_activityName}.");
    }

    public override void EndActivity()
    {
        // Implement common ending message if needed
        base.EndActivity();
    }
}
