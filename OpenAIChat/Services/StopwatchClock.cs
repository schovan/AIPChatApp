using System.Diagnostics;

namespace OpenAIChat.Services
{
    public static class StopwatchClock
    {
        private static readonly DateTime _anchorUtc = DateTime.UtcNow;
        private static readonly long _anchorTicks = Stopwatch.GetTimestamp();
        private static readonly double _ticksPerStopwatchTick = TimeSpan.TicksPerMillisecond * 1.0 / (Stopwatch.Frequency / 1000.0);

        public static DateTime UtcNow()
        {
            return _anchorUtc.AddTicks((long)((Stopwatch.GetTimestamp() - _anchorTicks) * _ticksPerStopwatchTick));
        }

        public static DateTime LocalNow()
        {
            return UtcNow().ToLocalTime();
        }

        public static string FormatTimestamp(DateTime local)
        {
            return $"{local:HH:mm:ss}.{local.Millisecond:D3}";
        }
    }
}
