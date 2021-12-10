using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    public class AddingContactToGroupTests : AuthTestBase
    {
        [Test]
        public void TestAddingContactToGroup()
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
            ContactData contact = ContactData.GetAll().Except(oldList).FirstOrDefault();
            if (contact == null)
            {
                app.Contact.Create(new ContactData("New", "New"));
                contact = ContactData.GetAll().Except(oldList).First();
            }

            app.Contact.AddContactToGroup(contact, group);

            List<ContactData> newList = group.GetContacts();
            oldList.Add(contact);
            newList.Sort();
            oldList.Sort();
            Assert.AreEqual(oldList, newList);
        }
    }
}
