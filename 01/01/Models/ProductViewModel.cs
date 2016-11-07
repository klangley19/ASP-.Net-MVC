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
    public class ProductViewModel
    {
        #region public properties
        [Display(Name = "Product Name")]
        public string Name { get; set; }

        [Display(Name = "Product Number")]
        public string Number { get; set; }
        #endregion

        #region public static List<ProductViewModel> LoadProducts(int ProductCategoryID)
        public static List<ProductViewModel> LoadProducts(int ProductCategoryID)
        {
            using (AdventureWorksContext db = new AdventureWorksContext())
            {

                var Products =
                    db.ProductSubcategories
                        .Join(db.Products, ps => ps.ProductSubcategoryID, p => p.ProductSubcategoryID,
                            (ps, p) => new { ps, p })
                        .Where(ps => ps.ps.ProductCategoryID == ProductCategoryID)
                        .Select(product => new ProductViewModel
                        {
                            Name = product.p.Name,
                            Number = product.p.ProductNumber
                        });


                return Products.ToList();
            }

        }
        #endregion
    }
}

