using JT.CodingChallenges.WC.TextReader;
using JT.WordCount.Tool.Options;
using JT.WordCount.Tool.Services;

var options = new WordCountOptions(args);

ITextReader textReader = string.IsNullOrEmpty(options.FileName) 
        ? new ConsoleTextReader() 
        : new FileTextReader(options.FileName);

var service = new WordCountService(options, textReader);

var count = service.GetCount();

Console.WriteLine(count);