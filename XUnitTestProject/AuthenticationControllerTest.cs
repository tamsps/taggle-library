using System;
using TaggleLib.Services;
using Xunit;

namespace XUnitTestProject
{
    public class AuthenticationControllerTest
    {
        private readonly AuthenticationRepository unitTest = null;

        public AuthenticationControllerTest()
        {
            if (unitTest == null)
                unitTest = new AuthenticationRepository();

        }
        [Fact]
        public void Test1_login_success()
        {
            var email = "abc1@taggle.com";
            var pass = "123456";
            var actual = unitTest.Login(email,pass);
        }
    }
}
