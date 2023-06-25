using AutoMapper;
using Business.Abstract;
using Business.Validations;
using DTOLayer.DTOs.Grade;
using DTOLayer.DTOs.UserType;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ExamCreator.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserTypeController : BaseController<IUserTypeService, UserTypeCreateDTO, UserTypeEditDTO, UserType>
    {
        private readonly IUserTypeService _userTypeService;
        private readonly IMapper _mapper;

        public UserTypeController(IUserTypeService UserTypeService, IMapper mapper) : base(UserTypeService, mapper)
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

     
    }
}
