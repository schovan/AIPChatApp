namespace OpenAIChat.ViewModels
{
    public interface IDialogViewModel<out TResult>
    {
        public TResult Result { get; }
    }
}
