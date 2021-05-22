using EventPlan.Application.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EventPlan.Infrastructure.Presistence.Contexts
{

    public class EventPlanDbcontext : DbContext
    {

        public EventPlanDbcontext(DbContextOptions<EventPlanDbcontext> options) : base(options)
        {

        }
        public virtual DbSet<EventOrganiserDetail>EventOrganiserDetails{ get; set; }
        public virtual DbSet<EventDetails> EventDetails { get; set; }
    }

}
