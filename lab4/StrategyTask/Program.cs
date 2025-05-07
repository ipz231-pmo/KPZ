using StrategyTask;

INode fileImg = new ImageNode("C:/images/cat.jpg");
INode webImg = new ImageNode("https://example.com/cat.jpg");

Console.WriteLine("File image:");
Console.WriteLine(fileImg.OuterHTML);
Console.WriteLine();

Console.WriteLine("Web image:");
Console.WriteLine(webImg.OuterHTML);