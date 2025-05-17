

using LightHTML;

ElementNode container = new("div");

ButtonNode btn = new();
container.Children.Add(btn);
btn.AddEventListener("click", new SaveCommand());
btn.AddEventListener("mouseenter", new HoverCommand());
btn.AddEventListener("mouseleave", () => { Console.WriteLine("Mouse leaved btn"); });

TextNode txt = new("Click on me!");
btn.Children.Add(txt);

string document = container.OuterHTML;
Console.WriteLine(document);

btn.TriggerEvent("click");
btn.TriggerEvent("mouseenter");
btn.TriggerEvent("mouseleave");
