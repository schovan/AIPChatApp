namespace AIPChatApp.Services
{
    public interface IDialogViewModel<out TResult>
    {
        public TResult Result { get; }
    }
}
