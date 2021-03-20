using AutoMapper;
using Ereceipt.Application.Interfaces;
using Ereceipt.Application.Services;
using Ereceipt.Application.ViewModels.User;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Ereceipt.Tests
{
    public class UserServiceTests
    {
        [Fact]
        public async void CreateUserTest()
        {
            var mock = new Mock<IUserService>();
            var userService = mock.Object;
            var userCreated = await userService.CreateUser(new Application.ViewModels.User.UserCreateViewModel
            {
                UserId = 0,
                Name = "Nikita Medko",
                Login = "yaroslav.mudryk@gmail.com",
                Password = "Some password",
                IP = "34.43.119.37"
            });

            Assert.NotNull(userCreated);
            Assert.Equal("Nikita Medko", userCreated.Data.Name);
            Assert.Equal(1, userCreated.Data.Id);
        }

        [Fact]
        public async void EditUserTest()
        {
            var mock = new Mock<IUserService>();
            var userService = mock.Object;
            var userForEdit = await userService.GetUserById(1);
            Assert.NotNull(userForEdit);
        }
    }
}