using AutoMapper;
using Business.Abstract;
using Business.Validations;
using DTOLayer.DTOs.Grade;
using DTOLayer.DTOs.Response;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ExamCreator.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ResponseController : BaseController<IResponseService, ResponseCreateDTO, ResponseEditDTO, Response>
    {
        public ResponseController(IResponseService ResponseService, IMapper mapper) : base(ResponseService, mapper) 
        {
        }

    }
}
