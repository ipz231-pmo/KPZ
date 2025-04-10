using ProxyTask;

string filePath = "test.txt";
File.WriteAllText(filePath, "Hello\nCruel\nWorld");

Console.WriteLine("Using SmartTextChecker:");
SmartTextReader reader1 = new SmartTextChecker(filePath);
reader1.ReadText();

Console.WriteLine("\nUsing SmartTextReaderLocker:");
SmartTextReader reader2 = new SmartTextReaderLocker(filePath, @".*test\.txt");
reader2.ReadText();