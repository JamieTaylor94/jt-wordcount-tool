namespace JT.WordCount.Tool.Counters;

public class WordCounter : ICounter
{
    public int Count(string text)
    {
        return text.Split(new[] { ' ', '\t', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries).Length;
    }
}