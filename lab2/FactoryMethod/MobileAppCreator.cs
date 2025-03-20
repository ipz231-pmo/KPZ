namespace FactoryMethod;
public class MobileAppCreator : ICreator
{
    public ISubscription CreateSubscription()
    {
        var subscription = new EducationalSubscription();
        subscription.Description += "\nCreated using Mobile App\n";
        return subscription;
    }
}