using System.Windows;
using OpenAIChat.Services;
using OpenAIChat.ViewModels;

namespace OpenAIChat.Views
{
    public partial class MainView : Window
    {
        public MainView()
        {
            InitializeComponent();
            AppServiceLocator.Initialize();
            this.DataContext = new MainViewModel(AppServiceLocator.ChatService);
        }
    }
}
