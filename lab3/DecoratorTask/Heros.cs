namespace DecoratorTask;


public abstract class Hero
{
    public List<string> Inventory { get; set; } = [];
    public virtual string Description { get => $"{HeroType} with items: " + (Inventory.Count > 0 ? string.Join(", ", Inventory) : "no items"); }

    public abstract string HeroType { get; }
    public abstract int BasePower { get; }
    public abstract int Power { get; }

    public virtual void AddItem(string item) => Inventory.Add(item);
    public virtual void RemoveItem(string item) => Inventory.Remove(item);
    public virtual IEnumerable<string> GetItems() => Inventory;
}

public class Warrior : Hero
{
    public override string HeroType => "Warrior";
    public override int BasePower => 10;
    public override int Power => BasePower + Inventory.Count * 2;
}

public class Mage : Hero
{
    public override string HeroType => "Mage";
    public override int BasePower => 8;
    public override int Power => BasePower + Inventory.Count * 2;
}

public class Paladin : Hero
{
    public override string HeroType => "Paladin";
    public override int BasePower => 12;
    public override int Power => BasePower + Inventory.Count * 2;
}