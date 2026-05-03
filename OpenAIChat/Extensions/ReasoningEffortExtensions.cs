using OpenAIChat.Models;

namespace OpenAIChat.Extensions
{
    public static class ReasoningEffortExtensions
    {
        public static string ToApiValue(this ReasoningEffort effort)
        {
            return effort switch
            {
                ReasoningEffort.None => "none",
                ReasoningEffort.Minimal => "minimal",
                ReasoningEffort.Low => "low",
                ReasoningEffort.Medium => "medium",
                ReasoningEffort.High => "high",
                ReasoningEffort.XHigh => "xhigh",
                _ => "medium"
            };
        }
    }
}
