using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactRemovalTests : ContactTestBase
    {

        [Test]
        public void ContactRemovalTest()
        {
            if (!app.Contacts.IsElementPresentByName())
            {
                ContactData contact = new ContactData("firstnameTest", "lastnameTest");
                //contact.Middlename = "qqq";
                //contact.Nickname = "www";
                //contact.Title = "eee";
                //contact.Company = "rrr";
                contact.Address = "ttt";
                contact.HomePhone = "yyy";
                contact.MobilePhone = "456";
                contact.WorkPhone = "iii";
                //contact.Fax = "123";
                contact.Email = "ppp";
                contact.Email2 = "aaa";
                contact.Email3 = "ddd";
                //contact.Homepage = "ccc";
                //contact.Address2 = "bbb";
                //contact.Home2 = "kkk";
                //contact.Notes = "lll";
                //contact.Birthday.Day = "1";
                //contact.Birthday.Month = "March";
                //contact.Birthday.Year = "1996";
                //contact.Anniversary.Day = "4";
                //contact.Anniversary.Month = "March";
                //contact.Anniversary.Year = "2008";

                app.Contacts.Create(contact);
            }

            List<ContactData> oldContacts = ContactData.GetAll();
            ContactData toBeRemoved = oldContacts[0];

            app.Contacts.Remove(toBeRemoved);
            app.Contacts.Wait(TimeSpan.FromSeconds(oldContacts.Count * 5));;

            Assert.AreEqual(oldContacts.Count - 1, app.Contacts.GetContactCount());

            List<ContactData> newContacts = ContactData.GetAll();

            oldContacts.RemoveAt(0);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        }
    }
}
