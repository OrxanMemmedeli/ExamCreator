using AutoMapper;
using Business.Abstract;
using Business.Validations;
using DTOLayer.DTOs.Grade;
using DTOLayer.DTOs.Section;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace ExamCreator.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SectionController : BaseController<ISectionService, SectionCreateDTO, SectionEditDTO, Section>
    {
        private readonly ISectionService _sectionService;
        private readonly IMapper _mapper;

        private readonly ISubjectService _subjectService;

        public SectionController(ISectionService SectionService, IMapper mapper, ISubjectService subjectService)
            : base(SectionService, mapper)
        {
            _sectionService = SectionService;
            _mapper = mapper;
            _subjectService = subjectService;
        }

        protected override async Task GetFields()
        {
            ViewData["SubjectId"] = new SelectList(await _subjectService.GetAllAsnyc().ToListAsync(), "Id", "Name");
        }


        [HttpGet]
        public virtual async Task<IActionResult> Index(int page = 1)
        {
            var Sections = await _sectionService.GetAllAsnyc(x => x.Subject).OrderBy(x => x.Subject.Name).ToListAsync();
            var datas = _mapper.Map<List<Section>, List<SectionIndexDTO>>(Sections);
            return View(datas);
        }

    }
}
