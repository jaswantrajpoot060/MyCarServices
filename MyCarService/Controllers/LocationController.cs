using BusinessManager;
using BusinessObject;
using MyCarService.AppCode;
using MyCarService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace MyCarService.Controllers
{
    [Obsolete]
    [Authorize(Roles = "Admin")]
    public class LocationController : Controller
    {
        // GET: Location
        public ActionResult Index()
        {
            return View();
        }

        //City

        public ActionResult City()
        {
            ViewBag.Master = "active";
            ViewBag.City = "active";

            MainModel itemnew = new MainModel
            {
                CityList = CityMasterManager.GetAll()
            };

            ViewBag.Msg = "";
            ViewBag.Msg = (TempData[Constant.INFO_MESSAGE] ?? string.Empty).ToString();
            TempData[Constant.INFO_MESSAGE] = "";
            ViewBag.TypeCss = "success";
            ViewBag.MsgTitle = "Success!";

            return View("~/Views/Location/City.cshtml", new MainModel { CityList = itemnew.CityList, Login = itemnew.Login });

        }

        public ActionResult AddCity(Guid Id)
        {
            ViewBag.Master = "active";
            ViewBag.City = "active";
            MainModel itemnew = new MainModel();
            List<StateMaster> StateList = StateMasterManager.GetAll();

            if (Id != Guid.Empty)
            {
                itemnew.City = CityMasterManager.GetById(Id);
                ViewBag.State = new SelectList(StateList, "Name", "Name", itemnew.City.CreatedBy);
            }
            else
            {
                ViewBag.State = new SelectList(StateList, "Name", "Name");
            }

            return View("~/Views/MasterPartial/AddCity.cshtml", new MainModel { City = itemnew.City, Login = itemnew.Login });
        }

        public ActionResult SaveCity(FormCollection coll)
        {
            MainModel itemnew = new MainModel();

            Guid Id = Guid.Empty;
            _ = Guid.TryParse(coll["Id"], out Id);

            CityMaster obj = new CityMaster();

            if (Id != Guid.Empty)
            {
                CityMaster oldobj = CityMasterManager.GetById(Id);
                if (oldobj != null)
                {
                    obj = oldobj;
                }
            }

            obj.Name = Constant.TextInfo.ToTitleCase(coll["Name"]);
            obj.CreatedBy = coll["drpstate"];
            obj.StateId = Guid.Empty;
            obj.CityCode = "";
            obj.ExtraColumn = "";

            if (Id != Guid.Empty)
            {
                obj.UpdatedBy = "Admin";
                obj.CreatedOn = obj.CreatedOn;
                obj.UpdatedOn = DateTime.Now.AddHours(12).AddMinutes(30).AddHours(12);

                CityMasterManager.Update(obj);

                TempData[Constant.INFO_MESSAGE] = "Record Updated Successfully";
            }
            else
            {
                obj.Id = Guid.NewGuid();

                obj.UpdatedBy = "Admin";
                obj.CreatedOn = obj.UpdatedOn = DateTime.Now.AddHours(12).AddMinutes(30).AddHours(12);

                List<CityMaster> CityList = CityMasterManager.GetAll().Where(s => s.Name == obj.Name).ToList();
                if (CityList.Count <= 0)
                {
                    CityMasterManager.Add(obj);

                    TempData[Constant.INFO_MESSAGE] = "Record Added Successfully.";
                }
                else
                {
                    TempData[Constant.INFO_MESSAGE] = "Record Already Exists With this Detail.";
                }
            }

            return RedirectToAction("City");
        }

        public ActionResult DeleteCity(Guid Id)
        {
            if (Id != Guid.Empty)
            {
                CityMaster obj = CityMasterManager.GetById(Id);
                if (obj != null)
                {
                    CityMasterManager.Delete(obj);
                }

                TempData[Constant.INFO_MESSAGE] = "Record Deleted Successfully.";
            }
            else
            {
                TempData[Constant.INFO_MESSAGE] = "Record Not Deleted.";
            }

            return RedirectToAction("City");
        }

        //State

        public ActionResult State()
        {
            ViewBag.Master = "active";
            ViewBag.State = "active";
            MainModel itemnew = new MainModel
            {
                StateList = StateMasterManager.GetAll()
            };

            ViewBag.Msg = "";
            ViewBag.Msg = (TempData[Constant.INFO_MESSAGE] ?? string.Empty).ToString();
            TempData[Constant.INFO_MESSAGE] = "";
            ViewBag.TypeCss = "success";
            ViewBag.MsgTitle = "Success!";

            return View("~/Views/Location/State.cshtml", new MainModel { StateList = itemnew.StateList, Login = itemnew.Login });
        }

        public ActionResult AddState(Guid Id)
        {
            ViewBag.Master = "active";
            ViewBag.State = "active";

            MainModel itemnew = new MainModel();
            if (Id != Guid.Empty)
            {
                itemnew.State = StateMasterManager.GetById(Id);
            }

            return View("~/Views/MasterPartial/AddState.cshtml", new MainModel { State = itemnew.State, Login = itemnew.Login });
        }

        public ActionResult SaveState(FormCollection coll)
        {
            MainModel itemnew = new MainModel();

            Guid Id = Guid.Empty;
            _ = Guid.TryParse(coll["Id"], out Id);

            StateMaster obj = new StateMaster();

            if (Id != Guid.Empty)
            {
                StateMaster oldobj = StateMasterManager.GetById(Id);
                if (oldobj != null)
                {
                    obj = oldobj;
                }
            }

            obj.Name = Constant.TextInfo.ToTitleCase(coll["Name"]);
            obj.StateCode = coll["statecode"];

            Guid CId = Guid.Empty;
            obj.CountryId = CId;
            obj.ExtraColumn = "";

            if (Id != Guid.Empty)
            {
                obj.CreatedBy = obj.UpdatedBy = "Admin";
                obj.CreatedOn = obj.CreatedOn;
                obj.UpdatedOn = DateTime.Now.AddHours(12).AddMinutes(30).AddHours(12);

                StateMasterManager.Update(obj);

                TempData[Constant.INFO_MESSAGE] = "Record Updated Successfully";
            }
            else
            {
                obj.Id = Guid.NewGuid();

                obj.CreatedBy = obj.UpdatedBy = "Admin";
                obj.CreatedOn = obj.UpdatedOn = DateTime.Now.AddHours(12).AddMinutes(30).AddHours(12);

                List<StateMaster> StateList = StateMasterManager.GetAll().Where(s => s.Name == obj.Name).ToList();
                if (StateList.Count <= 0)
                {
                    StateMasterManager.Add(obj);

                    TempData[Constant.INFO_MESSAGE] = "Record Added Successfully.";
                }
                else
                {
                    TempData[Constant.INFO_MESSAGE] = "Record Already Exists With this Detail.";
                }
            }

            return RedirectToAction("State");
        }

        public ActionResult DeleteState(Guid Id)
        {
            if (Id != Guid.Empty)
            {
                StateMaster obj = StateMasterManager.GetById(Id);
                if (obj != null)
                {
                    StateMasterManager.Delete(obj);
                }

                TempData[Constant.INFO_MESSAGE] = "Record Deleted Successfully.";
            }
            else
            {
                TempData[Constant.INFO_MESSAGE] = "Record Not Deleted.";
            }

            return RedirectToAction("State");
        }

        // Get State

        public JsonResult GetStateName(string Country)
        {
            List<StateMaster> StateList = StateMasterManager.GetAll().Where(s => s.ExtraColumn.ToUpper() == Country.ToUpper()).OrderBy(d => d.Name).ToList();
            var result = new { StateList };

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        // Get City

        public JsonResult GetcityName(string State)
        {
            List<CityMaster> CityList = CityMasterManager.GetAll().Where(s => s.CreatedBy.ToUpper() == State.ToUpper()).OrderBy(d => d.Name).ToList();
            var result = new { CityList };

            return Json(result, JsonRequestBehavior.AllowGet);
        }

    }
}