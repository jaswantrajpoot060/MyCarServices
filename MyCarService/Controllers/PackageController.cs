using BusinessManager;
using BusinessObject;
using MyCarService.AppCode;
using MyCarService.Models;
using System;
using System.Drawing;
using System.IO;
using System.Web;
using System.Web.Mvc;

namespace MyCarService.Controllers
{
    [Obsolete]
    [Authorize(Roles = "Admin")]
    public class PackageController : Controller
    {

        public ActionResult Index()
        {
            ViewBag.Package = "active";
            MainModel itemnew = new MainModel
            {
                PackageList = PackageManager.GetAll()
            };

            ViewBag.Msg = "";
            ViewBag.Msg = (TempData[Constant.INFO_MESSAGE] ?? string.Empty).ToString();
            TempData[Constant.INFO_MESSAGE] = "";
            ViewBag.TypeCss = "success";
            ViewBag.MsgTitle = "Success!";

            return View("", new MainModel { PackageList = itemnew.PackageList });
        }

        public ActionResult AddPackage(Guid Id)
        {
            ViewBag.Package = "active";
            ViewBag.AddPackage = "active";

            MainModel itemnew = new MainModel();

            if (Id != Guid.Empty)
            {
                itemnew.Package = PackageManager.GetById(Id);
            }

            return View("~/Views/Package/AddPackage.cshtml", new MainModel { Package = itemnew.Package });

        }

        [HttpPost]
        public ActionResult Index(FormCollection coll)
        {
            //Guid Id = Guid.Empty;
            _ = Guid.TryParse(coll["Id"], out Guid Id);

            Package obj = new Package();
            if (Id != Guid.Empty)
            {
                Package Oldobj = PackageManager.GetById(Id);
                if (Oldobj != null)
                {
                    obj = Oldobj;
                }
            }

            obj.Name = Constant.TextInfo.ToTitleCase(coll["name"]);

            _ = decimal.TryParse(coll["price"], out decimal VarAD);
            obj.Price = VarAD;

            obj.Duration = Constant.TextInfo.ToTitleCase(coll["duration"]);

            obj.TraininerName = Constant.TextInfo.ToTitleCase(coll["traininername"]);
            obj.Discription = Constant.TextInfo.ToTitleCase(coll["description"]);
            obj.Extra = "";

            if (obj.Id != Guid.Empty)
            {
                PackageManager.Update(obj);

                TempData[Constant.INFO_MESSAGE] = "Package Package Updated Successfully";
            }
            else
            {
                obj.Id = Guid.NewGuid();
                PackageManager.Add(obj);

                TempData[Constant.INFO_MESSAGE] = "Package Package Added Successfully";
            }

            return RedirectToAction("Index");
        }

        public ActionResult DeletePackage(Guid Id)
        {
            MainModel itemnew = new MainModel();

            if (Id != Guid.Empty)
            {
                Package obj = PackageManager.GetById(Id);
                if (obj != null)
                {
                    PackageManager.Delete(obj);

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

            itemnew.PackageList = PackageManager.GetAll();

            return PartialView("~/Views/Package/_PackagePartail.cshtml", new MainModel { PackageList = itemnew.PackageList });
        }

        //image
        public ActionResult AddPackageImage(Guid Id, Guid RowId)
        {
            ViewBag.MsgItem = "";
            ViewBag.MsgItem = (TempData[Constant.INFO_MESSAGE] ?? string.Empty).ToString();
            TempData[Constant.INFO_MESSAGE] = "";
            ViewBag.TypeCss = "success";
            ViewBag.MsgTitle = "Success!";

            MainModel itemnew = new MainModel();

            if (RowId != Guid.Empty)
            {
                itemnew.PImage = PImageManager.GetById(RowId);
            }

            if (itemnew.PImageList != null)
            {
                itemnew.PImageList = PImageManager.GetByPackageIdlist(Id);
            }
            else
            {
                itemnew.PImage = new PImage();
            }

            itemnew.Package = PackageManager.GetById(Id);


            return View("~/Views/Package/AddPackageImage.cshtml", new MainModel { Package = itemnew.Package, PImage = itemnew.PImage, PImageList = itemnew.PImageList });

        }


        [HttpPost]
        public ActionResult PackageImage(HttpPostedFileBase fileuploadss, FormCollection coll)
        {
            MainModel itemnew = new MainModel();
            PImage obj = new PImage();
            try
            {
                //Guid Id = Guid.Empty;
                _ = Guid.TryParse(coll["Id"], out Guid Id);
                if (Id != Guid.Empty)
                {
                    PImage oldobj = PImageManager.GetById(Id);
                    if (oldobj != null)
                    {
                        obj = oldobj;
                    }
                }

                //PACKAGE ID

                //Guid PId = Guid.Empty;
                _ = Guid.TryParse(coll["PIId"], out Guid PId);
                obj.PakageId = PId;
                obj.Extra = "";

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

                            obj.Image = "../UserImage/" + _FileName;
                        }
                        else
                        {
                            obj.Image = obj.Image;
                        }
                    }
                    else
                    {
                        obj.Image = obj.Image;
                    }
                    #endregion

                    PImageManager.Update(obj);

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

                            obj.Image = "../UserImage/" + _FileName;
                        }
                        else
                        {
                            obj.Image = "../UserImage/Noimage.png";
                        }
                    }
                    else
                    {
                        obj.Image = "../UserImage/" + "noimage.png";
                    }
                    #endregion

                    PImageManager.Add(obj);
                    TempData[Constant.INFO_MESSAGE] = "Your submission Has been submit!";
                }

                ViewBag.MsgItem = "";
                ViewBag.MsgItem = (TempData[Constant.INFO_MESSAGE] ?? string.Empty).ToString();
                TempData[Constant.INFO_MESSAGE] = "";
                ViewBag.TypeCss = "success";
                ViewBag.MsgTitle = "Success!";
                return RedirectToAction("AddPackageImage", "Package", new { Id = obj.PakageId, RowId = Guid.Empty });
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = "Some thing Error !" + "," + ex;
            }

            itemnew.PImageList = PImageManager.GetAll();

            ViewBag.MsgItem = "";
            ViewBag.MsgItem = (TempData[Constant.INFO_MESSAGE] ?? string.Empty).ToString();
            TempData[Constant.INFO_MESSAGE] = "";
            ViewBag.TypeCss = "success";
            ViewBag.MsgTitle = "Success!";
            return RedirectToAction("AddPackageImage", "Package", new { Id = obj.PakageId, RowId = Guid.Empty });
        }

        public ActionResult DeletePackageImage(Guid Id)
        {
            MainModel itemnew = new MainModel();

            if (Id != Guid.Empty)
            {
                PImage obj = PImageManager.GetById(Id);
                if (obj != null)
                {
                    PImageManager.Delete(obj);

                    ViewBag.MsgItem = "Record Deleted Successfully.";
                    ViewBag.TypeCss = "success";
                }
                else
                {
                    ViewBag.MsgItem = "Record Not Deleted.";
                    ViewBag.TypeCss = "info";
                }
            }
            else
            {
                ViewBag.MsgItem = "Record Not Deleted.";
                ViewBag.TypeCss = "info";
            }

            itemnew.PImageList = PImageManager.GetAll();

            return PartialView("~/Views/Package/_PackageImagePartail.cshtml", new MainModel { PImageList = itemnew.PImageList });
        }
    }
}