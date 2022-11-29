using AutoMapper;
using Business.Abstract;
using Business.Validations;
using EntityLayer.Concrete;
using ExamCreator.Areas.Admin.Models.ViewModels.Section;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ExamCreator.Areas.Admin.Controllers
{
    public class SectionController : Controller
    {
        private readonly ISectionService _sectionService;
        private readonly IMapper _mapper;
        private readonly SectionValidator _sectionValidator;

        public SectionController(ISectionService SectionService, IMapper mapper, SectionValidator sectionValidator)
        {
            _sectionService = SectionService;
            _mapper = mapper;
            _sectionValidator = sectionValidator;
        }

        [HttpGet]
        public virtual async Task<IActionResult> Index(int page = 1)
        {
            var Sections = await _sectionService.GetAllAsnyc().ToListAsync();
            var datas = _mapper.Map<List<Section>, List<ListSection>>(Sections);
            return View(datas);
        }

        [HttpGet]
        public virtual IActionResult Create()
        {
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

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual async Task<IActionResult> Edit(EditSection t)
        {
            if (!ModelState.IsValid)
            {
                return View(t);
            }
            var model = _mapper.Map<EditSection, Section>(t);

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
