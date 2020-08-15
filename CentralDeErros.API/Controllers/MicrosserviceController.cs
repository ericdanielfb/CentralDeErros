using AutoMapper;
using CentralDeErros.Core.Extensions;
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
    [Authorize]
    [Route("api/v1/[controller]")]
    [ApiController]
    public class MicrosserviceController:ControllerBase
    {
        private MicrosserviceService _service;
        private IMapper _mapper;
        private readonly TokenGeneratorService _tokenGeneratorService;

        public MicrosserviceController(MicrosserviceService service, IMapper mapper, TokenGeneratorService tokenGeneratorService)
        {
            _service = service;
            _mapper = mapper;
            _tokenGeneratorService = tokenGeneratorService;
        }

        [ClaimsAuthotize("Admin", "Read")]
        [HttpGet]
        public ActionResult<IEnumerable<MicrosserviceDTO>> GetAllMicrosservices()
        {
            return Ok
                 (_mapper.Map<IEnumerable<MicrosserviceDTO>>
                 (_service.List()));
        }

        [HttpGet("{clientId}")]
        public ActionResult<MicrosserviceDTO> GetMicrosserviceById(Guid? clientId)
        {
            if (clientId == null)
            {
                return NoContent();
            }
            return Ok
                (
                    _mapper.Map<MicrosserviceDTO>
                    (
                        _service.Fetch((Guid)clientId)
                    )
                );
        }

        [ClaimsAuthotize("Admin", "Delete")]
        [HttpDelete("{clientId}")]
        public void DeleteMicrosserviceById(Guid? clientId)
        {
            _service.Delete((Guid)clientId);
        }

        [ClaimsAuthotize("Admin", "Create")]
        [HttpPost]
        public ActionResult<MicrosserviceRegisterDTO> SaveMicrosservice([FromBody] string microsserviceName)
        {
            if (microsserviceName is null)
            {
                return BadRequest();
            }

            return Created(
                nameof(SaveMicrosservice),
                _mapper.Map<MicrosserviceRegisterDTO>(_service.Register(microsserviceName)));
        }

        [ClaimsAuthotize("Admin", "Update")]
        [HttpPut("{id}")]
        public ActionResult<MicrosserviceDTO> UpdateMicrosserviceName(Guid? clientId, string microsserviceName)
        {
            Microsservice microsservice;
            if (clientId.HasValue && microsserviceName != null)
            {
                microsservice = _service.Fetch((Guid)clientId);
                if (microsservice is null)
                {
                    return NoContent();
                } else
                {
                    return Ok(_mapper.Map<MicrosserviceDTO>(_service.Update(microsservice, microsserviceName)));
                }
            }
            return BadRequest();
        }

        [ClaimsAuthotize("Admin", "Update")]
        [HttpPost("regenerateSecret")]
        public ActionResult<MicrosserviceRegisterDTO> RegenerateClientSecret([FromBody]Guid? clientId)
        {
            Microsservice microsservice;
            if (clientId.HasValue)
            {
                microsservice = _service.Fetch((Guid)clientId);
                if (microsservice is null)
                {
                    return NoContent();
                }
                else
                {
                    return Ok(_mapper.Map<MicrosserviceDTO>(_service.GenerateClientSecret(microsservice)));
                }
            }
            return BadRequest();
        }
    }
}