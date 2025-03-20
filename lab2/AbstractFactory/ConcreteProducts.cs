namespace AbstractFactory;

// Xiaomi
internal class XiaomiPhone : IPhone
{
    public string Name { get; set; } = "Xiaomi Phone";
    public string Description { get; set; } = "Xiaomi Phone Description";
    public string Cost { get; set; } = "250 USD";
    public string Battery { get; set; } = "4000 mah";
}
internal class XiaomiLaptop : ILaptop
{
    public string Name { get; set; } = "Xiaomi Laptop";
    public string Description { get; set; } = "Xiaomi Laptop Description";
    public string Cost { get; set; } = "1600 USD";
    public string Screen { get; set; } = "15.6";
}

// Galaxy
internal class GalaxyPhone : IPhone
{
    public string Name { get; set; } = "Galaxy Phone";
    public string Description { get; set; } = "Galaxy Phone Description";
    public string Cost { get; set; } = "450 USD";
    public string Battery { get; set; } = "5000 mah";
}
internal class GalaxyLaptop : ILaptop
{
    public string Name { get; set; } = "Galaxy Laptop";
    public string Description { get; set; } = "Galaxy Laptop Description";
    public string Cost { get; set; } = "2100 USD";
    public string Screen { get; set; } = "16.6";
}