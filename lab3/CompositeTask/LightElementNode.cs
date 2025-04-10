using System.Text;

namespace CompositeTask;

// Composite entity
class LightElementNode : ILightNode
{
    public string TagName { get; }
    public bool IsBlock { get; }
    public bool IsSelfClosing { get; }
    public List<string> CssClasses { get; }
    public List<ILightNode> Children { get; }

    public LightElementNode(string tagName, IEnumerable<string> classes, IEnumerable<ILightNode> children, bool isBlock = true, bool isSelfClosing = false)
    {
        TagName = tagName;
        IsBlock = isBlock;
        IsSelfClosing = isSelfClosing;
        CssClasses = [.. classes];
        Children = [.. children];
    }

    public string OuterHTML
    {
        get
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<").Append(TagName);
            if (CssClasses.Count > 0)
            {
                sb.Append(" class=\"").Append(string.Join(" ", CssClasses)).Append("\"");
            }

            if (IsSelfClosing)
            {
                sb.Append(" />");
            }
            else
            {
                sb
                    .AppendLine(">")
                    .Append(InnerHTML)
                    .Append("</")
                    .Append(TagName)
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
