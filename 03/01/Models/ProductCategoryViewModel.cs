using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc.Html;

using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;

using AdventureWorks;


namespace _01.Models
{
    public class ProductCategoryViewModel
    {
        #region public properties
        [Display(Name = "Category ID")]
        public int CategoryID { get; set; }

        [Display(Name = "Product Category Name")]
        public string Name { get; set; }
        #endregion

        #region public override string ToString()
        public override string ToString()
        {
            return Name.ToString();
        }
        #endregion

        #region static public List<ProductCategoryViewModel> GetProductCategories()
        public static List<ProductCategoryViewModel> GetProductCategories()
        {
            using (AdventureWorksContext db = new AdventureWorksContext())
            {
                var ProductCategories =
                    db.ProductCategories
                        .Select(product_categories => new ProductCategoryViewModel
                        {
                            CategoryID = product_categories.ProductCategoryID,
                            Name = product_categories.Name
                        }).ToList();

                return ProductCategories;
            }
        }
        #endregion

    }
}


