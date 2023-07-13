using Business.Abstract.Generic;
using DTOLayer.DTOs.Company;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICompanyService : IGenericService<Company>
    {
        Task UpdateForJob(CompanyJobUpdateDTO t);
        Task UpdateForStatus(bool status);
    }
}
