using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InfotechVision.Models.IRepository
{
    public interface ICompaniesRepository:IRepository<Company>
    {
        IEnumerable<Company> GetCompanyForAdmin();
        IEnumerable<Company> GetCompanyForUser(string userEmail);
        Company GetCompanyByIDForAdmin(int? Id);
        Company GetCompanyByIDForUser(int? Id, string userEmail);
    }
}
