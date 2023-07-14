using AutoMapper;
using Business.Abstract;
using DTOLayer.DTOs.Company;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ExamCreator.Areas.Admin.Controllers
{
    public class CompanyController : BaseController<ICompanyService, CompanyCreateDTO, CompanyEditDTO, Company>
    {
        private readonly ICompanyService _companyService;
        private readonly IMapper _mapper;

        public CompanyController(ICompanyService service, IMapper mapper) : base(service, mapper)
        {
            _companyService = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Index(int page = 1)
        {
            var companies = await _companyService.GetAllAsnyc().ToListAsync();
            var datas = _mapper.Map<List<Company>, List<CompanyIndexDTO>>(companies);
            return View(datas);
        }
    }
}
