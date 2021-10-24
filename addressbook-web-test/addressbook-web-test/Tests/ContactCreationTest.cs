using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class CreateContactTests : TestBase
    {

        [Test]
        public void CreateContactTest()
        {
            ContactData contact = new ContactData("Test", "Auto", "Contact");
            app.Contact.Create(contact);
            app.Auth.LogOut();
        }
    }
}
