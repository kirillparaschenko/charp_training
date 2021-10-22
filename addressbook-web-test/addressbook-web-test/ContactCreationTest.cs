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
            OpenHomePage();
            Login(new AccountData("admin", "secret"));
            InitContactCreation();
            ContactData contact = new ContactData("Test", "Auto", "Contact");
            FillContactForm(contact);
            AddContact();
            ReturnToHomepage();
            LogOut();
        }
    }
}
