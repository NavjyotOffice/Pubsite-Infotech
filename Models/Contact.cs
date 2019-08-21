using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InfotechVision.Models
{
    public class Contact
    {
        public int ContactID { get; set; }

        [StringLength(1000)]
        public string Email { get; set; }

        [StringLength(20)]
        public string Phone { get; set; }

        public virtual ICollection<Address> Addresses { get; set; }
    }
}
