using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoServicesV2018.Models
{
    public class AnimalDetails
    {
        public int LiveStockId { get; set; }
        public string LiveStockName { get; set; }
        public string LiveStockNameHindi { get; set; }
        public int LiveStockType { get; set; }
        public int BreedId { get; set; }
        public string BreedName { get; set; }
        public bool IsMilk { get; set; }
        public int MilkQuantity { get; set; }
        public bool IsActive { get; set; }
        public string ImageUrl { get; set; }
        public List<BALLiveStock> BALLiveStock { get; set; }
    }
    public class BALLiveStock
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Extra { get; set; }
        public bool IsShow { get; set; }
        public string VideoUrl { get; set; }
        public string ImageUrl { get; set; }
        public List<Products> Products { get; set; }
    }
    public class Products
    {
        public Int64 RowNumber { get; set; }
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string OrganisationName { get; set; }
        public string BrandName { get; set; }
        public string TechnicalName { get; set; }
        public string SubCategoryName { get; set; }
        public string CategoryName { get; set; }
        public string CategoryHindi { get; set; }
        public int? CategoryID { get; set; }
        public int? PackageID { get; set; }
        public Int64? RN { get; set; }
        public int? OfferPrice_Qty { get; set; }
        public decimal Amount { get; set; }
        public string UnitName { get; set; }
        public decimal OurPrice { get; set; }
        public decimal offerprice { get; set; }
        public int RecordID { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsActive { get; set; }
        public bool IsDetails { get; set; }
        public string status { get; set; }
        public string CretedBy { get; set; }
        public string ProductHindiName { get; set; }
        public string ImagePath { get; set; }
        public int DistrictID { get; set; }
        public string DistrictName { get; set; }
        public decimal COD { get; set; }
        public decimal OnlinePrice { get; set; }
        public decimal MRP { get; set; }
        public string OfferDiscount { get; set; }


    }
}