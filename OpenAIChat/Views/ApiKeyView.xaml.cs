using System.Windows;
using OpenAIChat.ViewModels;

namespace OpenAIChat.Views
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
