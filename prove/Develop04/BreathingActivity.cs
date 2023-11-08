public class BreathingActivity : Activity
{
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

    public override void StartActivity()
    {
        while (_duration > 0)
        {
            BreathingActivityBreatheInPrompt();
            BreathingActivityBreatheOutPrompt();
            _duration -= 10;
        }
    }
}
