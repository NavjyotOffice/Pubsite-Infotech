using InfotechVision.Models.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InfotechVision.Models.Repository
{
    public class AddressRepository : Repository<Address>, IAddresssRepository
    {
        private readonly DbContext context;

        public AddressRepository(DbContext context):base(context)
        {
            this.context = context;
        }
    }
}
