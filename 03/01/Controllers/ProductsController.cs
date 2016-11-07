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
    public class ProductsController : Controller
    {

        #region public ActionResult Index()
        public ActionResult Index()
        {
            return View();
        }
        #endregion

        #region public ActionResult LoadProductCategories(_01.Models.ProductCategoryViewModel pc)
        public ActionResult LoadProductCategories()
        {
            return Json(ProductCategoryViewModel.GetProductCategories(), JsonRequestBehavior.AllowGet);
        }
        #endregion



        #region public ActionResult ShowProducts(int ProductCategoryID)
        public ActionResult ShowProducts(int ProductCategoryID)
        {
            TempData["ProductCategorySelectedID"] = ProductCategoryID;
            return RedirectToActionPermanent("OpenProducts");
        }
        #endregion

        #region public ActionResult OpenProducts()
        public ActionResult OpenProducts()
        {
            return View("Products");
        }
        #endregion

        #region public ActionResult GetProducts([DataSourceRequest]DataSourceRequest request)
        public ActionResult GetProducts([DataSourceRequest]DataSourceRequest request)
        {
            int ProductCategoryID = 0;

            if (TempData["ProductCategorySelectedID"] == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            if (int.TryParse(TempData["ProductCategorySelectedID"].ToString(), out ProductCategoryID) == false)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            else
            {
                return Json(ProductViewModel.LoadProducts(ProductCategoryID, request), JsonRequestBehavior.AllowGet);
            }

        }
        #endregion



    }
}