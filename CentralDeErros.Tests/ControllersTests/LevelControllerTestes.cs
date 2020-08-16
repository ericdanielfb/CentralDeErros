using AutoMapper;
using CentralDeErros.API;
using CentralDeErros.API.Controllers;
using CentralDeErros.ControllerTest;
using CentralDeErros.Model.Models;
using CentralDeErros.Services;
using CentralDeErros.Services.Interfaces;
using CentralDeErros.Transport;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace CentralDeErros.ControllersTests
{
    public class LevelControllerTestes : BaseControllerTest
    {
        Mock<ILevelService> _serviceMock;
        LevelController _controller;
        private readonly IMapper _mapper;

        public LevelControllerTestes()
        {
            var configuration = new MapperConfiguration(x => x.AddProfile(new AutoMapperProfile()));
            _mapper = new Mapper(configuration);

            _serviceMock = new Mock<ILevelService>();
            _controller = new LevelController(_serviceMock.Object, _mapper);
        }

        [Fact]
        public void GetAllLevel_ShouldCallService_AndReturn200WithDtos()
        {
            var expectedReturnFromService = new List<Level>()
            {
                new Level () { Id = 1, Name = "Teste" },
                new Level () { Id = 2, Name = "T" }
            }.AsQueryable();

            _serviceMock.Setup(x => x.List()).Returns(expectedReturnFromService);

            var result = _controller.GetAllLevel();

            _serviceMock.Verify(x => x.List(), Times.Once);

            var objectResult = Assert.IsType<OkObjectResult>(result.Result);
            Assert.Equal(200, objectResult.StatusCode);

            var dtos = Assert.IsType<List<LevelDTO>>(objectResult.Value);
            Assert.NotEmpty(dtos);

        }

        [Fact]
        public void GetLevelId_ShouldCallService_AndReturn200WithDtos_WhenLevelFound()
        {
            var expectedReturnFromService = new Level() { Id = 1, Name = "Teste" };

            _serviceMock.Setup(x => x.Fetch(1)).Returns(expectedReturnFromService);

            var result = _controller.GetLevelId(1);

            _serviceMock.Verify(x => x.Fetch(1), Times.Once);

            var objectResult = Assert.IsType<OkObjectResult>(result.Result);
            Assert.Equal(200, objectResult.StatusCode);

            var dto = Assert.IsType<LevelDTO>(objectResult.Value);
            Assert.Equal(expectedReturnFromService.Name.ToLower(), dto.Name);
        }



    }
}
