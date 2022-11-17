using AutoMapper;
using Business.Abstract;
using EntityLayer.Concrete;
using ExamCreator.Areas.Admin.Models.ViewModels.Grade;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ExamCreator.Areas.Admin.Controllers
{
    public class GradeController : Controller
    {
        private readonly IGradeService _gradeService;
        private readonly IMapper _mapper;

        public GradeController(IGradeService gradeService, IMapper mapper = null)
        {
            _gradeService = gradeService;
            _mapper = mapper;
        }

        [HttpGet]
        public virtual async Task<IActionResult> Index(int page = 1)
        {
            var grades = await _gradeService.GetAllAsnyc().ToListAsync();
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
            ModelState.Clear();
            var model = _mapper.Map<CreateGrade, Grade>(t);
            if (!ModelState.IsValid)
            {
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
            if (!ModelState.IsValid)
            {
                return View(t);
            }
            var model = _mapper.Map<EditGrade, Grade>(t);

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
            _gradeService.Remove(data);
            return RedirectToAction(nameof(Index));
        }
    }
}
