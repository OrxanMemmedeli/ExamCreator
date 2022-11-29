using AutoMapper;
using Business.Abstract;
using Business.Validations;
using EntityLayer.Concrete;
using ExamCreator.Areas.Admin.Models.ViewModels.QuestionType;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ExamCreator.Areas.Admin.Controllers
{
    public class QuestionTypeController : Controller
    {
        private readonly IQuestionTypeService _questionTypeService;
        private readonly IMapper _mapper;
        private readonly QuestionTypeValidator _questionTypeValidator;

        public QuestionTypeController(IQuestionTypeService QuestionTypeService, IMapper mapper, QuestionTypeValidator questionTypeValidator)
        {
            _questionTypeService = QuestionTypeService;
            _mapper = mapper;
            _questionTypeValidator = questionTypeValidator;
        }

        [HttpGet]
        public virtual async Task<IActionResult> Index(int page = 1)
        {
            var QuestionTypes = await _questionTypeService.GetAllAsnyc().ToListAsync();
            var datas = _mapper.Map<List<QuestionType>, List<ListQuestionType>>(QuestionTypes);
            return View(datas);
        }

        [HttpGet]
        public virtual IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual async Task<IActionResult> Create(CreateQuestionType t)
        {
            var model = _mapper.Map<CreateQuestionType, QuestionType>(t);
            var modelState = _questionTypeValidator.Validate(model);
            if (!modelState.IsValid)
            {
                if (modelState.Errors != null)
                    modelState.Errors.ForEach(item => ModelState.AddModelError(item.PropertyName, item.ErrorMessage));
                return View(t);
            }

            await _questionTypeService.Insert(model);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public virtual async Task<IActionResult> Edit(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var data = await _questionTypeService.GetByIdAsnyc(id);
            if (data == null)
            {
                return NotFound();
            }

            var model = _mapper.Map<QuestionType, EditQuestionType>(data);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual async Task<IActionResult> Edit(EditQuestionType t)
        {
            if (!ModelState.IsValid)
            {
                return View(t);
            }
            var model = _mapper.Map<EditQuestionType, QuestionType>(t);

            await _questionTypeService.Update(model, model.Id);
            return RedirectToAction(nameof(Index));
        }

        public virtual async Task<IActionResult> Delete(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var data = await _questionTypeService.GetByIdAsnyc(id);
            if (data == null)
            {
                return NotFound();
            }
            await _questionTypeService.Delete(data);
            return RedirectToAction(nameof(Index));
        }

        public virtual async Task<IActionResult> Remove(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var data = await _questionTypeService.GetByIdAsnyc(id);
            if (data == null)
            {
                return NotFound();
            }
            await _questionTypeService.Remove(data);
            return RedirectToAction(nameof(Index));
        }
    }
}
