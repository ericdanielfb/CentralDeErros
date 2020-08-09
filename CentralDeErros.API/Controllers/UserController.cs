﻿using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using CentralDeErros.Model.Models;
using CentralDeErros.Services;
using CentralDeErros.Transport;
using Microsoft.AspNetCore.Mvc;

namespace CentralDeErros.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly UserService service;
        private readonly IMapper mapper;

        public UserController(UserService service, IMapper mapper)
        {
            this.service = service;
            this.mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<UserDTO>> GetAll() => Ok(mapper.Map<IEnumerable<UserDTO>>(service.List()));
        
        
        [HttpGet("{id}")]
        public ActionResult<UserDTO> Get(int id) => Ok(mapper.Map<UserDTO>(service.Fetch(id)));
         

        [HttpDelete("{id}")]
        public ActionResult<UserDTO> Delete(UserDTO entry)
        {
            service.Delete(mapper.Map<User>(entry));

            return Ok(); 
        }  

        
        [HttpPut("{id}")]
        public ActionResult<UserDTO> Put(int id) => Ok(mapper.Map<UserDTO>(service.Fetch(id)));
        
        [HttpPost]
        public ActionResult<UserDTO> Post([FromBody]User value)
        {
            var userModel = mapper.Map<User>(value);

            service.Register(userModel);

            return Ok(mapper.Map<UserDTO>(mapper.Map<UserDTO>(userModel)));

        }

    }
}