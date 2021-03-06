﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace mantis_tests_project
{
    public class ProjectCreatingTest : AuthTestBase
    {
        [Test]
        public void ProjectCreationTest()
        {           
            string project = "project" + Guid.NewGuid();

            app.ManagementMenu.GoToManagePage();
            app.ManagementMenu.GoToManageProjectTab();

            List<string> oldProjects = app.ManagementProject.GetProjectList();
          
            app.ManagementProject.Create(project);
            app.ManagementProject.Wait(TimeSpan.FromSeconds(5));

            List<string> newProjects = app.ManagementProject.GetProjectList();           
            Assert.AreEqual(oldProjects.Count + 1, newProjects.Count);

            oldProjects.Add(project);
            oldProjects.Sort();
            newProjects.Sort();
            Assert.AreEqual(oldProjects, newProjects);   
        }
    }
}
