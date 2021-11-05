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
            if (app.Contact.IsContactCreated())
            {
                app.Contact.Remove(1);
                return;
            }
            app.Contact.Create(new ContactData("New", "New", "New"));
            app.Contact.Remove(1);
        }
    }
}
