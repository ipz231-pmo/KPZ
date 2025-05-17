namespace LightHTML;


class TextNode : AbstractNode
{
    public string Text { get; set; }

    public TextNode(string text = "")
    {
        Text = text;
    }

    public override string InnerHTML
    {
        get => Text;
    }
    public override string OuterHTML 
    {
        get => Text;
    }
}
