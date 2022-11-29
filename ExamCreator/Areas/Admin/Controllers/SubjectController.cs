using AutoMapper;
using Business.Abstract;
using Business.Validations;
using EntityLayer.Concrete;
using ExamCreator.Areas.Admin.Models.ViewModels.Subject;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ExamCreator.Areas.Admin.Controllers
{
    public class SubjectController : Controller
    {
        private readonly ISubjectService _subjectService;
        private readonly IMapper _mapper;
        private readonly SubjectValidator _subjectValidator;

        public SubjectController(ISubjectService SubjectService, IMapper mapper, SubjectValidator subjectValidator)
        {
            _subjectService = SubjectService;
            _mapper = mapper;
            _subjectValidator = subjectValidator;
        }

        [HttpGet]
        public virtual async Task<IActionResult> Index(int page = 1)
        {
            var Subjects = await _subjectService.GetAllAsnyc().ToListAsync();
            var datas = _mapper.Map<List<Subject>, List<ListSubject>>(Subjects);
            return View(datas);
        }

        [HttpGet]
        public virtual IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual async Task<IActionResult> Create(CreateSubject t)
        {
            var model = _mapper.Map<CreateSubject, Subject>(t);
            var modelState = _subjectValidator.Validate(model);
            if (!modelState.IsValid)
            {
                if (modelState.Errors != null)
                    modelState.Errors.ForEach(item => ModelState.AddModelError(item.PropertyName, item.ErrorMessage));
                return View(t);
            }

            await _subjectService.Insert(model);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public virtual async Task<IActionResult> Edit(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var data = await _subjectService.GetByIdAsnyc(id);
            if (data == null)
            {
                return NotFound();
            }

            var model = _mapper.Map<Subject, EditSubject>(data);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual async Task<IActionResult> Edit(EditSubject t)
        {
            if (!ModelState.IsValid)
            {
                return View(t);
            }
            var model = _mapper.Map<EditSubject, Subject>(t);

            await _subjectService.Update(model, model.Id);
            return RedirectToAction(nameof(Index));
        }

        public virtual async Task<IActionResult> Delete(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var data = await _subjectService.GetByIdAsnyc(id);
            if (data == null)
            {
                return NotFound();
            }
            await _subjectService.Delete(data);
            return RedirectToAction(nameof(Index));
        }

        public virtual async Task<IActionResult> Remove(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var data = await _subjectService.GetByIdAsnyc(id);
            if (data == null)
            {
                return NotFound();
            }
            await _subjectService.Remove(data);
            return RedirectToAction(nameof(Index));
        }
    }
}
