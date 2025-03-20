
namespace Singleton;

internal class Program
{
    private async static Task Main(string[] args)
    {
        List<Task> tasks = [];
        for (int i = 0; i < 10; i++)
        {
            tasks.Add(Task.Run(() => 
            {
                Authenticator authenticator = Authenticator.Instance;
                authenticator.Auth($"username", $"password");
            }));
        }
            
        await Task.WhenAll(tasks);
    }
}