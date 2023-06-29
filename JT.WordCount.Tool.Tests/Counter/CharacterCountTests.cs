using System.IO;
using JT.CodingChallenges.WC.Tests;
using JT.CodingChallenges.WC.TextReader;
using JT.WordCount.Tool.Options;
using JT.WordCount.Tool.Services;
using Xunit;

namespace JT.WordCount.Tool.Tests.Counter;

public class CharacterCountTests
{
    [Fact]
    public void TextFile_Returns_Correct_Result()
    {
        const string fileName = "Text.txt";

        var options = new WordCountOptions(new[] { "-m", fileName });
        var service = new WordCountService(options, new FileTextReader(fileName));

        var result = service.GetCount();

        Assert.Equal("339120 " + fileName, result);
    }

    [Fact]
    public void Given_ValidFileWithText_Return_CharacterCount()
    {
        var filePath = SharedUtilities.CreateFile("Hello world.");

        var options = new WordCountOptions(new[] { "-m", filePath });
        var service = new WordCountService(options, new FileTextReader(filePath));

        var result = service.GetCount();

        Assert.Equal("12 " + filePath, result);
        File.Delete(filePath);
    }
}