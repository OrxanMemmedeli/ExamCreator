using AutoMapper;
using Business.Abstract;
using Business.Validations;
using EntityLayer.Concrete;
using ExamCreator.Areas.Admin.Models.ViewModels.Response;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ExamCreator.Areas.Admin.Controllers
{
    public class ResponseController : Controller
    {
        private readonly IResponseService _responseService;
        private readonly IMapper _mapper;
        private readonly ResponseValidator _responseValidator;

        public ResponseController(IResponseService ResponseService, IMapper mapper, ResponseValidator responseValidator)
        {
            _responseService = ResponseService;
            _mapper = mapper;
            _responseValidator = responseValidator;
        }

        [HttpGet]
        public virtual async Task<IActionResult> Index(int page = 1)
        {
            var Responses = await _responseService.GetAllAsnyc().ToListAsync();
            var datas = _mapper.Map<List<Response>, List<ListResponse>>(Responses);
            return View(datas);
        }

        [HttpGet]
        public virtual IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual async Task<IActionResult> Create(CreateResponse t)
        {
            var model = _mapper.Map<CreateResponse, Response>(t);
            var modelState = _responseValidator.Validate(model);
            if (!modelState.IsValid)
            {
                if (modelState.Errors != null)
                    modelState.Errors.ForEach(item => ModelState.AddModelError(item.PropertyName, item.ErrorMessage));
                return View(t);
            }

            await _responseService.Insert(model);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public virtual async Task<IActionResult> Edit(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var data = await _responseService.GetByIdAsnyc(id);
            if (data == null)
            {
                return NotFound();
            }

            var model = _mapper.Map<Response, EditResponse>(data);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual async Task<IActionResult> Edit(EditResponse t)
        {
            var model = _mapper.Map<EditResponse, Response>(t);
            var modelState = _responseValidator.Validate(model);
            if (!modelState.IsValid)
            {
                if (modelState.Errors != null)
                    modelState.Errors.ForEach(item => ModelState.AddModelError(item.PropertyName, item.ErrorMessage));
                return View(t);
            }

            await _responseService.Update(model, model.Id);
            return RedirectToAction(nameof(Index));
        }

        public virtual async Task<IActionResult> Delete(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var data = await _responseService.GetByIdAsnyc(id);
            if (data == null)
            {
                return NotFound();
            }
            await _responseService.Delete(data);
            return RedirectToAction(nameof(Index));
        }

        public virtual async Task<IActionResult> Remove(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var data = await _responseService.GetByIdAsnyc(id);
            if (data == null)
            {
                return NotFound();
            }
            await _responseService.Remove(data);
            return RedirectToAction(nameof(Index));
        }
    }
}
