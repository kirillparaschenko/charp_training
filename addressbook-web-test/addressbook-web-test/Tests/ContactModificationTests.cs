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
            newData.Bday = "2";
            newData.Bmounth = "June";
            newData.Byear = "2001";
            newData.Aday = "3";
            newData.Amounth = "April";
            newData.Ayear = "2022";
            app.Contact.Modify(5, newData);
            app.Auth.LogOut();
        }
    }
}

