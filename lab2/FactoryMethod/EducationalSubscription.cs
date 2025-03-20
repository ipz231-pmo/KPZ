namespace FactoryMethod;
public class EducationalSubscription : ISubscription
{
    public List<string> Channels { get; set; } = ["ABC", "NBC"];
    public TimeSpan TimeSpan { get; set; } = TimeSpan.FromDays(28);
    public string Rent { get; set; } = "2 USD";
    public string Name { get; set; } = "EducationalSubscription";
    public string Description { get; set; } = "Subscription for Students only";
}