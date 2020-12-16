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

            app.ManagementMenu.GoToManagePage();
            app.ManagementMenu.GoToManageProjectTab();

            if (app.ManagementProject.GetProjectList().Count == 0)
            {
                ProjectData project = new ProjectData()
                {
                    Name = "testProject"
                };

                //app.ManagementProject.Create(project);
                app.API.CreateProject(account, project);
                app.ManagementProject.Wait(TimeSpan.FromSeconds(5));
            }
            
            List<string> oldProjects = app.ManagementProject.GetProjectList();

            app.ManagementProject.Remove();

            List<string> newProjects = app.ManagementProject.GetProjectList();

            Assert.AreEqual(oldProjects.Count - 1, newProjects.Count);

            oldProjects.RemoveAt(0);
            oldProjects.Sort();
            newProjects.Sort();
            Assert.AreEqual(oldProjects, newProjects);
        }
    }
}
