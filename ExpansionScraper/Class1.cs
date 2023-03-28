namespace ExpansionScraper
{
    public interface IScraper
    {
        IList<string> ExtractText(string filePath);
    }
}