using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;

using AdventureWorks;
using _01.Models;

namespace _01.Controllers
{
    public class SalesController : Controller
    {


        #region public ActionResult Index()
        public ActionResult Index()
        {
            return View();
        }
        #endregion

        #region public ActionResult GetSalesPersons([DataSourceRequest]DataSourceRequest request)
        public ActionResult GetSalesPersons([DataSourceRequest]DataSourceRequest request)
        {

            return Json(SalesPersonViewModel.GetSalesPeople(request), JsonRequestBehavior.AllowGet);
            
        }
        #endregion



        #region public ActionResult Orders(int? id)

        public ActionResult Orders(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            TempData["SalesPersonSelectedID"] = id;
            return View("Orders");
            
        }
        #endregion

        #region public ActionResult GetOrdersForSalesPerson([DataSourceRequest]DataSourceRequest request)

        public ActionResult GetOrdersForSalesPerson([DataSourceRequest]DataSourceRequest request)
        {
            int SalesPersonID = 0;

            if (TempData["SalesPersonSelectedID"] == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            if (int.TryParse(TempData["SalesPersonSelectedID"].ToString(), out SalesPersonID) == false)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            else
            {
                return Json(SalesOrderViewModel.GetOrdersBySalesPerson(SalesPersonID, request), JsonRequestBehavior.AllowGet);
            }
        }

        #endregion



    }
}

