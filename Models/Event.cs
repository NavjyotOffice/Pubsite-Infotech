using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace InfotechVision.Models
{
    public enum EventType
    {
        [Display(Name = "Conference")]
        Conference,

        [Display(Name = "OnDemand Webinar")]
        OnDemand,

        [Display(Name = "Live Webinar")]
        Live
    }

    public class Event
    {
        public int EventID { get; set; }

        public int? AddressID { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [Display(Name ="Start Date")]
        public DateTime? StartDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [Display(Name = "End Date")]
        public DateTime? EndDate { get; set; }

        public int? ContentID { get; set; }

        public virtual Address Address { get; set; }

        public virtual ContentDetail ContentDetail { get; set; }

        [Display(Name = "Event Type")]
        public string EventType
        {
            get
            {
                return this.E_Type.ToString();
            }
            set
            {
                E_Type = value.ParseEnum<EventType>();
            }
        }

        [NotMapped]
        [Required]
        [Display(Name = "Event Type")]
        public EventType? E_Type { get; set; }
    }
}
