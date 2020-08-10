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
        public ActionResult<IEnumerable<UserDTO>> GetAll()
        {
            try
            {
                return Ok(mapper.Map<IEnumerable<UserDTO>>(service.List()));

            }catch(NullReferenceException e)
            {
                throw new NullReferenceException(nameof(e));
            }
            
        } 

        [HttpGet("{id}")]
        public ActionResult<UserDTO> Get(int? id) 
        {
            try 
            {      
                if(ModelState.IsValid)
                {
                    User userFoundById = service.Fetch((int)id);        
                    return Ok(mapper.Map<UserDTO>(userFoundById));
                }

                return NotFound();    
                     
            }catch(NullReferenceException e) when(id == null)
            {
                throw new NullReferenceException(nameof(e));
            }
                  
        } 


        [HttpDelete("{id}")]
        public ActionResult<UserDTO> Delete(UserDTO entry) 
        {

          try
          {
              if(ModelState.IsValid)
            {
                service.Delete(mapper.Map<User>(entry)); 
                return Ok();   
            }

            return NotFound();

          }catch(NullReferenceException e){

              throw new NullReferenceException(nameof(e));

          }
            
        }   

        [HttpPut("{id}")]
        public ActionResult<UserDTO> Update(User user) 
        {
            try
            {
                if(ModelState.IsValid)
                {
                    mapper.Map<UserDTO>(service.Update(user));
                    return Ok();
                }

                return NotFound();  

            }catch(NullReferenceException e)
            {
                throw new NullReferenceException(nameof(e));
            }
                                                
        } 

        [HttpPost]
        public ActionResult<UserDTO> Create([FromBody]User value)
        {

            try
            {
                if(ModelState.IsValid) 
                {
                    var userModel = mapper.Map<User>(value);

                    service.Register(userModel);

                    return Ok(mapper.Map<UserDTO>(mapper.Map<UserDTO>(userModel)));
                }

                return NotFound();

            }catch(NullReferenceException e)
            {
                throw new NullReferenceException(nameof(e));
            }
           
        }

    }
} 