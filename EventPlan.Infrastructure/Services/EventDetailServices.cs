using EventPlan.Application.Interfaces.IServices;
using EventPlan.Application.Models;
using EventPlan.Infrastructure.Presistence.Contexts;
using System;
using System.Collections.Generic;
using System.Text;

namespace EventPlan.Infrastructure.Services
{
    public class EventDetailServices:IEventDetailService
    {
        private readonly EventPlanDbcontext _eventPlanDbContext;
        public EventDetailServices(EventPlanDbcontext eventPlanDbcontext)
        {
            _eventPlanDbContext = eventPlanDbcontext; 
        }

       
        public bool SaveEventDetails(EventDetails eventDetails)
        {
            bool status = false;
            try
            {
                if (eventDetails.EventId== 0)
                {
                    _eventPlanDbContext.EventDetails.Add(eventDetails);
                    _eventPlanDbContext.SaveChanges();
                }
                status = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return status;
        }

    }
}
