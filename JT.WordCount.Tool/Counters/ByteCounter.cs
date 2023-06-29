using System.Text;

namespace JT.WordCount.Tool.Counters;

public class ByteCounter : ICounter
{
    public int Count(string text)
    {
        return Encoding.UTF8.GetBytes(text).Length;
    }
}