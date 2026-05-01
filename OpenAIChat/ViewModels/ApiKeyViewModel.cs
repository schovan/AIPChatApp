using CommunityToolkit.Mvvm.ComponentModel;
using OpenAIChat.Services;

namespace OpenAIChat.ViewModels
{
    public partial class ApiKeyViewModel : ObservableObject, IDialogViewModel<string>
    {
        [ObservableProperty]
        private string _result;
    }
}
