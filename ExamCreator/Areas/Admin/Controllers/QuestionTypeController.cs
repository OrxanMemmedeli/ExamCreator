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
    public class QuestionTypeController : BaseController<IQuestionTypeService, QuestionTypeCreateDTO, QuestionTypeEditDTO, QuestionType>
    {
        private readonly IQuestionTypeService _questionTypeService;
        private readonly IMapper _mapper;

        public QuestionTypeController(IQuestionTypeService QuestionTypeService, IMapper mapper) : base(QuestionTypeService, mapper)
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

    }
}
