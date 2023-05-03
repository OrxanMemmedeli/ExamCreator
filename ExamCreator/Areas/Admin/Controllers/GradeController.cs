using AutoMapper;
using Business.Abstract;
using Business.Validations;
using CoreLayer.Helpers.Tools;
using EntityLayer.Concrete;
using ExamCreator.Areas.Admin.Models.ViewModels.Grade;
using ExamCreator.Attributes;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace ExamCreator.Areas.Admin.Controllers
{
    [Area("Admin")]
    //[CompanyAccess(typeof(IHttpContextAccessor))]
    public class GradeController : Controller
    {
        private readonly IGradeService _gradeService;
        private readonly IMapper _mapper;
        private readonly GradeValidator _gradeValidator;

        public GradeController(IGradeService gradeService, IMapper mapper, GradeValidator gradeValidator)
        {
            _gradeService = gradeService;
            _mapper = mapper;
            _gradeValidator = gradeValidator;
        }

        [HttpGet]
        public virtual async Task<IActionResult> Index(int page = 1)
        {
            var grades = await _gradeService.GetAllAsnyc().OrderBy(x => x.Name).ToListAsync();
            var datas = _mapper.Map<List<Grade>, List<ListGrade>>(grades);
            return View(datas);
        }

        [HttpGet]
        public virtual IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual async Task<IActionResult> Create(CreateGrade t)
        {
            var model = _mapper.Map<CreateGrade, Grade>(t);
            var modelState = _gradeValidator.Validate(model);
            if (!modelState.IsValid)
            {
                if (modelState.Errors != null)
                    modelState.Errors.ForEach(item => ModelState.AddModelError(item.PropertyName, item.ErrorMessage));
                return View(t);
            }

            await _gradeService.Insert(model);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public virtual async Task<IActionResult> Edit(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var data = await _gradeService.GetByIdAsnyc(id);
            if (data == null)
            {
                return NotFound();
            }

            var model = _mapper.Map<Grade, EditGrade>(data);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual async Task<IActionResult> Edit(EditGrade t)
        {
            var model = _mapper.Map<EditGrade, Grade>(t);
            var modelState = _gradeValidator.Validate(model);
            if (!modelState.IsValid)
            {
                if (modelState.Errors != null)
                    modelState.Errors.ForEach(item => ModelState.AddModelError(item.PropertyName, item.ErrorMessage));
                return View(t);
            }

            await _gradeService.Update(model, model.Id);
            return RedirectToAction(nameof(Index));
        }

        public virtual async Task<IActionResult> Delete(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var data = await _gradeService.GetByIdAsnyc(id);
            if (data == null)
            {
                return NotFound();
            }
            await _gradeService.Delete(data);
            return RedirectToAction(nameof(Index));
        }

        public virtual async Task<IActionResult> Remove(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var data = await _gradeService.GetByIdAsnyc(id);
            if (data == null)
            {
                return NotFound();
            }
            await _gradeService.Remove(data);
            return RedirectToAction(nameof(Index));
        }
    }
}
