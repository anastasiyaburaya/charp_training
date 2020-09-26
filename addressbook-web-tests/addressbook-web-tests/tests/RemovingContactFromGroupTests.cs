using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using NUnit.Framework;


using System.IO;
using System.Threading;
using System.Xml;
using System.Xml.Serialization;
using Newtonsoft.Json;
using Excel = Microsoft.Office.Interop.Excel;

namespace WebAddressbookTests
{
    public class RemovingContactFromGroupTests : AuthTestBase
    {
        [Test]
        public void TestRemovingContactFromGroup()
        {    
            bool IsContactRemoved = false;

            foreach (ContactData contact in ContactData.GetAll())
            {              
                List<GroupData> groupList = contact.GetGroups();

                if(groupList.Count != 0)
                {
                    GroupData group = groupList[0];
                    List<ContactData> oldList = group.GetContacts();

                    app.Contacts.RemoveContactFromGroup(contact, group);

                    List<ContactData> newList = group.GetContacts();
                    Assert.AreEqual(oldList.Count - 1, newList.Count);

                    oldList.Remove(contact);
                    newList.Sort();
                    oldList.Sort();
                    Assert.AreEqual(oldList, newList);

                    IsContactRemoved = true;
                    break;                  
                }             
            }

            if (IsContactRemoved == false)
            {
                GroupData group = GroupData.GetAll()[0];
                List<ContactData> oldList = group.GetContacts();
                ContactData contact = ContactData.GetAll().Except(oldList).First();

                app.Contacts.AddContactToGroup(contact, group);
                app.Contacts.RemoveContactFromGroup(contact, group);

                List<ContactData> newList = group.GetContacts();
                newList.Sort();
                oldList.Sort();

                Assert.AreEqual(oldList, newList);               
            }          
        }
    }
}
