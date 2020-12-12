using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace mantis_tests_project
{
    public class ProjectRemovalTest : AuthTestBase
    {
        [Test]
        public void ProjectRemoveTest()
        {
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
