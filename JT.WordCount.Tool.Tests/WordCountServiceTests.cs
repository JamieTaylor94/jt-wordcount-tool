using System;
using System.IO;
using System.Text;
using JT.CodingChallenges.WC.Tests;
using JT.CodingChallenges.WC.TextReader;
using JT.WordCount.Tool.Options;
using JT.WordCount.Tool.Services;
using Xunit;

namespace JT.WordCount.Tool.Tests;

public class WordCountServiceTests
{
    [Fact]
    public void Given_ValidFileWithNoArguments_Return_Default()
    {
        var filePath = SharedUtilities.CreateFile("Hello world.");
        var options = new WordCountOptions(new[] { filePath });
        var service = new WordCountService(options, new FileTextReader(filePath));

        var result = service.GetCount();

        Assert.Equal($"1      2      12      {filePath}", result);
        File.Delete(filePath);
    }

    [Fact]
    public void Given_InputFromConsole_When_NoFile_Returns_LineCount()
    {
        CreateConsoleInput("This is a test input.");
        var options = new WordCountOptions(new[] { "-l" });
        var service = new WordCountService(options,  new ConsoleTextReader());

        var result = service.GetCount();

        Assert.Equal("1", result.Trim());
    }
    
    private void CreateConsoleInput(string input)
    {
        var inputStream = new MemoryStream(Encoding.UTF8.GetBytes(input));
        inputStream.Position = 0;
        var streamReader = new StreamReader(inputStream);
        Console.SetIn(streamReader);
    }

}