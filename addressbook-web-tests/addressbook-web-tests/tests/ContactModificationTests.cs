﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;

namespace WebAddressbookTests
{
    [TestFixture]
    public  class ContactModificationTests : ContactTestBase
    {
        [Test]
        public void ContactModificationTest()
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

            ContactData newData = new ContactData("firstname2", "lastname2");
            //newData.Middlename = "yyy";
            //newData.Nickname = "wuuuww";
            //newData.Title = "gjg";
            //newData.Company = "ghjgj";
            newData.Address = "kkk";
            newData.HomePhone = "hjgj";
            newData.MobilePhone = "435";
            newData.WorkPhone = "fghfh";
            //newData.Fax = "556";
            newData.Email = "tyrty";
            newData.Email2 = "ghjgj";
            newData.Email3 = "gjghj";
            //newData.Homepage = "fghfh";
            //newData.Address2 = "fghfh";
            //newData.Home2 = "fhfh";
            //newData.Notes = "fgdgdfg";
            //newData.Birthday.Day = "1";
            //newData.Birthday.Month = "March";
            //newData.Birthday.Year = "1996";
            //newData.Anniversary.Day = "4";
            //newData.Anniversary.Month = "March";
            //newData.Anniversary.Year = "2008";

            List<ContactData> oldContacts = ContactData.GetAll();
            ContactData toBeModified = oldContacts[0];

            app.Contacts.Modify(toBeModified, newData);

            Assert.AreEqual(oldContacts.Count, app.Contacts.GetContactCount());

            List<ContactData> newContacts = ContactData.GetAll();

            oldContacts[0].Firstname = newData.Firstname;
            oldContacts[0].Lastname = newData.Lastname;
            oldContacts[0].Address = newData.Address;
            oldContacts[0].HomePhone = newData.HomePhone;
            oldContacts[0].MobilePhone = newData.MobilePhone;
            oldContacts[0].WorkPhone = newData.WorkPhone;
            oldContacts[0].Email = newData.Email;
            oldContacts[0].Email2 = newData.Email2;
            oldContacts[0].Email3 = newData.Email3;

            oldContacts.Sort();
            newContacts.Sort();

            Assert.AreEqual(oldContacts, newContacts);
        }
    }
}
