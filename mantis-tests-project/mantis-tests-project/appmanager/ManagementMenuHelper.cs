using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace mantis_tests_project
{
    public class ManagementMenuHelper : HelperBase
    {
        private string baseURL;

        public string BaseURL
        {
            get => baseURL;
            set => baseURL = value;
        }

        public ManagementMenuHelper(ApplicationManager manager, string baseURL) : base(manager)
        {
            this.BaseURL = baseURL;
        }

        public void GoToHomePage()
        {
            if (driver.Url == baseURL)
            {
                return;
            }
            driver.Navigate().GoToUrl(baseURL);
        }

        public void GoToManagePage()
        {
            var last = driver.FindElements(By.XPath("//div[@id='sidebar']/ul/li")).Count;
            driver.FindElement(By.XPath("//div[@id='sidebar']/ul/li[" + last + "]/a/i")).Click();
        }

        public void GoToManageProjectTab()
        {
            driver.FindElement(By.LinkText("Manage Projects")).Click();
        }
    }
}
               


