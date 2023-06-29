namespace JT.CodingChallenges.WC.TextReader;

public class ConsoleTextReader : ITextReader
{
    public string Read()
    {
        return Console.In.ReadToEnd();
    }
}