using AutoMapper;
using Business.Abstract;
using Business.Validations;
using DTOLayer.DTOs.Grade;
using DTOLayer.DTOs.Subject;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ExamCreator.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SubjectController : BaseController<ISubjectService, SubjectCreateDTO, SubjectEditDTO, Subject>
    {
        private readonly ISubjectService _subjectService;
        private readonly IMapper _mapper;

        public SubjectController(ISubjectService SubjectService, IMapper mapper)
            : base (SubjectService, mapper)
        {
            _subjectService = SubjectService;
            _mapper = mapper;
        }

        [HttpGet]
        public virtual async Task<IActionResult> Index(int page = 1)
        {
            var Subjects = await _subjectService.GetAllAsnyc().ToListAsync();
            var datas = _mapper.Map<List<Subject>, List<SubjectIndexDTO>>(Subjects);
            return View(datas);
        }
     

    }
}
