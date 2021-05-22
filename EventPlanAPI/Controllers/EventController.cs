using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EventPlan.Application.Interfaces.IServices;
using EventPlan.Application.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventPlanAPI.Controllers
{
    [Route("api/[controller]")]
    //[ApiController]
    public class EventController : ControllerBase
    {
        private readonly IEventDetailService _eventPlanService;
        public EventController(IEventDetailService eventPlanService)
        {
            _eventPlanService = eventPlanService;
        }

        [HttpPost("SaveEventDetail")]
        public ActionResult SaveEventDetail([FromBody]EventDetails eventDetails)
        {
            JSONModel objResult = new JSONModel ();
            bool result = _eventPlanService.SaveEventDetails(eventDetails);
            objResult.Data = result;
            objResult.Status = 200;
            objResult.Message = "Successful";
            return new OkObjectResult(objResult);
        }
    }
}
