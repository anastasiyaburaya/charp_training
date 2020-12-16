using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace mantis_tests_project_webservice
{
    [TestFixture]
    public class LoginTests : TestBase
    {
        [Test]
        public void LoginWithValidCredentials()
        {
            AccountData account = new AccountData("administrator", "root");
            app.Auth.Login(account);

            app.Auth.Logout();

        }
    }
}
