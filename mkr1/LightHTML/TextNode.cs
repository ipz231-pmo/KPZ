namespace LightHTML;


class TextNode : INode
{
    public string Text { get; set; }

    public TextNode(string text = "")
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
