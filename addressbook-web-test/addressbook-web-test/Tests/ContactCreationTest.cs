using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactCreateTests : TestBase
    {

        [Test]
        public void ContactCreateTest()
        {
            ContactData contact = new ContactData("Test", "Auto", "Contact");
            contact.Bday = "1";
            contact.Bmounth = "July";
            contact.Byear = "2000";
            contact.Aday = "2";
            contact.Amounth = "May";
            contact.Ayear = "2021";
            app.Contact.Create(contact);
            app.Auth.LogOut();
        }
    }
}
