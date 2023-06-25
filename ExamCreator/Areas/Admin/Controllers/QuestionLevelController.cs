using AutoMapper;
using Business.Abstract;
using Business.Validations;
using DTOLayer.DTOs.Grade;
using DTOLayer.DTOs.QuestionLevel;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ExamCreator.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class QuestionLevelController : BaseController<IQuestionLevelService, QuestionLevelCreateDTO, QuestionLevelEditDTO, QuestionLevel>
    {
        private readonly IQuestionLevelService _questionLevelService;
        private readonly IMapper _mapper;

        public QuestionLevelController(IQuestionLevelService QuestionLevelService, IMapper mapper) : base(QuestionLevelService, mapper)
        {
            _questionLevelService = QuestionLevelService;
            _mapper = mapper;
        }

        [HttpGet]
        public virtual async Task<IActionResult> Index(int page = 1)
        {
            var QuestionLevels = await _questionLevelService.GetAllAsnyc().OrderBy(x => x.Level).ToListAsync();
            var datas = _mapper.Map<List<QuestionLevel>, List<QuestionLevelIndexDTO>>(QuestionLevels);
            return View(datas);
        }

    }
}
