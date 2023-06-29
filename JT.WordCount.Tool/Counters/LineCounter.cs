namespace JT.WordCount.Tool.Counters;

public class LineCounter : ICounter
{
    public int Count(string text)
    {
        return text.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries).Length;
    }
}