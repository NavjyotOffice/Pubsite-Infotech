using InfotechVision.Models.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InfotechVision.Models.Repository
{
    public class CompaniesRepository : Repository<Company>, ICompaniesRepository
    {
        private readonly DbContext context;
        public CompaniesRepository(DbContext context):base(context)
        {
            this.context = context;
        }

        public Company GetCompanyByIDForAdmin(int? Id)
        {
            return this.context.Set<Company>().Include(c => c.Address).Include(c => c.CreatedBy).Include(c => c.UpdatedBy).SingleOrDefault(c=>c.CompanyID==Id);
        }

        public Company GetCompanyByIDForUser(int? Id, string userEmail)
        {
            return this.context.Set<Company>().Include(c => c.Address).Where(c => c.CreatedBy.Email.Contains(userEmail)).SingleOrDefault(c => c.CompanyID == Id);
        }

        public IEnumerable<Company> GetCompanyForAdmin()
        {
            return this.context.Set<Company>();
        }

        public IEnumerable<Company> GetCompanyForUser(string userEmail)
        {
            return this.context.Set<Company>().Where(c=>c.CreatedBy.Email.Contains(userEmail));
        }
    }
}
