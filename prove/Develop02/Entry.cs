using System;
using System.Collections.Generic;

public class Entry
{
    private static Random _random = new Random();
    private string _date;
    private string _response;
    private string _prompt;

    public string Date
    {
        get { return _date; }
        set { _date = value; }
    }

    public string Response
    {
        get { return _response; }
        set { _response = value; }
    }

    public string Prompt
    {
        get { return _prompt; }
        set { _prompt = value; }
    }

    public void EntryDetails()
    {
        Console.WriteLine($"{Date} {Prompt}");
        Console.WriteLine($"{Response}");
    }

    public string GetRandomPrompt()
    {
        var prompts = new List<string>
        {
            "Who was the most interesting person I interacted with today?",
            "What was the best part of my day?",
            "How did I see the hand of the Lord in my life today?",
            "What was the strongest emotion I felt today?",
            "If I had one thing I could do over today, what would it be?"
        };
        int index = _random.Next(prompts.Count);
        Prompt = prompts[index];
        return Prompt;
    }

    public string DisplayDate()
    {
        DateTime theCurrentTime = DateTime.Now;
        Date = theCurrentTime.ToShortDateString();
        return Date;
    }
}