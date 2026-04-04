using AIPChatApp.Services;
using CommunityToolkit.Mvvm.ComponentModel;

namespace AIPChatApp.ViewModels
{
    public partial class ApiKeyViewModel : ObservableObject, IDialogViewModel<string>
    {
        [ObservableProperty]
        private string _result;
    }
}
