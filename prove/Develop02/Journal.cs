using System;
using System.Collections.Generic;
using System.IO;

public class Journal
{
    private List<Entry> _entries = new List<Entry>();
    public IReadOnlyList<Entry> Entries => _entries;

    public void AddEntry()
{
    Entry entry = new Entry();
    string date = entry.DisplayDate();
    string prompt = entry.GetRandomPrompt();
    Console.WriteLine($"{prompt}");
    entry.Prompt = prompt;
    Console.Write("> ");
    string response = Console.ReadLine();
    entry.Response = response;
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
        try
        {
            if (File.Exists(fileName))
            {
                using (StreamReader sr = new StreamReader(fileName))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] entryLines = line.Split('|');
                        if (entryLines.Length >= 3)
                        {
                            Entry entry = new Entry
                            {
                                Date = entryLines[0],
                                Prompt = entryLines[1],
                                Response = entryLines[2]
                            };
                            _entries.Add(entry);
                        }
                    }
                }
                Console.WriteLine("Journal loaded successfully.");
            }
            else
            {
                Console.WriteLine("Error: File not found.");
            }
        }
        catch (FileNotFoundException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
        catch (IOException ex)
        {
            Console.WriteLine($"Error reading the file: {ex.Message}");
        }
    }

    public void SaveJournal()
    {
        Console.Write("What would you like to save your file as? ");
        string fileName = Console.ReadLine();
        try
        {
            using (StreamWriter sw = new StreamWriter(fileName))
            {
                foreach (Entry entry in _entries)
                {
                    sw.WriteLine($"{entry.Date}|{entry.Prompt}|{entry.Response}");
                }
            }
            Console.WriteLine("Journal saved successfully.");
        }
        catch (IOException ex)
        {
            Console.WriteLine($"Error writing to the file: {ex.Message}");
        }
    }
}