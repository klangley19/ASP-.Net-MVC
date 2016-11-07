using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using AdventureWorks;
using _01.Models;

namespace _01.Controllers
{
    public class ProductsController : Controller
    {
        #region public ActionResult Index()
        public ActionResult Index()
        {
            List<ProductCategoryViewModel> lstProductCategories = ProductCategoryViewModel.GetProductCategories();
            ViewData["ProductCategories"] = lstProductCategories;
            return View();                
        }
        #endregion

        #region public ActionResult LoadProducts(_01.Models.ProductCategoryViewModel pc)
        public ActionResult LoadProducts(_01.Models.ProductCategoryViewModel pc)
        {

            List<ProductViewModel> lstProducts = ProductViewModel.LoadProducts(pc.CategoryID);
            return View("Products", lstProducts);

        }
        #endregion
    }
}