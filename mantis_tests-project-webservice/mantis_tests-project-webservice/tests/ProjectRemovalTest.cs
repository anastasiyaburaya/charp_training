using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mantis_tests_project_webservice.Mantis;
using NUnit.Framework;

namespace mantis_tests_project_webservice
{
    public class ProjectRemovalTest : AuthTestBase
    {
        [Test]
        public void ProjectRemoveTest()
        {
            AccountData account = new AccountData("administrator", "root");

            if (app.API.GetProjectList(account).Count == 0)
            {
                ProjectData project = new ProjectData()
                {
                    Name = "testProject"
                };

                app.API.CreateProject(account, project);
            }

            app.ManagementMenu.GoToManagePage();
            app.ManagementMenu.GoToManageProjectTab();

            List<ProjectData> oldProjects = app.API.GetProjectList(account);

            app.ManagementProject.Remove();

            List<ProjectData> newProjects = app.API.GetProjectList(account);

            Assert.AreEqual(oldProjects.Count - 1, newProjects.Count);

            oldProjects.RemoveAt(0);
            oldProjects.Sort();
            newProjects.Sort();
            Assert.AreEqual(oldProjects, newProjects);
        }
    }
}