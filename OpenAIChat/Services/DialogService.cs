using System.Windows;
using OpenAIChat.ViewModels;

namespace OpenAIChat.Services
{
    public class DialogService : IDialogService
    {
        public TResult ShowDialog<TWindow, TResult>()
            where TWindow : Window, new()
            where TResult : class
        {
            var window = new TWindow();
            window.ShowDialog();
            if (window.DataContext is IDialogViewModel<TResult> dialogViewModel)
            {
                return dialogViewModel.Result;
            }
            throw new Exception("Invalid data context");
        }
    }
}