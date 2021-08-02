using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using Events.Infraestructure.Exception;
using Events.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Events.API.Controller
{
    [ExcludeFromCodeCoverage]
    [Route("api/")]
    [ApiController]
    public class CreateEvents : ControllerBase
    {
        private readonly IEventBusiness _eventBusiness;
        
        public CreateEvents(IEventBusiness eventBusiness)
        {
            _eventBusiness = eventBusiness;
        }

        
        [HttpGet("Event")]
        public async Task<IActionResult> InsertEvent()
        {
            try
            {
                var result = _eventBusiness.InsertEvents();
                return Ok(result);
            }catch (EventException e)
            {
                return new ObjectResult(e.Error.Description)
                {
                    StatusCode = (int) e.Error.StatusCode
                };
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}
