using System;
using System.Web.Mvc;
using BusinessManager;
using BusinessObject;
using MyCarService.AppCode;
using MyCarService.Models;

namespace MyCarService.Controllers
{
    [Obsolete]
    public class FeedBackController : Controller
    {
        private static string CreateRandomPassword(int length = 6)
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
            ViewBag.Msg = "";
            ViewBag.Msg = (TempData[Constant.INFO_MESSAGE] ?? string.Empty).ToString();
            TempData[Constant.INFO_MESSAGE] = "";
            ViewBag.TypeCss = "";
            ViewBag.MsgTitle = "";

            FeedBack item = new FeedBack
            {
                Answers = Common.GetAnswers()
            };
            ViewBag.Answer = item.Answers.Count;
            return View(item);
        }

        [HttpPost]
        public ActionResult Index(FeedBack obj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Guid Id = Guid.Empty;
                    _ = Guid.TryParse(obj.Id.ToString(), out Id);
                    if (Id != Guid.Empty)
                    {
                        FeedBack oldobj = FeedBackManager.GetById(Id);
                        if (oldobj != null)
                        {
                            obj = oldobj;
                        }
                    }

                    obj.Id = Guid.NewGuid();
                    //Rating
                    obj.AnswerId = obj.Select;

                    obj.Name = Constant.TextInfo.ToTitleCase(obj.Name);
                    obj.Email = obj.Email;
                    obj.Contact = obj.Contact;
                    obj.Comment = Constant.TextInfo.ToTitleCase(obj.Comment);
                    obj.Location = Constant.TextInfo.ToTitleCase(obj.Location);
                    obj.Extra = "";
                    obj.DateTime = DateTime.Now.AddHours(12).AddMinutes(30).ToString("dd-MM-yyyy");
                    obj.Address = "";
                    obj.CreatedOn = DateTime.Now.AddHours(12).AddMinutes(30);
                    obj.CreatedBy = obj.Name + "," + obj.Email + "," + obj.Contact;
                    obj.UpdatedOn = DateTime.Now.AddHours(12).AddMinutes(30);
                    obj.UpdatedBy = "Vistor";


                    FeedBackManager.Add(obj);

                    TempData[Constant.INFO_MESSAGE] = "Your Comment Has been submit!";

                    FeedBack item1 = new FeedBack
                    {
                        Answers = Common.GetAnswers()
                    };
                    ViewBag.Answer = item1.Answers.Count;

                    return RedirectToAction("Index", new { item1 });
                }
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = "Some thing Error !" + "," + ex;
            }

            FeedBack item = new FeedBack
            {
                Answers = Common.GetAnswers()
            };
            ViewBag.Answer = item.Answers.Count;
            return View(item);
        }

        [Obsolete]
        [Authorize(Roles = "Admin")]
        public ActionResult Review()
        {
            MainModel itemnew = new MainModel
            {
                FeedBackList = FeedBackManager.GetAll()
            };

            return View("", new MainModel { FeedBackList = itemnew.FeedBackList });
        }

        [Authorize(Roles = "Admin")]
        public ActionResult FeedbackResponse()
        {
            ViewBag.FeedBack = "active";
            ViewBag.Msg = "";
            ViewBag.Msg = (TempData[Constant.INFO_MESSAGE] ?? string.Empty).ToString();
            TempData[Constant.INFO_MESSAGE] = "";
            ViewBag.TypeCss = "";
            ViewBag.MsgTitle = "";

            MainModel itemnew = new MainModel
            {
                FeedBackList = FeedBackManager.GetAll()
            };

            return View("", new MainModel { FeedBackList = itemnew.FeedBackList });
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult FeedbackResponse(FormCollection coll)
        {
            ViewBag.FeedBack = "active";
            try
            {
                if (ModelState.IsValid)
                {
                    FeedBack obj = new FeedBack();
                    Guid Id = Guid.Empty;
                    _ = Guid.TryParse(coll["Id"], out Id);
                    if (Id != Guid.Empty)
                    {
                        FeedBack oldobj = FeedBackManager.GetById(Id);
                        if (oldobj != null)
                        {
                            obj = oldobj;
                        }
                    }

                    obj.Id = Guid.NewGuid();
                    //Rating
                    obj.AnswerId = obj.Select;
                    obj.Name = Constant.TextInfo.ToTitleCase(coll["name"]);
                    obj.Email = coll["email"];
                    obj.Contact = coll["contact"];
                    obj.Comment = Constant.TextInfo.ToTitleCase(coll["comment"]);
                    obj.Location = Constant.TextInfo.ToTitleCase(coll["location"]);

                    obj.Extra = "";

                    obj.DateTime = DateTime.Now.AddHours(12).AddMinutes(30).ToString("dd-MM-yyyy");
                    obj.Address = "";
                    obj.CreatedOn = DateTime.Now.AddHours(12).AddMinutes(30);
                    obj.CreatedBy = obj.Name + "," + obj.Email + "," + obj.Contact;
                    obj.UpdatedOn = DateTime.Now.AddHours(12).AddMinutes(30);
                    obj.UpdatedBy = "Vistor";


                    FeedBackManager.Add(obj);

                    TempData[Constant.INFO_MESSAGE] = "Your Comment Has been submit!";

                    FeedBack item1 = new FeedBack
                    {
                        Answers = Common.GetAnswers()
                    };
                    ViewBag.Answer = item1.Answers.Count;

                    return RedirectToAction("FeedbackResponse", new { item1 });
                }
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = "Some thing Error !" + "," + ex;
            }

            FeedBack item = new FeedBack
            {
                Answers = Common.GetAnswers()
            };
            ViewBag.Answer = item.Answers.Count;
            return View(item);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult AddResponse(Guid Id)
        {
            ViewBag.FeedBack = "active";
            MainModel itemnew = new MainModel();


            if (Id != Guid.Empty)
            {
                itemnew.FeedBack = FeedBackManager.GetById(Id);
            }

            return View("~/Views/FeedBack/AddResponse.cshtml", new MainModel { FeedBack = itemnew.FeedBack });
        }

        [Authorize(Roles = "Admin")]
        public ActionResult DeleteFeedBack(Guid Id)
        {
            MainModel itemnew = new MainModel();

            if (Id != Guid.Empty)
            {
                FeedBack obj = FeedBackManager.GetById(Id);
                if (obj != null)
                {
                    FeedBackManager.Delete(obj);

                    ViewBag.Msg = "Record Deleted Successfully.";
                    ViewBag.TypeCss = "success";
                }
                else
                {
                    ViewBag.Msg = "Record Not Deleted.";
                    ViewBag.TypeCss = "info";
                }
            }
            else
            {
                ViewBag.Msg = "Record Not Deleted.";
                ViewBag.TypeCss = "info";
            }

            itemnew.FeedBackList = FeedBackManager.GetAll();

            return PartialView("~/Views/FeedBack/_FeedBackPartail.cshtml", new MainModel { FeedBackList = itemnew.FeedBackList });

        }
    }
}