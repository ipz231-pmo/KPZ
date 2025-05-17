

using LightHTML;

ElementNode container = new("div");
container.CssClasses.Add("container");
container.CssClasses.Add("d-flex");

for (int i = 1; i <= 4; i++)
{
    ButtonNode btn = new();
    container.Children.Add(btn);
    int savedNumber = i;
    btn.AddEventListener("click", () => { Console.WriteLine($"Redirecting to page /items/item-{savedNumber}/"); });
    btn.CssClasses.Add("p-3");
    btn.CssClasses.Add("rounded");
    btn.CssClasses.Add("bg-secondary");
    if (i == 2) btn.CssClasses.Add("bg-warning");
    btn.AddEventListener("mouseenter", new HoverCommand());

    TextNode txt = new($"Click on me {i}!");
    btn.Children.Add(txt);
}




string document = container.OuterHTML;
Console.WriteLine(document);

foreach(var item in container)
{
    Console.WriteLine(item.OuterHTML);
}

AbstractNode node = (AbstractNode)container.First(n => n is AbstractNode);
Console.WriteLine();
Console.WriteLine("Markup Before button events");
Console.WriteLine(node.OuterHTML);
Console.WriteLine("In process");
node.TriggerEvent("mouseenter");
node.TriggerEvent("click");

Console.WriteLine();
Console.WriteLine("Markup After button events");
Console.WriteLine(node.OuterHTML);