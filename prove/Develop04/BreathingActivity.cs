public class BreathingActivity : Activity
{
    private void RunCountdown6(int _durationInSeconds2)
    {
        string[] _countdown = { "6", "5", "4", "3", "2", "1"};
        int _index = 0;
        for (int i = 0; i < _durationInSeconds2; i++)
        {
            Console.Write($"\r{_countdown[_index]}");
            Thread.Sleep(1000);
            _index = (_index + 1) % _countdown.Length;
        }
    }

    private void RunCountdown4(int _durationInSeconds2)
    {
        string[] _countdown = { "4", "3", "2", "1"};
        int _index = 0;
        for (int i = 0; i < _durationInSeconds2; i++)
        {
            Console.Write($"\r{_countdown[_index]}");
            Thread.Sleep(1000);
            _index = (_index + 1) % _countdown.Length;
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
