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
            driver.FindElements(By.ClassName("menu-icon"))[6].Click();
        }

        public void GoToManageProjectTab()
        {

            //driver.FindElement(By.ClassName("main-content")).FindElement(By.ClassName("page-content"))
            //    .FindElements(By.ClassName("nav"))[0].FindElements(By.TagName("li"))[2].FindElement(By.TagName("a")).Click();

            driver.FindElement(By.LinkText("Manage Projects")).Click();
        }
    }
}
               


