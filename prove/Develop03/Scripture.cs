using System;
using System.Collections.Generic;
using System.Linq;

class Scripture
{
    private Reference _reference;
    private List<Word> _words;
    private Random _random;

    public Scripture(string reference, string text)
    {
        _reference = new Reference(reference);
        _words = text.Split(' ').Select(word => new Word(word)).ToList();
        _random = new Random();
    }

    public void HideRandomWords()
    {
        // Get a list of words that are not already hidden
        List<Word> wordsToHide = _words.Where(word => !word.IsHidden).ToList();

        // Determine how many words to hide (you can adjust this number)
        int wordsToHideCount = _random.Next(1, 4); // Hide 1 to 3 words at a time

        // Hide random words
        for (int i = 0; i < wordsToHideCount; i++)
        {
            if (wordsToHide.Count > 0)
            {
                int randomIndex = _random.Next(0, wordsToHide.Count);
                wordsToHide[randomIndex].IsHidden = true;
                wordsToHide.RemoveAt(randomIndex);
            }
        }
    }

    public bool AllWordsHidden()
    {
        // Check if all words in the scripture are hidden
        return _words.All(word => word.IsHidden);
    }

    public void Display()
    {
        // Display the complete scripture including reference and text
        Console.WriteLine($"{_reference.Book} {_reference.Chapter}:{_reference.VerseStart}-{_reference.VerseEnd}");
        foreach (var word in _words)
        {
            if (word.IsHidden)
            {
                Console.Write("***** "); // Print asterisks for hidden words
            }
            else
            {
                Console.Write(word.Text + " ");
            }
        }
        Console.WriteLine();
    }
}
