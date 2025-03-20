namespace AbstractFactory;

// Here listed concreate factories, which in our example, are GadgetCreators

internal class XiaomiGadgetCreator : IGadgetCreator
{
    public ILaptop CreateLaptop() => new XiaomiLaptop();
    public IPhone CreatePhone() => new XiaomiPhone();
}
internal class GalaxyGadgetCreator : IGadgetCreator
{
    public ILaptop CreateLaptop() => new GalaxyLaptop();
    public IPhone CreatePhone() => new GalaxyPhone();
}
