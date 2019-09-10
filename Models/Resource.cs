using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace InfotechVision.Models
{
    public enum ResourceType { Whitepaper, Video, Infographics, blog }
    public class Resource
    {
        [Key]
        public int ResourcesID { get; set; }

        [StringLength(1000)]
        public string ResourceFile { get; set; }

        public int? ContentID { get; set; }

        public virtual ContentDetail ContentDetail { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [Display(Name ="Date Time")]
        public DateTime DateTime { get; set; }

        [NotMapped]
        [Display(Name ="Resource File")]
        public IFormFile Upload { get; set; }

        [Display(Name = "Resource Type")]
        public string ResourceType
        {
            get
            {
                return this.R_Type.ToString();
            }
            set
            {
                R_Type = value.ParseEnum<ResourceType>();
            }
        }

        [NotMapped]
        [Display(Name = "Resource Type")]
        public ResourceType R_Type { get; set; }
    }
}
