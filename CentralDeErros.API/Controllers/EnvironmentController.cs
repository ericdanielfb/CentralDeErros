using AutoMapper;
using CentralDeErros.Core;
using CentralDeErros.Services;
using CentralDeErros.Transport;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace CentralDeErros.API.Controllers
{

    [Route("api/v1/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class EnvironmentController : ControllerBase
    {
        private EnvironmentService _service;
        private IMapper _mapper;

        public EnvironmentController(EnvironmentService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        // GET api/v1/environment
        [HttpGet]
        public ActionResult<IEnumerable<EnvironmentDTO>> GetAllEnvironments()
        {
            var environments = _service.List();

            if (environments == null)
            {
                return NoContent();
            }
            else
            {
                return Ok
                    (environments.Select
                    (x => _mapper.Map<IEnumerable<EnvironmentDTO>>(x)
                    .ToList()));
            }
        }

        // GET api/v1/environment/{id}
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
        
        // DELETE api/v1/environment/{id}
        [HttpDelete("{id}")]
        public void DeleteEnvironmentId(int? id)
        { 
            _service.Delete((int)id);
        }

        // PUT api/v1/environment/{id}
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

        // POST api/v1/environment
        [HttpPost]
        public ActionResult<EnvironmentDTO> SaveEnvironment([FromBody] EnvironmentDTO value)
        {
      
                return Ok
                    (_mapper.Map<EnvironmentDTO>
                    (_service.RegisterOrUpdate
                    (_mapper.Map<Model.Models.Environment>
                    ((value)))));

        }



    }

}

