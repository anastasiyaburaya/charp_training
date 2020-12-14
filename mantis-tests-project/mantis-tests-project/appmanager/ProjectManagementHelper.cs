using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace mantis_tests_project
{
    public class ProjectManagementHelper : HelperBase
    {
        public ProjectManagementHelper(ApplicationManager manager) : base(manager)
        {

        }

        public ProjectManagementHelper Create(string project)
        {       
            InitProjectCreation();
            FillProjectName(project);
            AddProject();           
            return this;
        }

        public ProjectManagementHelper Remove()
        {
            SelectProject();
            RemoveProject();
            ConfirmRemovingProject();
            return this;
        }

        public ProjectManagementHelper InitProjectCreation()
        {
            driver.FindElement(By.ClassName("form-inline")).FindElement(By.ClassName("btn")).Click();
            return this;
        }

        public ProjectManagementHelper FillProjectName(string project)
        {
            Type(By.ClassName("input-sm"), project);
            return this;
        }

        public ProjectManagementHelper AddProject()
        {
            driver.FindElement(By.XPath("//input[@value='Add Project']")).Click();
            return this;
        }

        public List<string> GetProjectList()
        {
            List<string> projects = new List<string>();

            ICollection<IWebElement> elements = driver.FindElement(By.ClassName("table"))
                .FindElements(By.TagName("tr")).Skip(1).Select(p => p.FindElement(By.TagName("td")).FindElement(By.TagName("a"))).ToArray();

            foreach (IWebElement element in elements)
            {
                projects.Add(element.Text);
            }

            return projects;
        }

        public ProjectManagementHelper SelectProject()
        {
            driver.FindElement(By.TagName("td")).FindElement(By.TagName("a")).Click();
            return this;
        }

        public ProjectManagementHelper RemoveProject()
        {
            driver.FindElement(By.XPath("//input[@value='Delete Project']")).Click();
            return this;
        }

        public ProjectManagementHelper ConfirmRemovingProject()
        {
            driver.FindElement(By.XPath("//input[@value='Delete Project']")).Click();
            return this;
        }
    }
}
