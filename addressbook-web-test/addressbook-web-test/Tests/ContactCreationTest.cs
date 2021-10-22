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
            app.Navigator.OpenHomePage();
            app.Auth.Login(new AccountData("admin", "secret"));
            app.Contact.InitContactCreation();
            ContactData contact = new ContactData("Test", "Auto", "Contact");
            app.Contact.FillContactForm(contact);
            app.Contact.AddContact();
            app.Contact.ReturnToHomepage();
            app.Auth.LogOut();
        }
    }
}
