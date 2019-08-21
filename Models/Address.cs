using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace InfotechVision.Models
{
    public class Address
    {
        public int AddressID { get; set; }

        [StringLength(1000)]
        public string DetailAddress { get; set; }

        [StringLength(1000)]
        public string City { get; set; }

        [StringLength(1000)]
        public string State { get; set; }

        [StringLength(1000)]
        public string Country { get; set; }

        [StringLength(10)]
        public string ZipCode { get; set; }

        public int? Contact { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        public virtual Contact Contact1 { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Event> Events { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Company> Company { get; set; }
    }
}
