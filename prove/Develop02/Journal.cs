using System.IO;
public class Journal
{
    public List<Entry> _entries = new List<Entry>();
    public void AddEntry()
    {
        Entry entry = new Entry();
        string date = entry.DisplayDate();
        entry._date = date;
        string prompt = entry.GetRandomPrompt();
        Console.WriteLine($"{prompt}");
        entry._prompt = prompt;
        Console.Write("> ");
        string response = Console.ReadLine();
        entry._response = response;
        _entries.Add(entry);
    }
    public void DisplayJournal()
    {
        foreach (Entry entry in _entries)
        {
            Console.WriteLine();
            entry.EntryDetails();
        }
    }
    public void LoadJournal()
    {
        _entries.Clear();
        Console.Write("What is the name of your file? ");
        string fileName = Console.ReadLine();
        String line;
        try
        {
            using (StreamReader sr = new StreamReader(fileName))
            {
                line = sr.ReadLine();
                while (line != null)
                {
                    string[] entryLines = line.Split('|');
                    Entry entry = new Entry();
                    entry._date = entryLines[0];
                    entry._prompt = entryLines[1];
                    entry._response = entryLines[2];
                    _entries.Add(entry);
                    line = sr.ReadLine();
                };
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error: {e.Message}");
        }
    }
    public void SaveJournal()
    {
        Console.Write("What would you like to save your file as? ");
        string fileName = Console.ReadLine();
        using (StreamWriter sw = new StreamWriter(fileName))
        {
            foreach (Entry line in _entries)
            {
                sw.WriteLine($"{line._date}|{line._prompt}|{line._response}");
            }
        }
    }
}