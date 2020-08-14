using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using CentralDeErros.Model.Models;
using CentralDeErros.Services;
using CentralDeErros.Transport;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using CentralDeErros.Core;

namespace CentralDeErros.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly UserService _service;

        public UserController(UserManager<IdentityUser> userManager, IMapper mapper, UserService service)
        {
            _mapper = mapper;
            _userManager = userManager;
            _service = service;
        }

        [HttpGet]
        public ActionResult<IEnumerable<UserGetDTO>> GetAll()
        {

            return Ok(_mapper.Map<IEnumerable<UserGetDTO>>(_userManager.Users.ToList()));

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserGetDTO>> GetAsync(string id)
        {
            if (ModelState.IsValid)
            {
                return Ok(_mapper.Map<UserGetDTO>(await _userManager.FindByIdAsync(id)));
            }

            return NoContent();

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(string entry)
        {

            if (ModelState.IsValid)
            {
                var findById = await _userManager.FindByIdAsync(entry);

                var result = await _userManager.DeleteAsync(findById);

                if (!result.Succeeded)
                {
                    return BadRequest(result.Errors);
                }
                return Ok(result);
            }
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateAsync(string id, IdentityUser identityUser)
        {
            if (ModelState.IsValid)
            {
                var findBy = await _userManager.FindByIdAsync(id);

                findBy.UserName = identityUser.UserName;     

                var result = await _userManager.UpdateAsync(findBy);

                if (!result.Succeeded)
                {
                    return BadRequest(result.Errors);
                }

                return Ok();
            }
            return BadRequest();
        }



    }
}