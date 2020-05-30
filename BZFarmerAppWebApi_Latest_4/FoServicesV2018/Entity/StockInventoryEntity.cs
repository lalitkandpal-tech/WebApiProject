using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoServicesV2018.Entity
{
    public class StockInventoryEntity
    {
        public List <DealerProductData> _DealerProductList{ get; set; }
        public List<CategoryList> _CategoryList { set; get; }
    }

    public class CategoryList
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string CategoryHindi { get; set; }
    }
    public class DealerProductData
    {
       public int ProductId { get; set; }
        public string  ProductName { get; set; }
        public string  CompanyName { get; set; }
        public string BrandName { get; set; }

        public string TechnicalName { get; set;}
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public int SubCategoryId { get; set; }
        public string SubCategoryName { get; set; }
        public int PackageId { get; set; }
        public string PackSize { get; set; }
        public int DealerID { get; set; }
        public string DealerName { get; set; }
        public decimal DealerPrice { get; set; }
        public string PackageName { get; set; }
        public int RecordId { get; set; }
        public int StockId { get; set; }
        public int StockQuantity { get; set; }
        public bool IsActive { get; set; }
    }

    public class SubDealerProductCreate
    {
        public int StockId { get; set; }
        public int PackageId { get; set; }
        public int Quantity { get; set; }
        public int SubDealerId { get; set; }
    }

    public class SavedProductResult
    {
        public int Status { get; set; }
        public int StockQty { get; set; }
        public string Msg { get; set; }
    }

    public class TractorUsers
    {
        public string FarmerName { get; set; }
        public int StateID { get; set; }
        public string MobileNo { get; set; }
        public int CategoryId { get; set; }
        public int BzProductId { get; set; }
        public string ModelNo { get; set; }
        public decimal QuotationPrice { get; set; }
        public string RequestSource { get; set; }
        public string  DemoDate { get; set; }
        public string TimeSlot { get; set; }
        public int IsOldTractor { get; set; }

    }
    public class ApiPostResponse
    {
        public bool Success { get; set; }
        public string Msg { get; set; }
    }
}