namespace FlyweightTask;

// Leaf entity
class LightTextNode : ILightNode
{
    public string Text { get; set; }

    public LightTextNode(string text = "", LightElementNode? parent = null)
    {
        Text = text;
        parent?.Children.Add(this);
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
