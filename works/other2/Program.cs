using System;
using System.Threading;

// Base class for mindfulness activities
class MindfulnessActivity
{
    protected string activityName;
    protected string description;
    protected int duration;

    public MindfulnessActivity(string name, string desc)
    {
        activityName = name;
        description = desc;
        duration = 0;
    }

    public void SetDuration(int seconds)
    {
        duration = seconds;
    }

    public void StartActivity()
    {
        Console.WriteLine($"Starting {activityName} activity: {description}");
        Console.WriteLine($"Duration: {duration} seconds");
        Console.WriteLine("Get ready to begin...");
        Thread.Sleep(3000); // Pause for 3 seconds before starting activity
    }

    public void EndActivity()
    {
        Console.WriteLine($"Congratulations! You have completed the {activityName} activity.");
        Console.WriteLine($"Total time: {duration} seconds");
        Console.WriteLine("Well done!");
        Thread.Sleep(3000); // Pause for 3 seconds before finishing activity
    }
}

// BreathingActivity class inheriting from MindfulnessActivity
class BreathingActivity : MindfulnessActivity
{
    public BreathingActivity() : base("Breathing Activity", "This activity will help you relax by guiding you through deep breathing.")
    {
    }

    public void StartBreathing()
    {
        StartActivity();
        Console.WriteLine("Breathe in...");
        Thread.Sleep(2000); // Pause for 2 seconds
        Console.WriteLine("Breathe out...");
        Thread.Sleep(2000); // Pause for 2 seconds
        // Continue alternating messages until duration is reached
        while (duration > 4)
        {
            duration -= 4;
            Console.WriteLine("Breathe in...");
            Thread.Sleep(2000); // Pause for 2 seconds
            Console.WriteLine("Breathe out...");
            Thread.Sleep(2000); // Pause for 2 seconds
        }
        EndActivity();
    }
}

// ReflectionActivity class inheriting from MindfulnessActivity
class ReflectionActivity : MindfulnessActivity
{
    private string[] prompts = {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    public ReflectionActivity() : base("Reflection Activity", "This activity will help you reflect on times when you have shown strength and resilience.")
    {
    }

    public void StartReflection()
    {
        StartActivity();
        Random random = new Random();
        string prompt = prompts[random.Next(prompts.Length)];
        Console.WriteLine(prompt);
        Thread.Sleep(2000); // Pause for 2 seconds
        // Continue asking questions until duration is reached
        while (duration > 2)
        {
            duration -= 2;
            // Ask reflection questions (simplified for example)
            Console.WriteLine("Why was this experience meaningful to you?");
            Thread.Sleep(2000); // Pause for 2 seconds
            Console.WriteLine("What did you learn about yourself through this experience?");
            Thread.Sleep(2000); // Pause for 2 seconds
        }
        EndActivity();
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the Mindfulness Program!");
        Console.WriteLine("Choose an activity: ");
        Console.WriteLine("1. Breathing Activity");
        Console.WriteLine("2. Reflection Activity");

        int choice = Convert.ToInt32(Console.ReadLine());

        switch (choice)
        {
            case 1:
                BreathingActivity breathingActivity = new BreathingActivity();
                Console.WriteLine("Enter duration in seconds: ");
                int breathingDuration = Convert.ToInt32(Console.ReadLine());
                breathingActivity.SetDuration(breathingDuration);
                breathingActivity.StartBreathing();
                break;
            case 2:
                ReflectionActivity reflectionActivity = new ReflectionActivity();
                Console.WriteLine("Enter duration in seconds: ");
                int reflectionDuration = Convert.ToInt32(Console.ReadLine());
                reflectionActivity.SetDuration(reflectionDuration);
                reflectionActivity.StartReflection();
                break;
            default:
                Console.WriteLine("Invalid choice.");
                break;
        }
    }
}
