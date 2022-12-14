using AutoMapper;
using Business.Abstract;
using Business.Validations;
using EntityLayer.Concrete;
using ExamCreator.Areas.Admin.Models.ViewModels.Section;
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
        private readonly SectionValidator _sectionValidator;

        private readonly ISubjectService _subjectService;

        public SectionController(ISectionService SectionService, IMapper mapper, SectionValidator sectionValidator, ISubjectService subjectService)
        {
            _sectionService = SectionService;
            _mapper = mapper;
            _sectionValidator = sectionValidator;
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
            var datas = _mapper.Map<List<Section>, List<ListSection>>(Sections);
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
        public virtual async Task<IActionResult> Create(CreateSection t)
        {
            var model = _mapper.Map<CreateSection, Section>(t);
            var modelState = _sectionValidator.Validate(model);
            if (!modelState.IsValid)
            {
                if (modelState.Errors != null)
                    modelState.Errors.ForEach(item => ModelState.AddModelError(item.PropertyName, item.ErrorMessage));
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

            var model = _mapper.Map<Section, EditSection>(data);

            GetFields();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual async Task<IActionResult> Edit(EditSection t)
        {
            var model = _mapper.Map<EditSection, Section>(t);
            var modelState = _sectionValidator.Validate(model);
            if (!modelState.IsValid)
            {
                if (modelState.Errors != null)
                    modelState.Errors.ForEach(item => ModelState.AddModelError(item.PropertyName, item.ErrorMessage));
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
