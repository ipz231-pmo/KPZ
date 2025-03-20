namespace BuilderTask;

internal class Program
{
    private static void Main(string[] args)
    {
        IBuilder heroBuilder = new HeroBuilder();
        IBuilder enemyBuilder = new EnemyBuilder();
        Director director = new Director();
        
        Character hero = director.CreateWarrior(heroBuilder);
        Character enemy = director.CreateWizzard(enemyBuilder);

        hero.PrintInfo();
        enemy.PrintInfo();
    }
}