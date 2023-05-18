using AutoMapper;
using Business.Abstract;
using Business.Validations;
using DTOLayer.DTOs.QuestionLevel;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ExamCreator.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class QuestionLevelController : Controller
    {
        private readonly IQuestionLevelService _questionLevelService;
        private readonly IMapper _mapper;
        private readonly QuestionLevelValidator _questionLevelValidator;

        public QuestionLevelController(IQuestionLevelService QuestionLevelService, IMapper mapper, QuestionLevelValidator questionLevelValidator)
        {
            _questionLevelService = QuestionLevelService;
            _mapper = mapper;
            _questionLevelValidator = questionLevelValidator;
        }

        [HttpGet]
        public virtual async Task<IActionResult> Index(int page = 1)
        {
            var QuestionLevels = await _questionLevelService.GetAllAsnyc().OrderBy(x => x.Level).ToListAsync();
            var datas = _mapper.Map<List<QuestionLevel>, List<QuestionLevelIndexDTO>>(QuestionLevels);
            return View(datas);
        }

        [HttpGet]
        public virtual IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual async Task<IActionResult> Create(QuestionLevelCreateDTO t)
        {
            var model = _mapper.Map<QuestionLevelCreateDTO, QuestionLevel>(t);
            var modelState = _questionLevelValidator.Validate(model);
            if (!modelState.IsValid)
            {
                if (modelState.Errors != null)
                    modelState.Errors.ForEach(item => ModelState.AddModelError(item.PropertyName, item.ErrorMessage));
                return View(t);
            }

            await _questionLevelService.Insert(model);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public virtual async Task<IActionResult> Edit(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var data = await _questionLevelService.GetByIdAsnyc(id);
            if (data == null)
            {
                return NotFound();
            }

            var model = _mapper.Map<QuestionLevel, QuestionLevelEditDTO>(data);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual async Task<IActionResult> Edit(QuestionLevelEditDTO t)
        {
            var model = _mapper.Map<QuestionLevelEditDTO, QuestionLevel>(t);
            var modelState = _questionLevelValidator.Validate(model);
            if (!modelState.IsValid)
            {
                if (modelState.Errors != null)
                    modelState.Errors.ForEach(item => ModelState.AddModelError(item.PropertyName, item.ErrorMessage));
                return View(t);
            }


            await _questionLevelService.Update(model, model.Id);
            return RedirectToAction(nameof(Index));
        }

        public virtual async Task<IActionResult> Delete(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var data = await _questionLevelService.GetByIdAsnyc(id);
            if (data == null)
            {
                return NotFound();
            }
            await _questionLevelService.Delete(data);
            return RedirectToAction(nameof(Index));
        }

        public virtual async Task<IActionResult> Remove(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var data = await _questionLevelService.GetByIdAsnyc(id);
            if (data == null)
            {
                return NotFound();
            }
            await _questionLevelService.Remove(data);
            return RedirectToAction(nameof(Index));
        }
    }
}
