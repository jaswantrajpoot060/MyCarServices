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

namespace MyCarService.Controllers
{
    [Obsolete]
    [Authorize(Roles = "Admin,User")]
    public class AdminController : Controller
    {

        public ActionResult Index()
        {
            ViewBag.Admin = "active";
            return View();
        }

        //Subcribes
        public ActionResult Subcribes()
        {
            ViewBag.Subcribes = "active";

            MainModel itemnew = new MainModel
            {
                SubcribesList = SubcribesManager.GetAll()
            };

            ViewBag.Msg = "";
            ViewBag.Msg = (TempData[Constant.INFO_MESSAGE] ?? string.Empty).ToString();
            ViewBag.Msg = (TempData[Constant.INFO_MESSAGE] ?? string.Empty).ToString();
            TempData[Constant.INFO_MESSAGE] = "";
            ViewBag.TypeCss = "success";
            ViewBag.MsgTitle = "Success!";

            return View("~/Views/Admin/Subcribes.cshtml", new MainModel { SubcribesList = itemnew.SubcribesList });
        }

        public ActionResult AddSubcribes(Guid Id)
        {
            ViewBag.Subcribes = "active";
            MainModel itemnew = new MainModel();

            if (Id != Guid.Empty)
            {
                itemnew.Subcribes = SubcribesManager.GetById(Id);
            }

            return View("~/Views/Admin/AddSubcribes.cshtml", new MainModel { Subcribes = itemnew.Subcribes });
        }

        [HttpPost]
        public ActionResult Subcribes(FormCollection coll)
        {
            ViewBag.Subcribes = "active";
            MainModel itemnew = new MainModel();

            //Guid Id = Guid.Empty;
            _ = Guid.TryParse(coll["Id"], out Guid Id);

            Subcribes obj = new Subcribes();

            if (Id != Guid.Empty)
            {
                Subcribes oldobj = SubcribesManager.GetById(Id);
                if (oldobj != null)
                {
                    obj = oldobj;
                }
            }

            obj.Name = Constant.TextInfo.ToTitleCase(coll["name"]);
            obj.Email = coll["email"];
            obj.Mobile = coll["mobile"];
            obj.DateTime = DateTime.Now.AddHours(12).AddMinutes(30);

            if (Id != Guid.Empty)
            {
                SubcribesManager.Update(obj);

                TempData[Constant.INFO_MESSAGE] = "Record Updated Successfully";
            }
            else
            {
                obj.Id = Guid.NewGuid();

                List<Subcribes> SubcribesList = SubcribesManager.GetAll().Where(s => s.Name == obj.Name).ToList();
                if (SubcribesList.Count <= 0)
                {
                    SubcribesManager.Add(obj);

                    TempData[Constant.INFO_MESSAGE] = "Record Added Successfully.";
                }
                else
                {
                    TempData[Constant.INFO_MESSAGE] = "Record Already Exists With this Detail.";
                }
            }

            return RedirectToAction("Subcribes");

        }

        public ActionResult DeleteSubcribes(Guid Id)
        {
            ViewBag.Subcribes = "active";
            MainModel itemnew = new MainModel();

            if (Id != Guid.Empty)
            {
                Subcribes obj = SubcribesManager.GetById(Id);
                if (obj != null)
                {
                    SubcribesManager.Delete(obj);

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

            itemnew.SubcribesList = SubcribesManager.GetAll();

            return PartialView("~/Views/Admin/_SubcribesPartail.cshtml", new MainModel { SubcribesList = itemnew.SubcribesList });

        }

        //Enquiry

        public ActionResult Enquiry()
        {
            ViewBag.Enquiry = "active";

            MainModel itemnew = new MainModel
            {
                EnquiryList = EnquiryManager.GetAll()
            };

            ViewBag.Msg = "";
            ViewBag.Msg = (TempData[Constant.INFO_MESSAGE] ?? string.Empty).ToString();
            TempData[Constant.INFO_MESSAGE] = "";
            ViewBag.TypeCss = "success";
            ViewBag.MsgTitle = "Success!";

            return View("~/Views/Admin/Enquiry.cshtml", new MainModel { EnquiryList = itemnew.EnquiryList });
        }

        public ActionResult AddEnquiry(Guid Id)
        {
            ViewBag.Enquiry = "active";

            MainModel itemnew = new MainModel();

            if (Id != Guid.Empty)
            {
                itemnew.Enquiry = EnquiryManager.GetById(Id);
            }

            return View("~/Views/Admin/AddEnquiry.cshtml", new MainModel { Enquiry = itemnew.Enquiry });

        }

        [HttpPost]
        public ActionResult Enquiry(FormCollection coll)
        {
            ViewBag.Enquiry = "active";

            MainModel itemnew = new MainModel();

            //Guid Id = Guid.Empty;
            _ = Guid.TryParse(coll["Id"], out Guid Id);

            Enquiry obj = new Enquiry();

            if (Id != Guid.Empty)
            {
                Enquiry oldobj = EnquiryManager.GetById(Id);
                if (oldobj != null)
                {
                    obj = oldobj;
                }
            }

            obj.Name = Constant.TextInfo.ToTitleCase(coll["name"]);
            obj.Email = coll["email"];
            obj.Mobile = coll["mobile"];
            obj.Descripation = coll["descripation"];
            obj.Locaton = coll["locaton"];
            obj.DateTime = DateTime.Now.AddHours(12).AddMinutes(30);

            if (Id != Guid.Empty)
            {
                EnquiryManager.Update(obj);

                TempData[Constant.INFO_MESSAGE] = "Record Updated Successfully";
            }
            else
            {
                obj.Id = Guid.NewGuid();

                List<Enquiry> EnquiryList = EnquiryManager.GetAll().Where(s => s.Name == obj.Name).ToList();
                if (EnquiryList.Count <= 0)
                {
                    EnquiryManager.Add(obj);

                    TempData[Constant.INFO_MESSAGE] = "Record Added Successfully.";
                }
                else
                {
                    TempData[Constant.INFO_MESSAGE] = "Record Already Exists With this Detail.";
                }
            }

            return RedirectToAction("Enquiry");
        }

        public ActionResult DeleteEnquiry(Guid Id)
        {
            ViewBag.Enquiry = "active";

            MainModel itemnew = new MainModel();

            if (Id != Guid.Empty)
            {
                Enquiry obj = EnquiryManager.GetById(Id);
                if (obj != null)
                {
                    EnquiryManager.Delete(obj);

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

            itemnew.EnquiryList = EnquiryManager.GetAll();

            return PartialView("~/Views/Admin/_EnquiryPartail.cshtml", new MainModel { EnquiryList = itemnew.EnquiryList });
        }

        //Apply Users

        public ActionResult ApplyUser()
        {
            ViewBag.ApplyUser = "active";

            ViewBag.Msg = "";
            ViewBag.Msg = (TempData[Constant.INFO_MESSAGE] ?? string.Empty).ToString();
            TempData[Constant.INFO_MESSAGE] = "";
            ViewBag.TypeCss = "";
            ViewBag.MsgTitle = "";

            MainModel itemnew = new MainModel
            {
                ApplyUserList = ApplyUserManager.GetAll()
            };

            return View("", new MainModel { ApplyUserList = itemnew.ApplyUserList });

        }

        public ActionResult AddApplyUser(Guid Id)
        {
            ViewBag.ApplyUser = "active";
            ViewBag.Msg = "";
            ViewBag.Msg = (TempData[Constant.INFO_MESSAGE] ?? string.Empty).ToString();
            TempData[Constant.INFO_MESSAGE] = "";
            ViewBag.TypeCss = "";
            ViewBag.MsgTitle = "";

            MainModel itemnew = new MainModel();
            List<Package> PackageList = PackageManager.GetAll();

            if (Id != Guid.Empty)
            {
                itemnew.ApplyUser = ApplyUserManager.GetById(Id);
                ViewBag.Package = new SelectList(PackageList, "Id", "Name", itemnew.ApplyUser.PackageId);
                ViewBag.Gender = new SelectList(Constant.GenderList, "Text", "Value", itemnew.ApplyUser.Gender);
            }
            else
            {
                ViewBag.Package = new SelectList(PackageList, "Id", "Name");
                ViewBag.Gender = new SelectList(Constant.GenderList, "Text", "Value");
            }
            itemnew.PaymentList = PaymentManager.GetAll();
            return View("~/Views/Admin/AddApplyUser.cshtml", new MainModel { ApplyUser = itemnew.ApplyUser, PaymentList = itemnew.PaymentList });
        }
        [HttpPost]
        public ActionResult ApplyUser(FormCollection coll, HttpPostedFileBase fileuploadss)
        {
            ViewBag.ApplyUser = "active";
            try
            {
                ApplyUser obj = new ApplyUser();
                //Guid Id = Guid.Empty;
                _ = Guid.TryParse(coll["Id"], out Guid Id);
                if (Id != Guid.Empty)
                {
                    ApplyUser oldobj = ApplyUserManager.GetById(Id);
                    if (oldobj != null)
                    {
                        obj = oldobj;
                    }
                }
                //PACKAGE ID
                Guid PId = Guid.Empty;
                _ = Guid.TryParse(coll["drppackage"], out PId);
                obj.PackageId = PId;

                //Package pobj = PackageManager.GetById(PId);
                //if (pobj != null)
                //   // obj.PackageName = textInfo.ToTitleCase("Package Name=" + pobj.Name + ", " + "Traininer Name" + "= " + pobj.TraininerName + ", " + "Price" + "= " + pobj.Price.ToString("N2"));
                //else
                //    obj.PackageName = "";

                obj.RegistrationNo = Constant.CreateRandomPassword();
                obj.TrainingTime = coll["trainingtime"];
                obj.Name = Constant.TextInfo.ToTitleCase(coll["name"]);
                obj.Email = coll["email"];
                obj.Contact = coll["contact"];
                obj.Gender = coll["drpgender"];
                obj.LicenseNumber = coll["licensenumber"].ToUpper();

                obj.Dob = coll["dob"];

                DateTime dob = DateTime.Now.AddHours(12).AddMinutes(30);
                _ = DateTime.TryParse(coll["dob"], out dob);
                obj.Age = Constant.CalculateYourAge(dob).ToString();

                obj.Address = coll["address"];
                obj.AlternateNo = coll["alternateno"];
                obj.Extra = coll["status"];
                obj.IsActive = true;
                obj.PackageName = "";

                if (Id != Guid.Empty)
                {
                    #region Student img

                    if (fileuploadss != null)
                    {
                        if (fileuploadss.ContentLength > 0)
                        {
                            string _FileName = Path.GetFileName(fileuploadss.FileName);
                            //string _path = Path.Combine(Server.MapPath("../UserImage/"), _FileName);
                            string NewPath = "/UserImage/";

                            using (Image image = Image.FromStream(fileuploadss.InputStream))
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
                            //string _FileName = Path.GetFileName(fileuploadss.FileName);
                            //string _path = Path.Combine(Server.MapPath("../UserImage/"), _FileName);
                            //fileuploadss.SaveAs(_path);

                            obj.LicenseImg = "../UserImage/" + _FileName;
                        }
                        else
                        {
                            obj.LicenseImg = obj.LicenseImg;
                        }
                    }
                    else
                    {
                        obj.LicenseImg = obj.LicenseImg;
                    }
                    #endregion

                    obj.CreatedOn = obj.UpdatedOn = DateTime.Now.AddHours(12).AddMinutes(30);
                    obj.CreatedBy = "ApplyUser";
                    obj.UpdatedBy = "Admin";

                    ApplyUserManager.Update(obj);

                    TempData[Constant.INFO_MESSAGE] = "Record Updated Successfully";
                }
                else
                {
                    obj.Id = Guid.NewGuid();
                    #region Student img

                    if (fileuploadss != null)
                    {
                        if (fileuploadss.ContentLength > 0)
                        {
                            string _FileName = Path.GetFileName(fileuploadss.FileName);
                            //string _path = Path.Combine(Server.MapPath("../UserImage/"), _FileName);
                            string NewPath = "/UserImage/";

                            using (Image image = Image.FromStream(fileuploadss.InputStream))
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
                            //string _FileName = Path.GetFileName(fileuploadss.FileName);
                            //string _path = Path.Combine(Server.MapPath("../UserImage/"), _FileName);
                            //fileuploadss.SaveAs(_path);

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

                    obj.CreatedOn = obj.UpdatedOn = DateTime.Now.AddHours(12).AddMinutes(30);
                    obj.CreatedBy = "ApplyUser";
                    obj.UpdatedBy = "Admin";

                    List<ApplyUser> RegistrationNoList = ApplyUserManager.GetAll().Where(s => s.RegistrationNo == obj.RegistrationNo).ToList();
                    if (RegistrationNoList.Count <= 0)
                    {
                        ApplyUserManager.Add(obj);

                        TempData[Constant.INFO_MESSAGE] = "Record Added Successfully.";
                    }
                    else
                    {
                        TempData[Constant.INFO_MESSAGE] = "Record Already Exists With this Detail.";
                    }
                }

                TempData[Constant.INFO_MESSAGE] = "Your submission Has been submit!";

                return RedirectToAction("ApplyUser");
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = "Some thing Error !" + "," + ex;
            }

            return RedirectToAction("ApplyUser");
        }

        public ActionResult DeleteApplyUser(Guid Id)
        {
            ViewBag.ApplyUser = "active";

            MainModel itemnew = new MainModel();

            if (Id != Guid.Empty)
            {
                ApplyUser obj = ApplyUserManager.GetById(Id);
                if (obj != null)
                {
                    ApplyUserManager.Delete(obj);

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

            itemnew.ApplyUserList = ApplyUserManager.GetAll();

            return PartialView("~/Views/Admin/_ApplyUserPartail.cshtml", new MainModel { ApplyUserList = itemnew.ApplyUserList });
        }

        //Payment
        public ActionResult AddPayment(Guid Id)
        {
            ViewBag.Payment = "active";
            MainModel itemnew = new MainModel();

            if (Id != Guid.Empty)
            {
                itemnew.Payment = PaymentManager.GetById(Id);
            }

            return View("~/Views/Admin/AddPayment.cshtml", new MainModel { Payment = itemnew.Payment });
        }

        public ActionResult DeletePayment(Guid Id)
        {
            ViewBag.Payment = "active";
            MainModel itemnew = new MainModel();

            if (Id != Guid.Empty)
            {
                Payment obj = PaymentManager.GetById(Id);
                if (obj != null)
                {
                    PaymentManager.Delete(obj);

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

            itemnew.PaymentList = PaymentManager.GetAll();

            return PartialView("~/Views/Admin/_PaymentPartail.cshtml", new MainModel { PaymentList = itemnew.PaymentList });
        }
    }
}