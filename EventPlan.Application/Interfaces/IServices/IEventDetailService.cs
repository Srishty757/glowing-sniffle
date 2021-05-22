using EventPlan.Application.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace EventPlan.Application.Interfaces.IServices
{
  public  interface IEventDetailService
    {
        bool SaveEventDetails(EventDetails eventDetails);
    }
}
