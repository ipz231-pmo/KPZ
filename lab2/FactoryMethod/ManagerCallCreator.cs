namespace FactoryMethod;
public class ManagerCallCreator : ICreator
{
    public ISubscription CreateSubscription()
    {
        var subscription = new DomesticSubscription();
        subscription.Description += "\nCreated using Manager Call\n";
        return subscription;
    }
}