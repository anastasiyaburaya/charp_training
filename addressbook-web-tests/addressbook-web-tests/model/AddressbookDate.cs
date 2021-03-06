﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    public class AddressbookDate
    {
        private string day;
        private string month;
        private string year;

        public AddressbookDate(string day, string month, string year)
        {
            this.day = day;
            this.month = month;
            this.year = year;
        }

        public string Day
        {
            get { return day; }
            set { day = value; }
        }

        public string Month
        {
            get { return month; }
            set { month = value; }
        }

        public string Year
        {
            get { return year; }
            set { year = value; }
        }
    }
}
