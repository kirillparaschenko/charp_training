using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    public class RemovingContactFromGroupTests : AuthTestBase
    {
        [Test]
        public void TestRemovingContactFromGroup()
        {
            if (!app.Contact.IsContactCreated())
            {
                app.Contact.Create(new ContactData("New", "New"));
            }
            if (!app.Groups.IsGroupCreated())
            {
                app.Groups.Create(new GroupData("New test group"));
            }

            GroupData group = GroupData.GetAll()[0];
            List<ContactData> oldList = group.GetContacts();
            ContactData contact;
            if (oldList.Count > 0)
            {
                contact = oldList.First();
            }
            else
            {
                contact = ContactData.GetAll().First();
                app.Contact.AddContactToGroup(contact, group);
                oldList = group.GetContacts();
            }

            app.Contact.RemoveContactFromGroup(contact, group);

            List<ContactData> newList = group.GetContacts();
            oldList.Remove(contact);
            newList.Sort();
            oldList.Sort();
            Assert.AreEqual(oldList, newList);
        }
    }
}
