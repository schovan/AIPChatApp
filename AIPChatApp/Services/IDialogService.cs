using System.Windows;

namespace AIPChatApp.Services;

public interface IDialogService
{
    public TResult ShowDialog<TWindow, TResult>()
        where TWindow : Window, new()
        where TResult : class;

}