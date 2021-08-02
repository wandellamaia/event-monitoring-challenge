using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Events.Domain;
using Events.Business;
using Events.Infraestructure.Exception;
using Events.Infraestructure.Utils;
using Events.Interface;

namespace Events.Business
{
    public class EventBusiness : IEventBusiness
    {
        private readonly IEventsElasticRepository _eventsElasticRepository;
        public  EventBusiness(IEventsElasticRepository eventsElasticRepository)
        {
            _eventsElasticRepository = eventsElasticRepository;
        }

        public string InsertEvents()
        {
                var events = CreateEvent();
                var eventHandling = EventHandling(events);
                Insert(eventHandling,"eventos");
                var eventsOnlyRegion = EventFromRegion(eventHandling);
                Insert(eventsOnlyRegion,"regioes");
                return "OK";
        }
        
        public List<EventEntity> CreateEvent()
        {
            return _eventsElasticRepository.EventGenerate();
        }
        
        public string Insert(List<EventDto> eventList, string index)
        {
            try
            {
                if (index == null || !eventList.Any())
                    throw new EventException(MessageHelp.Get(400, EventException.VALORPARAMETROINVALIDO, System.Net.HttpStatusCode.BadRequest));
                return _eventsElasticRepository.InsertEvents(eventList, index);
            }
            catch(Exception e)
            {
                throw new EventException(MessageHelp.Get(424, "Falha na requisição."));
            }
        }
        public List<EventDto> EventHandling(List<EventEntity> eventList)
        {
            List<EventDto> eventListDto = new List<EventDto>();
            eventList.ForEach(item =>
            {
                eventListDto.Add(new EventDto(){
                    Tag = item.Tag,
                    Value = item.Value,
                    Data = Utils.GetDate(item.TimeStamp),
                    Status = item.Value != 0?"processado":"erro"
                });

            });

            return eventListDto;
        }
        
        public List<EventDto> EventFromRegion(List<EventDto> eventList)
        {
            eventList.ForEach(item =>
            {
                if (item.Tag.Contains(".sensor1"))
                {
                    item.Tag = item.Tag.Replace(".sensor1", "");
                }
                else
                {
                    item.Tag = item.Tag.Replace(".sensor2", "");
                }
                    
            });
                
            return eventList;
        }
        
    }
}
