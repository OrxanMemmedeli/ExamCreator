using AutoMapper;
using Business.Abstract;
using DTOLayer.DTOs.Company;
using EntityLayer.Concrete;
using ExamCreator.Attributes;
using ExamCreator.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ExamCreator.Areas.Admin.Controllers
{
    [AutoGenerateActionView(typeof(CompanyIndexDTO), typeof(CompanyCreateDTO), typeof(CompanyEditDTO))]
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
        [AutoGenerateActionView(MethodType.List)]
        public async Task<IActionResult> Index(int page = 1)
        {

            var test = typeof(CompanyIndexDTO).Namespace;
            var companies = await _companyService.GetAllAsnyc().ToListAsync();
            var datas = _mapper.Map<List<Company>, List<CompanyIndexDTO>>(companies);
            return View(datas);
        }
    }
}
