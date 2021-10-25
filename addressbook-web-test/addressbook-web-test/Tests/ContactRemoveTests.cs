using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    public class ContactRemoveTests : TestBase
    {
        [Test]
        public void ContactRemoveTest()
        {
            app.Contact.Remove(1);
            app.Auth.LogOut();
        }
    }
}
