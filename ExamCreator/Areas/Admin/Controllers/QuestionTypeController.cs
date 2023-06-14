using AutoMapper;
using Business.Abstract;
using Business.Validations;
using DTOLayer.DTOs.QuestionType;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ExamCreator.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class QuestionTypeController : Controller
    {
        private readonly IQuestionTypeService _questionTypeService;
        private readonly IMapper _mapper;

        public QuestionTypeController(IQuestionTypeService QuestionTypeService, IMapper mapper)
        {
            _questionTypeService = QuestionTypeService;
            _mapper = mapper;
        }

        [HttpGet]
        public virtual async Task<IActionResult> Index(int page = 1)
        {
            var QuestionTypes = await _questionTypeService.GetAllAsnyc().ToListAsync();
            var datas = _mapper.Map<List<QuestionType>, List<QuestionTypeIndexDTO>>(QuestionTypes);
            return View(datas);
        }

        [HttpGet]
        public virtual IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual async Task<IActionResult> Create(QuestionTypeCreateDTO t)
        {
            var model = _mapper.Map<QuestionTypeCreateDTO, QuestionType>(t);
            if (!ModelState.IsValid)
            {
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

            var model = _mapper.Map<QuestionType, QuestionTypeEditDTO>(data);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual async Task<IActionResult> Edit(QuestionTypeEditDTO t)
        {
            var model = _mapper.Map<QuestionTypeEditDTO, QuestionType>(t);
            if (!ModelState.IsValid)
            {
                return View(t);
            }

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
