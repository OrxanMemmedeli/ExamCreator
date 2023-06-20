using AutoMapper;
using Business.Abstract;
using Business.Validations;
using DTOLayer.DTOs.Response;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ExamCreator.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ResponseController : Controller
    {
        private readonly IResponseService _responseService;
        private readonly IMapper _mapper;

        public ResponseController(IResponseService ResponseService, IMapper mapper)
        {
            _responseService = ResponseService;
            _mapper = mapper;
        }

        //[HttpGet]
        //public virtual async Task<IActionResult> Index(int page = 1)
        //{
        //    var Responses = await _responseService.GetAllAsnyc().ToListAsync();
        //    var datas = _mapper.Map<List<Response>, List<ResponseIndexDTO>>(Responses);
        //    return View(datas);
        //}

        //[HttpGet]
        //public virtual IActionResult Create()
        //{
        //    return View();
        //}

        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual async Task<IActionResult> Create(ResponseCreateDTO t)
        {
            var model = _mapper.Map<ResponseCreateDTO, Response>(t);
            if (!ModelState.IsValid)
            {
                return View(t);
            }

            await _responseService.Insert(model);
            return RedirectToAction(nameof(Index));
        }

        //[HttpGet]
        //public virtual async Task<IActionResult> Edit(Guid id)
        //{
        //    if (id == Guid.Empty)
        //    {
        //        return NotFound();
        //    }
        //    var data = await _responseService.GetByIdAsnyc(id);
        //    if (data == null)
        //    {
        //        return NotFound();
        //    }

        //    var model = _mapper.Map<Response, EditResponse>(data);

        //    return View(model);
        //}

        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual async Task<IActionResult> Edit(ResponseEditDTO t)
        {
            var model = _mapper.Map<ResponseEditDTO, Response>(t);
            if (!ModelState.IsValid)
            {
                return View(t);
            }

            await _responseService.Update(model, model.Id);
            return RedirectToAction(nameof(Index));
        }

        public virtual async Task<IActionResult> Delete(Guid id)
        {
            if (id == Guid.Empty)
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
            if (id == Guid.Empty)
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
