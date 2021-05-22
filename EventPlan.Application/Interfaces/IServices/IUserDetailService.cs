using EventPlan.Application.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EventPlan.Application.Interfaces.IServices
{
   public  interface IUserDetailService
    {
        Task<IEnumerable<EventOrganiserDetail>> GetUserDetail();
        int UserLogin(EventOrganiserDetail eventOrganiserDetail);
        bool SaveUserDetails(EventOrganiserDetail userDetail);

       
    }
}
