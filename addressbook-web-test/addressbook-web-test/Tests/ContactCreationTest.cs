using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class CreateContact : TestBase
    {

        [Test]
        public void TheCreateContactTest()
        {
            ContactData contact = new ContactData("Test", "Auto", "Contact");
            app.Contact.Create(contact);
            app.Auth.LogOut();
        }
    }
}
