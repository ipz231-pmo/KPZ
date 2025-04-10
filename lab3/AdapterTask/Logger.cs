namespace AdapterTask;

class Logger
{
    public virtual void Log(string message)
    {
        ConsoleColor previusColor = Console.ForegroundColor;
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine(message);
        Console.ForegroundColor = previusColor;
    }
    public virtual void Warn(string message)
    {
        ConsoleColor previusColor = Console.ForegroundColor;
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine(message);
        Console.ForegroundColor = previusColor;
    }
    public virtual void Error(string message)
    {
        ConsoleColor previusColor = Console.ForegroundColor;
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(message);
        Console.ForegroundColor = previusColor;
    }
}
