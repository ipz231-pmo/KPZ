using System.Text;
using System.Windows.Input;

namespace LightHTML;

class ButtonNode : ElementNode
{
    public ButtonNode() : base("button", false, false)
    {

    }

    public override void OnBeforeEvent(string eventType)
    {
        if (eventType == "mouseenter")
        {
            if (!CssClasses.Contains("hovered"))
                CssClasses.Add("hovered");
        }
        else if (eventType == "click")
        {
            Console.WriteLine("Button clicked - default behavior");
        }
    }
    public override void OnAfterEvent(string eventType)
    {
        if (eventType == "click")
        {
            CssClasses.Add("clicked");
        }
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
