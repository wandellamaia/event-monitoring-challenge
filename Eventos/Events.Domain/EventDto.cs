
using System;
using System.Diagnostics.CodeAnalysis;

namespace Events.Domain
{
    [ExcludeFromCodeCoverage]
    public class EventDto
    {
        public DateTimeOffset Data { get; set; }

        public string Tag { get; set; }

        public int Value { get; set; }
        
        public string Status { get; set; }
    }
}
