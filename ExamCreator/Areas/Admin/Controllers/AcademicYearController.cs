using AutoMapper;
using Business.Abstract;
using Business.Validations;
using DTOLayer.DTOs.AcademicYear;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ExamCreator.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AcademicYearController : Controller
    {
        private readonly IAcademicYearService _academicYearService;
        private readonly IMapper _mapper;
        private readonly AcademicYearValidator _academicYearValidator;

        public AcademicYearController(IAcademicYearService academicYearService, IMapper mapper, AcademicYearValidator academicYearValidator)
        {
            _academicYearService = academicYearService;
            _mapper = mapper;
            _academicYearValidator = academicYearValidator;
        }

        [HttpGet]
        public virtual async Task<IActionResult> Index(int page = 1)
        {
            var AcademicYears = await _academicYearService.GetAllAsnyc().ToListAsync();
            var datas = _mapper.Map<List<AcademicYear>, List<AcademicYearIndexDTO>>(AcademicYears);
            return View(datas);
        }

        [HttpGet]
        public virtual IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual async Task<IActionResult> Create(AcademicYearCreateDTO t)
        {
            var model = _mapper.Map<AcademicYearCreateDTO, AcademicYear>(t);
            var modelState = _academicYearValidator.Validate(model);
            if (!modelState.IsValid)
            {
                if (modelState.Errors != null)
                    modelState.Errors.ForEach(item => ModelState.AddModelError(item.PropertyName, item.ErrorMessage));
                return View(t);
            }

            await _academicYearService.Insert(model);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public virtual async Task<IActionResult> Edit(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var data = await _academicYearService.GetByIdAsnyc(id);
            if (data == null)
            {
                return NotFound();
            }

            var model = _mapper.Map<AcademicYear, AcademicYearEditDTO>(data);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual async Task<IActionResult> Edit(AcademicYearEditDTO t)
        {
            var model = _mapper.Map<AcademicYearEditDTO, AcademicYear>(t);

            var modelState = _academicYearValidator.Validate(model);
            if (!modelState.IsValid)
            {
                if (modelState.Errors != null)
                    modelState.Errors.ForEach(item => ModelState.AddModelError(item.PropertyName, item.ErrorMessage));
                return View(t);
            }

            await _academicYearService.Update(model, model.Id);
            return RedirectToAction(nameof(Index));
        }

        public virtual async Task<IActionResult> Delete(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var data = await _academicYearService.GetByIdAsnyc(id);
            if (data == null)
            {
                return NotFound();
            }
            await _academicYearService.Delete(data);
            return RedirectToAction(nameof(Index));
        }

        public virtual async Task<IActionResult> Remove(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var data = await _academicYearService.GetByIdAsnyc(id);
            if (data == null)
            {
                return NotFound();
            }
            await _academicYearService.Remove(data);
            return RedirectToAction(nameof(Index));
        }
    }
}
