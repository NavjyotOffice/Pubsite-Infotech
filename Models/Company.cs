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
    public class Company
    {
        [Key]
        public int CompanyID { get; set; }

        [StringLength(1000)]
        public string CompanyName { get; set; }

        public string Description { get; set; }

        [StringLength(1000)]
        [DataType(DataType.Url)]
        public string WebsiteURL { get; set; }

        [StringLength(1000)]
        public string LogoImage { get; set; }

        public bool HideOnSite { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public string CreatedById { get; set; }
        public string UpdatedById { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        public virtual IdentityUser CreatedBy { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        public virtual IdentityUser UpdatedBy { get; set; }

        public int? AddressID { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        public virtual Address Address { get; set; }

        ////Not Mapped are below
        [NotMapped]
        public IFormFile Upload { get; set; }
    }
}
