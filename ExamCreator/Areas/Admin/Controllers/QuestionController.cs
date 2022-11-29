using AutoMapper;
using Business.Abstract;
using Business.Validations;
using EntityLayer.Concrete;
using ExamCreator.Areas.Admin.Models.ViewModels.Question;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ExamCreator.Areas.Admin.Controllers
{
    public class QuestionController : Controller
    {
        private readonly IQuestionService _questionService;
        private readonly IMapper _mapper;
        private readonly QuestionValidator _questionValidator;

        public QuestionController(IQuestionService QuestionService, IMapper mapper, QuestionValidator questionValidator)
        {
            _questionService = QuestionService;
            _mapper = mapper;
            _questionValidator = questionValidator;
        }

        [HttpGet]
        public virtual async Task<IActionResult> Index(int page = 1)
        {
            var Questions = await _questionService.GetAllAsnyc().ToListAsync();
            var datas = _mapper.Map<List<Question>, List<ListQuestion>>(Questions);
            return View(datas);
        }

        [HttpGet]
        public virtual IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual async Task<IActionResult> Create(CreateQuestion t)
        {
            var model = _mapper.Map<CreateQuestion, Question>(t);
            var modelState = _questionValidator.Validate(model);
            if (!modelState.IsValid)
            {
                if (modelState.Errors != null)
                    modelState.Errors.ForEach(item => ModelState.AddModelError(item.PropertyName, item.ErrorMessage));
                return View(t);
            }

            await _questionService.Insert(model);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public virtual async Task<IActionResult> Edit(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var data = await _questionService.GetByIdAsnyc(id);
            if (data == null)
            {
                return NotFound();
            }

            var model = _mapper.Map<Question, EditQuestion>(data);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual async Task<IActionResult> Edit(EditQuestion t)
        {
            if (!ModelState.IsValid)
            {
                return View(t);
            }
            var model = _mapper.Map<EditQuestion, Question>(t);

            await _questionService.Update(model, model.Id);
            return RedirectToAction(nameof(Index));
        }

        public virtual async Task<IActionResult> Delete(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var data = await _questionService.GetByIdAsnyc(id);
            if (data == null)
            {
                return NotFound();
            }
            await _questionService.Delete(data);
            return RedirectToAction(nameof(Index));
        }

        public virtual async Task<IActionResult> Remove(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var data = await _questionService.GetByIdAsnyc(id);
            if (data == null)
            {
                return NotFound();
            }
            await _questionService.Remove(data);
            return RedirectToAction(nameof(Index));
        }
    }
}
