using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc.Html;

using AdventureWorks;

namespace _01.Models
{
    public class SalesPersonViewModel
    {
        #region public properties
        [Display(Name = "Business Entity ID")]
        public int BusinessEntityID { get; set; }

        [Display(Name = "Title")]
        public string Title { get; set; }
        
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Middle Name")]
        public string MiddleName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Suffix")]
        public string Suffix { get; set; }

        [Display(Name = "Job Title")]
        public string JobTitle { get; set; }

        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Phone Number Type")]
        public string PhoneNumberType { get; set; }

        [Display(Name = "E-Mail Address")]
        public string EmailAddress { get; set; }

        [Display(Name = "E-Mail Promotion")]
        public int EmailPromotion { get; set; }

        [Display(Name = "Address Line One")]
        public string AddressLine1 { get; set; }

        [Display(Name = "Address Line Two")]
        public string AddressLine2 { get; set; }

        [Display(Name = "City")]
        public string City { get; set; }

        [Display(Name = "State Or Province")]
        public string StateProvinceName { get; set; }

        [Display(Name = "Postal Code")]
        public string PostalCode { get; set; }

        [Display(Name = "Country Or Region")]
        public string CountryRegionName { get; set; }

        [Display(Name = "Territory Name")]
        public string TerritoryName { get; set; }

        [Display(Name = "Territory Group")]
        public string TerritoryGroup { get; set; }


        private decimal? m_SalesQuota;
        public decimal? SalesQuota
        {
            get { return this.m_SalesQuota; }
            set { this.m_SalesQuota = value; }
        }
        [Display(Name = "Sales Quota")]
        public string SalesQuotaString
        {
            get
            {
                return string.Format("{0:C}", this.m_SalesQuota ?? 0);
            }
        }

        private decimal? m_SalesYTD;
        public decimal? SalesYTD
        {
            get { return this.m_SalesYTD; }
            set { this.m_SalesYTD = value; }
        }
        [Display(Name = "Sales YTD")]
        public string SalesYTDString
        {
            get
            {
                return string.Format("{0:C}", this.m_SalesYTD ?? 0);
            }
        }

        private decimal? m_SalesLastYear;
        public decimal? SalesLastYear
        {
            get { return this.m_SalesLastYear; }
            set { this.m_SalesLastYear = value; }
        }
        [Display(Name = "Sales Last Year")]
        public string SalesLastYearString
        {
            get
            {
                return string.Format("{0:C}", this.m_SalesLastYear ?? 0);
            }
        }

        #endregion

        #region public static List<SalesPersonViewModel> GetSalesPeople()
        public static List<SalesPersonViewModel> GetSalesPeople()
        {
            using (AdventureWorksContext db = new AdventureWorksContext())
            {
                var salespersons = db.vSalesPersons
                    .OrderBy(sp => sp.LastName)
                    .Select(sales_people => new _01.Models.SalesPersonViewModel
                        {
                            BusinessEntityID = sales_people.BusinessEntityID,
                            Title = sales_people.Title,
                            FirstName = sales_people.FirstName,
                            MiddleName = sales_people.MiddleName,
                            LastName = sales_people.LastName,
                            Suffix = sales_people.Suffix,
                            JobTitle = sales_people.JobTitle,
                            PhoneNumber = sales_people.PhoneNumber,
                            PhoneNumberType = sales_people.PhoneNumberType,
                            EmailAddress = sales_people.EmailAddress,
                            EmailPromotion = sales_people.EmailPromotion,
                            AddressLine1 = sales_people.AddressLine1,
                            AddressLine2 = sales_people.AddressLine2,
                            City = sales_people.City,
                            StateProvinceName = sales_people.StateProvinceName,
                            PostalCode = sales_people.PostalCode,
                            CountryRegionName = sales_people.CountryRegionName,
                            TerritoryName = sales_people.TerritoryName,
                            TerritoryGroup = sales_people.TerritoryGroup,
                            SalesQuota = sales_people.SalesQuota,
                            SalesYTD = sales_people.SalesYTD,
                            SalesLastYear = sales_people.SalesLastYear

                        });

                return salespersons.ToList();
            }
        }
        #endregion


    }
}