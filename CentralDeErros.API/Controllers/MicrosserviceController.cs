using AutoMapper;
using CentralDeErros.Model.Models;
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
    public class MicrosserviceController:ControllerBase
    {
        private MicrosserviceService _service;
        private IMapper _mapper;

        public MicrosserviceController(MicrosserviceService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        // GET api/v1/microsservice
        [HttpGet]
        public ActionResult<IEnumerable<MicrosserviceDTO>> GetAllMicrosservices()
        {
            var microsservices = _service.List();

            if (microsservices == null)
            {
                return NoContent();
            }
            else
            {
                return Ok
                    (microsservices.Select
                    (x => _mapper.Map<IEnumerable<MicrosserviceDTO>>(x)
                    .ToList()));
            }
        }

        // GET api/v1/microsservice/{id}
        [HttpGet("{id}")]
        public ActionResult<MicrosserviceDTO> GetEnviromentId(int? id)
        {
            if (id == null)
            {
                return NoContent();
            }
            else
            {
                return Ok
                    (_mapper.Map<MicrosserviceDTO>
                    (_service.Fetch
                    ((int)id)));
            }
        }

        // DELETE api/v1/microsservice/{id}
        [HttpDelete("{id}")]
        public void DeleteEnvironmentId(int? id)
        {
            _service.Delete((int)id);
        }

        // PUT api/v1/microsservice/{id}
        [HttpPut("{id}")]
        public ActionResult<MicrosserviceDTO> UpdateEnvironment(int? id, Microsservice microsservice)
        {
            if (id == null)
            {
                return NoContent();
            }
            else
            {
                return Ok
                    (_mapper.Map<MicrosserviceDTO>
                    (_service.RegisterOrUpdate
                    ((microsservice))));
            }

        }

        // POST api/v1/microsservice
        [HttpPost]
        public ActionResult<MicrosserviceDTO> SaveEnvironment([FromBody] MicrosserviceDTO value)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                return Ok
                (_mapper.Map<MicrosserviceDTO>
                (_service.RegisterOrUpdate
                (_mapper.Map<Microsservice>
                ((value)))));
            }
        }

    }
}
