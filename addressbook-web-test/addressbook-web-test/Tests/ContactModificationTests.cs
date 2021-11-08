using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    public class ContactModificationTests : AuthTestBase
    {
        [Test]
        public void ContactModificationTest()
        {
            ContactData newData = new ContactData("TestUpd", "ContactUPD");
            newData.Nickname = null;
            newData.Title = null;
            newData.Companyname = null;
            newData.Address = null;
            newData.Homephone = null;
            newData.Mobilephone = null;
            newData.Workphone = null;
            newData.Fax = null;
            newData.Email1 = null;
            newData.Email2 = null;
            newData.Email3 = null;
            newData.Homepage = null;
            //newData.Bday = null;
            //newData.Bmounth = null;
            newData.Byear = null;
            //newData.Aday = null;
            //newData.Amounth = null;
            newData.Ayear = null;
            newData.Address2 = null;
            newData.Phone2 = null;
            newData.Notes = null;

            if (app.Contact.IsContactCreated() is false)
            {
                app.Contact.Create(new ContactData("New", "New"));
            }

            List<ContactData> oldContacts = app.Contact.GetContactList();

            app.Contact.Modify(1, newData);

            List<ContactData> newContacts = app.Contact.GetContactList();
            oldContacts[1] = newData;
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        }
    }
}

