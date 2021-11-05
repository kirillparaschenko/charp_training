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
            GroupData newData = new GroupData("TestUpd");
            newData.Header = null;
            newData.Footer = null;

            if (app.Groups.IsGroupCreated())
            {
                app.Groups.Modify(1, newData);
                return;
            }
            app.Groups.Create(new GroupData("New test group"));
            app.Groups.Modify(1, newData);
        }
    }
}
