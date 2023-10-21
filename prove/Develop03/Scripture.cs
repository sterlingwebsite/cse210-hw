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
    if (_reference.VerseStart == _reference.VerseEnd)
    {
        Console.WriteLine($"{_reference.Book} {_reference.Chapter}:{_reference.VerseStart}");
    }
    else
    {
        Console.WriteLine($"{_reference.Book} {_reference.Chapter}:{_reference.VerseStart}-{_reference.VerseEnd}");
    }

    foreach (var word in _words)
    {
        if (word.IsHidden)
        {
            Console.Write(new string('_', word.Text.Length) + " ");
        }
        else
        {
            Console.Write(word.Text + " ");
        }
    }
    Console.WriteLine();
}


    private string FormatVerseRange()
    {
        return _reference.VerseStart == _reference.VerseEnd
            ? _reference.VerseStart.ToString()
            : $"{_reference.VerseStart}-{_reference.VerseEnd}";
    }

    public void HideRandomWords(int wordsToHide)
{
    ValidateWordsToHide(wordsToHide);
    Queue<int> unhiddenWordIndices = GetUnhiddenWordIndices(wordsToHide);

    List<int> originalIndices = new List<int>(unhiddenWordIndices);

    foreach (var index in originalIndices)
    {
        _words[index].IsHidden = true;
    }
}


    private void ValidateWordsToHide(int wordsToHide)
    {
        if (wordsToHide < 0 || wordsToHide > _words.Count)
        {
            throw new ArgumentException("Invalid number of words to hide.");
        }
    }

    private Queue<int> GetUnhiddenWordIndices(int wordsToHide)
{
    List<int> unhiddenIndices = new List<int>();
    for (int i = 0; i < _words.Count; i++)
    {
        if (!_words[i].IsHidden)
        {
            unhiddenIndices.Add(i);
        }
    }

    if (unhiddenIndices.Count < wordsToHide)
    {
        throw new InvalidOperationException("Not enough words to hide.");
    }

    Queue<int> unhiddenWordIndices = new Queue<int>(unhiddenIndices.OrderBy(x => Guid.NewGuid()));
    return new Queue<int>(unhiddenWordIndices.Take(wordsToHide));
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
