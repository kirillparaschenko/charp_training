using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests
{
    public class ContactHelper : HelperBase
    {

        public ContactHelper(ApplicationManager manager)
            : base(manager)
        {
        }

        public ContactHelper Create(ContactData contact)
        {
            InitContactCreation();
            FillContactForm(contact);
            AddContact();
            ReturnToHomepage();
            return this;
        }

        public ContactHelper Modify(int v, ContactData newData)
        {
            manager.Navigator.GoToHome();
            InitContactModigication(v);
            FillContactForm(newData);
            SubmitContactModification();
            ReturnToHomepage();
            return this;
        }
        public ContactHelper Modify(ContactData contact, ContactData newData)
        {
            manager.Navigator.GoToHome();
            InitContactModigication(contact.Id);
            FillContactForm(newData);
            SubmitContactModification();
            ReturnToHomepage();
            return this;
        }

        public ContactHelper Remove(int v)
        {
            manager.Navigator.GoToHome();
            SelectCheckbox(v);
            DeleteContact();
            SubmitContactRemoving();
            return this;
        }
        internal ContactHelper Remove(ContactData contact)
        {
            manager.Navigator.GoToHome();
            SelectCheckbox(contact.Id);
            DeleteContact();
            SubmitContactRemoving();
            manager.Navigator.GoToHome();
            return this;
        }
        internal void AddContactToGroup(ContactData contact, GroupData group)
        {
            manager.Navigator.GoToHome();
            ClearGroupFilter();
            SelectCheckbox(contact.Id);
            SelectGroupToAdd(group.Name);
            CommitAddingContactToGroup();
            new WebDriverWait(driver, TimeSpan.FromSeconds(10))
                .Until(d => driver.FindElements(By.CssSelector("div.msgbox")).Count > 0);
        }

        internal void RemoveContactFromGroup(ContactData contact, GroupData group)
        {
            manager.Navigator.GoToHome();
            SelectGroupToRemove(group.Name);
            SelectCheckbox(contact.Id);
            InitRemoveContactFromGroup();
        }

        private void SelectGroupToRemove(string name)
        {
            new SelectElement(driver.FindElement(By.Name("group"))).SelectByText(name);
        }

        private void InitRemoveContactFromGroup()
        {
            driver.FindElement(By.Name("remove")).Click();
        }

        private void CommitAddingContactToGroup()
        {
            driver.FindElement(By.Name("add")).Click();
        }

        private void SelectGroupToAdd(string name)
        {
            new SelectElement(driver.FindElement(By.Name("to_group"))).SelectByText(name);
        }

        private void ClearGroupFilter()
        {
            new SelectElement(driver.FindElement(By.Name("group"))).SelectByText("[all]");
        }

        public ContactHelper SelectCheckbox(int index)
        {
            driver.FindElement(By.XPath("//table[@id='maintable']/tbody/tr[" +(index+2)+ "]/td")).Click();
            return this;
        }

        public ContactHelper SelectCheckbox(String id)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]' and @value='" + id + "'])")).Click();
            return this;
        }


        public ContactHelper AddContact()
        {
            driver.FindElement(By.XPath("//div[@id='content']/form/input[21]")).Click();
            contactCache = null;
            return this;
        }

        public ContactHelper InitContactCreation()
        {
            driver.FindElement(By.LinkText("add new")).Click();
            return this;
        }
        public ContactHelper FillContactForm(ContactData contact)
        {
            Type(By.Name("firstname"), contact.Firstname);
            Type(By.Name("middlename"), contact.Middlename);
            Type(By.Name("lastname"), contact.Lastname);
            Type(By.Name("nickname"), contact.Nickname);
            Type(By.Name("title"), contact.Title);
            Type(By.Name("company"), contact.Companyname);
            Type(By.Name("address"), contact.Address);
            Type(By.Name("home"), contact.Homephone);
            Type(By.Name("mobile"), contact.Mobilephone);
            Type(By.Name("work"), contact.Workphone);
            Type(By.Name("fax"), contact.Fax);
            Type(By.Name("email"), contact.Email1);
            Type(By.Name("email2"), contact.Email2);
            Type(By.Name("email3"), contact.Email3);
            Type(By.Name("homepage"), contact.Homepage);
            //Dropdown(By.Name("bday"), contact.Bday);
            //Dropdown(By.Name("bmonth"), contact.Bmounth);
            Type(By.Name("byear"), contact.Byear);
            //Dropdown(By.Name("aday"), contact.Aday);
            //Dropdown(By.Name("amonth"), contact.Amounth);
            Type(By.Name("ayear"), contact.Ayear);
            Type(By.Name("address2"), contact.Address2);
            Type(By.Name("phone2"), contact.Phone2);
            Type(By.Name("notes"), contact.Notes);
            return this;
        }
        public void Dropdown(By locator, string text)
        {
            if (text != null)
            {
                driver.FindElement(locator).Click();
                new SelectElement(driver.FindElement(locator)).SelectByText(text);
            }
        }
        public ContactHelper ReturnToHomepage()
        {
            driver.FindElement(By.LinkText("home page")).Click();
            return this;
        }
        public ContactHelper SubmitContactRemoving()
        {
            driver.SwitchTo().Alert().Accept();
            contactCache = null;
            return this;
        }

        public ContactHelper DeleteContact()
        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            return this;
        }

        public ContactHelper SubmitContactModification()
        {
            driver.FindElement(By.Name("update")).Click();
            contactCache = null;
            return this;
        }

        public ContactHelper InitContactModigication(int index)
        {
            driver.FindElement(By.XPath("//tr[" + (index + 2) + "]/td[8]/a/img")).Click();
            return this;
        }
        public ContactHelper InitContactModigication(String id)
        {
            driver.FindElement(By.XPath("(//img[@alt='Edit'])['" + id + "']")).Click();
            return this;
        }

        public bool IsContactCreated()
        {
            manager.Navigator.GoToHome();
            return IsElementPresent(By.Name("selected[]"));
        }

        private List<ContactData> contactCache = null;

        public List<ContactData> GetContactList()
        {
            if (contactCache == null)
            {
                contactCache = new List<ContactData>();
                manager.Navigator.GoToHome();
                ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("tr[name='entry']"));
                foreach (IWebElement element in elements)

                {
                    var tds = element.FindElements(By.CssSelector("td"));
                    contactCache.Add(new ContactData(tds[2].Text, tds[1].Text) {
                        Id = element.FindElement(By.Name("selected[]")).GetAttribute("value")
                    });
                }
            }
            return new List<ContactData>(contactCache);
        }

        public ContactData GetContactInformationFromTable(int index)
        {
            manager.Navigator.GoToHome();
            IList<IWebElement> cells = driver.FindElements(By.Name("entry"))[index].FindElements(By.TagName("td"));
            string lastName = cells[1].Text;
            string firstName = cells[2].Text;
            string address = cells[3].Text;
            string allPhones = cells[5].Text;
            string allEmails = cells[4].Text;

            return new ContactData(firstName, lastName)
            {
                Address = address,
                AllPhones = allPhones,
                AllEmails = allEmails,
            };
        }

        public ContactData GetContactInformationFromEditForm (int index)
        {
            manager.Navigator.GoToHome();
            InitContactModigication(0);
            string firstName = driver.FindElement(By.Name("firstname")).GetAttribute("value");
            string middleName = driver.FindElement(By.Name("middlename")).GetAttribute("value");
            string lastName = driver.FindElement(By.Name("lastname")).GetAttribute("value");
            string nickName = driver.FindElement(By.Name("nickname")).GetAttribute("value");
            string title = driver.FindElement(By.Name("title")).GetAttribute("value");
            string company = driver.FindElement(By.Name("company")).GetAttribute("value");
            string address = driver.FindElement(By.Name("address")).GetAttribute("value");
            string homePhone = driver.FindElement(By.Name("home")).GetAttribute("value");
            string modilePhone = driver.FindElement(By.Name("mobile")).GetAttribute("value");
            string workPhone = driver.FindElement(By.Name("work")).GetAttribute("value");
            string fax = driver.FindElement(By.Name("fax")).GetAttribute("value");
            string email = driver.FindElement(By.Name("email")).GetAttribute("value");
            string email2 = driver.FindElement(By.Name("email2")).GetAttribute("value");
            string email3 = driver.FindElement(By.Name("email3")).GetAttribute("value");
            string homepage = driver.FindElement(By.Name("homepage")).GetAttribute("value");
            string bday = driver.FindElement(By.Name("bday")).FindElement(By.XPath("option[1]")).Text;
            string bmonth = driver.FindElement(By.Name("bmonth")).FindElement(By.XPath("option[1]")).Text;
            string byear = driver.FindElement(By.Name("byear")).GetAttribute("value");
            string aday = driver.FindElement(By.Name("aday")).FindElement(By.XPath("option[1]")).Text;
            string amonth = driver.FindElement(By.Name("amonth")).FindElement(By.XPath("option[1]")).Text;
            string ayear = driver.FindElement(By.Name("ayear")).GetAttribute("value");
            string address2 = driver.FindElement(By.Name("address2")).GetAttribute("value");
            string phone2 = driver.FindElement(By.Name("phone2")).GetAttribute("value");
            string notes = driver.FindElement(By.Name("notes")).GetAttribute("value");

            return new ContactData(firstName, lastName)
            {
                Firstname = firstName,
                Middlename = middleName,
                Lastname = lastName,
                Nickname = nickName,
                Title = title,
                Companyname = company,
                Address = address,
                Homephone = homePhone,
                Mobilephone = modilePhone,
                Workphone = workPhone,
                Fax = fax,
                Email1 = email,
                Email2 = email2,
                Email3 = email3,
                Homepage = homepage,
                Bday = bday,
                Bmounth = bmonth,
                Byear = byear,
                Aday = aday,
                Amounth = amonth,
                Ayear = ayear,
                Address2 = address2,
                Phone2 = phone2,
                Notes = notes
            };
        }
        public ContactData GetContactInformationFromDetails(int index)
        {
            manager.Navigator.GoToHome();
            InitContactDetails(0);
            string data = GetDetailData();
            return new ContactData(null, null)
            {
                View = data
            };
        }
        private string GetDetailData()
        {
            return driver.FindElement(By.Id("content")).Text;
        }
        public ContactHelper InitContactDetails(int index)
        {
            driver.FindElement(By.XPath("//tr[" + (index + 2) + "]/td[7]/a/img")).Click();
            return this;
        }
    }
}
