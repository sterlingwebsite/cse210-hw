class Reference
{
    public string Book { get; }
    public int Chapter { get; }
    public int VerseStart { get; }
    public int VerseEnd { get; }

    public Reference(string book, int chapter, int verseStart, int verseEnd)
    {
        Book = book;
        Chapter = chapter;
        VerseStart = verseStart;
        VerseEnd = verseEnd;
    }
}
