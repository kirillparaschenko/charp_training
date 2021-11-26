using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Globalization;
using LinqToDB.Mapping;

namespace WebAddressbookTests
{
    [Table(Name = "addressbook")]
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        private string allPhones;
        private string allEmails;
        public string view;

        public ContactData()
        {
        }

        public ContactData(string firstname, string lastname)
        {
            Firstname = firstname;
            Lastname = lastname;
        }

        public bool Equals(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }
            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }
            return Lastname == other.Lastname && Firstname == other.Firstname;

        }
        public override int GetHashCode()
        {
            return Lastname.GetHashCode() + Firstname.GetHashCode();
        }
        public override string ToString()
        {
            return "lastname= " + Lastname + ", firstname= " + Firstname;
        }

        public int CompareTo(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }
            if (this.Lastname != other.Lastname)
            {
                return Lastname.CompareTo(other.Lastname);
            }
            return Firstname.CompareTo(other.Firstname);
        }

        [Column(Name = "firstname")]
        public string Firstname { get; set; }
        [Column(Name = "middlename")]
        public string Middlename { get; set; }
        [Column(Name = "lastname")]
        public string Lastname { get; set; }
        [Column(Name = "nickname")]
        public string Nickname { get; set; }
        [Column(Name = "title")]
        public string Title { get; set; }
        [Column(Name = "company")]
        public string Companyname { get; set; }
        [Column(Name = "address")]
        public string Address { get; set; }
        [Column(Name = "home")]
        public string Homephone { get; set; }
        [Column(Name = "mobile")]
        public string Mobilephone { get; set; }
        [Column(Name = "work")]
        public string Workphone { get; set; }
        public string AllPhones
        {
            get
            {
                if (allPhones != null)
                {
                    return allPhones;
                }
                else
                {
                    return (CleanUp(Homephone) + CleanUp(Mobilephone) + CleanUp(Workphone)).Trim();
                }
            }
            set
            {
                allPhones = value;
            }
        }

        private string CleanUp(string phone)
        {
            if (phone == null || phone == "")
            {
                return "";
            }
            return phone.Replace(" ","").Replace("-", "").Replace("(", "").Replace(")", "") + "\r\n";
        }

        [Column(Name = "fax")]
        public string Fax { get; set; }
        [Column(Name = "email")]
        public string Email1 { get; set; }
        [Column(Name = "email2")]
        public string Email2 { get; set; }
        [Column(Name = "email3")]
        public string Email3 { get; set; }
        public string AllEmails
        {
            get
            {
                if (allEmails != null)
                {
                    return allEmails;
                }
                else
                {
                    return (NewEmail(Email1) + NewEmail(Email2) + NewEmail(Email3)).Trim();
                }
            }
            set
            {
                allEmails = value;
            }
        }
        private string NewEmail(string email)
        {
            if (email == null || email == "")
            {
                return "";
            }
            return email + "\r\n";
        }
        [Column(Name = "homepage")]
        public string Homepage { get; set; }
        [Column(Name = "bday")]
        public string Bday { get; set; }
        [Column(Name = "bmonth")]
        public string Bmounth { get; set; }
        [Column(Name = "byear")]
        public string Byear { get; set; }
        [Column(Name = "aday")]
        public string Aday { get; set; }
        [Column(Name = "amonth")]
        public string Amounth { get; set; }
        [Column(Name = "ayear")]
        public string Ayear { get; set; }
        [Column(Name = "address2")]
        public string Address2 { get; set; }
        [Column(Name = "phone2")]
        public string Phone2 { get; set; }
        [Column(Name = "notes")]
        public string Notes { get; set; }
        [Column(Name = "id"), PrimaryKey, Identity]
        public string Id { get; set; }
        public string View
        {
            get
            {
                if (view != null)
                {
                    return view;
                }
                else
                {
                    return (NameBlock() + PhoneBlock() + EmailBlock() + DateBlock() + SecondaryBlock()).Trim();
                }
            }
            set
            {
                view = value;
            }
        }
        private string NameBlock()
        {
            string namestr = "";
            if (!String.IsNullOrEmpty(Firstname) || !String.IsNullOrEmpty(Middlename) || !String.IsNullOrEmpty(Lastname))
            {
                string name = "";
                if (!String.IsNullOrEmpty(Firstname))
                    name += Firstname + " ";
                if (!String.IsNullOrEmpty(Middlename))
                    name += Middlename + " ";
                if (!String.IsNullOrEmpty(Lastname))
                    name += Lastname;
                namestr = name.Trim() + "\r\n";
            }
            if (!String.IsNullOrEmpty(Nickname))
                namestr += Nickname + "\r\n";
            if (!String.IsNullOrEmpty(Title))
                namestr += Title + "\r\n";
            if (!String.IsNullOrEmpty(Companyname))
                namestr += Companyname + "\r\n";
            if (!String.IsNullOrEmpty(Address))
                namestr += Address + "\r\n";
            if (namestr != "")
                return namestr + "\r\n";
            return namestr;
        }
        private string PhoneBlock()
        {
            string phonestr = "";
            if (!String.IsNullOrEmpty(Homephone))
                phonestr += "H: " + Homephone + "\r\n";
            if (!String.IsNullOrEmpty(Mobilephone))
                phonestr += "M: " + Mobilephone + "\r\n";
            if (!String.IsNullOrEmpty(Workphone))
                phonestr += "W: " + Workphone + "\r\n";
            if (!String.IsNullOrEmpty(Fax))
                phonestr += "F: " + Fax + "\r\n";
            if (phonestr != "")
                return phonestr + "\r\n";
            return phonestr;
        }
        private string EmailBlock()
        {
            string emailstr = "";
            if (!String.IsNullOrEmpty(Email1))
                emailstr += Email1 + "\r\n";
            if (!String.IsNullOrEmpty(Email2))
                emailstr += Email2 + "\r\n";
            if (!String.IsNullOrEmpty(Email3))
                emailstr += Email3 + "\r\n";
            if (!String.IsNullOrEmpty(Homepage))
                emailstr += "Homepage:\r\n" + Homepage + "\r\n";
            if (emailstr != "")
                return emailstr + "\r\n";
            return emailstr;
        }
        private string DateBlock()
        {
            string datestr = "";
            if ((!String.IsNullOrEmpty(Bday) && Bday != "-") || (!String.IsNullOrEmpty(Bmounth) && Bmounth != "-") || !String.IsNullOrEmpty(Byear))
            {
                string dateData = "";
                dateData += "Birthday ";
                if (!String.IsNullOrEmpty(Bday) && Bday != "-")
                    dateData += Bday + ". ";
                if (!String.IsNullOrEmpty(Bmounth) && Bmounth != "-")
                    dateData += Bmounth + " ";
                if (!String.IsNullOrEmpty(Byear))
                {
                    dateData += Byear + " (" + CalculateYears(Bday, Bmounth, Byear) + ")";
                }
                datestr += dateData.Trim() + "\r\n";
            }
            if ((!String.IsNullOrEmpty(Aday) && Aday != "-") || (!String.IsNullOrEmpty(Amounth) && Amounth != "-") || !String.IsNullOrEmpty(Ayear))
            {
                string dateData = "";
                dateData += "Anniversary ";
                if (!String.IsNullOrEmpty(Aday) && Aday != "-")
                    dateData += Aday + ". ";
                if (!String.IsNullOrEmpty(Amounth) && Amounth != "-")
                    dateData += Amounth + " ";
                if (!String.IsNullOrEmpty(Ayear))
                {
                    dateData += Ayear + " (" + CalculateYears(Aday, Amounth, Ayear) + ")";
                }
                datestr += dateData.Trim() + "\r\n";
            }
            if (datestr != "")
                return datestr + "\r\n";
            return datestr;
        }
        private string SecondaryBlock()
        {
            string secondarystr = "";
            if (!String.IsNullOrEmpty(Address2))
                secondarystr += Address2 + "\r\n\r\n";
            if (!String.IsNullOrEmpty(Phone2))
                secondarystr += "P: " + Phone2 + "\r\n\r\n";
            if (!String.IsNullOrEmpty(Notes))
                secondarystr += Notes;
            return secondarystr.Trim();
        }
        private int CalculateYears(string day, string month, string year)
        {
            if (String.IsNullOrEmpty(day) || day == "-")
                day = "1";
            if (String.IsNullOrEmpty(month) || month == "-")
                month = "January";
            DateTime dt = DateTime.ParseExact(day + " " + month + " " + year, "d MMMM yyyy", CultureInfo.InvariantCulture);
            int YearsPassed = DateTime.Now.Year - dt.Year;
            if (DateTime.Now.Month < dt.Month || (DateTime.Now.Month == dt.Month && DateTime.Now.Day < dt.Day))
            {
                YearsPassed--;
            }
            return YearsPassed;
        }
        public static List<ContactData> GetAll()
        {
            using (AddressBookDB db = new AddressBookDB())
            {
                return (from c in db.Contacts select c).ToList();
            }
        }

    }
}
