using System.Collections;
using System.Text;

namespace LightHTML;


class ElementNode : AbstractNode, IEnumerable<INode>
{
    public string TagName { get; set; }
    public bool IsBlock { get; set; }
    public bool IsSelfClosing { get; set; }
    public List<string> CssClasses { get; private set; }
    public List<INode> Children { get; private set; }

    public ElementNode(string tagName, bool isBlock = true, bool isSelfClosing = false)
    {
        TagName = tagName;
        IsBlock = isBlock;
        IsSelfClosing = isSelfClosing;
        CssClasses = [];
        Children = [];
    }

    public override string OuterHTML
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
    public override string InnerHTML
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

    public IEnumerator<INode> GetEnumerator()
    {
        return Children.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
