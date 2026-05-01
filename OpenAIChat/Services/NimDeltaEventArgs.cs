namespace OpenAIChat.Services
{
    public class NimDeltaEventArgs : EventArgs
    {
        public NimDeltaKind Kind { get; }
        public string Text { get; }
        public DateTime TimestampUtc { get; }
        public long NanosecondOfSecond { get; }

        public NimDeltaEventArgs(NimDeltaKind kind, string text, DateTime timestampUtc, long nanosecondOfSecond)
        {
            Kind = kind;
            Text = text;
            TimestampUtc = timestampUtc;
            NanosecondOfSecond = nanosecondOfSecond;
        }
    }
}
