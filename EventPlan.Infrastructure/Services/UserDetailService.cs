using EventPlan.Application.Models;
using EventPlan.Infrastructure.Presistence.Contexts;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using EventPlan.Application.Interfaces.IServices;

namespace EventPlan.Infrastructure.Services
{
   public class UserDetailService: IUserDetailService
    {
        private readonly EventPlanDbcontext _eventPlanDbContext;  
        public UserDetailService(EventPlanDbcontext eventPlanDbcontext)
        {
            _eventPlanDbContext = eventPlanDbcontext;
        }
        public  async Task<IEnumerable<EventOrganiserDetail>> GetUserDetail()
        {
            List<EventOrganiserDetail> userDetailModel = null;
            try
            {

                await Task.Run(() =>
                {
                  userDetailModel = _eventPlanDbContext.EventOrganiserDetails.ToList();

                  });
               
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return userDetailModel;
        }
    
        public bool SaveUserDetails(EventOrganiserDetail userDetail)
        {
            bool status = false;

            try
            {
                if (userDetail.Id == 0)
                {
                    _eventPlanDbContext.EventOrganiserDetails.Add(userDetail);
                    _eventPlanDbContext.SaveChanges();
                    status = true;
                }


            }
            catch (Exception ex)
            {
                throw ex;
            }
            return status;
        }

        public int UserLogin(EventOrganiserDetail eventOrganiserDetail)
        {
            int userId = 0;
            try
            {
              var userdetails = _eventPlanDbContext.EventOrganiserDetails.FirstOrDefault(x => x.Email== eventOrganiserDetail.Email && x.Password== eventOrganiserDetail.Password);
             if(userdetails != null && userdetails.Id>0)
                    userId = userdetails.Id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return userId;
          
        }

        
    }

}

