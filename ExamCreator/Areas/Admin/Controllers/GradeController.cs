using AutoMapper;
using Business.Abstract;
using Business.Validations;
using CoreLayer.Helpers.E_mail.Mailkit;
using CoreLayer.Helpers.Tools;
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
    //[CompanyAccess(typeof(IHttpContextAccessor))]
    public class GradeController : Controller
    {
        private readonly IGradeService _gradeService;
        private readonly IMapper _mapper;
        private readonly SendEMail _sendEmail;

        public GradeController(IGradeService gradeService, IMapper mapper, GradeValidator gradeValidator, IConfiguration configuration)
        {
            _gradeService = gradeService;
            _mapper = mapper;
            _sendEmail = new SendEMail(configuration);
        }

        [HttpGet]
        public virtual async Task<IActionResult> Index(int page = 1)
        {
            _sendEmail.Send("mahmut","xalid");
            var grades = await _gradeService.GetAllAsnyc().OrderBy(x => x.Name).ToListAsync();
            var datas = _mapper.Map<List<Grade>, List<GradeIndexDTO>>(grades);
            return View(datas);
        }

        [HttpGet]
        public virtual IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual async Task<IActionResult> Create(GradeCreateDTO t)
        {
            var model = _mapper.Map<GradeCreateDTO, Grade>(t);

            if (!ModelState.IsValid)
            {
                var text = ModelState;
                return View(t);
            }

            await _gradeService.Insert(model);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public virtual async Task<IActionResult> Edit(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var data = await _gradeService.GetByIdAsnyc(id);
            if (data == null)
            {
                return NotFound();
            }

            var model = _mapper.Map<Grade, GradeEditDTO>(data);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual async Task<IActionResult> Edit(GradeEditDTO t)
        {
            var model = _mapper.Map<GradeEditDTO, Grade>(t);
            if (!ModelState.IsValid)
            {
                return View(t);
            }

            await _gradeService.Update(model, model.Id);
            return RedirectToAction(nameof(Index));
        }

        public virtual async Task<IActionResult> Delete(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var data = await _gradeService.GetByIdAsnyc(id);
            if (data == null)
            {
                return NotFound();
            }
            await _gradeService.Delete(data);
            return RedirectToAction(nameof(Index));
        }

        public virtual async Task<IActionResult> Remove(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var data = await _gradeService.GetByIdAsnyc(id);
            if (data == null)
            {
                return NotFound();
            }
            await _gradeService.Remove(data);
            return RedirectToAction(nameof(Index));
        }
    }
}
