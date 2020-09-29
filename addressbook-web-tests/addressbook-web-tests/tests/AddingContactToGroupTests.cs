using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    public class AddingContactToGroupTests : AuthTestBase
    {
        [Test]
        public void TestAddingContactToGroup()
        {
            ContactData newContact = new ContactData("firstnameTest", "lastnameTest");
            newContact.Address = "ttt";
            newContact.HomePhone = "yyy";
            newContact.MobilePhone = "456";
            newContact.WorkPhone = "iii";
            newContact.Email = "ppp";
            newContact.Email2 = "aaa";
            newContact.Email3 = "ddd";


            app.Navigator.GoToGroupsPage();
            if (!app.Groups.IsElementPresentByClassName())
            {
                GroupData newGroup = new GroupData("qwerty");
                newGroup.Header = "asdfg";
                newGroup.Footer = "zxcvb";
                app.Groups.Create(newGroup);
            }

            app.Navigator.GoToHomePage();
            if (!app.Contacts.IsElementPresentByName())
            {
                app.Contacts.Create(newContact);
            }

            GroupData group = GroupData.GetAll()[0];
            List<ContactData> oldList = group.GetContacts();
            IList<ContactData> contactsOutOfGroup = ContactData.GetAll().Except(group.GetContacts()).ToList();

            if (contactsOutOfGroup.Count == 0)
            {
                app.Contacts.Create(newContact);
                List<ContactData> newContacts = ContactData.GetAll();
                newContact.Id = newContacts.Last().Id;
                app.Contacts.AddContactToGroup(newContact, group);
                oldList.Add(newContact);
            }
            else
            {
                ContactData contact = ContactData.GetAll().Except(oldList).First();
                app.Contacts.AddContactToGroup(contact, group);
                oldList.Add(contact);
            }

            List<ContactData> newList = group.GetContacts();
            newList.Sort();
            oldList.Sort();

            Assert.AreEqual(oldList, newList);
        }
    }
}
