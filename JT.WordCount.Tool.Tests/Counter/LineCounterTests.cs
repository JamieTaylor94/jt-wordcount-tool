using System.IO;
using JT.CodingChallenges.WC.Tests;
using JT.CodingChallenges.WC.TextReader;
using JT.WordCount.Tool.Options;
using JT.WordCount.Tool.Services;
using Xunit;

namespace JT.WordCount.Tool.Tests.Counter;

public class LineCounterTests
{
    [Fact]
    public void TextFile_Returns_Correct_Result()
    {
        const string fileName = "Text.txt";
        var options = new WordCountOptions(new[] { "-l", fileName });
        var service = new WordCountService(options, new FileTextReader(fileName));

        var result = service.GetCount();

        Assert.Equal("7137 " + fileName, result);
    }

    [Fact]
    public void Given_ValidFileWithText_Return_LineCount()
    {
        var filePath = SharedUtilities.CreateFile("Hello world.");
        var options = new WordCountOptions(new[] { "-l", filePath });
        var service = new WordCountService(options, new FileTextReader(filePath));

        var result = service.GetCount();

        Assert.Equal("1 " + filePath, result);
        File.Delete(filePath);
    }
}