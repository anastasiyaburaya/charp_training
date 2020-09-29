using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using LinqToDB.Mapping;
using Microsoft.Office.Interop.Excel;

namespace WebAddressbookTests
{
    [Table(Name = "addressbook")]
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        private string allPhones;
        private string allEmail;

        public ContactData()
        {         
        }

        public ContactData(string firstname, string lastname)
        {
            this.Firstname = firstname;
            this.Lastname = lastname;
        }

        public bool Equals(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }

            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }

            return Firstname == other.Firstname && Lastname == other.Lastname;
        }

        public override int GetHashCode()
        {
            return (Firstname + Lastname).GetHashCode();
        }

        public override string ToString()
        {
            //return "firstname=" + Firstname + " " + "lastname=" + Lastname;

            return "firstname=" + Firstname + "\nlastname=" + Lastname + "\naddress" + Address 
                + "\nhome phone" + HomePhone + "mobile phone" + MobilePhone + "\nwork phone" + WorkPhone
                + "\nemail" + Email + "\nemail2" + Email2 + "\nemail3" + Email3;
        }

        public int CompareTo(ContactData other)
        {
           
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }

            if (Lastname.CompareTo(other.Lastname) != 0)
            {
                return Lastname.CompareTo(other.Lastname);
            }

            return Firstname.CompareTo(other.Firstname);

        }

        [Column(Name = "firstname")]
        public string Firstname { get; set; }

        [Column(Name = "lastname")]
        public string Lastname { get; set; }

        //public string Middlename { get; set; } = "";

        //public string Nickname { get; set; } = "";

        //public string Title { get; set; } = "";

        //public string Company { get; set; } = "";

        [Column(Name = "address")]
        public string Address { get; set; } = "";

        [Column(Name = "home")]
        public string HomePhone { get; set; } = "";

        [Column(Name = "mobile")]
        public string MobilePhone { get; set; } = "";

        [Column(Name = "work")]
        public string WorkPhone { get; set; } = "";

        public string AllPhones
        {
            get
            {
                if (allPhones != null)
                {
                    return allPhones;
                }
                else
                {
                    return (CleanUp(HomePhone) + CleanUp(MobilePhone) + CleanUp(WorkPhone)).Trim();
                }
            }

            set { allPhones = value; }          
        }

        private string CleanUp(string phone)
        {
            if (phone == null || phone == "")
            {
                return "";
            }

            return Regex.Replace(phone, "[ -()]", "") + "\r\n";
        }

        //public string Fax { get; set; } = "";

        [Column(Name = "email")]
        public string Email { get; set; } = "";

        [Column(Name = "email2")]
        public string Email2 { get; set; } = "";

        [Column(Name = "email3")]
        public string Email3 { get; set; } = "";

        public string AllEmail
        {
            get
            {
                if (allEmail != null)
                {
                    return allEmail;
                }
                else
                {
                    return (CleanUp(Email) + CleanUp(Email2) + CleanUp(Email3)).Trim();
                }
            }

            set { allEmail = value; }

        }

        [Column(Name = "id"), PrimaryKey, Identity]
        public string Id { get; set; }

        [Column(Name = "deprecated")]
        public string Deprecated { get; set; }

        //public string Homepage { get; set; } = "";

        //public string Address2 { get; set; } = "";

        //public string Home2 { get; set; } = "";

        //public string Notes { get; set; } = "";

        //public AddressbookDate Birthday { get; set; } = new AddressbookDate("", "", "");

        //public AddressbookDate Anniversary { get; set; } = new AddressbookDate("", "", "");

        public static List<ContactData> GetAll()
        {
            using (AddressBookDB db = new AddressBookDB())
            {
                return (from g in db.Contacts.Where(x => x.Deprecated == "0000-00-00 00:00:00") select g).ToList();
            }
        }

        public List<GroupData> GetGroups()
        {
            using (AddressBookDB db = new AddressBookDB())
            {
                return (from c in db.Groups
                    from gcr in db.GCR.Where(p => p.ContactId == Id && p.GroupId == c.Id)
                    select c).ToList();
            }
        }   
    }
}

