using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests
{
    public class ContactHelper : HelperBase
    {

        public ContactHelper(ApplicationManager manager) : base(manager)
        {
        }

        public ContactHelper Create(ContactData contact)
        {
            InitContactCreation();
            FillContactForm(contact);
            SubmitContactCreation();
            ReturnToContactsPage();
            return this;
        }

        public ContactHelper Remove(string v)
        {
            SelectContact(v);
            RemoveContact();
            return this;
        }

        public ContactHelper Remove(ContactData contact)
        {
            SelectContact(contact.Id);
            RemoveContact();
            return this;
        }

        public ContactHelper Modify(ContactData contact, ContactData newData)
        {
            InitContactModification(contact.Id);
            FillContactForm(newData);
            SubmitContactModification();
            ReturnToContactsPage();
            return this;
        }

        private List<ContactData> contactCache = null;

        public List<ContactData> GetContactList()
        {
            if (contactCache == null)
            {
                contactCache = new List<ContactData>();

                ICollection<IWebElement> elements = driver.FindElements(By.Name("entry"));

                foreach (IWebElement element in elements)
                {
                    IList<IWebElement> cells = element.FindElements(By.TagName("td"));

                    contactCache.Add(new ContactData(cells[2].Text, cells[1].Text));
                }
            }

            return new List<ContactData>(contactCache);
        }

        public ContactHelper RemoveContact()
        {
            acceptNextAlert = true;
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            Assert.IsTrue(Regex.IsMatch(CloseAlertAndGetItsText(), "^Delete 1 addresses[\\s\\S]$"));
            contactCache = null;
            return this;
        }

        //public ContactHelper SelectContact(string v)
        //{
        //    driver.FindElement(By.Name(v)).Click();
        //    return this;
        //}

        public ContactHelper SelectContact(String id)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]' and @value='" + id + "'])")).Click();
            return this;
        }

        public ContactHelper ReturnToContactsPage()
        {
            driver.FindElement(By.LinkText("home page")).Click();
            return this;
        }

        public ContactHelper SubmitContactModification()
        {
            driver.FindElement(By.XPath("(//input[@name='update'])[1]")).Click();
            contactCache = null;
            return this;
        }

        public void InitContactModification(int index)
        {
            //driver.FindElement(By.XPath("(//img[@alt='Edit'])[1]")).Click();
            //return this;

            driver.FindElements(By.Name("entry"))[index]
                .FindElements(By.TagName("td"))[7]
                .FindElement(By.TagName("a")).Click();           
        }

        public void InitContactModification(String id)
        {
            //driver.FindElements(By.Name("entry"))[index]
            //    .FindElements(By.TagName("td"))[7]
            //    .FindElement(By.TagName("a")).Click();

            //driver.FindElement(By.XPath("(//input[@name='selected[]' and @value='" + id + "'])")).Click();

            driver.FindElement(By.XPath("(//img[@alt='Edit'])['"+ id +"']")).Click();
        }

        public ContactHelper SubmitContactCreation()
        {
            driver.FindElement(By.XPath("(//input[@name='submit'])[1]")).Click();
            contactCache = null;
            return this;
        }

        public ContactHelper FillContactForm(ContactData contact)
        {
            Type(By.Name("firstname"), contact.Firstname);
            //Type(By.Name("middlename"), contact.Middlename);
            Type(By.Name("lastname"), contact.Lastname);
            //Type(By.Name("nickname"), contact.Nickname);
            //Type(By.Name("title"), contact.Title);
            //Type(By.Name("company"), contact.Company);
            Type(By.Name("address"), contact.Address);
            Type(By.Name("home"), contact.HomePhone);  
            Type(By.Name("mobile"), contact.MobilePhone);
            Type(By.Name("work"), contact.WorkPhone);
            //Type(By.Name("fax"), contact.Fax);
            Type(By.Name("email"), contact.Email);
            Type(By.Name("email2"), contact.Email2);
            Type(By.Name("email3"), contact.Email3);
            //Type(By.Name("homepage"), contact.Homepage);
            //new SelectElement(driver.FindElement(By.Name("bday"))).SelectByText(contact.Birthday.Day);
            //driver.FindElement(By.XPath("//option[@value='1']")).Click();
            //new SelectElement(driver.FindElement(By.Name("bmonth"))).SelectByText(contact.Birthday.Month);
            //driver.FindElement(By.XPath("//option[@value='March']")).Click();
            //Type(By.Name("byear"), contact.Birthday.Year);            
            //new SelectElement(driver.FindElement(By.Name("aday"))).SelectByText(contact.Anniversary.Day);
            //driver.FindElement(By.XPath("(//option[@value='4'])[2]")).Click();
            //new SelectElement(driver.FindElement(By.Name("amonth"))).SelectByText(contact.Anniversary.Month);
            //driver.FindElement(By.XPath("//option[@value='March']")).Click();
            //Type(By.Name("ayear"), contact.Anniversary.Year);
            //Type(By.Name("address2"), contact.Address2);
            //Type(By.Name("phone2"), contact.Home2);
            //Type(By.Name("notes"), contact.Notes);
            return this;
        }

        public ContactHelper InitContactCreation()
        {
            driver.FindElement(By.LinkText("add new")).Click();
            return this;
        }

        public void ShowContactDetails(int index)
        {
            driver.FindElements(By.Name("entry"))[index]
                .FindElements(By.TagName("td"))[6]
                .FindElement(By.TagName("a")).Click();
        }

        public int GetContactCount()
        {
            return driver.FindElements(By.Name("entry")).Count;
        }

        public ContactData GetContactInformationFromTable(int index)
        {
            manager.Navigator.GoToHomePage();

            IList<IWebElement> cells = driver.FindElements(By.Name("entry"))[index]
                .FindElements(By.TagName("td"));

            string lastName = cells[1].Text;
            string firstName = cells[2].Text;
            string address = cells[3].Text;
            string allEmail = cells[4].Text;
            string allPhones = cells[5].Text;

            return new ContactData(firstName, lastName)
            {
                Address = address,
                AllPhones = allPhones,
                AllEmail = allEmail
            };
        }

        public string GetContactInformationFromDetails()
        {
            manager.Navigator.GoToHomePage();
            ShowContactDetails(0);

            string detailsText = driver.FindElement(By.Id("content")).Text;

            return detailsText;
        }

        public ContactData GetContactInformationFromEditForm(int index)
        {
            manager.Navigator.GoToHomePage();
            InitContactModification(0);

            string firstName = driver.FindElement(By.Name("firstname")).GetAttribute("value");
            string lastName = driver.FindElement(By.Name("lastname")).GetAttribute("value");
            string address = driver.FindElement(By.Name("address")).GetAttribute("value");

            string homePhone = driver.FindElement(By.Name("home")).GetAttribute("value");
            string mobilePhone = driver.FindElement(By.Name("mobile")).GetAttribute("value");
            string workPhone = driver.FindElement(By.Name("work")).GetAttribute("value");

            string email = driver.FindElement(By.Name("email")).GetAttribute("value");
            string email2 = driver.FindElement(By.Name("email2")).GetAttribute("value");
            string email3 = driver.FindElement(By.Name("email3")).GetAttribute("value");

            return new ContactData(firstName, lastName)
            {
                Address = address,
                HomePhone = homePhone,
                MobilePhone = mobilePhone,
                WorkPhone = workPhone,
                Email = email,
                Email2 = email2,
                Email3 = email3
            };
        }   
    }
}
