namespace StrategyTask;


interface IImageLoadingStrategy
{
    string Load(string href);
}

class FileImageLoadingStrategy : IImageLoadingStrategy
{
    public string Load(string href)
    {
        return $"<img src=\"file://{href}\" />";
    }
}

class NetworkImageLoadingStrategy : IImageLoadingStrategy
{
    public string Load(string href)
    {
        return $"<img src=\"{href}\" />";
    }
}