using System.Text;

namespace VisitorTask;

// Composite entity
class ElementNode : AbstractNode
{
    public string TagName { get; }
    public bool IsBlock { get; }
    public bool IsSelfClosing { get; }
    public List<string> CssClasses { get; }
    public List<INode> Children { get; }

    public ElementNode(
        string tagName, 
        bool isBlock = true, 
        bool isSelfClosing = false,
        IEnumerable<string>? cssClasses = null,
        IEnumerable<INode>? children = null
        )
    {
        cssClasses ??= [];
        children ??= [];

        TagName = tagName;
        IsBlock = isBlock;
        IsSelfClosing = isSelfClosing;
        CssClasses = [..cssClasses];
        Children = [.. children];
    }

    public override string OuterHTML
    {
        get
        {
            StringBuilder sb = new();
            sb
                .Append('<')
                .Append(TagName);
            if (CssClasses.Count > 0)
            {
                sb
                    .Append(" class=\"")
                    .Append(string.Join(" ", CssClasses))
                    .Append('"');
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
    public override string InnerHTML
    {
        get
        {
            StringBuilder sb = new();
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
