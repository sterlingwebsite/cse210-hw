public class BreathingActivity : Activity
{
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
