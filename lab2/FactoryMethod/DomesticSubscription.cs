namespace FactoryMethod;
public class DomesticSubscription : ISubscription
{
    public List<string> Channels { get; set; } = ["ABC", "NBC", "TET"];
    public TimeSpan TimeSpan { get; set; } = TimeSpan.FromDays(28);
    public string Rent { get; set; } = "5 USD";
    public string Name { get; set; } = "DomesticSubscription";
    public string Description { get; set; } = "Basic Subscription for Family";
}