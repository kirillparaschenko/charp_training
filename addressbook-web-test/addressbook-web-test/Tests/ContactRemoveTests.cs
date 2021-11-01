using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    public class ContactRemoveTests : AuthTestBase
    {
        [Test]
        public void ContactRemoveTest()
        {
            app.Contact.Remove(1);
        }
    }
}
