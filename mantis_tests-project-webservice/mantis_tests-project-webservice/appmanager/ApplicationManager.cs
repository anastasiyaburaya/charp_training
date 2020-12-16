using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;


namespace mantis_tests_project_webservice
{
    public class ApplicationManager
    {
        protected IWebDriver driver;
        protected string baseURL;
       
        protected LoginHelper loginHelper;
        public ManagementMenuHelper managementMenu;
        public ProjectManagementHelper managementProject;

        private static ThreadLocal<ApplicationManager> app = new ThreadLocal<ApplicationManager>();

        private ApplicationManager()
        {
            driver = new FirefoxDriver();
            baseURL = "http://localhost/mantisbt-2.24.2/login_page.php";

            loginHelper = new LoginHelper(this);
            managementMenu = new ManagementMenuHelper(this, baseURL);
            managementProject = new ProjectManagementHelper(this);
            API = new APIHelper(this);
        }

        ~ApplicationManager()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
        }

        public static ApplicationManager GetInstance()
        {
            if (!app.IsValueCreated)
            {
                ApplicationManager newInstance = new ApplicationManager();
                newInstance.ManagementMenu.GoToHomePage();
                app.Value = newInstance;
            }
            return app.Value;
        }

        public IWebDriver Driver
        {
            get { return driver; }
        }

        public LoginHelper Auth
        {
            get { return loginHelper; }
        }

        public ManagementMenuHelper ManagementMenu
        {
            get { return managementMenu; }
        }

        public ProjectManagementHelper ManagementProject
        {
            get { return managementProject; }
        }

        public APIHelper API { get; set; }
    }
}