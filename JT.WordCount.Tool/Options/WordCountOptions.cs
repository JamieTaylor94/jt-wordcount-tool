using System.Text;

namespace JT.WordCount.Tool.Options;

public class WordCountOptions
{
    public OptionType OptionType { get; private set; }
    public string FileName { get; private set; }

    public WordCountOptions(string[] args)
    {
        ParseAndValidateArguments(args);
    }

    private void ParseAndValidateArguments(string[] args)
    {
        if (args.Length == 1)
        {
            OptionType = ParseOptionsType(args[0]);
            FileName = args[0].StartsWith('-') ? string.Empty : args[0].Trim();
        }
        else if (args.Length == 2)
        {
            OptionType = ParseOptionsType(args[0]);
            FileName = args[1].Trim();
        }
        else
        {
            throw new ArgumentException("Usage: jtwc <option> <file>");
        }
    }

    private OptionType ParseOptionsType(string option)
    {
        return option switch
        {
            "-c" => OptionType.Byte,
            "-l" => OptionType.Line,
            "-w" => OptionType.Word,
            "-m" when !Encoding.UTF8.IsSingleByte => OptionType.Character,
            "-m" when Encoding.UTF8.IsSingleByte => OptionType.Byte,
            _ => OptionType.Default,
        };
    }
}