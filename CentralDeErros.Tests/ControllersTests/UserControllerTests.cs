using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CentralDeErros.API;
using CentralDeErros.Data;
using CentralDeErros.Transport;
using Xunit;

namespace CentralDeErros.ControllersTests
{
    public class UserControllerTests
    {
        List<User> userList = new 
        {
            //successfull result
            new User() { Id = 1, UserName = "Teste1", Email = "Teste1@email.com"},

            //non-successfull results => constraints
            new User() { Id = 2, UserName = "", Email = "Teste2@email.com"},
            new User() { Id = 3, UserName = "Teste3", Email = ""},
            new User() { Id = null, UserName = "Teste4", Email = "Teste4@email.com"},
        };

        List<UserDTO> userDTOlist = new 
        {
            new UserDTO() { UserName = "Teste1", Email = "Teste1@email.com"},
            new UserDTO() { UserName = "Teste2", Email = "Teste2@email.com"},
            new UserDTO() { UserName = "Teste3", Email = "Teste3@email.com"},
            new UserDTO() { UserName = "Teste4", Email = "Teste4@email.com"},
        };

        UserController controller;
        public UserControllerTests()
        {
            this.controller = new UserController();
        }

        [Fact]
        public void Create_ShouldReturnOkResult()
        {
          
            //Act

            var action = controller.Post(userList[0]);

            //Assert

            Assert.IsType<OkObjectResult>(action.Result);
        }

        [Fact]
        public void Delete_ShouldReturnOkResult()
        {
            
            //Act

            var action = controller.Delete(userDTOlist[0]);

            //Assert

            Assert.IsType<OkObjectResult>(action.Result);
        }

        [Fact]
        public void Update_ShouldReturnOkResult()
        {
            
            //Act
            var action = controller.Update(userList[0].id);

            //Assert
            Assert.IsType<OkObjectResult>(action.Result);
        }

        [Fact]
        public void GetItems_ShouldReturnOkResult()
        {
            
            //Act
            var action = controller.GetAll();

            //Assert
            Assert.IsType<OkObjectResult>(action.Result);
        }

    }
}
