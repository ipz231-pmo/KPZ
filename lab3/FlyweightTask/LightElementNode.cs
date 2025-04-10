using System.Text;

namespace FlyweightTask;

// Composite entity
class LightElementNode : ILightNode
{
    public LightElementNodeInfo NodeInfo { get; set; }
    public List<ILightNode> Children { get; }

    public LightElementNode(
        string tagName,

        List<string>? classes = null,
        List<ILightNode>? children = null,
        bool isBlock = true,
        bool isSelfClosing = false,
        LightElementNode? parent = null
        )
    {
        parent?.Children.Add(this);
        NodeInfo = new(tagName, isBlock, isSelfClosing, classes);
        Children = children ?? [];
    }
    public LightElementNode(LightElementNodeInfo nodeInfo, List<ILightNode>? children = null, LightElementNode? parent = null)
    {
        parent?.Children.Add(this);
        NodeInfo = nodeInfo;
        Children = children ?? [];
    }

    public string OuterHTML
    {
        get
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<").Append(NodeInfo.TagName);
            if (NodeInfo.CssClasses.Count > 0)
            {
                sb.Append(" class=\"").Append(string.Join(" ", NodeInfo.CssClasses)).Append("\"");
            }

            if (NodeInfo.IsSelfClosing)
            {
                sb.Append(" />");
            }
            else
            {
                sb
                    .AppendLine(">")
                    .Append(InnerHTML)
                    .Append("</")
                    .Append(NodeInfo.TagName)
                    .AppendLine(">");
            }
            return sb.ToString();
        }
    }
    public string InnerHTML
    {
        get
        {
            StringBuilder sb = new StringBuilder();
            foreach (var child in Children)
            {
                string[] lines = child.OuterHTML.Split("\n");
                for (int i = 0; i < lines.Length; i++)
                    sb.AppendLine($"\t{lines[i]}");
            }
            return sb.ToString();
        }        
    }
}
