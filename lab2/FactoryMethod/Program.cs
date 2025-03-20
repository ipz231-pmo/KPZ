namespace FactoryMethod;
internal class Program
{
    private static void Main(string[] args)
    {
        // Some code to choose Factory
        ICreator creator = new WebSiteCreator();
        ISubscription subscription = creator.CreateSubscription();

        Console.WriteLine($"Name: {subscription.Name}, Rent: {subscription.Rent}, Description: {subscription.Description}");
    }
}