using System;
public class Entry
{
    public string _date;
    public string _response;
    public string _prompt;
    public void EntryDetails()
    {
        Console.WriteLine($"{_date} {_prompt}");
        Console.WriteLine($"{_response}");
    }
    public string GetRandomPrompt()
    {
        var random = new Random();
        var prompts = new List<string>{
            "Who was the most interesting person I interacted with today?",
            "What was the best part of my day?",
            "How did I see the hand of the Lord in my life today?",
            "What was the strongest emotion I felt today?",
            "If I had one thing I could do over today, what would it be?",
            };
        int index = random.Next(prompts.Count);
        _prompt = prompts[index];
        return _prompt;
    }
    public string DisplayDate()
    {
        DateTime theCurrentTime = DateTime.Now;
        string dateText = theCurrentTime.ToShortDateString();
        return dateText;
    }
}