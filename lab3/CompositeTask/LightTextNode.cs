namespace CompositeTask;

// Leaf entity
class LightTextNode : ILightNode
{
    public string Text { get; set; }

    public LightTextNode(string text = "")
    {
        Text = text;
    }

    public string InnerHTML
    {
        get => Text;
        set => Text = value;
    }
    public string OuterHTML 
    {
        get => Text;
        set => Text = value;
    }

}
