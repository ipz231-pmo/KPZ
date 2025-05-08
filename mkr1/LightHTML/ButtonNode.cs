using System.Text;
using System.Windows.Input;

namespace LightHTML;

class ButtonNode : ElementNode
{
    private ICommand? clickCommand;
    public ButtonNode() : base("button", false, false)
    {

    }
    public void SetClickCommand(ICommand? command = null)
    {
        clickCommand = command;        
    }
    public void PerformClick()
    {
        if (clickCommand != null)
            clickCommand.Execute(this);
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
            
            sb
                .AppendLine(">")
                .Append(InnerHTML)
                .Append("</")
                .Append(TagName)
                .AppendLine(">");
            
            return sb.ToString();
        }
    }

}
