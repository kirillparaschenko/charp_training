using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    public class ContactModificationTests : TestBase
    {
        [Test]
        public void ContactModificationTest()
        {
            ContactData newData = new ContactData("TestUpd", "AutoUPD", "ContactUPD");
            app.Contact.Modify(1, newData);
            app.Auth.LogOut();
        }
    }
}

