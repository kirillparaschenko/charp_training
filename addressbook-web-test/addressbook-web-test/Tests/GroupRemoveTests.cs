using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupRemoveTests : AuthTestBase
    {
        [Test]
        public void GroupRemoveTest()
        {
            if (app.Groups.IsGroupCreated() is false)
            {
                app.Groups.Create(new GroupData("New test group"));
            }

            List<GroupData> oldGroups = app.Groups.GetGroupList();

            app.Groups.Remove(0);

            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups.RemoveAt(0);
            Assert.AreEqual(oldGroups, newGroups);
        }
    }
}
