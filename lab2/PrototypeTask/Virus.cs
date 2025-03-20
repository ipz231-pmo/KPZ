namespace PrototypeTask;

internal class Virus : ICloneable
{
    public string Name { get; set; }
    public string Type { get; set; }
    public decimal Weight { get; set; }
    public TimeSpan Age { get; set; }
    public List<Virus> Childs { get; set; }

    public Virus(string name, string type, decimal weight, TimeSpan age, List<Virus> childs)
    {
        Name = name;
        Type = type;
        Weight = weight;
        Age = age;
        Childs = childs;
    }
    public void PrintInfo()
    {
        Console.WriteLine($"Name: {Name}, Type: {Type}, Weight: {Weight}, Age: {Age.Days} days");
        foreach ( Virus virus in Childs )
            virus.PrintInfo();
    }

    public Virus(Virus other)
    {
        Name = other.Name;
        Type = other.Type;
        Weight = other.Weight;
        Age = other.Age;
        Childs = [];
        foreach(var child in other.Childs)
        {
            Childs.Add(child.Clone() as Virus);
        }
    }
    public object Clone() => new Virus(this);
}
