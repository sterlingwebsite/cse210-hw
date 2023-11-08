public class ListingActivity : Activity
{
    private string _specialPrompt;
    private List<string> _specialPrompts;
    private int _numberOfAnswers;

    public ListingActivity()
    {
        _specialPrompts = new List<string>
        {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?"
        };
    }

    public void ListingActivityMainPrompt()
    {
        Console.Clear();
        Console.WriteLine("List as many responses as you can to the following prompt:");
        _specialPrompt = GetRandomItem(_specialPrompts);
        Console.WriteLine($"--- {_specialPrompt} ---");
        Console.WriteLine("You may begin in:");
        RunCountdown5(5);
        // Collect user responses within the specified duration
        DateTime _endTime = DateTime.Now.AddSeconds(_duration);
        _numberOfAnswers = 0;

        while (DateTime.Now < _endTime)
        {
            string _userInput = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(_userInput))
            {
                _numberOfAnswers++;
            }
        }

        Console.WriteLine($"You listed {_numberOfAnswers} items!");
        Console.WriteLine(); // Output a blank line
    }

    private string GetRandomItem(List<string> _list)
    {
        Random _random = new Random();
        int _index = _random.Next(0, _list.Count);
        string _item = _list[_index];
        _list.RemoveAt(_index); // Remove the selected _item to prevent repetition
        return _item;
    }

    private void RunCountdown5(int _durationInSeconds)
    {
        string[] _countdown = { "5", "4", "3", "2", "1" };
        int _index = 0;
        for (int i = 0; i < _durationInSeconds; i++)
        {
            Console.Write($"\r{_countdown[_index]}");
            Thread.Sleep(1000);
            _index = (_index + 1) % _countdown.Length;
        }
        Console.WriteLine();
    }

    public override void StartActivity()
    {
        ListingActivityMainPrompt();
    }
}
