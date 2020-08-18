using AutoMapper;
using CentralDeErros.Core.Extensions;
using CentralDeErros.Services;
using CentralDeErros.Services.Interfaces;
using CentralDeErros.Transport;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;


namespace CentralDeErros.API.Controllers
{
    [Authorize]
    [Route("api/v1/[controller]")]
    [ApiController]
    public class EnvironmentController : ControllerBase
    {
        private readonly IEnvironmentService _service;
        private readonly IMapper _mapper;

        public EnvironmentController(IEnvironmentService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<EnvironmentDTO>> GetAllEnvironments()
        {
            return Ok
                (_mapper.Map<IEnumerable<EnvironmentDTO>>
                (_service.List()));  
        }

        [HttpGet("{id}")]
        public ActionResult<EnvironmentDTO> GetEnviromentId(int? id)
        {
            if (id == null)
            {
                return NoContent();
            }
            else
            {
                return Ok
                    (_mapper.Map<EnvironmentDTO>
                    (_service.Fetch
                    ((int)id)));
            }
        }

        [ClaimsAuthorize("Admin","Delete")]
        [HttpDelete("{id}")]
        public ActionResult DeleteEnvironmentId(int? id)
        {
            if(id == null)
            {
                return NoContent();
            }

            _service.Delete((int)id);

            return Ok();
        }

        [ClaimsAuthorize("Admin","Update")]
        [HttpPut("{id}")]
        public ActionResult<EnvironmentDTO> UpdateEnvironment(int? id, Model.Models.Environment environment)
        {
            if (id == null)
            {
                return NoContent();
            }
            else
            {
                return Ok
                    (_mapper.Map<EnvironmentDTO>
                    (_service.RegisterOrUpdate
                    ((environment))));
            }

        }

        [ClaimsAuthorize("Admin","Create")]
        [HttpPost]
        public ActionResult<EnvironmentDTO> SaveEnvironment([FromBody] EnvironmentDTO value)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                return Ok
                (_mapper.Map<EnvironmentDTO>
                (_service.RegisterOrUpdate
                (_mapper.Map<Model.Models.Environment>
                ((value)))));
            }
        }



    }

}

