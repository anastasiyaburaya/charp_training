using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public  class ContactModificationTests : TestBase
    {
        [Test]
        public void ContactModificationTest()
        {
            ContactData newData = new ContactData("firstname2", "lastname2");
            newData.Middlename = "yyy";
            newData.Nickname = "wuuuww";
            newData.Title = "gjg";
            newData.Company = "ghjgj";
            newData.Home = "hjgj";
            newData.Mobile = "435";
            newData.Work = "fghfh";
            newData.Fax = "556";
            newData.Email = "tyrty";
            newData.Email2 = "ghjgj";
            newData.Email3 = "gjghj";
            newData.Homepage = "fghfh";
            newData.Address2 = "fghfh";
            newData.Home2 = "fhfh";
            newData.Notes = "fgdgdfg";
            newData.Birthday.Day = "1";
            newData.Birthday.Month = "March";
            newData.Birthday.Year = "1996";
            newData.Anniversary.Day = "4";
            newData.Anniversary.Month = "March";
            newData.Anniversary.Year = "2008";

            app.Contacts.Modify(newData);
        }
    }
}
