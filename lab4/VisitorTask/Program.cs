using VisitorTask;

var div = new ElementNode("div");

div.AddEventListener("click", (sender) =>
{
    if (sender is ElementNode elementNode)
        Console.WriteLine($"Clicked on: <{elementNode.TagName}> element");
    else if (sender is TextNode textNode)
        Console.WriteLine($"Clicked on: \"{textNode.InnerHTML}\" text");
});

div.AddEventListener("mouseover", (sender) =>
{
    if (sender is ElementNode elementNode)
        Console.WriteLine($"Mouse over: <{elementNode.TagName}> element");
    else if (sender is TextNode textNode)
        Console.WriteLine($"Mouse over: \"{textNode.InnerHTML}\" text");
});

div.TriggerEvent("click");
div.TriggerEvent("mouseover");
