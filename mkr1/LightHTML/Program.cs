

using LightHTML;

ElementNode container = new("div");

ButtonNode btn = new();
container.Children.Add(btn);
SaveCommand cmd = new();
btn.SetClickCommand(cmd);

TextNode txt = new("Click on me!");
btn.Children.Add(txt);

string document = container.OuterHTML;
Console.WriteLine(document);

btn.PerformClick();
