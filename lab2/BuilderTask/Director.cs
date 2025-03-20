namespace BuilderTask;

class Director
{
    public Director() { }

    public Character CreateWizzard(IBuilder builder)
    {
        builder
            .WithHat("Wizzard's Hat")
            .WithChest("Wizzard's Mantle")
            .WithPants("Wizzard's Pants")
            .WithBoots("Wizzard's Boots")

            .WithName("Little Wizzard")
            .WithLevel(12)
            .WithWeapon("Epic Damage Spell", 60, false)
            .WithAction("Destroyed someone`s house", 20)
            .WithAction("Killed a bunch of peoples", 50)
            .WithItems(["Yantar", "Epic Regenerating Spell", "Door Key"]);
        return builder.GetCharacter();
    }
    public Character CreateWarrior(IBuilder builder)
    {
        builder
            .WithHat("Warrior's Helmet")
            .WithChest("Warrior's Chestplate")
            .WithPants("Warrior's Pants")
            .WithBoots("Warrior's Boots")

            .WithName("Lord Who?")
            .WithLevel(10)
            .WithWeapon("Legendary Spear", 120, true)
            .WithAction("Helped a shepherd to find his sheep", 12)
            .WithAction("Killed a wolves near the village", 18)
            .WithItems(["Regenerating Potion", "Gold (68)"]);
        return builder.GetCharacter();
    }
}
