namespace BuilderTask;

class HeroBuilder : IBuilder
{
    private Character character;
    public HeroBuilder()
    {
        character = new Character();
    }
    public Character GetCharacter()
    {
        Character result = character;
        character = new Character();
        return result;
    }

    public IBuilder WithName(string name)
    {
        character.Name = name;
        return this;
    }
    public IBuilder WithLevel(int level)
    {
        character.Level = level;
        return this;
    }
    public IBuilder WithAction(string action, double carmaOffset)
    {
        character.ActionsList.Add(action);
        character.Carma += carmaOffset;
        return this;
    }
    public IBuilder WithItems(List<string> items)
    {
        character.Inventory.AddRange(items);
        return this;
    }
    public IBuilder WithWeapon(string weapon, double damage, bool melee)
    {
        character.Weapon = weapon;
        character.Damage = damage;
        character.MeleeWeapon = melee;
        return this;
    }


    public IBuilder WithHat(string hat)
    {
        character.HatCloth = hat;
        return this;
    }
    public IBuilder WithChest(string chest)
    {
        character.ChestCloth = chest;
        return this;
    }
    public IBuilder WithPants(string pants)
    {
        character.PantsCloth = pants;
        return this;
    }
    public IBuilder WithBoots(string boots)
    {
        character.BootsCloth = boots;
        return this;
    }
}
