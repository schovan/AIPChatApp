using System.Windows;
using AIPChatApp.ViewModels;

namespace AIPChatApp.Views
{
    public partial class ApiKeyView : Window
    {
        public ApiKeyView()
        {
            InitializeComponent();
            this.DataContext = new ApiKeyViewModel();
        }
    }
}
