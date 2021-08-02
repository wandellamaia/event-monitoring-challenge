using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using Events.Business.Test.Documents;
using Events.Domain;
using Events.Infraestructure.Exception;
using Events.Interface;
using Moq;
using Xunit;

namespace Events.Business.Test
{
    [ExcludeFromCodeCoverage]
    public class EventsTest
    {
        private readonly Mock<IEventsElasticRepository> eventsElasticRepository;

        public EventsTest()
        {
            eventsElasticRepository = new Mock<IEventsElasticRepository>();
        }
        
        [Fact]
        public async Task CreateEventTest()
        {
            List<EventEntity> eventList = eventsBuilder.Events();
            
            //Configurações
            eventsElasticRepository.Setup(x => x.EventGenerate())
                .Returns(eventList);
            
            var creatEventBusiness = new EventBusiness(eventsElasticRepository.Object);
            List<EventEntity> events = creatEventBusiness.CreateEvent();
            
            Assert.Equal(eventList, events);
        }
        
        [Fact]
        public async Task EventHandlingTest()
        {
            List<EventEntity> eventList = eventsBuilder.Events();
            List<EventDto> eventsDto = eventsBuilder.EventsDto();
            
            //Configurações
            eventsElasticRepository.Setup(x => x.EventGenerate())
                .Returns(eventList);
            
            var creatEventBusiness = new EventBusiness(eventsElasticRepository.Object);
            List<EventDto> eventsHandling = creatEventBusiness.EventHandling(eventList);
            
            Assert.Equal(eventsDto[0].Data, eventsHandling[0].Data);
        }
        
        [Fact]
        public async Task EventeventsInlyRegionTest()
        {
            List<EventEntity> events = eventsBuilder.Events();
            List<EventDto> eventList = eventsBuilder.EventsDto();
            List<EventDto> eventsOnlyRegion = eventsBuilder.EventsOnlyRegion();
           
            //Configurações
            eventsElasticRepository.Setup(x => x.EventGenerate())
                .Returns(events);
            
            var creatEventBusiness = new EventBusiness(eventsElasticRepository.Object);
            List<EventDto> eventsHandling = creatEventBusiness.EventFromRegion(eventList);
            
            Assert.Equal(eventsOnlyRegion[0].Tag, eventsHandling[0].Tag);
        }

        [Fact]
        public async Task InsertEventWithoutIndexTest()
        {
            List<EventEntity> events = eventsBuilder.Events();
            List<EventDto> eventsOnlyRegion = eventsBuilder.EventsOnlyRegion();
           
            //Configurações
            eventsElasticRepository.Setup(x => x.EventGenerate())
                .Returns(events);
            
            var createEventBusiness = new EventBusiness(eventsElasticRepository.Object);
            // Act
            string Act() => createEventBusiness.Insert(eventsOnlyRegion,null);
            
            // Assert
            Assert.Throws<EventException>(Act);
        }
        
        [Fact]
        public async Task InsertEvent()
        {
            List<EventEntity> events = eventsBuilder.Events();
            List<EventDto> eventsOnlyRegion = eventsBuilder.EventsOnlyRegion();
           
            //Configurações
            eventsElasticRepository.Setup(x => x.EventGenerate())
                .Returns(events);
            
            var createEventBusiness = new EventBusiness(eventsElasticRepository.Object);
            // Act
            string Act() => createEventBusiness.InsertEvents();
            
            // Assert
            Assert.Equal("OK",Act());
        }
    }
}