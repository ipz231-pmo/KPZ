namespace FlyweightTask;

class LightElementNodeInfo
{
    public string TagName { get; set; }
    public bool IsBlock { get; set; }
    public bool IsSelfClosing { get; set; }
    public List<string> CssClasses { get; set; }
    public LightElementNodeInfo(
        string tagName, 
        bool isBlock = true, 
        bool isSelfClosing = false,
        List<string>? cssClasses = null
        )
    {
        TagName = tagName;
        IsBlock = isBlock;
        IsSelfClosing = isSelfClosing;
        CssClasses = cssClasses ?? [];
    }
}
