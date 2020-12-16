using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using System.Text.RegularExpressions;
using mantis_tests_project_webservice.Mantis;

namespace mantis_tests_project_webservice
{
    public class APIHelper : HelperBase
    {

        public APIHelper(ApplicationManager manager) : base(manager) { }

        public List<ProjectData> GetProjectList(AccountData account)
        {
            List<ProjectData> projects = new List<ProjectData>();
            Mantis.MantisConnectPortTypeClient client = new MantisConnectPortTypeClient();
            Mantis.ProjectData[] elements = client.mc_projects_get_user_accessible(account.Username, account.Password);

            foreach (Mantis.ProjectData element in elements)
            {
                projects.Add(new ProjectData { Name = element.name });
            }

            return projects;
        }
        
        public void CreateProject(AccountData account, ProjectData projectData)
        {
            Mantis.MantisConnectPortTypeClient client = new MantisConnectPortTypeClient();
            Mantis.ProjectData project = new Mantis.ProjectData();
            project.name = projectData.Name;
            client.mc_project_add(account.Username, account.Password, project);           
        }
    }
}
