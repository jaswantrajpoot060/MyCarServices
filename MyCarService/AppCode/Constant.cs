using System;
using System.Collections.Generic;
using System.Web;
using System.IO;
using System.Text.RegularExpressions;
using System.Net.Mail;
using System.Net;
using System.Web.UI.WebControls;
using System.Security.Cryptography;
using System.Text;
using System.Globalization;

namespace MyCarService.AppCode
{
    [Obsolete]
    public class Constant
    {
        public static TextInfo TextInfo = new CultureInfo("en-US", false).TextInfo;

        public static string CreateRandomPassword(int length = 8)
        {
            // Create a string of characters, numbers, special characters that allowed in the password  
            string validChars = "0123456789";
            Random random = new Random();

            // Select one random character at a time from the string  
            // and create an array of chars  
            char[] chars = new char[length];
            for (int i = 0; i < length; i++)
            {
                chars[i] = validChars[random.Next(0, validChars.Length)];
            }
            return new string(chars);
        }

        public static int CalculateAge(DateTime dateOfBirth)
        {
            int age = DateTime.Now.AddHours(12).AddMinutes(30).Year - dateOfBirth.Year;
            if (DateTime.Now.AddHours(12).AddMinutes(30).DayOfYear < dateOfBirth.DayOfYear)
            {
                age--;
            }

            return age;
        }

        public static string CalculateYourAge(DateTime Dob)
        {
            DateTime Now = DateTime.Now.AddHours(12).AddMinutes(30);
            int Years = new DateTime(DateTime.Now.AddHours(12).AddMinutes(30).Subtract(Dob).Ticks).Year - 1;
            DateTime PastYearDate = Dob.AddYears(Years);
            int Months = 0;
            for (int i = 1; i <= 12; i++)
            {
                if (PastYearDate.AddMonths(i) == Now)
                {
                    Months = i;
                    break;
                }
                else if (PastYearDate.AddMonths(i) >= Now)
                {
                    Months = i - 1;
                    break;
                }
            }
            int Days = Now.Subtract(PastYearDate.AddMonths(Months)).Days;
            _ = Now.Subtract(PastYearDate).Hours;
            _ = Now.Subtract(PastYearDate).Minutes;
            _ = Now.Subtract(PastYearDate).Seconds;
            //return String.Format("Age: {0} Year(s) {1} Month(s) {2} Day(s) {3} Hour(s) {4} Second(s)",
            //Years, Months, Days, Hours, Seconds);
            return string.Format("Age: {0} Year {1} Month {2} Day",
                                Years, Months, Days);
        }

        public static List<ListItem> BindPager(int recordCount, int currentPage, int pageSize)
        {
            double dblPageCount = (double)((decimal)recordCount / pageSize);
            int pageCount = (int)Math.Ceiling(dblPageCount);
            List<ListItem> pages = new List<ListItem>();
            if (pageCount > 1)
            {

                if (currentPage > 5)
                {
                    int counnt = 0;
                    pages.Add(new ListItem("Previous", (currentPage - 1).ToString(), currentPage > 1));
                    for (int i = currentPage; i <= pageCount; i++)
                    {
                        pages.Add(new ListItem(i.ToString(), i.ToString(), i != currentPage));
                        counnt++;
                        if (counnt == 5)
                        {
                            break;
                        }
                    }
                    pages.Add(new ListItem("Next", (currentPage + 1).ToString(), currentPage < pageCount));

                }
                else if (currentPage == 1)
                {
                    //pages.Add(new ListItem("Previous", (currentPage - 1).ToString(), currentPage > 1));
                    for (int i = 1; i <= pageCount; i++)
                    {
                        pages.Add(new ListItem(i.ToString(), i.ToString(), i != currentPage));
                        if (i == 5)
                        {
                            break;
                        }
                    }
                    pages.Add(new ListItem("Next", (currentPage + 1).ToString(), currentPage < pageCount));

                }
                else
                {

                    pages.Add(new ListItem("Previous", (currentPage - 1).ToString(), currentPage > 1));
                    for (int i = 1; i <= pageCount; i++)
                    {
                        pages.Add(new ListItem(i.ToString(), i.ToString(), i != currentPage));
                        if (i == 5)
                        {
                            break;
                        }
                    }
                    pages.Add(new ListItem("Next", (currentPage + 1).ToString(), currentPage < pageCount));

                }

            }
            return pages;
        }

        public static List<ListItem> Relation
        {
            get
            {
                List<ListItem> items = new List<ListItem>
                     {
                             new ListItem{ Text="FORWARDER", Value = "FORWARDER" },
                             new ListItem{ Text="CHA", Value = "CHA" },
                             new ListItem{ Text="TRANSPORT", Value = "TRANSPORT" },
                     };
                return items;
            }
        }

        public static string Encrypt(string clearText)
        {
            string EncryptionKey = "MAKV2SPBNI99212";
            byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    clearText = Convert.ToBase64String(ms.ToArray());
                }
            }
            return clearText;
        }

        public static string Decrypt(string cipherText)
        {
            string EncryptionKey = "MAKV2SPBNI99212";
            byte[] cipherBytes = Convert.FromBase64String(cipherText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(cipherBytes, 0, cipherBytes.Length);
                        cs.Close();
                    }
                    cipherText = Encoding.Unicode.GetString(ms.ToArray());
                }
            }
            return cipherText;
        }

        public static List<ListItem> States
        {
            get
            {
                List<ListItem> items = new List<ListItem>
                     {
                             new ListItem{ Text="Select State", Value = "Select State", },
                             new ListItem{ Text="Andhra Pradesh", Value = "Andhra Pradesh" },
                             new ListItem{ Text="Arunachal Pradesh", Value = "Arunachal Pradesh" },
                             new ListItem{ Text="Assam", Value = "Assam" },
                             new ListItem{ Text="Bihar", Value = "Bihar" },
                             new ListItem{ Text="Chhattisgarh", Value = "Chhattisgarh", },
                             new ListItem{ Text="Goa", Value = "Goa" },
                             new ListItem{ Text="Gujarat", Value = "Gujarat" },
                             new ListItem{ Text="Haryana", Value = "Haryana" },
                             new ListItem{ Text="Himachal Pradesh", Value = "Himachal Pradesh" },
                             new ListItem{ Text="Jammu & Kashmir", Value = "Jammu & Kashmir" },
                             new ListItem{ Text="Jharkhand", Value = "Jharkhand" },
                             new ListItem{ Text="Karnataka", Value = "Karnataka" },
                             new ListItem{ Text="Kerala", Value = "Kerala" },
                             new ListItem{ Text="Madhya Pradesh", Value = "Madhya Pradesh" },
                             new ListItem{ Text="Maharashtra", Value = "Maharashtra" },
                             new ListItem{ Text="Manipur", Value = "Manipur" },
                             new ListItem{ Text="Meghalaya", Value = "Meghalaya" },
                             new ListItem{ Text="Mizoram", Value = "Mizoram" },
                             new ListItem{ Text="Nagaland", Value = "Nagaland" },
                             new ListItem{ Text="Odisha", Value = "Odisha" },
                             new ListItem{ Text="Punjab", Value = "Punjab" },
                             new ListItem{ Text="Rajasthan", Value = "Rajasthan" },
                             new ListItem{ Text="Sikkim", Value = "Sikkim" },
                             new ListItem{ Text="Tamil Nadu", Value = "Tamil Nadu" },
                             new ListItem{ Text="Telangana", Value = "Telangana" },
                             new ListItem{ Text="Tripura", Value = "Tripura" },
                             new ListItem{ Text="Uttar Pradesh", Value = "Uttar Pradesh" },
                             new ListItem{ Text="Uttarakhand", Value = "Uttarakhand" },
                             new ListItem{ Text="West Bengal", Value = "West Bengal" },
                     };
                return items;
            }
        }

        public static List<ListItem> ReverseParameter
        {
            get
            {
                List<ListItem> items = new List<ListItem>
                     {
                             new ListItem{ Text="Y", Value = "Y" },
                             new ListItem{ Text="N", Value = "N" },
                     };
                return items;
            }
        }

        public static List<ListItem> Position
        {
            get
            {
                List<ListItem> items = new List<ListItem>
                     {
                             new ListItem{ Text="LEFT", Value = "LEFT" },
                             new ListItem{ Text="RIGHT", Value = "RIGHT" },
                     };
                return items;
            }
        }

        public static List<ListItem> UserRole
        {
            get
            {
                List<ListItem> items = new List<ListItem>
                     {
                             new ListItem{ Text="Admin", Value = "Admin" },
                             new ListItem{ Text="Teacher", Value = "Teacher" },
                             new ListItem{ Text="Student", Value = "Student" },
                             new ListItem{ Text="User", Value = "User" },
                     };
                return items;
            }
        }

        public static List<ListItem> TDSPer
        {
            get
            {
                List<ListItem> items = new List<ListItem>
                     {
                             new ListItem{ Text="1", Value = "1" },
                             new ListItem{ Text="2", Value = "2" },
                             new ListItem{ Text="3", Value = "3" },
                             new ListItem{ Text="4", Value = "4" },
                             new ListItem{ Text="5", Value = "5" },
                             new ListItem{ Text="6", Value = "6" },
                             new ListItem{ Text="7", Value = "7" },
                             new ListItem{ Text="8", Value = "8" },
                             new ListItem{ Text="9", Value = "9" },
                             new ListItem{ Text="10", Value = "10" },
                             new ListItem{ Text="11", Value = "11" },
                             new ListItem{ Text="12", Value = "12" },
                             new ListItem{ Text="13", Value = "13" },
                             new ListItem{ Text="14", Value = "14" },
                             new ListItem{ Text="15", Value = "15" },
                             new ListItem{ Text="16", Value = "16" },
                             new ListItem{ Text="17", Value = "17" },
                             new ListItem{ Text="18", Value = "18" },
                             new ListItem{ Text="19", Value = "19" },
                             new ListItem{ Text="20", Value = "20" },
                     };
                return items;
            }
        }


        public static List<ListItem> City
        {
            get
            {
                List<ListItem> items = new List<ListItem>
                     {
                             new ListItem{ Text="Select City", Value = "Select City", },
                             new ListItem{ Text="Delhi / NCR", Value = "Delhi / NCR" },
                             new ListItem{ Text="Delhi Central", Value = "Delhi Central" },
                             new ListItem{ Text="Delhi Dwarka", Value = "Delhi Dwarka" },
                             new ListItem{ Text="Delhi East", Value = "Delhi East" },
                             new ListItem{ Text="Delhi North", Value = "Delhi North", },
                             new ListItem{ Text="Delhi / NCR", Value = "Delhi" },
                             new ListItem{ Text="Delhi Central", Value = "Delhi South" },
                             new ListItem{ Text="Delhi West", Value = "Delhi West" },
                             new ListItem{ Text="Faridabad", Value = "Faridabad" },
                             new ListItem{ Text="Ghaziabad", Value = "Ghaziabad" },
                             new ListItem{ Text="Greater Noida", Value = "Greater Noida" },
                             new ListItem{ Text="Gurgaon", Value = "Gurgaon" },
                             new ListItem{ Text="Noida", Value = "Noida" },
                             new ListItem{ Text="Mumbai", Value = "Mumbai" },
                             new ListItem{ Text="Mumbai Suburbs", Value = "Mumbai Suburbs" },
                             new ListItem{ Text="Mira Road And Beyond", Value = "Mira Road And Beyond" },
                             new ListItem{ Text="Mumbai Andheri-Dahisar", Value = "Mumbai Andheri-Dahisar" },
                             new ListItem{ Text="Mumbai Beyond Thane", Value = "Mumbai Beyond Thane" },
                             new ListItem{ Text="Mumbai Harbour", Value = "Mumbai Harbour" },
                             new ListItem{ Text="Mumbai Navi", Value = "Mumbai Navi" },
                             new ListItem{ Text="Mumbai", Value = "Mumbai" },
                             new ListItem{ Text="Mumbai", Value = "Mumbai" },
                             new ListItem{ Text="Mumbai South", Value = "Mumbai South" },
                             new ListItem{ Text="Mumbai South West", Value = "Mumbai South West" },
                             new ListItem{ Text="Mumbai Thane", Value = "Mumbai Thane" },
                             new ListItem{ Text="Bangalore", Value = "Bangalore" },
                             new ListItem{ Text="Bangalore Central", Value = "Bangalore Central" },
                             new ListItem{ Text="Bangalore East", Value = "Bangalore East" },
                             new ListItem{ Text="Bangalore North", Value = "Bangalore North" },
                             new ListItem{ Text="Bangalore", Value = "Bangalore" },
                             new ListItem{ Text="Bangalore West", Value = "Bangalore West" },
                             new ListItem{ Text="Bangalore South", Value = "Bangalore South" },
                             new ListItem{ Text="Kolkata", Value = "Kolkata" },
                             new ListItem{ Text="Kolkata Central", Value = "Kolkata Central" },
                             new ListItem{ Text="Kolkata East", Value = "Kolkata East" },
                             new ListItem{ Text="Kolkata North", Value = "Kolkata North" },
                             new ListItem{ Text="Kolkata", Value = "Kolkata" },
                             new ListItem{ Text="Kolkata South", Value = "Kolkata South" },
                             new ListItem{ Text="Kolkata West", Value = "Kolkata West" },
                             new ListItem{ Text="Chennai", Value = "Chennai" },
                             new ListItem{ Text="Chennai Central", Value = "Chennai Central" },
                             new ListItem{ Text="Chennai North", Value = "Chennai North" },
                             new ListItem{ Text="Chennai", Value = "Chennai" },
                             new ListItem{ Text="Chennai South", Value = "Chennai South" },
                             new ListItem{ Text="Chennai West", Value = "Chennai West" },
                             new ListItem{ Text="Hyderabad", Value = "Hyderabad" },
                             new ListItem{ Text="Greater Hyderabad", Value = "Greater Hyderabad" },
                             new ListItem{ Text="Hyderabad", Value = "Hyderabad" },
                             new ListItem{ Text="Hyderabad", Value = "Hyderabad" },
                             new ListItem{ Text="Secunderabad", Value = "Secunderabad" },
                             new ListItem{ Text="Ahmedabad", Value = "Ahmedabad" },
                             new ListItem{ Text="Ahmedabad City & East", Value = "Ahmedabad City & East" },
                             new ListItem{ Text="Ahmedabad", Value = "Ahmedabad" },
                             new ListItem{ Text="SG Highway & Surroundings", Value = "SG Highway & Surroundings" },
                             new ListItem{ Text="Ahmedabad West", Value = "Ahmedabad West" },
                             new ListItem{ Text="Gandhinagar & Sabarmati", Value = "Gandhinagar & Sabarmati" },
                             new ListItem{ Text="Pune", Value = "Pune" },
                             new ListItem{ Text="Coimbatore", Value = "Coimbatore" },
                             new ListItem{ Text="Other Hotspots", Value = "Other Hotspots" },
                             new ListItem{ Text="Bhopal", Value = "Bhopal" },
                             new ListItem{ Text="Bhubaneswar", Value = "Bhubaneswar" },
                             new ListItem{ Text="Chandigarh", Value = "Chandigarh" },
                             new ListItem{ Text="Dehradun", Value = "Dehradun" },
                             new ListItem{ Text="Goa", Value = "Goa" },
                             new ListItem{ Text="Guwahati", Value = "Guwahati" },
                             new ListItem{ Text="Indore", Value = "Indore" },
                             new ListItem{ Text="Jaipur", Value = "Jaipur" },
                             new ListItem{ Text="Kochi", Value = "Kochi" },
                             new ListItem{ Text="Lucknow", Value = "Lucknow" },
                             new ListItem{ Text="Ludhiana", Value = "Ludhiana" },
                             new ListItem{ Text="Mangalore", Value = "Mangalore" },
                             new ListItem{ Text="Mysore", Value = "Mysore" },
                             new ListItem{ Text="Nagpur", Value = "Nagpur" },
                             new ListItem{ Text="Nasik", Value = "Nasik" },
                             new ListItem{ Text="Surat", Value = "Surat" },
                             new ListItem{ Text="Vishakhapatnam", Value = "Vishakhapatnam" },
                             new ListItem{ Text="Andhra Pradesh", Value = "Andhra Pradesh" },
                             new ListItem{ Text="East Godavari", Value = "East Godavari" },
                             new ListItem{ Text="Anantapur", Value = "Anantapur" },
                             new ListItem{ Text="Guntakal", Value = "Guntakal" },
                             new ListItem{ Text="Guntur", Value = "Guntur" },
                             new ListItem{ Text="Kakinada", Value = "Kakinada" },
                             new ListItem{ Text="Kammam", Value = "Kammam" },
                             new ListItem{ Text="Karimnagar", Value = "Karimnagar" },
                             new ListItem{ Text="Kurnool", Value = "Kurnool" },
                             new ListItem{ Text="Dadri", Value = "Dadri" },
                             new ListItem{ Text="Mahabubnagar", Value = "Mahabubnagar" },
                             new ListItem{ Text="Nalgonda", Value = "Nalgonda" },
                             new ListItem{ Text="Nellore", Value = "Nellore" },
                             new ListItem{ Text="Nizamabad", Value = "Nizamabad" },
                             new ListItem{ Text="Ongole", Value = "Ongole" },
                             new ListItem{ Text="Prakasham", Value = "Prakasham" },
                             new ListItem{ Text="Razahmundry", Value = "Razahmundry" },
                             new ListItem{ Text="Secunderabad", Value = "Secunderabad" },
                             new ListItem{ Text="Srikakulam", Value = "Srikakulam" },
                             new ListItem{ Text="Tirupati", Value = "Tirupati" },
                             new ListItem{ Text="Vijayawada", Value = "Vijayawada" },
                             new ListItem{ Text="Vishakhapatnam", Value = "Vishakhapatnam" },
                             new ListItem{ Text="Vizianagaram", Value = "Vizianagaram" },
                             new ListItem{ Text="Warangal", Value = "Warangal" },
                             new ListItem{ Text="Andhra Pradesh", Value = "Andhra Pradesh" },
                             new ListItem{ Text="Itanagar", Value = "Itanagar" },
                             new ListItem{ Text="Arunachal Pradesh", Value = "Arunachal Pradesh" },
                             new ListItem{ Text="Assam", Value = "Assam" },
                             new ListItem{ Text="Guwahati", Value = "Guwahati" },
                             new ListItem{ Text="Silchar", Value = "Silchar" },
                             new ListItem{ Text="Assam", Value = "Assam" },
                             new ListItem{ Text="Bihar", Value = "Bihar" },
                             new ListItem{ Text="Bhagalpur", Value = "Bhagalpur" },
                             new ListItem{ Text="Darbhanga", Value = "Darbhanga" },
                             new ListItem{ Text="Madhubani", Value = "Madhubani" },
                             new ListItem{ Text="Muzaffarpur", Value = "Muzaffarpur" },
                             new ListItem{ Text="Patna", Value = "Patna" },
                             new ListItem{ Text="Bihar", Value = "Bihar" },
                             new ListItem{ Text="Chattisgarh", Value = "Chattisgarh" },
                             new ListItem{ Text="Bhillai", Value = "Bhillai" },
                             new ListItem{ Text="Bilaspur", Value = "Bilaspur" },
                             new ListItem{ Text="Jagdalpur", Value = "Jagdalpur" },
                             new ListItem{ Text="Raipur", Value = "Raipur" },
                             new ListItem{ Text="Simga", Value = "Simga" },
                             new ListItem{ Text="Chattisgarh", Value = "Chattisgarh" },
                             new ListItem{ Text="Goa", Value = "Goa" },
                             new ListItem{ Text="North Goa", Value = "North Goa" },
                             new ListItem{ Text="South Goa<", Value = "South Goa" },
                             new ListItem{ Text="Margao", Value = "Margao" },
                             new ListItem{ Text="Panaji", Value = "Panaji" },
                             new ListItem{ Text="Panjim", Value = "Panjim" },
                             new ListItem{ Text="Vasco Da Gama", Value = "Vasco Da Gama" },
                             new ListItem{ Text="Goa", Value = "Goa" },
                             new ListItem{ Text="Gujarat", Value = "Gujarat" },
                             new ListItem{ Text="Anand", Value = "Anand" },
                             new ListItem{ Text="Anjar", Value = "Anjar" },
                             new ListItem{ Text="Bharuch", Value = "Bharuch" },
                             new ListItem{ Text="Bhavnagar", Value = "Bhavnagar" },
                             new ListItem{ Text="Bhuj", Value = "Bhuj" },
                             new ListItem{ Text="Gandhidham", Value = "Gandhidham" },
                             new ListItem{ Text="Gandhinagar", Value = "Gandhinagar" },
                             new ListItem{ Text="Gir", Value = "Gir" },
                             new ListItem{ Text="Jamnagar", Value = "Jamnagar" },
                             new ListItem{ Text="Junagadh", Value = "Junagadh" },
                             new ListItem{ Text="Kandla", Value = "Kandla" },
                             new ListItem{ Text="Navsari", Value = "Navsari" },
                             new ListItem{ Text="Kandla", Value = "Kandla" },
                             new ListItem{ Text="Navsari", Value = "Navsari" },
                             new ListItem{ Text="Palanpur", Value = "Palanpur" },
                             new ListItem{ Text="Porbandar", Value = "Porbandar" },
                             new ListItem{ Text="Radhanpur", Value = "Radhanpur" },
                             new ListItem{ Text="Surat", Value = "Surat" },
                             new ListItem{ Text="Vadodara", Value = "Vadodara" },
                             new ListItem{ Text="Vapi", Value = "Vapi" },
                             new ListItem{ Text="Gujarat", Value = "Gujarat" },
                             new ListItem{ Text="Haryana", Value = "Haryana" },
                             new ListItem{ Text="Ambala", Value = "Ambala" },
                             new ListItem{ Text="Bahadurgarh", Value = "Bahadurgarh" },
                             new ListItem{ Text="Faridabad", Value = "Faridabad" },
                             new ListItem{ Text="Dharuhera", Value = "Dharuhera" },
                             new ListItem{ Text="Gurgaon", Value = "Gurgaon" },
                             new ListItem{ Text="Hissar", Value = "Hissar" },
                             new ListItem{ Text="Karnal", Value = "Karnal" },
                             new ListItem{ Text="Jhajjar", Value = "Jhajjar" },
                             new ListItem{ Text="Kurukshetra", Value = "Kurukshetra" },
                             new ListItem{ Text="Panchkula", Value = "Panchkula" },
                             new ListItem{ Text="Palwal", Value = "Palwal" },
                             new ListItem{ Text="Panipat", Value = "Panipat" },
                             new ListItem{ Text="Rewari", Value = "Rewari" },
                             new ListItem{ Text="Rohtak", Value = "Rohtak" },
                             new ListItem{ Text="Sonipat", Value = "Sonipat" },
                             new ListItem{ Text="Haryana", Value = "Haryana" },
                             new ListItem{ Text="Himachal Pradesh", Value = "Himachal Pradesh" },
                             new ListItem{ Text="Baddi", Value = "Baddi" },
                             new ListItem{ Text="Dalhousie", Value = "Dalhousie" },
                             new ListItem{ Text="Dharamsala", Value = "Dharamsala" },
                             new ListItem{ Text="Kulu/Manali", Value = "Kulu/Manali" },
                             new ListItem{ Text="Shimla", Value = "Shimla" },
                             new ListItem{ Text="Solan", Value = "Solan" },
                             new ListItem{ Text="Himachal Pradesh", Value = "Himachal Pradesh" },
                             new ListItem{ Text="Jammu & Kashmir", Value = "Jammu & Kashmir" },
                             new ListItem{ Text="Jammu", Value = "Jammu" },
                             new ListItem{ Text="Srinagar", Value = "Srinagar" },
                             new ListItem{ Text="Jammu & Kashmir", Value = "Jammu & Kashmir" },
                             new ListItem{ Text="Jharkhand", Value = "Jharkhand" },
                             new ListItem{ Text="Bokaro", Value = "Bokaro" },
                             new ListItem{ Text="Dhanbad", Value = "Dhanbad" },
                             new ListItem{ Text="Jamshedpur", Value = "Jamshedpur" },
                             new ListItem{ Text="Ranchi", Value = "Ranchi" },
                             new ListItem{ Text="Jharkhand", Value = "Jharkhand" },
                             new ListItem{ Text="Karnataka", Value = "Karnataka" },
                             new ListItem{ Text="Belgaum", Value = "Belgaum" },
                             new ListItem{ Text="Bellary", Value = "Bellary" },
                             new ListItem{ Text="Bidar", Value = "Bidar" },
                             new ListItem{ Text="Chikamagalur", Value = "Chikamagalur" },
                             new ListItem{ Text="Chikamagalur", Value = "Chikamagalur" },
                             new ListItem{ Text="Coorg / Madikeri", Value = "Coorg / Madikeri" },
                             new ListItem{ Text="Dharwad", Value = "Dharwad" },
                             new ListItem{ Text="Gulbarga", Value = "Gulbarga" },
                             new ListItem{ Text="Hubli", Value = "Hubli" },
                             new ListItem{ Text="Karwar", Value = "Karwar" },
                             new ListItem{ Text="Kolar", Value = "Kolar" },
                             new ListItem{ Text="Mangalore", Value = "Mangalore" },
                             new ListItem{ Text="Mysore", Value = "Mysore" },
                             new ListItem{ Text="Sakaleshpur", Value = "Sakaleshpur" },
                             new ListItem{ Text="Tumkur", Value = "Tumkur" },
                             new ListItem{ Text="Karnataka", Value = "Karnataka" },
                             new ListItem{ Text="Kerala", Value = "Kerala" },
                             new ListItem{ Text="Alappuzha", Value = "Alappuzha" },
                             new ListItem{ Text="Calicut", Value = "Calicut" },
                             new ListItem{ Text="Ernakulam", Value = "Ernakulam" },
                             new ListItem{ Text="Idukki", Value = "Idukki" },
                             new ListItem{ Text="Irinjalakuda", Value = "Irinjalakuda" },
                             new ListItem{ Text="Kannur", Value = "Kannur" },
                             new ListItem{ Text="Kasargod", Value = "Kasargod" },
                             new ListItem{ Text="Kochi", Value = "Kochi" },
                             new ListItem{ Text="Kollam", Value = "Kollam" },
                             new ListItem{ Text="Kottayam", Value = "Kottayam" },
                             new ListItem{ Text="Palakkad", Value = "Palakkad" },
                             new ListItem{ Text="Palakkad", Value = "Palakkad" },
                             new ListItem{ Text="Palghat", Value = "Palghat" },
                             new ListItem{ Text="Thrissur", Value = "Thrissur" },
                             new ListItem{ Text="Trivandrum", Value = "Trivandrum" },
                             new ListItem{ Text="Wayanad", Value = "Wayanad" },
                             new ListItem{ Text="Kerala", Value = "Kerala" },
                             new ListItem{ Text="Madhya Pradesh", Value = "Madhya Pradesh" },
                             new ListItem{ Text="Bhopal", Value = "Bhopal" },
                             new ListItem{ Text="Damoh", Value = "Damoh" },
                             new ListItem{ Text="Gwalior", Value = "Gwalior" },
                             new ListItem{ Text="Indore", Value = "Indore" },
                             new ListItem{ Text="Jabalpur", Value = "Jabalpur" },
                             new ListItem{ Text="Khajuraho", Value = "Khajuraho" },
                             new ListItem{ Text="Ujjain", Value = "Ujjain" },
                             new ListItem{ Text="Madhya Pradesh", Value = "Madhya Pradesh" },
                             new ListItem{ Text="Maharashtra", Value = "Maharashtra" },
                             new ListItem{ Text="Ahmednagar", Value = "Ahmednagar" },
                             new ListItem{ Text="Aurangabad", Value = "Aurangabad" },
                             new ListItem{ Text="Dapoli", Value = "Dapoli" },
                             new ListItem{ Text="Dhulia", Value = "Dhulia" },
                             new ListItem{ Text="Jalgaon", Value = "Jalgaon" },
                             new ListItem{ Text="Karjat", Value = "Karjat" },
                             new ListItem{ Text="Kasara", Value = "Kasara" },
                             new ListItem{ Text="Khardi", Value = "Khardi" },
                             new ListItem{ Text="Kolad", Value = "Kolad" },
                             new ListItem{ Text="Kolhapur", Value = "Kolhapur" },
                             new ListItem{ Text="Konkan", Value = "Konkan" },
                             new ListItem{ Text="Lavasa", Value = "Lavasa" },
                             new ListItem{ Text="Lonavala", Value = "Lonavala" },
                             new ListItem{ Text="Nagpur", Value = "Nagpur" },
                             new ListItem{ Text="Nasik", Value = "Nasik" },
                             new ListItem{ Text="Pune", Value = "Pune" },
                             new ListItem{ Text="Ratnagiri", Value = "Ratnagiri" },
                             new ListItem{ Text="Sangli", Value = "Sangli" },
                             new ListItem{ Text="Satara District", Value = "Satara District" },
                             new ListItem{ Text="Sawantwadi", Value = "Sawantwadi" },
                             new ListItem{ Text="Sholapur", Value = "Sholapur" },
                             new ListItem{ Text="Sindhudurg", Value = "Sindhudurg" },
                             new ListItem{ Text="Maharashtra", Value = "Maharashtra" },
                             new ListItem{ Text="Manipur", Value = "Manipur" },
                             new ListItem{ Text="Imphal", Value = "Imphal" },
                             new ListItem{ Text="Manipur", Value = "Manipur" },
                             new ListItem{ Text="Meghalaya", Value = "Meghalaya" },
                             new ListItem{ Text="Shillong", Value = "Shillong" },
                             new ListItem{ Text="Meghalaya", Value = "Meghalaya" },
                             new ListItem{ Text="Mizoram", Value = "Mizoram" },
                             new ListItem{ Text="Aizwal", Value = "Aizwal" },
                             new ListItem{ Text="Mizoram", Value = "Mizoram" },
                             new ListItem{ Text="Nagaland", Value = "Nagaland" },
                             new ListItem{ Text="Dimapur", Value = "Dimapur" },
                             new ListItem{ Text="Nagaland", Value = "Nagaland" },
                             new ListItem{ Text="Angul", Value = "Angul" },
                             new ListItem{ Text="Bhubaneswar", Value = "Bhubaneswar" },
                             new ListItem{ Text="Cuttak", Value = "Cuttak" },
                             new ListItem{ Text="Paradeep", Value = "Paradeep" },
                             new ListItem{ Text="Puri", Value = "Puri" },
                             new ListItem{ Text="Rourkela", Value = "Rourkela" },
                             new ListItem{ Text="Orissa", Value = "Orissa" },
                             new ListItem{ Text="Punjab", Value = "Punjab" },
                             new ListItem{ Text="Amritsar", Value = "Amritsar" },
                             new ListItem{ Text="Bhatinda", Value = "Bhatinda" },
                             new ListItem{ Text="Jalandhar", Value = "Jalandhar" },
                             new ListItem{ Text="Khanna", Value = "Khanna" },
                             new ListItem{ Text="Ludhiana", Value = "Ludhiana" },
                             new ListItem{ Text="Mohali", Value = "Mohali" },
                             new ListItem{ Text="Moga", Value = "Moga" },
                             new ListItem{ Text="Pathankot", Value = "Pathankot" },
                             new ListItem{ Text="Patiala", Value = "Patiala" },
                             new ListItem{ Text="Punjab", Value = "Punjab" },
                             new ListItem{ Text="Rajasthan", Value = "Rajasthan" },
                             new ListItem{ Text="Ajmer", Value = "Ajmer" },
                             new ListItem{ Text="Alwar", Value = "Alwar" },
                             new ListItem{ Text="Barmer", Value = "Barmer" },
                             new ListItem{ Text="Bhilwara", Value = "Bhilwara" },
                             new ListItem{ Text="Bhiwadi", Value = "Bhiwadi" },
                             new ListItem{ Text="Bikaner", Value = "Bikaner" },
                             new ListItem{ Text="Dholpur", Value = "Dholpur" },
                             new ListItem{ Text="Hanumangarh", Value = "Hanumangarh" },
                             new ListItem{ Text="Jaipur", Value = "Jaipur" },
                             new ListItem{ Text="Jaisalmer", Value = "Jaisalmer" },
                             new ListItem{ Text="Jodhpur", Value = "Jodhpur" },
                             new ListItem{ Text="Kota", Value = "Kota" },
                             new ListItem{ Text="Nagaur", Value = "Nagaur" },
                             new ListItem{ Text="Neemrana", Value = "Neemrana" },
                             new ListItem{ Text="Phulera", Value = "Phulera" },
                             new ListItem{ Text="Sikar", Value = "Sikar" },
                             new ListItem{ Text="Sri Ganganagar", Value = "Sri Ganganagar" },
                             new ListItem{ Text="Tonk", Value = "Tonk" },
                             new ListItem{ Text="Udaipur", Value = "Udaipur" },
                             new ListItem{ Text="Rajasthan", Value = "Rajasthan" },
                             new ListItem{ Text="Sikkim", Value = "Sikkim" },
                             new ListItem{ Text="Gangtok", Value = "Gangtok" },
                             new ListItem{ Text="Sikkim", Value = "Sikkim" },
                             new ListItem{ Text="Tamil Nadu", Value = "Tamil Nadu" },
                             new ListItem{ Text="Coimbatore", Value = "Coimbatore" },
                             new ListItem{ Text="Courtallam", Value = "Courtallam" },
                             new ListItem{ Text="Dindigul", Value = "Dindigul" },
                             new ListItem{ Text="Erode", Value = "Erode" },
                             new ListItem{ Text="Hosur", Value = "Hosur" },
                             new ListItem{ Text="Karur", Value = "Karur" },
                             new ListItem{ Text="Kodaikanal", Value = "Kodaikanal" },
                             new ListItem{ Text="Madurai", Value = "Madurai" },
                             new ListItem{ Text="Nagerkoil", Value = "Nagerkoil" },
                             new ListItem{ Text="Nanganallur", Value = "Nanganallur" },
                             new ListItem{ Text="Ooty", Value = "Ooty" },
                             new ListItem{ Text="Palani", Value = "Palani" },
                             new ListItem{ Text="Pollachi", Value = "Pollachi" },
                             new ListItem{ Text="Ranipet", Value = "Ranipet" },
                             new ListItem{ Text="Salem", Value = "Salem" },
                             new ListItem{ Text="Tirunelveli", Value = "Tirunelveli" },
                             new ListItem{ Text="Tirupur", Value = "Tirupur" },
                             new ListItem{ Text="Trichy", Value = "Trichy" },
                             new ListItem{ Text="Vellore", Value = "Vellore" },
                             new ListItem{ Text="Tamil Nadu", Value = "Tamil Nadu" },
                             new ListItem{ Text="Tripura", Value = "Tripura" },
                             new ListItem{ Text="Agartala", Value = "Agartala" },
                             new ListItem{ Text="Tripura", Value = "Tripura" },
                             new ListItem{ Text="Uttar Pradesh", Value = "Uttar Pradesh" },
                             new ListItem{ Text="Agra", Value = "Agra" },
                             new ListItem{ Text="Aligarh", Value = "Aligarh" },
                             new ListItem{ Text="Allahabad", Value = "Allahabad" },
                             new ListItem{ Text="Bagpat", Value = "Bagpat" },
                             new ListItem{ Text="Bareilly", Value = "Bareilly" },
                             new ListItem{ Text="Bulandshahr", Value = "Bulandshahr" },
                             new ListItem{ Text="Faizabad", Value = "Faizabad" },
                             new ListItem{ Text="Ghaziabad", Value = "Ghaziabad" },
                             new ListItem{ Text="Gorakhpur", Value = "Gorakhpur" },
                             new ListItem{ Text="Greater Noida", Value = "Greater Noida" },
                             new ListItem{ Text="Hapur", Value = "Hapur" },
                             new ListItem{ Text="Hathras", Value = "Hathras" },
                             new ListItem{ Text="Kanpur", Value = "Kanpur" },
                             new ListItem{ Text="Lucknow", Value = "Lucknow" },
                             new ListItem{ Text="Mathura", Value = "Mathura" },
                             new ListItem{ Text="Meerut", Value = "Meerut" },
                             new ListItem{ Text="Muzaffar Nagar", Value = "Muzaffar Nagar" },
                             new ListItem{ Text="Noida", Value = "Noida" },
                             new ListItem{ Text="Prabudh Nagar", Value = "SelPrabudh Nagarect" },
                             new ListItem{ Text="Saharanpur", Value = "Saharanpur" },
                             new ListItem{ Text="Varanasi", Value = "Varanasi" },
                             new ListItem{ Text="Vrindavan", Value = "Vrindavan" },
                             new ListItem{ Text="Moradabad", Value = "Moradabad" },
                             new ListItem{ Text="Uttar Pradesh", Value = "Uttar Pradesh" },
                             new ListItem{ Text="Uttarakhand", Value = "Uttarakhand" },
                             new ListItem{ Text="Dehradun", Value = "Dehradun" },
                             new ListItem{ Text="Haldwani", Value = "Haldwani" },
                             new ListItem{ Text="Haridwar", Value = "Haridwar" },
                             new ListItem{ Text="Mukteswar", Value = "Mukteswar" },
                             new ListItem{ Text="Mussoorie", Value = "Mussoorie" },
                             new ListItem{ Text="Nainital", Value = "Nainital" },
                             new ListItem{ Text="Pauri Garhwal", Value = "Pauri Garhwal" },
                             new ListItem{ Text="Ranikhet", Value = "Ranikhet" },
                             new ListItem{ Text="Rishikesh", Value = "Rishikesh" },
                             new ListItem{ Text="Roorkee", Value = "Roorkee" },
                             new ListItem{ Text="Rudrapur", Value = "Rudrapur" },
                             new ListItem{ Text="Uttarakhand", Value = "Uttarakhand" },
                             new ListItem{ Text="West Bengal", Value = "West Bengal" },
                             new ListItem{ Text="Asansol", Value = "Asansol" },
                             new ListItem{ Text="Durgapur", Value = "Durgapur" },
                             new ListItem{ Text="Haldia", Value = "Haldia" },
                             new ListItem{ Text="Howrah", Value = "Howrah" },
                             new ListItem{ Text="Kharagpur", Value = "Kharagpur" },
                             new ListItem{ Text="Midnapore", Value = "Midnapore" },
                             new ListItem{ Text="Shantiniketan", Value = "Shantiniketan" },
                             new ListItem{ Text="Siliguri", Value = "Siliguri" },
                             new ListItem{ Text="West Bengal", Value = "West Bengal" },
                             new ListItem{ Text="Union Territory", Value = "Union Territory" },
                             new ListItem{ Text="Chandigarh", Value = "Chandigarh" },
                             new ListItem{ Text="Dadra & Nagar Haveli", Value = "Dadra & Nagar Haveli" },
                             new ListItem{ Text="Daman & Diu<", Value = "Daman & Diu<" },
                             new ListItem{ Text="Pondicherry", Value = "Pondicherry" },
                             new ListItem{ Text="Andaman & Nicobar", Value = "Andaman & Nicobar" },
                             new ListItem{ Text="Port Blair", Value = "Port Blair" },
                             new ListItem{ Text="Other Cities", Value = "Other Cities" },
                     };
                return items;
            }
        }

        public static List<ListItem> CountList
        {
            get
            {
                List<ListItem> items = new List<ListItem>
                     {
                             new ListItem{ Text="0", Value = "0", },
                             new ListItem{ Text="1", Value = "1" },
                             new ListItem{ Text="2", Value = "2" },
                             new ListItem{ Text="3", Value = "3" },
                             new ListItem{ Text="4", Value = "4" },
                             new ListItem{ Text="5", Value = "5", },
                             new ListItem{ Text="6", Value = "6" },
                             new ListItem{ Text="7", Value = "7" },
                             new ListItem{ Text="8", Value = "8" },
                             new ListItem{ Text="9", Value = "9" },
                     };
                return items;
            }
        }

        public static List<ListItem> LeaveType
        {
            get
            {
                List<ListItem> items = new List<ListItem>
                     {
                             new ListItem{ Text="TODAY", Value = "TODAY", },
                             new ListItem{ Text="DAYS", Value = "DAYS" },
                     };
                return items;
            }
        }

        public static List<ListItem> LeavePeriod
        {
            get
            {
                List<ListItem> items = new List<ListItem>
                     {
                             new ListItem{ Text="FULL DAY", Value = "FULL DAY", },
                             new ListItem{ Text="FIRST HALF", Value = "FIRST HALF" },
                             new ListItem{ Text="SECOND HALF", Value = "SECOND HALF" },
                             new ListItem{ Text="HOURS", Value = "HOURS" },
                     };
                return items;
            }
        }

        public static List<ListItem> LeaveTag
        {
            get
            {
                List<ListItem> items = new List<ListItem>
                     {
                             new ListItem{ Text="PERSONAL", Value = "PERSONAL", },
                             new ListItem{ Text="OFFICIAL", Value = "OFFICIAL" },
                     };
                return items;
            }
        }


        public static List<ListItem> CategoryList
        {
            get
            {
                List<ListItem> items = new List<ListItem>
                     {
                             new ListItem{ Text="Amount", Value = "Amount", },
                             new ListItem{ Text="Income", Value = "Income" },
                             new ListItem{ Text="Payment", Value = "Payment", },
                             new ListItem{ Text="Top Up", Value = "Top Up" },
                             new ListItem{ Text="Withdrawal", Value = "Withdrawal", },
                             new ListItem{ Text="Other", Value = "Other" },
                     };
                return items;
            }
        }
        public static List<ListItem> GenderList
        {
            get
            {
                List<ListItem> items = new List<ListItem>
                     {
                             new ListItem{ Text="Male", Value = "Male", },
                             new ListItem{ Text="Female", Value = "Female" },
                             new ListItem{ Text="Transgender", Value = "Transgender" }
                     };
                return items;
            }
        }

        public static List<ListItem> ReligionList
        {
            get
            {
                List<ListItem> items = new List<ListItem>
                     {
                             new ListItem{ Text="Hindu", Value = "Hindu", },
                             new ListItem{ Text="Muslim", Value = "Muslim" },
                     };
                return items;
            }
        }

        public static List<ListItem> MaritalList
        {
            get
            {
                List<ListItem> items = new List<ListItem>
                     {
                             new ListItem{ Text="Married", Value = "Married", },
                             new ListItem{ Text="Single", Value = "Single" },
                             new ListItem{ Text="Divorced", Value = "Divorced" },
                             new ListItem{ Text="Widowed", Value = "Widowed" },
                     };
                return items;
            }
        }

        public static List<ListItem> EmpCategory
        {
            get
            {
                List<ListItem> items = new List<ListItem>
                     {
                             new ListItem{ Text="ON-ROLE", Value = "ON-ROLE", },
                             new ListItem{ Text="OFF-ROLE", Value = "OFF-ROLE" },
                     };
                return items;
            }
        }

        public static List<ListItem> JobStatus
        {
            get
            {
                List<ListItem> items = new List<ListItem>
                     {
                             new ListItem{ Text="SEEN", Value = "SEEN", },
                             new ListItem{ Text="DISPATCH", Value = "DISPATCH" },
                             new ListItem{ Text="DELIEVERED", Value = "DELIEVERED" },
                     };
                return items;
            }
        }

        public static List<ListItem> AllDepartment
        {
            get
            {
                List<ListItem> items = new List<ListItem>
                     {
                new ListItem{Text="ACCOUNT DEPARTMENT",Value="ACCOUNT DEPARTMENT"},
                new ListItem{Text="ADMINISTRATION OFFICE",Value="ADMINISTRATION OFFICE"},
                new ListItem{Text="BLOCK-B FIRST FLOOR PLATING DEPARTMENT",Value="BLOCK-B FIRST FLOOR PLATING DEPARTMENT"},
                new ListItem{Text="BLOCK-B FIRST FLOOR PACKING DEPARTMENT 207 (NICKEL - CHANDI - BRASS)",Value="BLOCK-B FIRST FLOOR PACKING DEPARTMENT 207 (NICKEL - CHANDI - BRASS)"},
                new ListItem{Text="BLOCK-B IRON - BRASS CHECKING DEPARTMENT",Value="BLOCK-B IRON - BRASS CHECKING DEPARTMENT"},
                new ListItem{Text="BLOCK-C ANTIQUE COLOR DEPARTMENT",Value="BLOCK-C ANTIQUE COLOR DEPARTMENT"},
                new ListItem{Text="BOX DEPARTMENT",Value="BOX DEPARTMENT"},
                new ListItem{Text="BRASS - IRON DEPARTMENT",Value="BRASS - IRON DEPARTMENT"},
                new ListItem{Text="CASH DEPARTMENT",Value="CASH DEPARTMENT"},
                new ListItem{Text="ELECTRIC FITTING DEPARTMENT",Value="ELECTRIC FITTING DEPARTMENT"},
                new ListItem{Text="GATE DEPARTMENT",Value="GATE DEPARTMENT"},
                new ListItem{Text="GENERATOR DEPARTMENT",Value="GENERATOR DEPARTMENT"} ,
                new ListItem{Text="GLASS DEPARTMENT",Value="GLASS DEPARTMENT"},
                new ListItem{Text="GODOWN DEPARTMENT",Value="GODOWN DEPARTMENT"},
                new ListItem{Text="KORA DEPARTMENT",Value="KORA DEPARTMENT"} ,
                new ListItem{Text="KORA A.M.C. DEPARTMENT",Value="KORA A.M.C. DEPARTMENT"} ,
                new ListItem{Text="LAURA ASHLEY DEPARTMENT",Value="LAURA ASHLEY DEPARTMENT"} ,
                new ListItem{Text="KORA",Value="KORA"},
                new ListItem{Text="PLATING",Value="PLATING"},
                new ListItem{Text="SAMPLE DEPARTMENT",Value="SAMPLE DEPARTMENT"} ,
                new ListItem{Text="TAKADA (FIELD) DEPARTMENT",Value="TAKADA (FIELD) DEPARTMENT"} ,
                new ListItem{Text="WIRING AND MATERIAL DEPARTMENT",Value="WIRING AND MATERIAL DEPARTMENT"} ,
                new ListItem{Text="WOOD DEPARTMENT",Value="WOOD DEPARTMENT"} ,
                new ListItem{Text="WOOD (KORA) DEPARTMENT",Value="WOOD (KORA) DEPARTMENT"} ,
                     };
                return items;
            }
        }

        public static List<ListItem> AllMonth
        {
            get
            {
                List<ListItem> items = new List<ListItem>
                     {
                             new ListItem{ Text="Janurary", Value = "Janurary", },
                             new ListItem{ Text="February", Value = "February" },
                             new ListItem{ Text="March", Value = "March" },
                             new ListItem{ Text="April", Value = "April" },
                             new ListItem{ Text="May", Value = "May" },
                             new ListItem{ Text="June", Value = "June" },
                             new ListItem{ Text="July", Value = "July" },
                             new ListItem{ Text="August", Value = "August" },
                             new ListItem{ Text="September", Value = "September" },
                             new ListItem{ Text="October", Value = "October" },
                             new ListItem{ Text="November", Value = "November" },
                             new ListItem{ Text="December", Value = "December" },
                     };
                return items;
            }
        }

        public static List<ListItem> VehicleType
        {
            get
            {
                List<ListItem> items = new List<ListItem>
                     {
                             new ListItem{ Text="TATA 407, 10 FT, 10 C.B.M.", Value = "TATA 407, 10 FT, 10 C.B.M.", },
                             new ListItem{ Text="D.C.M., 14 FT, 14 C.B.M.", Value = "D.C.M., 14 FT, 14 C.B.M." },
                             new ListItem{ Text="L.P.T., 17 FT, 17 C.B.M.", Value = "L.P.T., 17 FT, 17 C.B.M." },
                             new ListItem{ Text="TRUCK, 20 FT, 28 C.B.M.", Value = "TRUCK, 20 FT, 28 C.B.M." },
                             new ListItem{ Text="TRUCK, 40 FT, 65 C.B.M.", Value = "TRUCK, 40 FT, 65 C.B.M." },
                             new ListItem{ Text="TEMPO, 4 C.B.M.", Value = "TEMPO, 4 C.B.M." },
                     };
                return items;
            }
        }

        public static List<ListItem> FinishSuffix
        {
            get
            {
                List<ListItem> items = new List<ListItem>
                     {
                             new ListItem{ Text="G.NO.:", Value = "G.NO.:", },
                             new ListItem{ Text="", Value = "" },
                     };
                return items;
            }
        }

        public static List<ListItem> SheetUnit
        {
            get
            {
                List<ListItem> items = new List<ListItem>
                     {
                             new ListItem{ Text="SHEET", Value = "SHEET", },
                             new ListItem{ Text="PIECES", Value = "PIECES" },
                             new ListItem{ Text="SQUARE INCH", Value = "SQUARE INCH" },
                     };
                return items;
            }
        }

        public static List<string> TypeList()
        {
            List<string> typeList = new List<string>
            {
                "Monthly",
                "Quarterly",
                "Half Yearly",
                "Yearly",
                "OneTime"
            };
            return typeList;
        }
        public static List<string> CommissionTypeList()
        {
            List<string> typeList = new List<string>
            {
                "Direct",
                "Referal"
            };
            return typeList;
        }

        public static List<string> RoleList()
        {
            List<string> typeList = new List<string>
            {
                "Agent",
                "Branch Manager"
            };
            return typeList;
        }

        public static List<string> SheetList()
        {
            List<string> typeList = new List<string>
            {
                "A4",
                "A3",
                "Letter",
                "Legal",
                "Tabloid"
            };
            return typeList;
        }

        public static List<string> FormType()
        {
            List<string> typeList = new List<string>
            {
                "S. D. FORM"
            };
            return typeList;
        }


        public static List<string> RoleType()
        {
            List<string> typeList = new List<string>
            {
                "ADMIN",
                "INSPECTOR",
                "MERCHANT",
                "RECEPTION",
                "USER",
                "MAIN GATE"
            };
            return typeList;
        }

        public static List<string> InspectionStatus()
        {
            List<string> typeList = new List<string>
            {
                "FAIL",
                "PASS"
            };
            return typeList;
        }

        public static List<string> SelectionVolt()
        {
            List<string> typeList = new List<string>
            {
                "5000",
                "6000"
            };
            return typeList;
        }

        public static List<string> ParameterUnit()
        {
            List<string> typeList = new List<string>
            {
                "INCH",
                "CM"
            };
            return typeList;
        }

        public static List<string> PhotoIDList()
        {
            List<string> typeList = new List<string>
            {
                "PAN Card",
                "Passport",
                "Driving Licence",
                "Voter ID Card",
                "Identity Card",
                "Other"
            };
            return typeList;
        }

        public static List<string> AddressProofList()
        {
            List<string> typeList = new List<string>
            {
                "Ration Card",
                "Electricity Bill",
                "Telephone Bill",
                "Voter ID Card",
                "Driving Licence",
                "Other"
            };
            return typeList;
        }

        public static List<string> PaymentOptionList()
        {
            List<string> typeList = new List<string>
            {
                "Cash",
                "Cheque",
                "Draft",
                "Other"
            };
            return typeList;
        }

        public static string GetPassword(int PasswordLength)
        {
            string _allowedChars = "0123456789abcdefghijkmnopqrstuvwxyzABCDEFGHJKLMNOPQRSTUVWXYZ";
            Random randNum = new Random();
            char[] chars = new char[PasswordLength];
            _ = _allowedChars.Length;
            for (int i = 0; i < PasswordLength; i++)
            {
                chars[i] = _allowedChars[(int)(_allowedChars.Length * randNum.NextDouble())];
            }
            return new string(chars);
        }

        public static bool Checkemail(string email)
        {
            // string strPattern = "^([0-9a-zA-Z]([-.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$";
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(email);
            return match.Success;

        }

        public const string VoteUp = "Vote Up";
        public const string VoteDown = "Vote Down";
        public const string ADMINROLE = "Admin";
        public const string USERADMIN = "AdminUser";
        public const string CUSTOMERROLE = "Customer";
        public const string REFERALROLE = "Referal";
        public const string COUNTRY = "INDIA";
        public class GetOriginalImage
        {
            public static string GetFilePath(string Imageurl, string filePath)
            {

                //Log.LogDebug(string.Format("main File path= {0}", filePath));
                if (File.Exists(filePath))
                {
                    FileInfo info = new FileInfo(filePath);
                    string path = "~/SiteImage/";
                    string Updatedfilepath = Path.Combine(path, info.Name);
                    //Log.LogDebug(string.Format("File path= {0}", Updatedfilepath));
                    return Updatedfilepath;
                }
                else
                {
                    return string.Format("~/Images/no-property-image.jpg");
                }
            }
        }
        public static decimal GetSchemeType(string type, int amount, decimal rate)
        {
            decimal op = 0;
            switch (type)
            {
                case "Monthly":
                    op = amount * rate;
                    op /= 100 * 12;
                    break;
                case "Quarterly":
                    op = amount * rate * 3;
                    op /= 100 * 12;
                    break;
                case "Half Yearly":
                    op = amount * rate * 6;
                    op /= 100 * 12;
                    break;
                case "Yearly":
                    op = amount * rate * 12;
                    op /= 100 * 12;
                    break;
                default:
                    break;
            }

            return op;
        }

        public static string INFO_MESSAGE = "InfoMessage";
        public static string ALERT_MESSAGE = "AlertMessage";

        public static string USERNAME = "UserName";
        public static string USER = "User";
        public static string USERID = "UserId";
        public static string ROLE = "Role";
        public const string CHECKROLE = "CheckRole";
        public static string ReturnUrl = "ReturnUrl";

        public static string FullUrl = HttpContext.Current.Request.Url.AbsoluteUri;


        public static string GetFilePath(string filePath)
        {

            //Log.LogDebug(string.Format("main File path= {0}", filePath));

            FileInfo info = new FileInfo(filePath);
            string path = "~/UploadImage/";
            string Updatedfilepath = Path.Combine(path, info.Name);
            //Log.LogDebug(string.Format("File path= {0}", Updatedfilepath));
            return Updatedfilepath;

        }
        public static void DeleteImage(string path, string Image)
        {

            FileInfo info = new FileInfo(Image);

            string Updatedfilepath = Path.Combine(path, info.Name);
            if (File.Exists(Path.GetFullPath(Updatedfilepath)))
            {
                File.Delete(Path.GetFullPath(Updatedfilepath));
            }



            //Log.LogDebug(string.Format("File path= {0}", Updatedfilepath));

        }
        public class Save
        {
            public static string FOLDERNAME = "220x200";
            public static int WIDTH = 220;
            public static int HEIGTH = 200;

            public static string GetFilePath(string imageurl, string filePath)
            {

                //Log.LogDebug(string.Format("main File path= {0}", filePath));
                if (File.Exists(filePath))
                {
                    FileInfo info = new FileInfo(filePath);
                    string path = "~/Logo/";
                    string Updatedfilepath = Path.Combine(path, FOLDERNAME, info.Name);
                    //Log.LogDebug(string.Format("File path= {0}", Updatedfilepath));
                    return Updatedfilepath;
                }
                else
                {
                    return string.Format("~/Images/no-property-image.jpg");
                }
            }
            public static string GetSizeImage(string imageurl, string filePath)
            {

                //Log.LogDebug(string.Format("main File path= {0}", filePath));
                if (File.Exists(filePath))
                {
                    FileInfo info = new FileInfo(filePath);
                    string path = "~/SiteImage/";
                    string Updatedfilepath = Path.Combine(path, FOLDERNAME, info.Name);
                    //Log.LogDebug(string.Format("File path= {0}", Updatedfilepath));
                    return Updatedfilepath;
                }
                else
                {
                    return string.Format("~/Images/no-property-image.jpg");
                }
            }
            public static string GetSizeImageForEmployee(string filePath)
            {

                //Log.LogDebug(string.Format("main File path= {0}", filePath));
                if (File.Exists(filePath))
                {
                    FileInfo info = new FileInfo(filePath);
                    string path = "~/EmployeeImage/";
                    string Updatedfilepath = Path.Combine(path, FOLDERNAME, info.Name);
                    //Log.LogDebug(string.Format("File path= {0}", Updatedfilepath));
                    return Updatedfilepath;
                }
                else
                {
                    return string.Format("~/Images/no-property-image.jpg");
                }
            }
            public static string GetSizeImageForPolicy(string imageurl, string filePath)
            {

                //Log.LogDebug(string.Format("main File path= {0}", filePath));
                if (File.Exists(filePath))
                {
                    FileInfo info = new FileInfo(filePath);
                    string path = "~/policyImage/";
                    string Updatedfilepath = Path.Combine(path, FOLDERNAME, info.Name);
                    //Log.LogDebug(string.Format("File path= {0}", Updatedfilepath));
                    return Updatedfilepath;
                }
                else
                {
                    return string.Format("~/Images/no-property-image.jpg");
                }
            }

            public static string GetSizeImageForPolicyForBond(string filePath)
            {

                //Log.LogDebug(string.Format("main File path= {0}", filePath));
                if (File.Exists(filePath))
                {
                    FileInfo info = new FileInfo(filePath);
                    string path = "http://localhost:53818/PolicyImage/";
                    string Updatedfilepath = Path.Combine(path, info.Name);
                    //Log.LogDebug(string.Format("File path= {0}", Updatedfilepath));
                    return Updatedfilepath;
                }
                else
                {
                    return string.Format("~/Images/no-property-image.jpg");
                }
            }

            public static string GetProductImage(string filePath)
            {

                //Log.LogDebug(string.Format("main File path= {0}", filePath));
                if (File.Exists(filePath))
                {
                    FileInfo info = new FileInfo(filePath);
                    string path = "~/ProducatImage/";
                    string Updatedfilepath = Path.Combine(path, FOLDERNAME, info.Name);
                    //Log.LogDebug(string.Format("File path= {0}", Updatedfilepath));
                    return Updatedfilepath;
                }
                else
                {
                    return string.Format("~/Images/no-property-image.jpg");
                }
            }

            public static void SaveImage(string filePath, string fileName)
            {
                if (File.Exists(filePath))
                {
                    FileInfo info = new FileInfo(filePath);
                    string newFilePath = Path.Combine(info.Directory.FullName, FOLDERNAME);
                    if (!Directory.Exists(newFilePath))
                    {
                        _ = Directory.CreateDirectory(newFilePath);
                    }

                    _ = Path.Combine(newFilePath, fileName);

                    // new WebImage(filePath)
                    //.Resize(WIDTH, HEIGTH, false, true) // Resizing the image to 100x100 px on the fly...
                    //.Crop(1, 1) // Cropping it to remove 1px border at top and left sides (bug in WebImage)
                    //.Save(newFilePath, null, true);
                }
            }

            public static void DeleteImage(string imageurl, string filePath)
            {
                string SMALLFOLDERNAME = "220x200";

                //Log.LogDebug(string.Format("main File path= {0}", filePath));
                if (File.Exists(filePath))
                {
                    FileInfo info = new FileInfo(filePath);
                    string smallfilepath = Path.Combine(imageurl, SMALLFOLDERNAME, info.Name);


                    if (File.Exists(Path.GetFullPath(filePath)))
                    {
                        File.Delete(Path.GetFullPath(filePath));
                    }

                    if (File.Exists(Path.GetFullPath(smallfilepath)))
                    {
                        File.Delete(Path.GetFullPath(smallfilepath));
                    }


                    //Log.LogDebug(string.Format("File path= {0}", Updatedfilepath));

                }

            }
        }

        public static void SendMail(string mailto, string from, string Subject, string body)
        {
            MailAddress MailFrom = new MailAddress(from, "IDBFinancialSolutions.com");
            MailAddress MailTo = new MailAddress(mailto, "");
            MailMessage mailmessage = new MailMessage(MailFrom, MailTo);

            mailmessage.To.Add(mailto);
            mailmessage.Subject = Subject;
            mailmessage.Body = body;
            mailmessage.ReplyTo = new MailAddress(from);
            mailmessage.IsBodyHtml = true;


            string emailsentfrom = "no-reply@idbfinancialsolutions.com";
            string emailsendpassword = "frndufv5";
            NetworkCredential credential = new NetworkCredential(emailsentfrom, emailsendpassword);

            SmtpClient mailClient = new SmtpClient("smtp.idbfinancialsolutions.com", 587)
            {
                EnableSsl = false,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Timeout = 20000,
                Credentials = credential
            };
            mailClient.Send(mailmessage);

        }

        //Number To Words

        private static readonly string[] _ones =
        {
            "zero",
            "one",
            "two",
            "three",
            "four",
            "five",
            "six",
            "seven",
            "eight",
            "nine"
        };

        private static readonly string[] _teens =
        {
            "ten",
            "eleven",
            "twelve",
            "thirteen",
            "fourteen",
            "fifteen",
            "sixteen",
            "seventeen",
            "eighteen",
            "nineteen"
        };

        private static readonly string[] _tens =
        {
            "",
            "ten",
            "twenty",
            "thirty",
            "forty",
            "fifty",
            "sixty",
            "seventy",
            "eighty",
            "ninety"
        };

        // US Nnumbering:
        private static readonly string[] _thousands =
        {
            "",
            "thousand",
            "million",
            "billion",
            "trillion",
            "quadrillion"
        };

        public static string ConvertDecimal(decimal value)
        {
            string digits, temp;
            bool allZeros = true;

            // Use StringBuilder to build result
            StringBuilder builder = new StringBuilder();
            // Convert integer portion of value to string
            digits = ((long)value).ToString();
            // Traverse characters in reverse order
            for (int i = digits.Length - 1; i >= 0; i--)
            {
                int ndigit = digits[i] - '0';
                int column = digits.Length - (i + 1);

                // Determine if ones, tens, or hundreds column
                switch (column % 3)
                {
                    case 0:        // Ones position
                        bool showThousands = true;
                        if (i == 0)
                        {
                            // First digit in number (last in loop)
                            temp = string.Format("{0} ", _ones[ndigit]);
                        }
                        else if (digits[i - 1] == '1')
                        {
                            // This digit is part of "teen" value
                            temp = string.Format("{0} ", _teens[ndigit]);
                            // Skip tens position
                            i--;
                        }
                        else if (ndigit != 0)
                        {
                            // Any non-zero digit
                            temp = string.Format("{0} ", _ones[ndigit]);
                        }
                        else
                        {
                            // This digit is zero. If digit in tens and hundreds
                            // column are also zero, don't show "thousands"
                            temp = string.Empty;
                            // Test for non-zero digit in this grouping
                            showThousands = digits[i - 1] != '0' || (i > 1 && digits[i - 2] != '0');
                        }

                        // Show "thousands" if non-zero in grouping
                        if (showThousands)
                        {
                            if (column > 0)
                            {
                                temp = string.Format("{0}{1}{2}",
                                    temp,
                                    _thousands[column / 3],
                                    allZeros ? " " : ", ");
                            }
                            // Indicate non-zero digit encountered
                            allZeros = false;
                        }
                        _ = builder.Insert(0, temp);
                        break;

                    case 1:        // Tens column
                        if (ndigit > 0)
                        {
                            temp = string.Format("{0}{1}",
                                _tens[ndigit],
                                (digits[i + 1] != '0') ? "-" : " ");
                            _ = builder.Insert(0, temp);
                        }
                        break;

                    case 2:        // Hundreds column
                        if (ndigit > 0)
                        {
                            temp = string.Format("{0} hundred ", _ones[ndigit]);
                            _ = builder.Insert(0, temp);
                        }
                        break;
                    default:
                        break;
                }
            }


            _ = decimal.TryParse(digits, out decimal digi);

            decimal lastdiigi = (value - digi) * 100;
            string updatedigi = lastdiigi.ToString("0");

            _ = int.TryParse(updatedigi, out int newDigi);

            string word = ConvertNumbertoWords(newDigi);
            // Append fractional portion/cents
            if (word != "ZERO")
            {
                _ = builder.AppendFormat("and {0:00}", word);
                // Capitalize first letter
                return string.Format("{0}{1}",
                    char.ToUpper(builder[0]),
                    builder.ToString(1, builder.Length - 1));
            }
            else
            {
                return builder.ToString();
            }
        }

        public static string ConvertNumbertoWords(int number)
        {
            if (number == 0)
            {
                return "ZERO";
            }

            if (number < 0)
            {
                return "minus " + ConvertNumbertoWords(Math.Abs(number));
            }

            string words = "";

            if ((number / 1000000000) > 0)
            {
                words += ConvertNumbertoWords(number / 1000000000) + " Billion ";
                number %= 1000000000;
            }

            if ((number / 10000000) > 0)
            {
                words += ConvertNumbertoWords(number / 10000000) + " Crore ";
                number %= 10000000;
            }

            if ((number / 1000000) > 0)
            {
                words += ConvertNumbertoWords(number / 1000000) + " Million ";
                number %= 1000000;
            }

            if ((number / 100000) > 0)
            {
                words += ConvertNumbertoWords(number / 100000) + " Lacs ";
                number %= 100000;
            }
            if ((number / 1000) > 0)
            {
                words += ConvertNumbertoWords(number / 1000) + " Thousand ";
                number %= 1000;
            }
            if ((number / 100) > 0)
            {
                words += ConvertNumbertoWords(number / 100) + " Hundred ";
                number %= 100;
            }
            if (number > 0)
            {
                if (words != "")
                {
                    words += "and ";
                }

                string[] unitsMap = new[] { "Zero", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Eleven", "Tweleve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen" };
                string[] tensMap = new[] { "Zero", "Ten", "Twenty", "Thirty", "Fourty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety" };

                if (number < 20)
                {
                    words += unitsMap[number];
                }
                else
                {
                    words += tensMap[number / 10];
                    if ((number % 10) > 0)
                    {
                        words += " " + unitsMap[number % 10];
                    }
                }
            }
            return words;
        }

        public static List<ListItem> SupplyList
        {
            get
            {
                List<ListItem> items = new List<ListItem>
                     {
                             new ListItem{ Text="LOCAL", Value = "LOCAL" },
                             new ListItem{ Text="OUT", Value = "OUT" },
                             new ListItem{ Text="BOTH", Value = "BOTH" },
                     };
                return items;
            }
        }
    }
}