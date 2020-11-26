using System;
using System.Collections.Generic;
using NUnit.Framework;
using TestStack.White.InputDevices;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.TreeItems;
using TestStack.White.UIItems.WindowItems;
using System.Windows.Automation;
using TestStack.White.WindowsAPI;


namespace addressbook_tests_white
{
    [TestFixture]
    public class GroupRemovalTests : TestBase
    {
        [Test]
        public void TestGroupRemoval()
        {
            Window dialogue = app.Groups.OpenGroupsDialogue();
            Tree tree = dialogue.Get<Tree>("uxAddressTreeView");
            bool isGroupAdded = false;

            if (tree.Nodes[0].Nodes.Count <= 1)
            {
                GroupData newGroup = new GroupData()
                {
                    Name = "newGroup"
                };
                app.Groups.CloseGroupsDialogue(dialogue);
                app.Groups.Add(newGroup);
                isGroupAdded = true;
            }           

            if(!isGroupAdded)
            {
                app.Groups.CloseGroupsDialogue(dialogue);
            }

            List<GroupData> oldGroups = app.Groups.GetGroupList();

            app.Groups.Remove();

            List<GroupData> newGroups = app.Groups.GetGroupList();

            oldGroups.RemoveAt(0);
            Assert.AreEqual(oldGroups, newGroups);
        }

    }
}
