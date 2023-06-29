using JT.WordCount.Tool.Counters;
using JT.WordCount.Tool.Options;

namespace JT.WordCount.Tool.Factories;

public static class CounterFactory
{
    private static readonly Dictionary<OptionType, ICounter> CounterDictionary = new()
    {
        { OptionType.Byte, new ByteCounter() },
        { OptionType.Line, new LineCounter() },
        { OptionType.Word, new WordCounter() },
        { OptionType.Character, new CharacterCounter() }
    };

    public static ICounter CreateCounter(OptionType type)
    {
        if (CounterDictionary.ContainsKey(type))
            return CounterDictionary[type];

        throw new ArgumentException("Unknown option", nameof(type));
    }
}