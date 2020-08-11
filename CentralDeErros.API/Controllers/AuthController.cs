using AutoMapper;
using CentralDeErros.Services;
using CentralDeErros.Transport;
using Microsoft.AspNetCore.Mvc;
using CentralDeErros.Model.Models;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace CentralDeErros.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly UserService _service;
        private readonly IMapper _mapper;

        public AuthController(UserService service, IMapper mapper, SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager)
        {
            _service = service;
            _mapper = mapper;
            _signInManager = signInManager;
            _userManager = userManager;
        }

        // POST api/v1/signin
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] RegisterUserDTO value)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var user = _mapper.Map<IdentityUser>((value));

            var result = await _userManager.CreateAsync(user, value.Password);

            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user, false);
                return Created(nameof(Post), value);
            }

            return Ok(value);

            

        }


    }
}
