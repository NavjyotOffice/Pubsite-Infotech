using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace InfotechVision.Models
{
    public class ContentDetail
    {
        [Key]
        public int ContentID { get; set; }

        [StringLength(1000)]
        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Keywords { get; set; }

        [StringLength(1000)]
        [Required]
        public string Author { get; set; }

        [StringLength(1000)]
        public string Image { get; set; }

        [StringLength(1000)]
        [DataType(DataType.Url)]
        [Required]
        [Display(Name ="URL Link")]
        public string URL { get; set; }

        [Required]
        [Display(Name = "Company Name")]
        public string CompanyName { get; set; }

        [Display(Name = "Hide On Site")]
        public bool HideOnSite { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? UpdatedDate { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        public virtual ICollection<Event> Events { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        public virtual ICollection<News> News { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        public virtual ICollection<Resource> Resources { get; set; }

        public string CreatedById { get; set; }
        public string UpdatedById { get; set; }

        public virtual IdentityUser CreatedBy { get; set; }
        public virtual IdentityUser UpdatedBy { get; set; }


        //Not Mapped are below
        [NotMapped]
        [JsonIgnore]
        [IgnoreDataMember]
        [Display(Name ="Banner Image")]
        public IFormFile Upload { get; set; }
    }
}
