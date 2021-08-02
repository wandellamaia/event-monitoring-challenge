using System.Collections.Generic;
using Events.Domain;

namespace Events.Interface
{
    public interface IEventsElasticRepository
    {
        public string InsertEvents(List<EventDto> eventList, string index);
        
        public List<EventEntity> EventGenerate();
        
    }
}