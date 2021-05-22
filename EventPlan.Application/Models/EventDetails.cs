using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EventPlan.Application.Models
{
    [Table("EventDetails")]
    public class EventDetails
    {   
        [Key]
        public int EventId { get; set; }
        public string EventName { get; set; }
        public string EventType { get; set; }
        public string OrganiserDetails { get; set; }
        public DateTime EventDate { get; set; }
         
    }

}
