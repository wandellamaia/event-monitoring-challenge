using System.Collections.Generic;
using Events.Domain;

namespace Events.Interface
{
    public interface IEventHandlingBusiness
    {
        public List<EventDto> EventFromRegion(List<EventDto> eventList);

        public List<EventDto> EventHandling(List<EventEntity> eventList);
    }
}