using System.Text;
using System.Windows.Input;

namespace LightHTML;

class ButtonNode : ElementNode
{
    private ICommand? clickCommand, mouseEnterCommand, mouseLeaveCommand;
    public ButtonNode() : base("button", false, false)
    {

    }
    public void SetClickCommand(ICommand? command = null) => clickCommand = command;
    public void SetMouseEnterCommand(ICommand? command = null) => mouseEnterCommand = command;
    public void SetMouseLeaveCommand(ICommand? command = null) => mouseLeaveCommand = command;
    public void PerformClick() => clickCommand?.Execute(this);
    public void PerformMouseEnter() => mouseEnterCommand?.Execute(this);
    public void PerformMouseLeave() => mouseLeaveCommand?.Execute(this);

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
