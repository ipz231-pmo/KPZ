using System.Windows;

namespace lab6.Core.Services
{
    public class MessageService : IMessageService
    {
        public void Show(string message)
        {
            MessageBox.Show(message);
        }
    }
}