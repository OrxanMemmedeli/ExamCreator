using AutoMapper;
using Business.Abstract;
using Business.Validations;
using DTOLayer.DTOs.Subject;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ExamCreator.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SubjectController : Controller
    {
        private readonly ISubjectService _subjectService;
        private readonly IMapper _mapper;

        public SubjectController(ISubjectService SubjectService, IMapper mapper)
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

        [HttpGet]
        public virtual IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual async Task<IActionResult> Create(SubjectCreateDTO t)
        {
            var model = _mapper.Map<SubjectCreateDTO, Subject>(t);
            if (!ModelState.IsValid)
            {
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

            var model = _mapper.Map<Subject, SubjectEditDTO>(data);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual async Task<IActionResult> Edit(SubjectEditDTO t)
        {
            var model = _mapper.Map<SubjectEditDTO, Subject>(t);
            if (!ModelState.IsValid)
            {
                return View(t);
            }


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
