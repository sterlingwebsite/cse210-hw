using System;
using System.Collections.Generic;

class Scripture
{
    private Reference _reference;
    private List<Word> _words;

    public Scripture(string book, int chapter, int verseStart, int verseEnd, string text)
    {
        _reference = new Reference(book, chapter, verseStart, verseEnd);
        _words = ParseText(text);
    }

    private List<Word> ParseText(string text)
    {
        string[] wordsArray = text.Split(new[] { ' ', '.', ',', ';', ':', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);
        List<Word> wordsList = new List<Word>();

        foreach (var wordText in wordsArray)
        {
            wordsList.Add(new Word(wordText));
        }

        return wordsList;
    }

    public void Display()
    {
        Console.WriteLine($"{_reference.Book} {_reference.Chapter}:{_reference.VerseStart}-{_reference.VerseEnd}");
        foreach (var word in _words)
        {
            if (word.IsHidden)
            {
                Console.Write(new string('*', word.Text.Length) + " ");
            }
            else
            {
                Console.Write(word.Text + " ");
            }
        }
        Console.WriteLine();
    }

    public void HideRandomWords(int wordsToHide)
    {
        ValidateWordsToHide(wordsToHide);

        Random random = new Random();
        List<int> unhiddenWordIndices = GetUnhiddenWordIndices(wordsToHide);

        for (int i = 0; i < wordsToHide; i++)
        {
            int randomIndex = random.Next(unhiddenWordIndices.Count);
            int wordIndex = unhiddenWordIndices[randomIndex];

            _words[wordIndex].IsHidden = true;
            unhiddenWordIndices.RemoveAt(randomIndex);
        }
    }

    private void ValidateWordsToHide(int wordsToHide)
    {
        if (wordsToHide < 0 || wordsToHide > _words.Count)
        {
            throw new ArgumentException("Invalid number of words to hide.");
        }
    }

    private List<int> GetUnhiddenWordIndices(int wordsToHide)
    {
        List<int> unhiddenWordIndices = new List<int>();
        for (int i = 0; i < _words.Count; i++)
        {
            if (!_words[i].IsHidden)
            {
                unhiddenWordIndices.Add(i);
            }
        }
        if (unhiddenWordIndices.Count < wordsToHide)
        {
            throw new InvalidOperationException("Not enough words to hide.");
        }
        return unhiddenWordIndices;
    }

    public bool AllWordsHidden()
    {
        foreach (var word in _words)
        {
            if (!word.IsHidden)
            {
                return false;
            }
        }
        return true;
    }
}
