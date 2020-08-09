using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CentralDeErros.Model.Models;
using CentralDeErros.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CentralDeErros.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ErrorController : ControllerBase
    {
        private readonly ErrorService _service;
        public ErrorController(ErrorService service)
        {
            _service = service;
        }


        [HttpGet]
        public IActionResult List(int? start, int? end)
        {
            return Ok(_service.List(start, end));
        }
        
    }
}
