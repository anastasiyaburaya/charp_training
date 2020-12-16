using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace mantis_tests_project_webservice
{
    public class ProjectCreatingTest : AuthTestBase
    {
        [Test]
        public void ProjectCreationTest()
        {
            AccountData account = new AccountData("administrator", "root");
            
            ProjectData project = new ProjectData()
            {
                Name = "project" + Guid.NewGuid()
            }; 

            app.ManagementMenu.GoToManagePage();
            app.ManagementMenu.GoToManageProjectTab();

            List<ProjectData> oldProjects = app.API.GetProjectList(account);

            app.ManagementProject.Create(project.Name);
            app.ManagementProject.Wait(TimeSpan.FromSeconds(5));

            List<ProjectData> newProjects = app.API.GetProjectList(account);
            Assert.AreEqual(oldProjects.Count + 1, newProjects.Count);

            oldProjects.Add(project);
            oldProjects.Sort();
            newProjects.Sort();
            Assert.AreEqual(oldProjects, newProjects);   
        }
    }
}
