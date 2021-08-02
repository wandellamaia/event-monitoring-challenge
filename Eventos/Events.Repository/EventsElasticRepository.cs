using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
 using Elasticsearch.Net;
using Events.Domain;
using Events.Infraestructure.Exception;
using Events.Infraestructure.Utils;
using Events.Interface;


namespace Events.Repository
{
    [ExcludeFromCodeCoverage]
    public class EventsElasticRepository : IEventsElasticRepository
    {
        private static ElasticLowLevelClient _elasticLowLevelClient;

        public EventsElasticRepository()
        {
            var settings = new ConnectionConfiguration(new Uri("http://elasticsearch:9200/"))
                .RequestTimeout(TimeSpan.FromMinutes(2)).ThrowExceptions();
            _elasticLowLevelClient = new ElasticLowLevelClient(settings);
        }

        public List<EventEntity> EventGenerate()
        {
            Random rnd = new Random();
            List<EventEntity> eventList = new List<EventEntity>();
            for (int i = 0; i < 36; i++)
            {
                var eventTemp = new EventEntity
                {
                    TimeStamp = Utils.GetTimeStamp(),
                    Tag = "brasil." + Utils.GetRegion() + "." + Utils.GetSensor(),
                    Value = rnd.Next(10)
                };
                eventList.Add(eventTemp);
            }

            return eventList;
        }

        public string InsertEvents(List<EventDto> eventList, string index)
        {
            byte[] responseBytes = { };
            foreach (var eventOnly in eventList)
            {
                try
                {
                    var eventDto = new EventDto
                    {
                        Status = eventOnly.Status,
                        Data = eventOnly.Data,
                        Tag = eventOnly.Tag,
                        Value = eventOnly.Value
                    };
                    var indexResponse =
                        _elasticLowLevelClient.Index<BytesResponse>(index, PostData.Serializable(eventDto));
                    responseBytes.Concat(indexResponse.Body);
                }
                catch (EventException e)
                {
                    throw new EventException();
                }
            }

            return responseBytes.ToString();
        }
    }
}
