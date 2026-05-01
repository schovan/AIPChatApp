namespace OpenAIChat.Services
{
    public interface IDialogViewModel<out TResult>
    {
        public TResult Result { get; }
    }
}
