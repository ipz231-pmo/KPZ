using System.Text.RegularExpressions;

namespace ProxyTask;

class SmartTextReader
{
    protected string filePath;

    public SmartTextReader(string filePath)
    {
        this.filePath = filePath;
    }

    public virtual char[][] ReadText()
    {
        string[] lines = File.ReadAllLines(filePath);
        return [.. lines.Select(line => line.ToCharArray())];
    }
}

class SmartTextChecker : SmartTextReader
{
    public SmartTextChecker(string filePath) : base(filePath) { }

    public override char[][] ReadText()
    {
        Console.WriteLine("Opening file: " + filePath);
        char[][] result = base.ReadText();
        int totalLines = result.Length;
        int totalChars = result.Sum(line => line.Length);
        Console.WriteLine($"File successfully read. Lines: {totalLines}, Characters: {totalChars}");
        Console.WriteLine("Closing file.");
        return result;
    }
}

class SmartTextReaderLocker : SmartTextReader
{
    private Regex restrictionPattern;

    public SmartTextReaderLocker(string filePath, string restrictionPattern) : base(filePath)
    {
        this.restrictionPattern = new Regex(restrictionPattern);
    }

    public override char[][] ReadText()
    {
        if (restrictionPattern.IsMatch(filePath))
        {
            Console.WriteLine("Access denied!");
            return [];
        }
        return base.ReadText();
    }
}
