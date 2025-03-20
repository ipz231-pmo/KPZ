namespace AbstractFactory;

internal interface IGadgetCreator
{
    ILaptop CreateLaptop();
    IPhone CreatePhone();
}
internal interface IPhone
{
    string Name { get; }
    string Description { get; }
    string Cost { get; }
    string Battery { get; }
}
internal interface ILaptop
{
    string Name { get; }
    string Description { get; }
    string Cost { get; }
    string Screen { get; }
}
