

using DecoratorTask;

Hero warrior = new Warrior();
warrior = new ArmorDecorator(warrior);
warrior = new SwordDecorator(warrior);
warrior = new ShieldDecorator(warrior);

Hero paladin = new Paladin();
paladin = new ArmorDecorator(paladin);
paladin = new SwordDecorator(paladin);
paladin = new RegenerationSpellDecorator(paladin);

Hero wizzard = new Mage();
wizzard = new RegenerationSpellDecorator(wizzard);
wizzard = new RegenerationSpellDecorator(wizzard);
wizzard = new MagicAmuletDecorator(wizzard);
wizzard = new ManaGlobeDecorator(wizzard);

List<Hero> heroes = [warrior, paladin, wizzard];

foreach(Hero hero in heroes)
{
    Console.WriteLine();
    Console.WriteLine($"{hero.HeroType}");
    Console.WriteLine($"{hero.Description}");
    Console.WriteLine($"Power: {hero.Power}");
    Console.WriteLine();
}

