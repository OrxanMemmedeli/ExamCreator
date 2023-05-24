using AutoMapper;
using Business.Abstract;
using Business.Validations;
using DTOLayer.DTOs.UserType;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ExamCreator.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserTypeController : Controller
    {
        private readonly IUserTypeService _userTypeService;
        private readonly IMapper _mapper;

        public UserTypeController(IUserTypeService UserTypeService, IMapper mapper, UserTypeValidator userTypeValidator)
        {
            _userTypeService = UserTypeService;
            _mapper = mapper;
        }

        [HttpGet]
        public virtual async Task<IActionResult> Index(int page = 1)
        {
            var UserTypes = await _userTypeService.GetAllAsnyc().ToListAsync();
            var datas = _mapper.Map<List<UserType>, List<UserTypeIndexDTO>>(UserTypes);
            return View(datas);
        }

        [HttpGet]
        public virtual IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual async Task<IActionResult> Create(UserTypeCreateDTO t)
        {
            var model = _mapper.Map<UserTypeCreateDTO, UserType>(t);
            if (!ModelState.IsValid)
            {
                return View(t);
            }

            await _userTypeService.Insert(model);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public virtual async Task<IActionResult> Edit(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var data = await _userTypeService.GetByIdAsnyc(id);
            if (data == null)
            {
                return NotFound();
            }

            var model = _mapper.Map<UserType, UserTypeEditDTO>(data);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual async Task<IActionResult> Edit(UserTypeEditDTO t)
        {
            var model = _mapper.Map<UserTypeEditDTO, UserType>(t);
            if (!ModelState.IsValid)
            {
                return View(t);
            }

            await _userTypeService.Update(model, model.Id);
            return RedirectToAction(nameof(Index));
        }

        public virtual async Task<IActionResult> Delete(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var data = await _userTypeService.GetByIdAsnyc(id);
            if (data == null)
            {
                return NotFound();
            }
            await _userTypeService.Delete(data);
            return RedirectToAction(nameof(Index));
        }

        public virtual async Task<IActionResult> Remove(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var data = await _userTypeService.GetByIdAsnyc(id);
            if (data == null)
            {
                return NotFound();
            }
            await _userTypeService.Remove(data);
            return RedirectToAction(nameof(Index));
        }
    }
}
