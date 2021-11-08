using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupModificationTests : AuthTestBase
    {
        [Test]
        public void GroupModifictionTest()
        {
            GroupData newData = new GroupData("TestUpd1");
            newData.Header = null;
            newData.Footer = null;

            if (app.Groups.IsGroupCreated() is false)
            {
                app.Groups.Create(new GroupData("New test group"));
            }

            List<GroupData> oldGroups = app.Groups.GetGroupList();
            
            app.Groups.Modify(0, newData);

            List<GroupData> newGroups = app.Groups.GetGroupList();
            
            oldGroups[0].Name = newData.Name;
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
        }
    }
}
