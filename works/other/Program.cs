using System;
using System.Threading;

// Base class for mindfulness activities
class MindfulnessActivity
{
    protected int duration;

    public MindfulnessActivity(int duration)
    {
        this.duration = duration;
    }

    public virtual void Start()
    {
        Console.WriteLine("Starting the activity...");
        Thread.Sleep(2000);
    }

    public virtual void End(string activityName)
    {
        Console.WriteLine("Great job! You have completed the " + activityName + " activity for " + duration + " seconds.");
        Thread.Sleep(2000);
    }
}

// Breathing activity class
class BreathingActivity : MindfulnessActivity
{
    public BreathingActivity(int duration) : base(duration)
    {
    }

    public override void Start()
    {
        base.Start();
        Console.WriteLine("This activity will help you relax by guiding you through breathing in and out slowly. Clear your mind and focus on your breathing.");
        Thread.Sleep(2000);
        Console.WriteLine("Get ready to breathe...");
        Thread.Sleep(2000);
        for (int i = 0; i < duration; i++)
        {
            Console.WriteLine(i % 2 == 0 ? "Breathe in..." : "Breathe out...");
            Thread.Sleep(1000);
        }
        base.End("Breathing");
    }
}

// Reflection activity class
class ReflectionActivity : MindfulnessActivity
{
    public ReflectionActivity(int duration) : base(duration)
    {
    }

    public override void Start()
    {
        base.Start();
        Console.WriteLine("This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.");
        Thread.Sleep(2000);

        string[] prompts = {
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you did something truly selfless."
        };

        Random random = new Random();
        string selectedPrompt = prompts[random.Next(prompts.Length)];

        Console.WriteLine(selectedPrompt);
        Thread.Sleep(2000);

        string[] questions = {
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

        foreach (var question in questions)
        {
            Console.WriteLine(question);
            Thread.Sleep(2000);
        }

        base.End("Reflection");
    }
}

// Listing activity class
class ListingActivity : MindfulnessActivity
{
    public ListingActivity(int duration) : base(duration)
    {
    }

    public override void Start()
    {
        base.Start();
        Console.WriteLine("This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.");
        Thread.Sleep(2000);

        string[] prompts = {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?"
        };

        Random random = new Random();
        string selectedPrompt = prompts[random.Next(prompts.Length)];

        Console.WriteLine(selectedPrompt);
        Thread.Sleep(2000);

        Console.WriteLine("Start listing items...");
        Thread.Sleep(2000);

        int itemsCount = 0;
        while (duration > 0)
        {
            Console.WriteLine("Item " + (itemsCount + 1) + ": ");
            itemsCount++;
            Thread.Sleep(1000);
            duration--;
        }

        Console.WriteLine("You listed " + itemsCount + " items.");
        base.End("Listing");
    }
}

// Main program
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the Mindfulness Program!");

        while (true)
        {
            Console.WriteLine("Choose an activity: ");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflection Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Exit");

            int choice = int.Parse(Console.ReadLine());

            if (choice == 4)
            {
                Console.WriteLine("Goodbye!");
                break;
            }

            Console.WriteLine("Enter the duration in seconds: ");
            int duration = int.Parse(Console.ReadLine());

            MindfulnessActivity activity = null;

            switch (choice)
            {
                case 1:
                    activity = new BreathingActivity(duration);
                    break;
                case 2:
                    activity = new ReflectionActivity(duration);
                    break;
                case 3:
                    activity = new ListingActivity(duration);
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }

            if (activity != null)
            {
                activity.Start();
            }
        }
    }
}
