using AutoMapper;
using CentralDeErros.Core.Extensions;
using CentralDeErros.Model.Models;
using CentralDeErros.Services;
using CentralDeErros.Transport;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CentralDeErros.API.Controllers
{
    [Authorize]
    [Route("api/v1/[controller]")]
    [ApiController]
    public class LevelController : ControllerBase
    {
        private LevelService _service;
        private IMapper _mapper;

        public LevelController(LevelService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }
        
        [HttpGet]
        public ActionResult<IEnumerable<LevelDTO>> GetAllLevel()
        {
            return Ok
                 (_mapper.Map<IEnumerable<LevelDTO>>
                 (_service.List()));
        }

        [HttpGet("{id}")]
        public ActionResult<LevelDTO> GetLevelById(int? id)
        {
            if (id == null)
            {
                return NoContent();
            }
            else
            {
                return Ok
                    (_mapper.Map<LevelDTO>
                    (_service.Fetch
                    ((int)id)));
            }
        }

        [ClaimsAuthorize("Admin", "Delete")]
        [HttpDelete("{id}")]
        public void DeleteLevelById(int? id)
        {
            _service.Delete((int)id);
        }

        [ClaimsAuthorize("Admin", "Update")]
        [HttpPut("{id}")]
        public ActionResult<LevelDTO> UpdateLevel(int? id, [FromBody] LevelDTO level)
        {
            if (id == null)
            {
                return NoContent();
            }
            else
            {
                return Ok
                    (_mapper.Map<LevelDTO>
                    (_service.RegisterOrUpdate
                    (_mapper.Map<Level>(level))));
            }
        }

        [ClaimsAuthorize("Admin", "Create")]
        [HttpPost]
        public ActionResult<LevelDTO> SaveEnvironment([FromBody] LevelDTO value)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                return Ok
                    (_mapper.Map<LevelDTO>
                    (_service.RegisterOrUpdate
                    (_mapper.Map<Level>
                    ((value)))));
            }
        }
    }
}