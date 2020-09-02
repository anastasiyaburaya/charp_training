﻿using System;
using System.Collections.Generic;
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
    public class ContactCreationTests : AuthTestBase
    {
        [Test]
        public void ContactCreationTest()
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

            List<ContactData> oldContacts = app.Contacts.GetContactList();

            app.Contacts.Create(contact);

            Assert.AreEqual(oldContacts.Count + 1, app.Contacts.GetContactCount());

            List<ContactData> newContacts = app.Contacts.GetContactList();
            oldContacts.Add(contact);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        }
    }
}
