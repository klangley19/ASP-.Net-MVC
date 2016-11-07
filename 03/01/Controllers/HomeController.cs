using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;

using AdventureWorks;
using _01.Models;

namespace _01.Controllers
{
    public class HomeController : Controller
    {

        #region public ActionResult Index()
        public ActionResult Index()
        {
            return View();
        }
        #endregion

    }
}
