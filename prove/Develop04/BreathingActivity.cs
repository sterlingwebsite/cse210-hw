public class BreathingActivity : Activity
{
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
