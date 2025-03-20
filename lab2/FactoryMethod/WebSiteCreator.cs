namespace FactoryMethod;
public class WebSiteCreator : ICreator
{
    public ISubscription CreateSubscription()
    {
        var subscription = new PremiumSubscription();
        subscription.Description += "\nCreated using Web Site\n";
        return subscription;
    }
}