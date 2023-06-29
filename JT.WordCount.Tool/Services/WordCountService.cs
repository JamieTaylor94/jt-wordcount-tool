using JT.CodingChallenges.WC.TextReader;
using JT.WordCount.Tool.Factories;
using JT.WordCount.Tool.Options;

namespace JT.WordCount.Tool.Services;

public class WordCountService
{
    private readonly WordCountOptions _wordCountOptions;
    private readonly ITextReader _textReader;

    public WordCountService(WordCountOptions wordCountOptions, ITextReader textReader)
    {
        _wordCountOptions = wordCountOptions;
        _textReader = textReader;
    }

    public string GetCount()
    {
        var text = _textReader.Read();
        
        if (_wordCountOptions.OptionType == OptionType.Default)
        {
            var byteCounter = CounterFactory.CreateCounter(OptionType.Byte);
            var lineCounter = CounterFactory.CreateCounter(OptionType.Line);
            var wordCounter = CounterFactory.CreateCounter(OptionType.Word);

            return $"{lineCounter.Count(text),-7}" +
                   $"{wordCounter.Count(text),-7}" +
                   $"{byteCounter.Count(text),-7}" +
                   $" {_wordCountOptions.FileName}";
        }

        var counter = CounterFactory.CreateCounter(_wordCountOptions.OptionType);
        return $"{counter.Count(text)} {_wordCountOptions.FileName}";
    }
}
