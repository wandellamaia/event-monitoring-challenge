using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Events.Domain;
using Events.Infraestructure.Utils;

namespace Events.Business.Test.Documents
{
    [ExcludeFromCodeCoverage]
    public class eventsBuilder
    {
        public static List<EventEntity> Events()
        {
            return new List<EventEntity>
            {
                new EventEntity()
                {
                    Tag = "brasil.sudeste.sensor1",
                    TimeStamp = 1539112021301,
                    Value = 6
                },
                new EventEntity()
                {
                    Tag = "brasil.norte.sensor2",
                    TimeStamp = 1539112021301,
                    Value = 8
                }
            };
        }

        public static List<EventEntity> EventsWithoutValue()
        {
            return new List<EventEntity>
            {
                new EventEntity()
                {
                    Tag = "brasil.sudeste.sensor1",
                    TimeStamp = 1539112021301,
                    Value = 6
                },
                new EventEntity()
                {
                    Tag = "brasil.norte.sensor2",
                    TimeStamp = 1539112021301,
                    Value = 8
                }
            };
        }

        public static List<EventDto> EventsDto()
        {
            return new List<EventDto>
            {
                new EventDto()
                {
                    Data = Utils.GetDate(1539112021301),
                    Tag = "brasil.sudeste.sensor1",
                    Value = 6,
                    Status = "processado"
                },
                new EventDto()
                {
                    Data = Utils.GetDate(1539112021301),
                    Tag = "brasil.norte.sensor2",
                    Value = 8,
                    Status = "processado"
                }
            };
        }

        public static List<EventDto> EventsOnlyRegion()
        {
            return new List<EventDto>
            {
                new EventDto()
                {
                    Data = Utils.GetDate(1539112021301),
                    Tag = "brasil.sudeste",
                    Value = 6,
                    Status = "processado"
                },
                new EventDto()
                {
                    Data = Utils.GetDate(1539112021301),
                    Tag = "brasil.norte",
                    Value = 8,
                    Status = "processado"
                }
            };
        }

            public static List<EventDto> EventsHandling()
            {
                return new List<EventDto>
                {
                    new EventDto()
                    {
                        Data = new DateTime(),
                        Tag = "brasil.sudeste.sensor1",
                        Value = 6,
                        Status = "processado"
                    },
                    new EventDto()
                    {
                        Data = new DateTime(),
                        Tag = "brasil.norte.sensor2",
                        Value = 8,
                        Status = "processado"
                    }
                };
            }
        }
}