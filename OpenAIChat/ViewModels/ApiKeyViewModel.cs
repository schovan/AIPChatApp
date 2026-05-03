using CommunityToolkit.Mvvm.ComponentModel;

namespace OpenAIChat.ViewModels
{
    public partial class ApiKeyViewModel : ObservableObject, IDialogViewModel<string>
    {
        [ObservableProperty]
        private string _result;
    }
}
