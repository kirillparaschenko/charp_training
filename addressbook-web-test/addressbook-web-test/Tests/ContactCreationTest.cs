using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactCreateTests : AuthTestBase
    {

        [Test]
        public void ContactCreateTest()
        {
            ContactData contact = new ContactData("Test", "Auto", "Contact");
            //contact.Firstname = null;
            //contact.Middlename = null;
            //contact.Lastname = null;
            contact.Nickname = null;
            contact.Title = null;
            contact.Companyname = null;
            contact.Address = null;
            contact.Homephone = null;
            contact.Mobilephone = null;
            contact.Workphone = null;
            contact.Fax = null;
            contact.Email1 = null;
            contact.Email2 = null;
            contact.Email3 = null;
            contact.Homepage = null;
            contact.Bday = null;
            contact.Bmounth = null;
            contact.Byear = null;
            contact.Aday = null;
            contact.Amounth = null;
            contact.Ayear = null;
            contact.Address2 = null;
            contact.Phone2 = null;
            contact.Notes = null;
            app.Contact.Create(contact);
            //app.Auth.LogOut();
        }
    }
}
