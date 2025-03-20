namespace FactoryMethod;
public class PremiumSubscription : ISubscription
{
    public List<string> Channels { get; set; } = ["ABC", "NBC", "TET", "Inter", "1+1"];
    public TimeSpan TimeSpan { get; set; } = TimeSpan.FromDays(60);
    public string Rent { get; set; } = "11 USD";
    public string Name { get; set; } = "Premium Subscription";
    public string Description { get; set; } = "Premium Subscription";
}