using AutoMapper;
using Business.Abstract;
using Business.Validations;
using EntityLayer.Concrete;
using ExamCreator.Areas.Admin.Models.ViewModels.UserType;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ExamCreator.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserTypeController : Controller
    {
        private readonly IUserTypeService _userTypeService;
        private readonly IMapper _mapper;
        private readonly UserTypeValidator _userTypeValidator;

        public UserTypeController(IUserTypeService UserTypeService, IMapper mapper, UserTypeValidator userTypeValidator)
        {
            _userTypeService = UserTypeService;
            _mapper = mapper;
            _userTypeValidator = userTypeValidator;
        }

        [HttpGet]
        public virtual async Task<IActionResult> Index(int page = 1)
        {
            var UserTypes = await _userTypeService.GetAllAsnyc().ToListAsync();
            var datas = _mapper.Map<List<UserType>, List<ListUserType>>(UserTypes);
            return View(datas);
        }

        [HttpGet]
        public virtual IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual async Task<IActionResult> Create(CreateUserType t)
        {
            var model = _mapper.Map<CreateUserType, UserType>(t);
            var modelState = _userTypeValidator.Validate(model);
            if (!modelState.IsValid)
            {
                if (modelState.Errors != null)
                    modelState.Errors.ForEach(item => ModelState.AddModelError(item.PropertyName, item.ErrorMessage));
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

            var model = _mapper.Map<UserType, EditUserType>(data);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual async Task<IActionResult> Edit(EditUserType t)
        {
            var model = _mapper.Map<EditUserType, UserType>(t);
            var modelState = _userTypeValidator.Validate(model);
            if (!modelState.IsValid)
            {
                if (modelState.Errors != null)
                    modelState.Errors.ForEach(item => ModelState.AddModelError(item.PropertyName, item.ErrorMessage));
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
