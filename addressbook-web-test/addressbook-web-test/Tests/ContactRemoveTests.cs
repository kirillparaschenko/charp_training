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
            if (app.Contact.IsContactCreated() is false)
            {
                app.Contact.Create(new ContactData("New", "New"));
            }

            List<ContactData> oldContacts = app.Contact.GetContactList();

            app.Contact.Remove(0);

            List<ContactData> newContacts = app.Contact.GetContactList();
            oldContacts.RemoveAt(0);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        }
    }
}
