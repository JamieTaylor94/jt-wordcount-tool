using System.Text;

namespace JT.CodingChallenges.WC.TextReader;

public class FileTextReader : ITextReader
{
    private readonly string _path;

    public FileTextReader(string path)
    {
        _path = path;
        if (!File.Exists(path))
        {
            throw new FileNotFoundException("File not found", path);
        }
    }
    
    public string Read()
    {
        var fileBytes = File.ReadAllBytes(_path);
        return Encoding.UTF8.GetString(fileBytes);
    }
}