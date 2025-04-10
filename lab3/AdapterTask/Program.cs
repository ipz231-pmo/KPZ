// See https://aka.ms/new-console-template for more information
using AdapterTask;


List<Logger> loggers = [
    new LoggerFileWriterAdapter("log.txt"),
    new Logger()    
];

foreach(Logger logger in loggers)
{
    logger.Log($"{DateTime.Now}, Very helpful log message");
    logger.Warn($"{DateTime.Now}, Very helpful warn message");
    logger.Error($"{DateTime.Now}, Very helpful error message");
}

