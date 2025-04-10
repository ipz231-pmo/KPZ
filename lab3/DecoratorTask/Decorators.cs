namespace DecoratorTask;

public abstract class HeroDecorator : Hero
{
    protected Hero _hero;

    protected HeroDecorator(Hero hero)
    {
        _hero = hero;
    }

    public override string HeroType => _hero.HeroType;
    public override int BasePower => _hero.BasePower;
    public override int Power => _hero.Power;

    public override string Description => _hero.Description;
    public override void AddItem(string item) => _hero.AddItem(item);
    public override void RemoveItem(string item) => _hero.RemoveItem(item);
    public override IEnumerable<string> GetItems() => _hero.GetItems();
}

public class ArmorDecorator : HeroDecorator
{
    public ArmorDecorator(Hero hero) : base(hero)
    {
        AddItem("Armor");
    }

    public override int Power => _hero.Power + 5;
}

public class SwordDecorator : HeroDecorator
{
    public SwordDecorator(Hero hero) : base(hero)
    {
        AddItem("Sword");
    }

    public override int Power => _hero.Power + 7;
}

public class MagicAmuletDecorator : HeroDecorator
{
    public MagicAmuletDecorator(Hero hero) : base(hero)
    {
        AddItem("Magic Amulet");
    }

    public override int Power => _hero.Power + 10;
}
public class ShieldDecorator : HeroDecorator
{
    public ShieldDecorator(Hero hero) : base(hero)
    {
        AddItem("Shield");
    }

    public override int Power => _hero.Power + 4;
}
public class RegenerationSpellDecorator : HeroDecorator
{
    public RegenerationSpellDecorator(Hero hero) : base(hero)
    {
        AddItem("Regeneration Spell");
    }

    public override int Power => _hero.Power + 3;
}
public class ManaGlobeDecorator : HeroDecorator
{
    public ManaGlobeDecorator(Hero hero) : base(hero)
    {
        AddItem("Strange Globe");
    }

    public override int Power => _hero.Power + 7;
}