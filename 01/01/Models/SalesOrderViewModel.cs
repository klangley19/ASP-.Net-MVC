using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc.Html;

using AdventureWorks;



using _01.Models;

namespace _01.Models
{
    public class SalesOrderViewModel
    {

        #region public properties
        [Display(Name = "Sales Order Number")]
        public string SalesOrderNumber { get; set; }

        [Display(Name = "Account Number")]
        public string AccountNumber { get; set; }

        [Display(Name = "Purchase Order Number")]
        public string PurchaseOrderNumber { get; set; }


        [Display(Name = "Sales Order ID")]
        public int SalesOrderID { get; set; }

        [Display(Name = "Customer ID")]
        public int CustomerID { get; set; }

        [Display(Name = "Sales Person ID")]
        public int? SalesPersonID { get; set; }

        [Display(Name = "Person ID")]
        public int? PersonID { get; set; }

        [Display(Name = "Store ID")]
        public int? StoreID { get; set; }

        [Display(Name = "Territory ID")]
        public int? TerritoryID { get; set; }

        #region Bill To Address Properties
        [Display(Name = "Address ID")]
        public int BillToAddressID { get; set; }

        [Display(Name = "Address Line One")]
        public string BillToAddressLine1 { get; set; }

        [Display(Name = "Address Line Two")]
        public string BillToAddressLine2 { get; set; }

        [Display(Name = "City")]
        public string BillToCity { get; set; }

        [Display(Name = "State Or Province")]
        public string BillToStateProvince { get; set; }

        [Display(Name = "Postal Code")]
        public string BillToPostalCode { get; set; }
        #endregion

        #region Ship To Address Properties
        [Display(Name = "Address ID")]
        public int ShipToAddressID { get; set; }

        [Display(Name = "Address Line One")]
        public string ShipToAddressLine1 { get; set; }

        [Display(Name = "Address Line Two")]
        public string ShipToAddressLine2 { get; set; }

        [Display(Name = "City")]
        public string ShipToCity { get; set; }

        [Display(Name = "State Or Province")]
        public string ShipToStateProvince { get; set; }

        [Display(Name = "Postal Code")]
        public string ShipToPostalCode { get; set; }
        #endregion

        #region Sale Order Detail Properties

        [Display(Name = "Title")]
        public string CustomerTitle { get; set; }

        [Display(Name = "First Name")]
        public string CustomerFirstName { get; set; }

        [Display(Name = "Middle Name")]
        public string CustomerMiddleName { get; set; }

        [Display(Name = "Last Name")]
        public string CustomerLastName { get; set; }

        [Display(Name = "Suffix")]
        public string CustomerSuffix { get; set; }

        [Display(Name = "Name")]
        public string CustomerFullName 
        { 
            get
            {
                return string.Format("{0} {1} {2} {3} {4}", this.CustomerTitle, this.CustomerFirstName, this.CustomerMiddleName, this.CustomerLastName, this.CustomerSuffix);
            }  
        }


        [Display(Name = "Order Date")]
        public DateTime OrderDate { get; set; }

        [Display(Name = "Due Date")]
        public DateTime DueDate { get; set; }

        [Display(Name = "Ship Date")]
        public DateTime? ShipDate { get; set; }

        [Display(Name = "Status")]
        public byte Status { get; set; }


        private decimal m_SubTotal;
        public decimal SubTotal
        { 
            get { return this.m_SubTotal; }
            set { this.m_SubTotal = value; }
        }
        [Display(Name = "Sub Total")]
        public string SubTotalString 
        {
            get 
            {
                return string.Format("{0:C}", this.m_SubTotal); 
            }             
        }

        private decimal m_TaxAmt;
        public decimal TaxAmt 
        {
            get { return this.m_TaxAmt; }
            set { this.m_TaxAmt = value; }
        }
        [Display(Name = "Tax Amount")]
        public string TaxAmtString
        {
            get
            {
                return string.Format("{0:C}", this.m_TaxAmt);
            }
        }

        private decimal m_Freight;
        public decimal Freight 
        {
            get { return this.m_Freight; }
            set { this.m_Freight = value; }
        }
        [Display(Name = "Freight")]
        public string FreightString
        {
            get
            {
                return string.Format("{0:C}", this.m_Freight);
            }
        }


        private decimal m_TotalDue;
        public decimal TotalDue 
        {
            get { return this.m_TotalDue; }
            set { this.m_TotalDue = value; }
        }
        [Display(Name = "Total Due")]
        public string TotalDueString
        {
            get
            {
                return string.Format("{0:C}", this.m_TotalDue);
            }
        }


        #endregion
        #endregion

        #region public static List<SalesPersonViewModel> GetSalesPeople()
        public static List<SalesOrderViewModel> GetOrdersBySalesPerson(int? SalesPersonID)
        {
            if (SalesPersonID.HasValue == false)
            {
                return new List<SalesOrderViewModel>();            
            }
            else
            { 
                using (AdventureWorksContext db = new AdventureWorksContext())
                {

                    var orders = db.SalesOrderHeaders
                        .Include(o => o.Address)
                        .Include(o => o.Address.StateProvince)
                        .Include(o => o.Address1)
                        .Include(o => o.Address1.StateProvince)
                        .Include(o => o.Customer)
                        .Include(o => o.Customer.Person)
                        .Where(o => o.SalesPersonID == SalesPersonID)
                        .OrderBy(o => o.SalesOrderNumber)
                        .Select(order => new _01.Models.SalesOrderViewModel
                        {
                            SalesOrderNumber = order.SalesOrderNumber,
                            AccountNumber = order.Customer.AccountNumber,
                            PurchaseOrderNumber = order.PurchaseOrderNumber,
                            SalesOrderID = order.SalesOrderID,
                            CustomerID = order.Customer.CustomerID,
                            SalesPersonID = order.SalesPersonID,
                            PersonID = order.Customer.PersonID,
                            StoreID = order.Customer.StoreID,
                            TerritoryID = order.Customer.TerritoryID,
                            CustomerTitle = order.Customer.Person.Title,
                            CustomerFirstName = order.Customer.Person.FirstName,
                            CustomerMiddleName = order.Customer.Person.MiddleName,
                            CustomerLastName = order.Customer.Person.LastName,
                            CustomerSuffix = order.Customer.Person.Suffix,
                            OrderDate = order.OrderDate,
                            DueDate = order.DueDate,
                            ShipDate = order.ShipDate,
                            Status = order.Status,
                            SubTotal = order.SubTotal,
                            Freight = order.Freight,
                            TaxAmt = order.TaxAmt,
                            TotalDue = order.TotalDue,
                            BillToAddressID = order.Address.AddressID,
                            BillToAddressLine1 = order.Address.AddressLine1,
                            BillToAddressLine2 = order.Address.AddressLine2,
                            BillToCity = order.Address.City,
                            BillToStateProvince = order.Address.StateProvince.Name,
                            BillToPostalCode = order.Address.PostalCode,
                            ShipToAddressID = order.Address1.AddressID,
                            ShipToAddressLine1 = order.Address1.AddressLine1,
                            ShipToAddressLine2 = order.Address1.AddressLine2,
                            ShipToCity = order.Address1.City,
                            ShipToStateProvince = order.Address1.StateProvince.Name,
                            ShipToPostalCode = order.Address1.PostalCode
                        });
                        return orders.ToList();
                }
            }
        }
        #endregion

    }
}