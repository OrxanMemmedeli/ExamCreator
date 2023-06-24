using AutoMapper;
using Business.Abstract;
using DTOLayer.DTOs.AcademicYear;
using EntityLayer.Concrete;
using EntityLayer.Concrete.Base;
using Microsoft.AspNetCore.Mvc;

namespace ExamCreator.Areas.Admin.Controllers
{
    [Area("Admin")]
    //[CompanyAccess(typeof(IHttpContextAccessor))]
    public class BaseController<TService, TCreateDTO, TEditDto, TEntity> : Controller
    where TService : IGenericService<TEntity>
    where TEntity : BaseEntity
    {
        protected readonly TService _service;
        private readonly IMapper _mapper;

        public BaseController(TService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }


        public virtual void GetFields() { }


        [HttpGet]
        public virtual IActionResult Create()
        {
            GetFields();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual async Task<IActionResult> Create(TCreateDTO t)
        {
            var model = _mapper.Map<TCreateDTO, TEntity>(t);
            if (!ModelState.IsValid)
            {
                GetFields();
                return View(t);
            }

            await _service.Insert(model);
            return RedirectToAction(nameof(Index));
        }




        [HttpGet]
        public virtual async Task<IActionResult> Edit(Guid id)
        {
            if (id == Guid.Empty)
            {
                return NotFound();
            }
            var data = await _service.GetByIdAsnyc(id);
            if (data == null)
            {
                return NotFound();
            }

            var model = _mapper.Map<TEntity, TEditDto>(data);

            GetFields();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual async Task<IActionResult> Edit(TEditDto t)
        {
            var model = _mapper.Map<TEditDto, TEntity>(t);

            if (!ModelState.IsValid)
            {
                GetFields();
                return View(t);
            }

            await _service.Update(model, model.Id);
            return RedirectToAction(nameof(Index));
        }





        public virtual async Task<IActionResult> Delete(Guid id)
        {
            if (id == Guid.Empty)
            {
                return NotFound();
            }

            var data = await _service.GetByIdAsnyc(id);
            if (data == null)
            {
                return NotFound();
            }

            await _service.Delete(data);
            return RedirectToAction(nameof(Index));
        }

        public virtual async Task<IActionResult> Remove(Guid id)
        {
            if (id == Guid.Empty)
            {
                return NotFound();
            }

            var data = await _service.GetByIdAsnyc(id);
            if (data == null)
            {
                return NotFound();
            }

            await _service.Remove(data);
            return RedirectToAction(nameof(Index));
        }
    }



}
