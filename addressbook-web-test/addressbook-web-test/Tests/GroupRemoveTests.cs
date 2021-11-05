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
            if (app.Groups.IsGroupCreated())
            {
                app.Groups.Remove(1);
                return;
            }
            app.Groups.Create(new GroupData("New test group"));
            app.Groups.Remove(1);
        }
    }
}
