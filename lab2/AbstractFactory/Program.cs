namespace AbstractFactory;
internal class Program
{
    private static void Main(string[] args)
    {
        // Here listed basic usage of Abstract Factory Pattern
        /*
            My analogy:
            Interfaces: IWindow, IButton, IPanel, ILayoutCreator
            ConcreteProducts: WinWindow, WinButton, WinPanel, LinuxWindow, LinuxButton, LinuxPanel
            ConcreteFactories: WinLayoutCreator, LinuxLayoutCreator
            In this example good solution is also use Singleton Pattern for Factory Choose and usage
            

            // there is also Singleton class - LayoutCreator, that has Configure method that chooses which factory to use and also has GetFactory method.
            LayoutCreator.Configure();
            ILayoutCreator layoutCreator = LayoutCreator.GetLayoutCreator(); 
            IPanel settingsPanel = layoutCreator.CreatePanel();
            settingsPanel.Width = 800;
            settingsPanel.Height = 600;
            // ...
         */

        IGadgetCreator gadgetCreator = new GalaxyGadgetCreator();
        ILaptop laptop = gadgetCreator.CreateLaptop();
        IPhone phone = gadgetCreator.CreatePhone();

        Console.WriteLine($"{phone.Name}, {phone.Cost}, {phone.Description}, Battery {phone.Battery}");
        Console.WriteLine($"{laptop.Name}, {laptop.Cost}, {laptop.Description}, Battery {laptop.Screen}");
    }
}