namespace BuilderTask;

class Character
{
    public string Name { get; set; }
    public int Level { get; set; }

    public List<string> Inventory { get; set; }

    public string? HatCloth { get; set; }
    public string? ChestCloth { get; set; }
    public string? PantsCloth { get; set; }
    public string? BootsCloth { get; set; }

    public double Damage { get; set; }
    public bool MeleeWeapon { get; set; }
    public string Weapon { get; set; }

    public List<string> ActionsList { get; set; }
    public double Carma { get; set; }

    public Character()
    {
        Name = "Hero";
        Level = 1;

        Inventory = [];

        Damage = 10;
        MeleeWeapon = true;
        Weapon = "Fists";

        ActionsList = [];
        Carma = 0;
    }

    public void PrintInfo()
    {
        Console.WriteLine();
        Console.WriteLine("--------------------------");
        Console.WriteLine($"Name: {Name}");
        Console.WriteLine($"Name: {Level}");
        Console.WriteLine($"Weapon: {Weapon} ({Damage})");
        Console.WriteLine($"Carma: {Carma}");
        Console.WriteLine($"Actions:");
        Console.WriteLine($"{string.Join("\n", ActionsList)}");
        Console.WriteLine();
        Console.WriteLine("Inventory: ");
        Console.WriteLine($"Hat: {HatCloth}");
        Console.WriteLine($"Chest: {ChestCloth}");
        Console.WriteLine($"Pants: {PantsCloth}");
        Console.WriteLine($"Boots: {BootsCloth}");
        Console.WriteLine($"Items: {string.Join(", ", Inventory)}");
    }

}
