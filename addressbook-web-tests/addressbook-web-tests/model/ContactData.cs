﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        private string allPhones;

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
            return "firstname=" + Firstname + " " + "lastname=" + Lastname;
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

        public string Firstname { get; set; }

        public string Lastname { get; set; }

        //public string Middlename { get; set; } = "";

        //public string Nickname { get; set; } = "";

        //public string Title { get; set; } = "";

        //public string Company { get; set; } = "";

        public string Address { get; set; } = "";

        public string HomePhone { get; set; } = "";

        public string MobilePhone { get; set; } = "";

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

            return phone.Replace(" ", "").Replace("-", "").Replace("(", "").Replace(")", "") + "\r\n";
        }

        //public string Fax { get; set; } = "";

        public string Email { get; set; } = "";

        public string Email2 { get; set; } = "";

        public string Email3 { get; set; } = "";

        //public string Homepage { get; set; } = "";

        //public string Address2 { get; set; } = "";

        //public string Home2 { get; set; } = "";

        //public string Notes { get; set; } = "";

        //public AddressbookDate Birthday { get; set; } = new AddressbookDate("", "", "");

        //public AddressbookDate Anniversary { get; set; } = new AddressbookDate("", "", "");
       }
    }

