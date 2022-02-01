using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using BusinessManager;
using BusinessObject;
using DotNetOpenAuth.OpenId;
using DotNetOpenAuth.OpenId.Extensions.AttributeExchange;
using DotNetOpenAuth.OpenId.RelyingParty;
using MyCarService.AppCode;
using MyCarService.Models;
using Newtonsoft.Json.Linq;

namespace MyCarService.Controllers
{

    [Obsolete]
    [AllowAnonymous]

    public class AccountController : Controller
    {
        public static string connection = ConfigurationSettings.AppSettings["ConnectionInfo"];
        readonly SqlConnection con = new SqlConnection(connection);
        public ActionResult Index()
        {
            return RedirectToAction("Login");
        }

        public ActionResult Login()
        {
            ViewBag.Msg = "";
            ViewBag.Msg = (TempData[Constant.INFO_MESSAGE] ?? string.Empty).ToString();
            TempData[Constant.INFO_MESSAGE] = "";
            ViewBag.TypeCss = "success";
            ViewBag.MsgTitle = "Success!";
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            try
            {
                string role = string.Empty;
                List<Login> LoginList = LoginManager.Login(model.Email, model.Password);
                if (LoginList.Count > 0)
                {
                    FormsAuthentication.SetAuthCookie(model.Email, false);

                    FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, model.Email, DateTime.Now.AddHours(12).AddMinutes(30), DateTime.Now.AddHours(12).AddMinutes(30).AddMinutes(5),
                        false, role);

                    var encrytedTicket = FormsAuthentication.Encrypt(ticket);
                    HttpCookie authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encrytedTicket);
                    HttpContext.Response.Cookies.Add(authCookie);

                    return RedirectToAction("Index", "Admin");
                }

                ModelState.AddModelError("", "Log in details not exist");
                return View(model);
            }
            catch (Exception Ex)
            {
                ViewBag.Error = "Something Else" + Ex;

            }

            return View();
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, "");
            cookie.Expires = DateTime.Now.AddHours(12).AddMinutes(30).AddYears(-1);
            Response.Cookies.Add(cookie);
            return RedirectToAction("Login");
        }

        //FaceBook Login

        public ActionResult FacebookLogin()
        {
            string clientId = ConfigurationManager.AppSettings["AppId"];
            string returnurl = ConfigurationManager.AppSettings["BaseAddress"] + ConfigurationManager.AppSettings["ReturnUrl"];
            string url = string.Format("https://www.facebook.com/dialog/oauth?client_id={0}&redirect_uri={1}&scope=email,read_stream", clientId, returnurl);
            return Redirect(string.Format(url));

        }

        private void FacebookOpenId()
        {
            string code = Request.QueryString["code"];
            string fullUrl = ConfigurationManager.AppSettings["GetAccessTokenUrl"] + "client_id=" + ConfigurationManager.AppSettings["AppId"] + "&redirect_uri=" + ConfigurationManager.AppSettings["BaseAddress"] + ConfigurationManager.AppSettings["ReturnUrl"] + "&client_secret=" + ConfigurationManager.AppSettings["ClientSecret"] + "&code=" + code;
            WebClient client = new WebClient();
            string result = string.Empty;
            try
            {
                result = client.DownloadString(fullUrl);
            }
            catch (WebException)
            {

            }
            if (!string.IsNullOrEmpty(result))
            {
                result = result.Replace("access_token=", string.Empty);
                string accessToken = result.Substring(0, result.IndexOf("&"));
                string graphApiUrl = string.Format(ConfigurationManager.AppSettings["GetResponseUrl"], accessToken);
                try
                {
                    bool response = false;
                    string facebookUserDetails = client.DownloadString(graphApiUrl);
                    if (facebookUserDetails != null)
                    {

                        response = true;
                        JObject jsonObj = JObject.Parse(facebookUserDetails);
                        string UserName = (string)jsonObj["name"];
                        string Email = (string)jsonObj["email"];
                        //TextBox tbFirstName = (TextBox)registerControl.FindControl("tbFirstName");
                        //TextBox tbLastName = (TextBox)registerControl.FindControl("tbLastName");
                        //TextBox tbEmailId = (TextBox)registerControl.FindControl("tbEmail");

                        //tbFirstName.Text = UserName.Split(' ')[0] != null ? UserName.Split(' ')[0] : string.Empty;
                        //tbLastName.Text = UserName.Split(' ')[1] != null ? UserName.Split(' ')[1] : string.Empty;
                        //tbEmailId.Text = Email;
                        OpenId openId = OpenIdManager.GetByResponseId((string)jsonObj["id"]);
                        if (openId != null)
                        {
                            openId.LoginDate = DateTime.UtcNow;
                            openId.UpdatedOn = DateTime.UtcNow;
                            OpenIdManager.Update(openId);
                            if (openId.UserId != Guid.Empty)
                            {
                                Login user = LoginManager.GetById(openId.UserId);
                                if (user != null)
                                {
                                    if (user.IsActive)
                                    {
                                        FormsAuthentication.SetAuthCookie(user.Id.ToString(), false);

                                        if (user.Role == "Admin")
                                        {
                                            Session["Admin"] = user;
                                            Response.Redirect("~/Admin/AdminHome.aspx");
                                        }
                                        else if (user.Role == "Users")
                                        {
                                            Session["User"] = user;
                                            Response.Redirect("IIT-JEE-Products.aspx");
                                        }
                                        else
                                        {

                                            TempData[Constant.INFO_MESSAGE] = "You are not autorize user.";
                                        }
                                    }
                                    else
                                    {
                                        TempData[Constant.INFO_MESSAGE] = "You are not active user .Please contact to admin";

                                    }
                                }

                            }


                        }
                        else
                        {
                            Login user = LoginManager.GetByEmailId(Email);
                            if (user != null)
                            {

                                OpenId openIdNew = new OpenId
                                {
                                    ResponseId = (string)jsonObj["id"],
                                    UserName = Email,
                                    Provider = ConfigurationManager.AppSettings["Provider"],
                                    IsAuthenticated = response,
                                    LoginDate = DateTime.UtcNow
                                };
                                openIdNew.CreatedBy = openIdNew.UpdatedBy = UserName;
                                openIdNew.CreatedOn = openIdNew.UpdatedOn = DateTime.UtcNow;
                                OpenIdManager.Add(openIdNew);

                                if (user.IsActive)
                                {
                                    FormsAuthentication.SetAuthCookie(user.Id.ToString(), false);

                                    if (user.Role == "Login")
                                    {
                                        openIdNew.UserId = user.Id;
                                        OpenIdManager.Update(openIdNew);
                                        Session["User"] = user;
                                        Response.Redirect("IIT-JEE-Products.aspx");
                                    }
                                    else
                                    {

                                        TempData[Constant.INFO_MESSAGE] = "You are not autorize user.";
                                        Response.Redirect("Index.aspx");
                                    }
                                }
                            }
                            else if (user == null)
                            {
                                OpenId openIdNew = new OpenId
                                {
                                    ResponseId = (string)jsonObj["id"],
                                    UserName = Email,
                                    Provider = ConfigurationManager.AppSettings["Provider"],
                                    IsAuthenticated = response,
                                    LoginDate = DateTime.UtcNow
                                };
                                openIdNew.CreatedBy = openIdNew.UpdatedBy = UserName;
                                openIdNew.CreatedOn = openIdNew.UpdatedOn = DateTime.UtcNow;
                                OpenIdManager.Add(openIdNew);
                                user = new Login
                                {
                                    Email = Email
                                };
                                user.CreatedBy = user.UpdatedBy = UserName;
                                user.CreatedOn = user.UpdatedOn = DateTime.UtcNow;
                                user.IsActive = true;
                                user.ContactNo = string.Empty;
                                user.Name = UserName;
                                user.Role = "Login";
                                user.Password = string.Empty;
                                LoginManager.Add(user);
                                openIdNew.UserId = user.Id;
                                OpenIdManager.Update(openIdNew);
                                Session["User"] = user;
                                Response.Redirect("IIT-JEE-Products.aspx");

                            }
                            else
                            {
                                TempData[Constant.INFO_MESSAGE] = "You are not a valid user.Please Sing up OR contact admin";
                                Response.Redirect("Index.aspx");
                            }
                            //Page.ClientScript.RegisterStartupScript(this.GetType(), "show", "$(document).ready(function() {openRegistrationPopUp();});", true);


                        }
                    }
                }
                catch (WebException)
                {

                }
            }
        }

        private void IntegrateUser(IAuthenticationResponse authenticationResponse)
        {

            string UserName = string.Empty;
            string email = string.Empty;
            bool status = true;
            _ = new OpenId();
            if (authenticationResponse.Status != AuthenticationStatus.Authenticated)
            {

                TempData[Constant.INFO_MESSAGE] = "Failed to associate your account with google.";

                return;
            }
            FetchResponse fetch = authenticationResponse.GetExtension<FetchResponse>();
            if (fetch != null)
            {
                IList<string> emailAddresses = fetch.Attributes[WellKnownAttributes.Contact.Email].Values;
                email = emailAddresses[0];
                IList<string> Fname = fetch.Attributes[WellKnownAttributes.Name.First].Values;
                IList<string> Lname = fetch.Attributes[WellKnownAttributes.Name.Last].Values;
                UserName = string.Format("{0} {1}", Fname[0], Lname[0]);
                UserName = UserName.ToUpper();
                Session["Email"] = email;
            }

            Identifier identifier = authenticationResponse.ClaimedIdentifier;
            UriIdentifier uriIdentifier = (UriIdentifier)identifier;
            Uri uri = uriIdentifier;
            string responseid = uri.AbsoluteUri.Contains("wordpress") || uri.AbsoluteUri.Contains("myopenid") ? uri.AbsoluteUri : uri.PathAndQuery;
            OpenId openId = OpenIdManager.GetByResponseId(responseid);
            if (openId != null)
            {
                openId.LoginDate = DateTime.UtcNow;
                openId.UpdatedOn = DateTime.UtcNow;
                OpenIdManager.Update(openId);
                if (openId.UserId != default && openId.UserId != null)
                {
                    Login user = LoginManager.GetById(openId.UserId);
                    if (user != null)
                    {
                        if (user.IsActive)
                        {
                            FormsAuthentication.SetAuthCookie(user.Id.ToString(), false);

                            if (user.Role == "Admin")
                            {
                                Session["Admin"] = user;
                                Response.Redirect("~/Admin/AdminHome.aspx");
                            }
                            else if (user.Role == "Login")
                            {
                                Session["User"] = user;
                                Response.Redirect("IIT-JEE-Products.aspx");
                            }
                            else
                            {

                                TempData[Constant.INFO_MESSAGE] = "You are not autorize user.";
                                Response.Redirect("Index.aspx");
                            }
                        }
                    }
                    else
                    {

                        TempData[Constant.INFO_MESSAGE] = "You are not autorize user.";
                        Response.Redirect("Index.aspx");
                    }
                }
                else
                {
                    AddUserDetail(uri, UserName, status, email);
                }
            }
            else
            {
                AddUserDetail(uri, UserName, status, email);
            }
        }

        private void AddUserDetail(Uri uri, string username, bool response, string email)
        {
            Login user = LoginManager.GetByEmailId(email);
            if (user != null)
            {
                OpenId openId = new OpenId
                {
                    ResponseId = uri.AbsoluteUri.Contains("wordpress") || uri.AbsoluteUri.Contains("myopenid") ? uri.AbsoluteUri : uri.PathAndQuery,
                    UserName = email,
                    Provider = uri.Host,
                    IsAuthenticated = response,
                    LoginDate = DateTime.UtcNow
                };
                openId.CreatedBy = openId.UpdatedBy = username;
                openId.CreatedOn = openId.UpdatedOn = DateTime.UtcNow;
                openId.UserId = user.Id;
                OpenIdManager.Add(openId);
                if (user.IsActive)
                {
                    FormsAuthentication.SetAuthCookie(user.Id.ToString(), false);
                    if (user.Role == "Login")
                    {
                        Session["User"] = user;
                        Response.Redirect("IIT-JEE-Products.aspx");
                    }
                    else
                    {

                        TempData[Constant.INFO_MESSAGE] = "You are not autorize user.";
                        Response.Redirect("Index.aspx");
                    }
                }


            }
            else if (user == null)
            {
                OpenId openId = new OpenId
                {
                    ResponseId = uri.AbsoluteUri.Contains("wordpress") || uri.AbsoluteUri.Contains("myopenid") ? uri.AbsoluteUri : uri.PathAndQuery,

                    UserName = email,
                    Provider = uri.Host,
                    IsAuthenticated = response,
                    LoginDate = DateTime.UtcNow
                };
                openId.CreatedBy = openId.UpdatedBy = username;
                openId.CreatedOn = openId.UpdatedOn = DateTime.UtcNow;
                OpenIdManager.Add(openId);

                user = new Login
                {
                    Email = email
                };
                user.CreatedBy = user.UpdatedBy = username;
                user.CreatedOn = user.UpdatedOn = DateTime.UtcNow;
                user.IsActive = true;
                user.ContactNo = string.Empty;
                user.Name = username;
                user.Role = "Login";
                user.Password = string.Empty;
                LoginManager.Add(user);
                openId.UserId = user.Id;
                OpenIdManager.Update(openId);
                Session["User"] = user;
                Response.Redirect("IIT-JEE-Products.aspx");

            }
        }

    }
}