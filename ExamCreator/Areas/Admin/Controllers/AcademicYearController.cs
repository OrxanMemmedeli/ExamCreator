using AutoMapper;
using Business.Abstract;
using Business.Validations;
using DTOLayer.DTOs.AcademicYear;
using DTOLayer.DTOs.Grade;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ExamCreator.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AcademicYearController : BaseController<IAcademicYearService, AcademicYearCreateDTO, AcademicYearEditDTO, AcademicYear>
    {
        private readonly IAcademicYearService _academicYearService;
        private readonly IMapper _mapper;

        public AcademicYearController(IAcademicYearService academicYearService, IMapper mapper) 
            : base (academicYearService, mapper)
        {
            _academicYearService = academicYearService;
            _mapper = mapper;
        }

        [HttpGet]
        public virtual async Task<IActionResult> Index(int page = 1)
        {
            var AcademicYears = await _academicYearService.GetAllAsnyc().ToListAsync();
            var datas = _mapper.Map<List<AcademicYear>, List<AcademicYearIndexDTO>>(AcademicYears);
            return View(datas);
        }

    }
}
