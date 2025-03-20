namespace Singleton;
public class Authenticator
{
    private Authenticator()
    {
        Console.WriteLine("Authenticator initialization!");
    }
    public void Auth(string username, string password)
    {
        Console.WriteLine($"Username: {username}, Password: {password}");
    }


    private static object _lock = new();
    private static Authenticator? instance;
    public static Authenticator Instance
    {
        get
        {
            lock (_lock)
            {
                if (instance == null)
                    instance = new Authenticator();
                return instance;
            }
            
        }
    }
}