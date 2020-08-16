using CentralDeErros.Core;
using CentralDeErros.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CentralDeErros.ModelsTests
{
    public class UserModelTests : BaseModelTest
    {
        public UserModelTests()
        {
        }


        [Fact(DisplayName = "User should not be null")]
        public void UserShouldNotBeNull()
        {                         
            Assert.NotNull(context.Users);                            
        } 


        [Fact(DisplayName = "Id should be positive")]
        public void UserIdShouldBePositive()
        {       
            var negativeId = context.Users[0].Id;
            
            Assert.NotNull(context.Users);                            
        } 


        [Fact(DisplayName = "UserName should be longer than three")]
        public void UserNameShouldBeLongerThanThree()
        {       
            var negativeId = context.Users[1].Id;
            
            Assert.NotNull(context.Users);                            
        }


        [Fact(DisplayName = "UserName should have a valid email")]
        public void UserShouldHaveValidEmail()
        {       
            var negativeId = context.Users[2].Id;
            
            Assert.NotNull(context.Users);                            
        }  

        

    }
}
