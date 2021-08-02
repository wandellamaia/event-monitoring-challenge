using System.Diagnostics.CodeAnalysis;

namespace Events.Domain
{
    [ExcludeFromCodeCoverage]
    public class EventEntity
    {
        public long TimeStamp { get; set; }

        public string Tag { get; set; }

        public int Value { get; set; }
    }
}
