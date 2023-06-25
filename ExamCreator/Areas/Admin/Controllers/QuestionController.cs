using AutoMapper;
using Business.Abstract;
using Business.Validations;
using DataAccess.Concrete.Context;
using DTOLayer.DTOs.Grade;
using DTOLayer.DTOs.Question;
using EntityLayer.Concrete;
using ExamCreator.Attributes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace ExamCreator.Areas.Admin.Controllers
{
    [Area("Admin")]
    [RouteDataFilter]
    public class QuestionController : BaseController<IQuestionService, QuestionCreateDTO, QuestionEditDTO, Question>
    {
        private readonly IQuestionService _questionService;
        private readonly IMapper _mapper;

        private readonly IAcademicYearService _academicYearService;
        private readonly IGradeService _gradeService;
        private readonly IQuestionLevelService _questionLevelService;
        private readonly IQuestionTypeService _questionTypeService;
        private readonly ISectionService _sectionService;
        private readonly ISubjectService _subjectService;

        public QuestionController(IQuestionService QuestionService, IMapper mapper, IAcademicYearService academicYearService, IGradeService gradeService, IQuestionLevelService questionLevelService, IQuestionTypeService questionTypeService, ISectionService sectionService, ISubjectService subjectService) : base(QuestionService, mapper)
        {
            _questionService = QuestionService;
            _mapper = mapper;
            _academicYearService = academicYearService;
            _gradeService = gradeService;
            _questionLevelService = questionLevelService;
            _questionTypeService = questionTypeService;
            _sectionService = sectionService;
            _subjectService = subjectService;
        }

        protected override async Task GetFields()
        {
            ViewData["AcademicYearId"] = new SelectList(await _academicYearService.GetAllAsnyc().ToListAsync(), "Id", "Name");
            ViewData["GradeId"] = new SelectList(await _gradeService.GetAllAsnyc().ToListAsync(), "Id", "Name");
            ViewData["QuestionLevelId"] = new SelectList(await _questionLevelService.GetAllAsnyc().ToListAsync(), "Id", "Name");
            ViewData["QuestionTypeId"] = new SelectList(await _questionTypeService.GetAllAsnyc().ToListAsync(), "Id", "Description");
            ViewData["SectionId"] = new SelectList(await _sectionService.GetAllAsnyc().ToListAsync(), "Id", "Name");
            ViewData["SubjectId"] = new SelectList(await _subjectService.GetAllAsnyc().ToListAsync(), "Id", "Name");
        }


        [HttpGet]
        public virtual async Task<IActionResult> Index(int page = 1)
        {
            var Questions = await _questionService.GetAllAsnyc().ToListAsync();
            var datas = _mapper.Map<List<Question>, List<QuestionIndexDTO>>(Questions);
            return View(datas);
        }

    }
}
