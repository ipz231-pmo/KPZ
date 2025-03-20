namespace FactoryMethod;
public interface ISubscription
{
    List<string> Channels { get; }
    TimeSpan TimeSpan { get; }
    string Rent {  get; }
    string Name { get; }
    string Description { get; }
}