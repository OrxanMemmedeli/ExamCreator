using AutoMapper;
using Business.Abstract;
using Business.Validations;
using DTOLayer.DTOs.Section;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace ExamCreator.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SectionController : Controller
    {
        private readonly ISectionService _sectionService;
        private readonly IMapper _mapper;

        private readonly ISubjectService _subjectService;

        public SectionController(ISectionService SectionService, IMapper mapper, SectionValidator sectionValidator, ISubjectService subjectService)
        {
            _sectionService = SectionService;
            _mapper = mapper;
            _subjectService = subjectService;
        }

        private void GetFields()
        {
            ViewData["SubjectId"] = new SelectList(_subjectService.GetAllAsnyc(), "Id", "Name");
        }

        [HttpGet]
        public virtual async Task<IActionResult> Index(int page = 1)
        {
            var Sections = await _sectionService.GetAllAsnyc(x => x.Subject).OrderBy(x => x.Subject.Name).ToListAsync();
            var datas = _mapper.Map<List<Section>, List<SectionIndexDTO>>(Sections);
            return View(datas);
        }

        [HttpGet]
        public virtual IActionResult Create()
        {
            GetFields();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual async Task<IActionResult> Create(SectionCreateDTO t)
        {
            var model = _mapper.Map<SectionCreateDTO, Section>(t);
            if (!ModelState.IsValid)
            {
                GetFields();
                return View(t);
            }

            await _sectionService.Insert(model);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public virtual async Task<IActionResult> Edit(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var data = await _sectionService.GetByIdAsnyc(id);
            if (data == null)
            {
                return NotFound();
            }

            var model = _mapper.Map<Section, SectionEditDTO>(data);

            GetFields();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual async Task<IActionResult> Edit(SectionEditDTO t)
        {
            var model = _mapper.Map<SectionEditDTO, Section>(t);
            if (!ModelState.IsValid)
            {
                GetFields();
                return View(t);
            }

            await _sectionService.Update(model, model.Id);
            return RedirectToAction(nameof(Index));
        }

        public virtual async Task<IActionResult> Delete(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var data = await _sectionService.GetByIdAsnyc(id);
            if (data == null)
            {
                return NotFound();
            }
            await _sectionService.Delete(data);
            return RedirectToAction(nameof(Index));
        }

        public virtual async Task<IActionResult> Remove(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var data = await _sectionService.GetByIdAsnyc(id);
            if (data == null)
            {
                return NotFound();
            }
            await _sectionService.Remove(data);
            return RedirectToAction(nameof(Index));
        }
    }
}
