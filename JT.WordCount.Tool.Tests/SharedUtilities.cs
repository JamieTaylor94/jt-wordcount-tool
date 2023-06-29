using System.IO;

namespace JT.CodingChallenges.WC.Tests;

public class SharedUtilities
{
    public static string CreateFile(string content)
    {
        var fileName = Path.GetTempFileName();
        File.WriteAllText(fileName, content);
        return fileName;
    }
}