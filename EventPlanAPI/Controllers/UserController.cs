using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EventPlan.Application.Interfaces.IServices;
using EventPlan.Application.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace EventPlanAPI.Controllers
{

    //[ApiController]
     [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly JsonSerializerSettings _serializerSettings;
        private readonly IUserDetailService _servicerepo;
        public UserController(IUserDetailService servicerepo)
        {
            _serializerSettings = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                NullValueHandling = NullValueHandling.Ignore
            };
            _servicerepo = servicerepo;
        }


        [HttpPost("SaveUserInformation")]
        public IActionResult SaveUserInformation([FromBody] EventOrganiserDetail userinfo)
        {
            JSONModel objResult = new JSONModel(); 
            bool result = _servicerepo.SaveUserDetails(userinfo);
           
            objResult.Data = result;
            objResult.Status = 200;
            objResult.Message = "Successful";
            return new OkObjectResult(objResult);
        }

        [HttpGet]
        public async Task<IActionResult> GetUserDetail()
        {
            JSONModel objResult = new JSONModel();
            IEnumerable<EventOrganiserDetail> eventOrganiserDetail =await _servicerepo.GetUserDetail();
            if (eventOrganiserDetail!=null && eventOrganiserDetail.Count()>0)
            {
                objResult.Data = eventOrganiserDetail;
                objResult.Status = 200;
                objResult.Message = "Successful";
              
            }
            var result = JsonConvert.SerializeObject(objResult, _serializerSettings);
            return  new OkObjectResult(result);
        }

        [HttpPost("UserLogin")]
        public IActionResult UserLogin([FromBody]EventOrganiserDetail loginModel)
        {
            JSONModel objResult = new JSONModel();
            int userId= _servicerepo.UserLogin(loginModel);
            if (userId!=0)
            {
                objResult.Data = userId;
                objResult.Status =200;
                objResult.Message = "Successful";
            }
            var result = JsonConvert.SerializeObject(objResult, _serializerSettings);
            return new OkObjectResult(result);
        }
    }




}

