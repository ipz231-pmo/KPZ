namespace BuilderTask;

interface IBuilder
{
    Character GetCharacter();

    IBuilder WithName(string name);
    IBuilder WithLevel(int level);
    IBuilder WithItems(List<string> items);
    IBuilder WithWeapon(string weapon, double damage, bool melee);
    IBuilder WithAction(string action, double carmaOffset);

    IBuilder WithHat(string hat);
    IBuilder WithChest(string chest);
    IBuilder WithPants(string pants);
    IBuilder WithBoots(string boots);
}