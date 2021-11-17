using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactInformationTests : AuthTestBase
    {
        [Test]
        public void TestContactInformationEditForm()
        {
            ContactData fromTable = app.Contact.GetContactInformationFromTable(0);
            ContactData fromForm = app.Contact.GetContactInformationFromEditForm(0);

            Assert.AreEqual(fromTable, fromForm);
            Assert.AreEqual(fromTable.Address, fromForm.Address);
            Assert.AreEqual(fromTable.AllPhones, fromForm.AllPhones);
            Assert.AreEqual(fromTable.AllEmails, fromForm.AllEmails);
        }

        //[Test]
        //public void TestContactInformationDetailsForm()
        //{
        //    ContactData fromDetails = app.Contact.GetContactInformationFromDetails(0);
        //    ContactData fromForm = app.Contact.GetContactInformationFromEditForm(0);

        //    Assert.AreEqual(fromDetails, fromForm);
        //    Assert.AreEqual(fromDetails.Address, fromForm.Address);
        //    Assert.AreEqual(fromDetails.AllPhones, fromForm.AllPhones);
        //    Assert.AreEqual(fromDetails.Fax, fromForm.Fax);
        //    Assert.AreEqual(fromDetails.AllEmails, fromForm.AllEmails);
        //}

    }
}
