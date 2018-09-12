﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PageCheckerAPI.DTOs.User;
using PageCheckerAPI.Models;
using PageCheckerAPI.Services.Interfaces;

namespace PageCheckerAPI.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly IUserService _service;
        private readonly IMapper _mapper;

        public UserController(IUserService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody] UserDto userDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            User user = _service.Register(userDto);

            if (user == null)
                return BadRequest(ModelState);

            return Ok();
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] UserDto userDto)
        {
            User user = _service.Login(userDto);
            if (user == null)
                return Unauthorized();

            return Ok();
        }

    }
}