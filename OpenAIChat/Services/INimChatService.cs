namespace OpenAIChat.Services
{
    public interface INimChatService
    {
        event EventHandler<NimDeltaEventArgs> DeltaReceived;
        Task<string> StreamAsync(IReadOnlyList<(string Role, string Content)> history, CancellationToken ct = default);
    }
}
