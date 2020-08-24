using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;


namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupRemovalTests : AuthTestBase
    {
        [Test]
        public void GroupRemovalTest()
        {
            app.Navigator.GoToGroupsPage();

            if (!app.Groups.IsElementPresent(By.ClassName("group")))
            {
                GroupData group = new GroupData("qwerty");
                group.Header = "asdfg";
                group.Footer = "zxcvb";
                app.Groups.Create(group);
            }

            app.Groups.Remove(1);
        }
    }
}
