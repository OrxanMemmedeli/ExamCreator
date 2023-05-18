using AutoMapper;
using Business.Abstract;
using Business.Validations;
using DataAccess.Concrete.Context;
using DTOLayer.DTOs.Question;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace ExamCreator.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class QuestionController : Controller
    {
        private readonly IQuestionService _questionService;
        private readonly IMapper _mapper;
        private readonly QuestionValidator _questionValidator;

        private readonly IAcademicYearService _academicYearService;
        private readonly IGradeService _gradeService;
        private readonly IQuestionLevelService _questionLevelService;
        private readonly IQuestionTypeService _questionTypeService;
        private readonly ISectionService _sectionService;
        private readonly ISubjectService _subjectService;


        public QuestionController(IQuestionService QuestionService, IMapper mapper, QuestionValidator questionValidator, IAcademicYearService academicYearService, IGradeService gradeService, IQuestionLevelService questionLevelService, IQuestionTypeService questionTypeService, ISectionService sectionService, ISubjectService subjectService)
        {
            _questionService = QuestionService;
            _mapper = mapper;
            _questionValidator = questionValidator;
            _academicYearService = academicYearService;
            _gradeService = gradeService;
            _questionLevelService = questionLevelService;
            _questionTypeService = questionTypeService;
            _sectionService = sectionService;
            _subjectService = subjectService;
        }
       private void GetFields()
        {
            ViewData["AcademicYearId"] = new SelectList(_academicYearService.GetAllAsnyc(), "Id", "Name");
            ViewData["GradeId"] = new SelectList(_gradeService.GetAllAsnyc(), "Id", "Name");
            ViewData["QuestionLevelId"] = new SelectList(_questionLevelService.GetAllAsnyc(), "Id", "Name");
            ViewData["QuestionTypeId"] = new SelectList(_questionTypeService.GetAllAsnyc(), "Id", "Description");
            ViewData["SectionId"] = new SelectList(_sectionService.GetAllAsnyc(), "Id", "Name");
            ViewData["SubjectId"] = new SelectList(_subjectService.GetAllAsnyc(), "Id", "Name");
        }


        [HttpGet]
        public virtual async Task<IActionResult> Index(int page = 1)
        {
            var Questions = await _questionService.GetAllAsnyc().ToListAsync();
            var datas = _mapper.Map<List<Question>, List<QuestionIndexDTO>>(Questions);
            return View(datas);
        }

        [HttpGet]
        public virtual IActionResult Create()
        {
            GetFields();
            return View();
        }

 

        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual async Task<IActionResult> Create(QuestionCreateDTO t)
        {
            var model = _mapper.Map<QuestionCreateDTO, Question>(t);
            var modelState = _questionValidator.Validate(model);
            if (!modelState.IsValid)
            {
                if (modelState.Errors != null)
                    modelState.Errors.ForEach(item => ModelState.AddModelError(item.PropertyName, item.ErrorMessage));
              
                GetFields();
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

            var model = _mapper.Map<Question, QuestionEditDTO>(data);

            GetFields();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual async Task<IActionResult> Edit(QuestionEditDTO t)
        {           
            var model = _mapper.Map<QuestionEditDTO, Question>(t);
            var modelState = _questionValidator.Validate(model);

            if (!modelState.IsValid)
            {
                if (modelState.Errors != null)
                    modelState.Errors.ForEach(item => ModelState.AddModelError(item.PropertyName, item.ErrorMessage));

                GetFields();
                return View(t);
            }

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
