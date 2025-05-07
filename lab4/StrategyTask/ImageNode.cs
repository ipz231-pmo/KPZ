using System.Text.RegularExpressions;

namespace StrategyTask;

class ImageNode : INode
{
    public string Href { get; }
    private readonly IImageLoadingStrategy _strategy;

    public ImageNode(string href)
    {
        Href = href;

        if (Regex.IsMatch(href, @"^http"))
            _strategy = new NetworkImageLoadingStrategy();
        else
            _strategy = new FileImageLoadingStrategy();

    }

    public string InnerHTML => string.Empty;

    public string OuterHTML => _strategy.Load(Href);
}
