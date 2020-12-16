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


        //public void CreateNewIssue(AccountData account, ProjectData project, IssueData issueData)
        //{
        //    Mantis.MantisConnectPortTypeClient client = new MantisConnectPortTypeClient();
        //    Mantis.IssueData issue = new Mantis.IssueData();
        //    issue.summary = issueData.Summary;
        //    issue.description = issueData.Description;
        //    issue.category = issueData.Category;
        //    issue.project = new Mantis.ObjectRef();
        //    issue.project.id = project.Id;
        //    client.mc_issue_add(account.Name, account.Password, issue);
        //}

        public List<string> GetProjectList(AccountData account)
        {
            // using System.Net;
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            // Use SecurityProtocolType.Ssl3 if needed for compatibility reasons

            List<string> projects = new List<string>();

            Mantis.MantisConnectPortTypeClient client = new MantisConnectPortTypeClient();
            //ProjectData[] elements = client.mc_projects_get_user_accessible(account.Username, account.Password);

            //foreach (IWebElement element in elements)
            //{
            //    projects.Add(element.Text);
            //}

            return projects;
        }

        public void CreateProject(AccountData account, ProjectData projectData)
        {


            //ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;

            //ServicePointManager.Expect100Continue = true;
            //ServicePointManager.DefaultConnectionLimit = 9999;
            //ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls
            //                                      | SecurityProtocolType.Tls11
            //                                      | SecurityProtocolType.Tls12
            //                                      | SecurityProtocolType.Ssl3;

            Mantis.MantisConnectPortTypeClient client = new MantisConnectPortTypeClient();
            Mantis.ProjectData project = new Mantis.ProjectData();
            project.name = projectData.Name;
            client.mc_project_add(account.Username, account.Password, project);           
        }
    }
}
