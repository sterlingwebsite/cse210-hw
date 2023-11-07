public class BreathingActivity : Activity
{
    private int _duration;
    private int _fullDuration;

    private void RunSpinner(int durationInSeconds)
    {
        string[] spinner = { "-", "\\", "|", "/" };
        int index = 0;
        for (int i = 0; i < durationInSeconds * 10; i++) // Assuming each spin takes 0.1 seconds
        {
            Console.Write($"\r{spinner[index]}"); // Use \r to overwrite the spinner in the same line
            Thread.Sleep(100); // Wait for 0.1 seconds
            index = (index + 1) % spinner.Length; // Move to the next spinner character
        }
        Console.WriteLine(); // Move to the next line after the spinner is done
    }

    private void RunCountdown6(int durationInSeconds2)
    {
        string[] countdown = { "6", "5", "4", "3", "2", "1"};
        int index = 0;
        for (int i = 0; i < durationInSeconds2; i++)
        {
            Console.Write($"\r{countdown[index]}");
            Thread.Sleep(1000);
            index = (index + 1) % countdown.Length;
        }
    }

    private void RunCountdown4(int durationInSeconds2)
    {
        string[] countdown = { "4", "3", "2", "1"};
        int index = 0;
        for (int i = 0; i < durationInSeconds2; i++)
        {
            Console.Write($"\r{countdown[index]}");
            Thread.Sleep(1000);
            index = (index + 1) % countdown.Length;
        }
    }
    public void BreathingActivityOpeningPrompt()
    {
        Console.Clear();
        Console.WriteLine("Welcome to the Breathing Activity.");
        Console.WriteLine("This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.");
        Console.WriteLine("How long, in seconds, would you like your session?");
        _duration = int.Parse(Console.ReadLine());
        _fullDuration = _duration;
        _duration = (int)(_duration * 0.1);
    }

    public void BreathingActivitySecondPrompt()
    {
        Console.WriteLine("Get ready...");
        RunSpinner(3);
        Console.Clear();
    }

    public void BreathingActivityBreatheInPrompt()
    {
        Console.WriteLine("Breath in...");
        RunCountdown4(4);
        Console.Clear();
    }

    public void BreathingActivityBreatheOutPrompt()
    {
        Console.WriteLine("Now breath out...");
        RunCountdown6(6);
        Console.Clear();
    }

    public void BreathingActivityCompletedPrompt()
    {
        Console.WriteLine("Well done!");
        RunSpinner(2);
        Console.WriteLine($"You have completed {_fullDuration} seconds of the Breathing Activity.");
        RunSpinner(2);
    }

    public override void StartActivity()
    {
        BreathingActivityOpeningPrompt();
        BreathingActivitySecondPrompt();

        while (_duration > 0)
        {
            BreathingActivityBreatheInPrompt();
            BreathingActivityBreatheOutPrompt();
            _duration--;
        }

        BreathingActivityCompletedPrompt();
    }
}
