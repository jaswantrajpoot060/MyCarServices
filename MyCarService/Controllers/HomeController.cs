using BusinessManager;
using BusinessObject;
using MyCarService.AppCode;
using MyCarService.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DotNetOpenAuth.GoogleOAuth2;
using Microsoft.AspNet.Membership.OpenAuth;
using System.Collections.Specialized;
using System.Web.Security;
using System.Net;
using System.Management;

namespace MyCarService.Controllers
{
    [Obsolete]

    public class HomeController : Controller
    {
        private static string CreateRandomPassword(int length = 8)
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

        public ActionResult Index()
        {
            IPHostEntry ip = Dns.GetHostEntry(Dns.GetHostName());
            string IpAddress = Convert.ToString(ip.AddressList.FirstOrDefault(address => address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork));

            //for macId
            ManagementClass mc = new ManagementClass("Win32_NetworkAdapterConfiguration");
            ManagementObjectCollection moc = mc.GetInstances();
            string MACAddress = string.Empty;
            foreach (ManagementObject mo in moc)
            {
                if (MACAddress == string.Empty)
                {
                    if ((bool)mo["IpEnabled"] == true) MACAddress = mo["MacAddress"].ToString();
                }
                mo.Dispose();
            }
            MACAddress = MACAddress.Replace(":", "-");

            ViewBag.IpAddress = IpAddress;
            ViewBag.MACAddress = MACAddress;

            //ViewBag.IpAddress = GetPublicIp.IP();
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult ApplyNow()
        {
            ViewBag.ApplyUser = "active";

            ViewBag.Msg = "";
            ViewBag.Msg = (TempData[Constant.INFO_MESSAGE] ?? string.Empty).ToString();
            TempData[Constant.INFO_MESSAGE] = "";
            ViewBag.TypeCss = "";
            ViewBag.MsgTitle = "";

            List<Package> PackageList = PackageManager.GetAll();
            ViewBag.Package = new SelectList(PackageList, "Id", "Name");
            ViewBag.Gender = new SelectList(Constant.GenderList, "Text", "Value");

            return View("");

        }

        [HttpPost]
        public ActionResult ApplyNow(ApplyUser obj, HttpPostedFileBase LicenseImg)
        {
            List<Package> PackageList = PackageManager.GetAll();
            ViewBag.ApplyNow = "active";
            try
            {
                obj.RegistrationNo = CreateRandomPassword();
                obj.IsActive = true;
                obj.Extra = "Active";
                obj.TrainingTime = "";
                obj.PackageName = "";
                obj.CreatedOn = obj.UpdatedOn = DateTime.Now.AddHours(12).AddMinutes(30);
                obj.CreatedBy = "ApplyUser";
                obj.UpdatedBy = "Admin";
                _ = ModelState.Remove("Id");
                if (ModelState.IsValid)
                {
                    obj.Id = Guid.NewGuid();

                    Guid PId = Guid.Empty;
                    _ = Guid.TryParse(obj.PackageId.ToString(), out PId);
                    obj.PackageId = PId;

                    obj.Name = Constant.TextInfo.ToTitleCase(obj.Name);
                    obj.Email = obj.Email;
                    obj.Contact = obj.Contact;
                    obj.Gender = Constant.TextInfo.ToTitleCase(obj.Gender);
                    obj.LicenseNumber = obj.LicenseNumber.ToUpper();

                    obj.Dob = obj.Dob;

                    DateTime dob = DateTime.Now.AddHours(12).AddMinutes(30);
                    _ = DateTime.TryParse(obj.Dob, out dob);
                    obj.Age = Constant.CalculateYourAge(dob).ToString();


                    obj.Address = Constant.TextInfo.ToTitleCase(obj.Address);
                    obj.AlternateNo = obj.AlternateNo;

                    #region Student img

                    if (LicenseImg != null)
                    {
                        if (LicenseImg.ContentLength > 0)
                        {
                            string _FileName = Path.GetFileName(LicenseImg.FileName);
                            //string _path = Path.Combine(Server.MapPath("../UserImage/"), _FileName);
                            string NewPath = "/UserImage/";

                            using (Image image = Image.FromStream(LicenseImg.InputStream))
                            {
                                int newWidth = 300;
                                int newHeight = 250;

                                Bitmap thumbnailImg = new Bitmap(newWidth, newHeight);
                                Graphics thumbGraph = Graphics.FromImage(thumbnailImg);
                                thumbGraph.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                                thumbGraph.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                                thumbGraph.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                                Rectangle imageRectangle = new Rectangle(0, 0, newWidth, newHeight);
                                thumbGraph.DrawImage(image, imageRectangle);
                                string targetPath1 = Server.MapPath(NewPath + _FileName);
                                thumbnailImg.Save(targetPath1, image.RawFormat);
                            }
                            //string _FileName = Path.GetFileName(LicenseImg.FileName);
                            //string _path = Path.Combine(Server.MapPath("../UserImage/"), _FileName);
                            //LicenseImg.SaveAs(_path);

                            obj.LicenseImg = "../UserImage/" + _FileName;
                        }
                        else
                        {
                            obj.LicenseImg = "../UserImage/Noimage.png";
                        }
                    }
                    else
                    {
                        obj.LicenseImg = "../UserImage/" + "noimage.png";
                    }
                    #endregion

                    ApplyUserManager.Add(obj);

                    TempData[Constant.INFO_MESSAGE] = "You have Apply Successfully Your Registration Number =" + obj.RegistrationNo;

                    ViewBag.Package = new SelectList(PackageList, "Id", "Name");
                    ViewBag.Gender = new SelectList(Constant.GenderList, "Text", "Value");
                    return RedirectToAction("ApplyNow");
                }
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = "Some thing Error !" + "," + ex;
            }
            ViewBag.Package = new SelectList(PackageList, "Id", "Name");
            ViewBag.Gender = new SelectList(Constant.GenderList, "Text", "Value");
            return View("ApplyNow");
        }

        //get Age
        public JsonResult GetCalculateAge(DateTime Dob)
        {
            JsonResult result = new JsonResult();

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
            string res = string.Format("Age: {0} Year {1} Month {2} Day",
                                Years, Months, Days);
            result.Data = new { success = res };
            return result;
        }

        public ActionResult Contactus()
        {
            ViewBag.Contact = "active";

            return View();
        }

        [HttpPost]
        public ActionResult ContactUs()
        {
            ViewBag.Contact = "active";

            return View();
        }

        public ActionResult Enquiry()
        {
            ViewBag.Enquiry = "active";

            ViewBag.Msg = "";
            ViewBag.Msg = (TempData[Constant.INFO_MESSAGE] ?? string.Empty).ToString();
            TempData[Constant.INFO_MESSAGE] = "";
            ViewBag.TypeCss = "success";
            ViewBag.MsgTitle = "Success!";

            return View("");

        }

        [HttpPost]
        public ActionResult Enquiry(Enquiry obj)
        {
            try
            {
                _ = ModelState.Remove("Id");
                if (ModelState.IsValid)
                {
                    obj.Id = Guid.NewGuid();
                    obj.Name = Constant.TextInfo.ToTitleCase(obj.Name);
                    obj.Email = obj.Email;
                    obj.Mobile = obj.Mobile;
                    obj.Descripation = obj.Descripation;
                    obj.Locaton = obj.Locaton;
                    obj.DateTime = DateTime.Now.AddHours(12).AddMinutes(30);

                    EnquiryManager.Add(obj);

                    TempData[Constant.INFO_MESSAGE] = "Your Enquiry Submit Successfully.";
                    return RedirectToAction("Enquiry");
                }
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = "Some thing Error !" + "," + ex;
            }

            return View();
        }

        public ActionResult Packages()
        {
            MainModel itemnew = new MainModel
            {
                PackageList = PackageManager.GetAll(),
                PImageList = PImageManager.GetAll()
            };

            return View("", new MainModel { PackageList = itemnew.PackageList, PImageList = itemnew.PImageList });
        }

        [HttpPost]
        public ActionResult Subcribe(FormCollection coll)
        {
            MainModel itemnew = new MainModel();

            Subcribes obj = new Subcribes
            {
                Name = Constant.TextInfo.ToTitleCase(coll["name"]),
                Email = coll["email"],
                Mobile = coll["mobile"],
                DateTime = DateTime.Now.AddHours(12).AddMinutes(30),

                Id = Guid.NewGuid()
            };

            List<Subcribes> SubcribesList = SubcribesManager.GetAll().Where(s => s.Email == obj.Email).ToList();
            if (SubcribesList.Count <= 0)
            {
                SubcribesManager.Add(obj);

                ViewBag.Msg = "Record Added Successfully.";
            }
            else
            {
                ViewBag.Msg = "Record Already Exists With this Detail.";
            }

            return RedirectToAction("Index");

        }


        public ActionResult CommentNow(Guid Id)
        {
            MainModel itemnew = new MainModel
            {
                PackageList = PackageManager.GetAll().Where(s => s.Id == Id).ToList(),
                PImageList = PImageManager.GetAll(),
                CommentList = CommentManager.GetByRefId(Id),
                CommentReplyList = CommentReplyManager.GetByRefId(Id),

            };
            ViewBag.PackId = Id;
            return View("", new MainModel { PackageList = itemnew.PackageList, PImageList = itemnew.PImageList, CommentReplyList = itemnew.CommentReplyList, CommentList = itemnew.CommentList });
        }

        public ActionResult SaveComment(FormCollection coll)
        {
            MainModel itemnew = new MainModel();
            try
            {
                Guid Id = Guid.Empty;
                Guid.TryParse(coll["Id"], out Id);
                string sid = Request.Cookies["4465-ae15-003f49a2deff"].Value;
                string[] AllCookie = sid.Split(',');
                Comment obj = new Comment
                {

                    Id = Guid.NewGuid(),
                    RefId = Id,
                    UserId = Guid.Empty,
                    Name = Constant.TextInfo.ToTitleCase(AllCookie[1]),
                    Description = Constant.TextInfo.ToTitleCase(coll["comment"]),
                    Flag = "",
                    Extra1 = AllCookie[2],
                    Extra2 = Constant.TextInfo.ToTitleCase(AllCookie[0]),
                    Status = "",
                    CreatedBy = "",
                    UpdatedBy = "",
                    CreatedOn = DateTime.Now.AddHours(12).AddMinutes(30),
                    UpdatedOn = DateTime.Now.AddHours(12).AddMinutes(30),

                };
                CommentManager.Add(obj);

                itemnew.CommentList = CommentManager.GetByRefId(Id);
                itemnew.CommentReplyList = CommentReplyManager.GetByRefId(Id);
            }
            catch (Exception Ex)
            {
                TempData[Constant.INFO_MESSAGE] = "Somthing Wrong =" + Ex;
            }

            return PartialView("~/Views/Home/_CommentPartail.cshtml", new MainModel { CommentList = itemnew.CommentList, CommentReplyList = itemnew.CommentReplyList });
        }

        public ActionResult SaveCommentReply(Guid RefIdC, string Comment)
        {
            MainModel itemnew = new MainModel();
            try
            {
                string sid = Request.Cookies["4465-ae15-003f49a2deff"].Value;
                string[] AllCookie = sid.Split(',');
                Comment objc = CommentManager.GetById(RefIdC);

                CommentReply obj = new CommentReply
                {
                    Id = Guid.NewGuid(),
                    CommentId = RefIdC, //Comment Id
                    UserId = Guid.Empty,
                    Name = Constant.TextInfo.ToTitleCase(AllCookie[1]),
                    Description = Constant.TextInfo.ToTitleCase(Comment),
                    Flag = "",
                    Extra1 = AllCookie[2],
                    Extra2 = Constant.TextInfo.ToTitleCase(AllCookie[0]),
                    Status = "",
                    CreatedBy = "",
                    UpdatedBy = "",
                    CreatedOn = DateTime.Now.AddHours(12).AddMinutes(30),
                    UpdatedOn = DateTime.Now.AddHours(12).AddMinutes(30),

                };
                if (objc != null)
                    obj.RefId = objc.RefId; //Package Id
                else
                    obj.RefId = Guid.Empty;

                CommentReplyManager.Add(obj);

                itemnew.CommentList = CommentManager.GetByRefId(objc.RefId);
                itemnew.CommentReplyList = CommentReplyManager.GetByRefId(objc.RefId);
            }
            catch (Exception Ex)
            {
                TempData[Constant.INFO_MESSAGE] = "Somthing Wrong =" + Ex;
            }

            return PartialView("~/Views/Home/_CommentPartail.cshtml", new MainModel { CommentList = itemnew.CommentList, CommentReplyList = itemnew.CommentReplyList });
        }

        //Google Login
        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            //Call https://www.google.com/accounts/Logout if you want to logoff at provider
            return Redirect(Url.Action("Packages", "Home"));
        }

        public ActionResult RedirectToGoogle()
        {
            string provider = "google";
            string returnUrl = "";
            return new ExternalLoginResult(provider, Url.Action("ExternalLoginCallback", new { ReturnUrl = returnUrl }));
        }

        [AllowAnonymous]
        public ActionResult ExternalLoginCallback(string returnUrl)
        {
            try
            {
                string ProviderName = OpenAuth.GetProviderNameFromCurrentRequest();

                if (ProviderName == null || ProviderName == "")
                {
                    NameValueCollection nvs = Request.QueryString;
                    if (nvs.Count > 0)
                    {
                        if (nvs["state"] != null)
                        {
                            NameValueCollection provideritem = HttpUtility.ParseQueryString(nvs["state"]);
                            if (provideritem["__provider__"] != null)
                            {
                                ProviderName = provideritem["__provider__"];
                            }
                        }
                    }
                }

                OpenId obj = new OpenId();
                GoogleOAuth2Client.RewriteRequest();

                var redirectUrl = Url.Action("ExternalLoginCallback", new { ReturnUrl = returnUrl });
                var retUrl = returnUrl;
                var authResult = OpenAuth.VerifyAuthentication(redirectUrl);


                //string ProviderDisplayName = OpenAuth.GetProviderDisplayName(ProviderName);

                if (!authResult.IsSuccessful)
                {
                    return Redirect(Url.Action("Login", "Account"));
                }

                // User has logged in with provider successfully
                // Check if user is already registered locally
                //You can call you user data access method to check and create users based on your model
                List<OpenId> OpenIdList = OpenIdManager.Login(authResult.ProviderUserId, authResult.UserName, authResult.ExtraData["email"]);

                if (OpenIdList.Count > 0)
                {
                    Response.Cookies["4465-ae15-003f49a2deff"].Expires = DateTime.Now.AddHours(12).AddMinutes(30).AddDays(-1);

                    HttpCookie RPCookiesNew = new HttpCookie("4465-ae15-003f49a2deff");
                    RPCookiesNew.Value = authResult.ExtraData["email"] + "," + authResult.UserName + "," + authResult.ExtraData["picture"];
                    RPCookiesNew.Expires = DateTime.Now.AddHours(12).AddMinutes(30).AddMonths(2);
                    Response.Cookies.Add(RPCookiesNew);
                    FormsAuthentication.SetAuthCookie(authResult.ExtraData["email"], false);

                    return Redirect(Url.Action("Packages", "Home"));
                }

                //Get provider user details
                string ProviderUserId = authResult.ProviderUserId;
                string ProviderUserName = authResult.UserName;

                string Email = null;
                string pic = null;
                if (Email == null && authResult.ExtraData.ContainsKey("email"))
                {
                    Email = authResult.ExtraData["email"];
                    pic = authResult.ExtraData["picture"];
                }
                if (User.Identity.IsAuthenticated)
                {

                    List<OpenId> OpenIdExistList = OpenIdManager.LoginExist(authResult.Provider, authResult.ProviderUserId, ProviderUserName, Email);
                    if (OpenIdExistList.Count > 0)
                    {
                        Response.Cookies["4465-ae15-003f49a2deff"].Expires = DateTime.Now.AddHours(12).AddMinutes(30).AddDays(-1);

                        HttpCookie RPCookiesNew = new HttpCookie("4465-ae15-003f49a2deff");
                        RPCookiesNew.Value = authResult.ExtraData["email"] + "," + authResult.UserName + "," + authResult.ExtraData["picture"];
                        RPCookiesNew.Expires = DateTime.Now.AddHours(12).AddMinutes(30).AddMonths(2);
                        Response.Cookies.Add(RPCookiesNew);
                        FormsAuthentication.SetAuthCookie(Email, false);

                        return Redirect(Url.Action("Packages", "Home"));
                    }
                    // User is already authenticated, add the external login and redirect to return url
                    //OpenAuth.AddAccountToExistingUser(ProviderName, ProviderUserId, ProviderUserName, User.Identity.Name);
                    //return Redirect(Url.Action("Packages", "Home"));
                }
                else
                {
                    obj.Id = Guid.NewGuid();
                    obj.UserId = Guid.Empty;

                    obj.ResponseId = ProviderUserId; //google provider
                    obj.UserName = ProviderUserName; //google user name
                    obj.UpdatedBy = pic; //google image
                    obj.CreatedBy = Email; //google email
                    obj.Provider = ProviderName; //google provider name
                    obj.LoginDate = DateTime.UtcNow;
                    obj.IsAuthenticated = true;
                    obj.CreatedOn = DateTime.UtcNow;
                    obj.UpdatedOn = DateTime.UtcNow;

                    if (!obj.IsAuthenticated)
                    {
                        ViewBag.Message = "User cannot be created";
                        return View();
                    }
                    OpenIdManager.Add(obj);

                    Response.Cookies["4465-ae15-003f49a2deff"].Expires = DateTime.Now.AddHours(12).AddMinutes(30).AddDays(-1);
                    HttpCookie RPCookies = new HttpCookie("4465-ae15-003f49a2deff")
                    {
                        Value = Email + "," + ProviderUserName + "," + pic,
                        Expires = DateTime.Now.AddHours(12).AddMinutes(30).AddDays(1)
                    };
                    Response.Cookies.Add(RPCookies);
                    FormsAuthentication.SetAuthCookie(Email, false);
                    return Redirect(Url.Action("Packages", "Home"));
                }

                return View();

            }
            catch (Exception Ex)
            {
                ViewBag.Message = "User cannot be created" + Ex;
                return Redirect(Url.Action("Packages", "Home"));
            }
        }

        internal class ExternalLoginResult : ActionResult
        {
            public ExternalLoginResult(string provider, string returnUrl)
            {
                Provider = provider;
                ReturnUrl = returnUrl;
            }

            public string Provider { get; private set; }
            public string ReturnUrl { get; private set; }

            public override void ExecuteResult(ControllerContext context)
            {
                OpenAuth.RequestAuthentication(Provider, ReturnUrl);
            }
        }
    }
}