using AutoMapper;
using CentralDeErros.Core.Extensions;
using CentralDeErros.Model.Models;
using CentralDeErros.Services;
using CentralDeErros.Services.Interfaces;
using CentralDeErros.Transport.MicrosserviceDTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace CentralDeErros.API.Controllers
{
    [Authorize]
    [Route("api/v1/[controller]")]
    [ApiController]
    public class MicrosserviceController : ControllerBase
    {
        private readonly IMicrosserviceService _service;
        private readonly IMapper _mapper;
        private readonly ITokenGeneratorService _tokenGeneratorService;

        public MicrosserviceController(IMicrosserviceService service, IMapper mapper, ITokenGeneratorService tokenGeneratorService)
        {
            _service = service;
            _mapper = mapper;
            _tokenGeneratorService = tokenGeneratorService;
        }

        [ClaimsAuthorize("Admin", "Read")]
        [HttpGet]
        public ActionResult<IEnumerable<MicrosserviceDTO>> GetAllMicrosservices()
        {
            return Ok
                 (_mapper.Map<IEnumerable<MicrosserviceDTO>>
                 (_service.List()));
        }

        [HttpGet("GetByClientId")]
        public ActionResult<MicrosserviceDTO> GetMicrosserviceById([FromBody] MicrosserviceClientIdOnlyDTO microsserviceClientId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                Microsservice microsservice = _service.Fetch(_mapper.Map<Microsservice>(microsserviceClientId).ClientId);
                if (microsservice is null)
                {
                    return NoContent();
                }
                else
                {
                    return Ok(_mapper.Map<MicrosserviceDTO>(microsservice));
                }
            }
        }

        [ClaimsAuthorize("Admin", "Delete")]
        [HttpDelete("DeleteByClientId")]
        public ActionResult DeleteMicrosserviceById([FromBody] MicrosserviceClientIdOnlyDTO microsserviceClientId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                Microsservice microsservice = _service.Fetch(_mapper.Map<Microsservice>(microsserviceClientId).ClientId);
                if (microsservice is null)
                {
                    return NoContent();
                }
                else
                {
                    _service.Delete(microsservice.ClientId);
                    return Ok();
                }
            }
        }


        [ClaimsAuthorize("Admin", "Create")]
        [HttpPost]
        public ActionResult<MicrosserviceRegisterDTO> SaveMicrosservice([FromBody] MicrosserviceNameOnlyDTO microsserviceName)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                return Created(
                    nameof(SaveMicrosservice),
                    _mapper.Map<MicrosserviceRegisterDTO>(
                        _service.Register(microsserviceName.Name))
                    );
            }
        }
        [ClaimsAuthorize("Admin", "Update")]
        [HttpPut("UpdateName")]
        public ActionResult<MicrosserviceDTO> UpdateMicrosserviceName([FromBody] MicrosserviceDTO microsservice)

        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                Microsservice response = _service.Fetch(microsservice.ClientId);
                if (response is null)
                {
                    return NoContent();
                }
                else
                {
                    return Ok(
                        _mapper.Map<MicrosserviceDTO>(
                            _service.Update(_mapper.Map<Microsservice>(microsservice))
                        )
                    );
                }
            }
        }

        [ClaimsAuthorize("Admin", "Update")]
        [HttpPost("RegenerateSecret")]
        public ActionResult<MicrosserviceRegisterDTO> RegenerateClientSecret([FromBody] MicrosserviceClientIdOnlyDTO microsserviceClientId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            { 
                Microsservice response = _service.Fetch(microsserviceClientId.ClientId);
                if (response is null)
                {
                    return NoContent();
                }
                else
                {
                    return Ok(_mapper.Map<MicrosserviceRegisterDTO>(_service.GenerateClientSecret(response)));
                }
            }
        }
    }
}