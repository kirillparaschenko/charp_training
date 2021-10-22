using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupCreationTests : TestBaseGroup
    {

        [Test]
        public void GroupCreationTest()
        {
            OpenHomePage();
            Login(new AccountData("admin", "secret"));
            GoToGroupPage();
            InitGroupCreation();
            GroupData group = new GroupData("Test");
            group.Header = "Test 1!";
            group.Footer = "Test 2%";
            FillGroupForm(group); 
            SubmitGroupCreation();
            ReturnToGroupsPage();
            LogOut();
        }
    }
}
