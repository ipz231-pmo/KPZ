namespace PrototypeTask;

internal class Program
{
    private static void Main(string[] args)
    {
        Virus generation1Virus = new Virus("Virus Mk1", "Mk1 type", 0.5M, TimeSpan.FromDays(30), new List<Virus>());
        Virus generation2Virus = new Virus("Virus Mk2", "Mk2 type", 0.3M, TimeSpan.FromDays(20), new List<Virus>());
        Virus generation3Virus = new Virus("Virus Mk3", "Mk3 type", 0.25M, TimeSpan.FromDays(10), new List<Virus>());

        generation2Virus.Childs.Add(generation3Virus);
        generation2Virus.Childs.Add(generation3Virus.Clone() as Virus);

        generation1Virus.Childs.Add(generation2Virus);
        generation1Virus.Childs.Add(generation2Virus.Clone() as Virus);

        generation1Virus.PrintInfo();
        Console.WriteLine();
        Console.WriteLine();
        Virus clone = generation1Virus.Clone() as Virus;
        clone.PrintInfo();

    }
}