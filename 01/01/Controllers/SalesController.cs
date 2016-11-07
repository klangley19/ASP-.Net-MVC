using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AdventureWorks;

using _01.Models;

namespace _01.Controllers
{
    public class SalesController : Controller
    {
        #region public enum SalesPersonSortOrder
        public enum SalesPersonSortOrder
        {
            Unspecified = -1,
            Title,
            FirstName,
            MiddleName,
            LastName,
            Suffix,
            SalesQuota,
            SalesYTD,
            SalesLastYear
        }
        #endregion

        #region public enum SalesPersonSortingDirection
        public enum SalesPersonSortingDirection
        {
            Unspecified = -1,
            Ascending,
            Decending
        }
        #endregion

        
        
        #region private static data members
        private static List<SalesPersonViewModel> SalesPeople = new List<SalesPersonViewModel>();
        private static SalesPersonSortingDirection SortingDirection = SalesPersonSortingDirection.Unspecified;
        private static SalesPersonSortOrder LastSortDone = SalesPersonSortOrder.Unspecified;
        #endregion


        //BEGIN :: SALES PERSON ACTION METHODS
        #region public ActionResult Index(SalesPersonSortOrder sort_order = SalesPersonSortOrder.NoSortingSpecified)
        public ActionResult Index(SalesPersonSortOrder sort_order = SalesPersonSortOrder.Unspecified)
        {

            if (SalesPeople.Count == 0)
            {
                SalesController.SalesPeople = SalesPersonViewModel.GetSalesPeople();
                SalesController.LastSortDone = SalesPersonSortOrder.LastName;
            }

            #region code for sorting sales people according to how the user selects it to be done
            if (sort_order == SalesController.LastSortDone)
            {
                switch (SalesController.SortingDirection)
                {
                    case SalesPersonSortingDirection.Unspecified:
                        SalesController.SortingDirection = SalesPersonSortingDirection.Ascending;
                        break;
                    case SalesPersonSortingDirection.Ascending:
                        SalesController.SortingDirection = SalesPersonSortingDirection.Decending;
                        break;
                    case SalesPersonSortingDirection.Decending:
                        SalesController.SortingDirection = SalesPersonSortingDirection.Ascending;
                        break;
                }
            }
            else
            {
                SalesController.SortingDirection = SalesPersonSortingDirection.Ascending;
            }

            switch (sort_order)
            {
                case SalesPersonSortOrder.Unspecified:
                    break;
                case SalesPersonSortOrder.Title:
                    if (SalesController.SortingDirection == SalesPersonSortingDirection.Decending)
                        SalesController.SalesPeople = SalesController.SalesPeople.OrderByDescending(sp => sp.Title).ToList();
                    else
                        SalesController.SalesPeople = SalesController.SalesPeople.OrderBy(sp => sp.Title).ToList();
                    break;
                case SalesPersonSortOrder.FirstName:
                    if (SalesController.SortingDirection == SalesPersonSortingDirection.Decending)
                        SalesController.SalesPeople = SalesController.SalesPeople.OrderByDescending(sp => sp.FirstName).ToList();
                    else
                        SalesController.SalesPeople = SalesController.SalesPeople.OrderBy(sp => sp.FirstName).ToList();
                    break;
                case SalesPersonSortOrder.MiddleName:
                    if (SalesController.SortingDirection == SalesPersonSortingDirection.Decending)
                        SalesController.SalesPeople = SalesController.SalesPeople.OrderByDescending(sp => sp.MiddleName).ToList();
                    else
                        SalesController.SalesPeople = SalesController.SalesPeople.OrderBy(sp => sp.MiddleName).ToList();
                    break;
                case SalesPersonSortOrder.LastName:
                    if (SalesController.SortingDirection == SalesPersonSortingDirection.Decending)
                        SalesController.SalesPeople = SalesController.SalesPeople.OrderByDescending(sp => sp.LastName).ToList();
                    else
                        SalesController.SalesPeople = SalesController.SalesPeople.OrderBy(sp => sp.LastName).ToList();
                    break;
                case SalesPersonSortOrder.Suffix:
                    if (SalesController.SortingDirection == SalesPersonSortingDirection.Decending)
                        SalesController.SalesPeople = SalesController.SalesPeople.OrderByDescending(sp => sp.Suffix).ToList();
                    else
                        SalesController.SalesPeople = SalesController.SalesPeople.OrderBy(sp => sp.Suffix).ToList();
                    break;
                case SalesPersonSortOrder.SalesQuota:
                    if (SalesController.SortingDirection == SalesPersonSortingDirection.Decending)
                        SalesController.SalesPeople = SalesController.SalesPeople.OrderByDescending(sp => sp.SalesQuota).ToList();
                    else
                        SalesController.SalesPeople = SalesController.SalesPeople.OrderBy(sp => sp.SalesQuota).ToList();
                    break;
                case SalesPersonSortOrder.SalesYTD:
                    if (SalesController.SortingDirection == SalesPersonSortingDirection.Decending)
                        SalesController.SalesPeople = SalesController.SalesPeople.OrderByDescending(sp => sp.SalesYTD).ToList();
                    else
                        SalesController.SalesPeople = SalesController.SalesPeople.OrderBy(sp => sp.SalesYTD).ToList();
                    break;
                case SalesPersonSortOrder.SalesLastYear:
                    if (SalesController.SortingDirection == SalesPersonSortingDirection.Decending)
                        SalesController.SalesPeople = SalesController.SalesPeople.OrderByDescending(sp => sp.SalesLastYear).ToList();
                    else
                        SalesController.SalesPeople = SalesController.SalesPeople.OrderBy(sp => sp.SalesLastYear).ToList();
                    break;

            }

            SalesController.LastSortDone = sort_order;

            #endregion

            return View(SalesController.SalesPeople.ToList());

        }
        #endregion

        #region public ActionResult Details(int? id)
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            if (SalesPeople.Count == 0)
            {
                SalesController.SalesPeople = SalesPersonViewModel.GetSalesPeople();
                SalesController.LastSortDone = SalesPersonSortOrder.LastName;
            }

            if (SalesPeople.Count > 0)
            {
                SalesPersonViewModel sales_person =
                    SalesController.SalesPeople
                        .Where(sp => sp.BusinessEntityID == id)
                        .FirstOrDefault();

                if (sales_person == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                return View(sales_person);
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
        }
        #endregion
        //END


        //BEGIN :: ORDER ACTION METHODS
        #region public ActionResult Orders(int? id)

        public ActionResult Orders(int? id)
        {
            if (id.HasValue == false)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            return View(SalesOrderViewModel.GetOrdersBySalesPerson(id));

        }
        #endregion

        #region public ActionResult OrderDetails(_04.Models.SalesOrderViewModel model)

        public ActionResult OrderDetails(_01.Models.SalesOrderViewModel model)
        {
            if (model == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            return View(model);

        }
        #endregion

        #region public ActionResult AddressBillTo(_04.Models.SalesOrderViewModel model)

        public ActionResult AddressBillTo(_01.Models.SalesOrderViewModel model)
        {
            if (model == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            return View(model);

        }
        #endregion

        #region public ActionResult AddressShipTo(_04.Models.SalesOrderViewModel model)
        public ActionResult AddressShipTo(_01.Models.SalesOrderViewModel model)
        {
            if (model == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }


            return View(model);
        }
        #endregion
        //END





    }
}
