namespace JT.WordCount.Tool.Counters;

public class CharacterCounter : ICounter
{
    public int Count(string text)
    {
        return text.Length;
    }
}