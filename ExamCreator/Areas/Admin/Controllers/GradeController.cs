using AutoMapper;
using Business.Abstract;
using Business.Validations;
using CoreLayer.Helpers.E_mail.Mailkit;
using CoreLayer.Helpers.Tools;
using CoreLayer.Utilities.GuidFormatControl;
using DTOLayer.DTOs.Grade;
using EntityLayer.Concrete;
using ExamCreator.Attributes;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using System.Configuration;
using System.Security.Claims;

namespace ExamCreator.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class GradeController : BaseController<IGradeService, GradeCreateDTO, GradeEditDTO, Grade>
    {
        private readonly IGradeService _gradeService;
        private readonly IMapper _mapper;

        public GradeController(IGradeService gradeService, IMapper mapper)
            : base(gradeService, mapper)
        {
            _gradeService = gradeService;
            _mapper = mapper;
        }

        [HttpGet]
        public virtual async Task<IActionResult> Index(int page = 1)
        {
            var grades = await _gradeService.GetAllAsnyc().OrderBy(x => x.Name).ToListAsync();
            var datas = _mapper.Map<List<Grade>, List<GradeIndexDTO>>(grades);
            return View(datas);
        }
   
    }
}
