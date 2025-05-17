using System.Text;
using System.Windows.Input;

namespace LightHTML;

class ButtonNode : ElementNode
{
    public ButtonNode() : base("button", false, false)
    {

    }

    //public override string OuterHTML
    //{
    //    get
    //    {
    //        StringBuilder sb = new StringBuilder();
    //        sb.Append("<").Append(TagName);
    //        if (CssClasses.Count > 0)
    //        {
    //            sb.Append(" class=\"").Append(string.Join(" ", CssClasses)).Append("\"");
    //        }
            
    //        sb
    //            .AppendLine(">")
    //            .Append(InnerHTML)
    //            .Append("</")
    //            .Append(TagName)
    //            .AppendLine(">");
            
    //        return sb.ToString();
    //    }
    //}

}
