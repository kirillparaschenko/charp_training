using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupModificationTests : TestBase
    {
        [Test]
        public void GroupModifictionTest()
        {
            GroupData newData = new GroupData("TestUpd");
            newData.Header = "TestUPD!";
            newData.Footer = "TestUPD%";
            app.Groups.Modify(1, newData);
            app.Auth.LogOut();
        }

    }
}
