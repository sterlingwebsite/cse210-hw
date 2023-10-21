class Reference
{
    public string Book { get; private set; }
    public int Chapter { get; private set; }
    public int VerseStart { get; private set; }
    public int VerseEnd { get; private set; }

    public Reference(string reference)
    {
        // Parse the reference string and initialize Book, Chapter, VerseStart, and VerseEnd
        // Handle single verses and verse ranges (e.g., "Proverbs 3:5" or "Proverbs 3:5-6")
    }
}