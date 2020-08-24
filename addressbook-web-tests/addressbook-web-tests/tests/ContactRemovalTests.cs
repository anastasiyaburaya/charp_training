using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactRemovalTests : AuthTestBase
    {

        [Test]
        public void ContactRemovalTest()
        {
            if (!app.Groups.IsElementPresent(By.Name("selected[]")))
            {
                ContactData contact = new ContactData("firstnameTest", "lastnameTest");
                contact.Middlename = "qqq";
                contact.Nickname = "www";
                contact.Title = "eee";
                contact.Company = "rrr";
                contact.Address = "ttt";
                contact.Home = "yyy";
                contact.Mobile = "456";
                contact.Work = "iii";
                contact.Fax = "123";
                contact.Email = "ppp";
                contact.Email2 = "aaa";
                contact.Email3 = "ddd";
                contact.Homepage = "ccc";
                contact.Address2 = "bbb";
                contact.Home2 = "kkk";
                contact.Notes = "lll";
                contact.Birthday.Day = "1";
                contact.Birthday.Month = "March";
                contact.Birthday.Year = "1996";
                contact.Anniversary.Day = "4";
                contact.Anniversary.Month = "March";
                contact.Anniversary.Year = "2008";

                app.Contacts.Create(contact);
            }

            app.Contacts.Remove("selected[]");
        }
    }
}
