
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Moq;
using System;
using TaggleLib.Controllers;
using TaggleLib.Entities;
using TaggleLib.Services;
using Xunit;

namespace XUnitTestProject
{
    public class AuthenticationControllerTest
    {
        private readonly Mock<IAuthenticationRepository>  unitTest = null;
        private readonly Mock<IConfiguration> config = null;

        public AuthenticationControllerTest()
        {
            if (unitTest == null)
                unitTest = new Mock<IAuthenticationRepository>();
            config = new Mock<IConfiguration>();
        }

        [Fact]
        public void Test1_login_success()
        {

            var email = "abc1@taggle.com";
            var pass = "123456";
            var user = new Users() { Email = email, Password = pass };

            unitTest.Setup(p => p.Login(email, pass)).Returns(true);

            AuthenticationController emp = new AuthenticationController(unitTest.Object, config.Object);
            var result = emp.Login(user);

            Assert.True(result);

        }

        [Fact]
        public void Test1_login_fail()
        {

            var email = "abc1@taggle.com";
            var pass = "1234";
            var user = new Users() { Email = email, Password = pass };

            unitTest.Setup(p => p.Login(email, pass)).Returns(false);

            AuthenticationController emp = new AuthenticationController(unitTest.Object, config.Object);
            var result = emp.Login(user);

            Assert.False(result);

        }
    }
}
