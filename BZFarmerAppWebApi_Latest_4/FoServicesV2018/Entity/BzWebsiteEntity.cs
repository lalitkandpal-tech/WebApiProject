using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Entity
{
    public class BzWebsiteEntity
    {
    }
    public class BzCartItems
    {
        public string InType { get; set; }
        public int CartItemId { get; set; }
        public string UserId { get; set; }
        public int BzProductId { get; set; }
        public int Quantity { get; set; }
    }
    public class AddtoCartResult
    {
        public int Status { get; set; }
    }

    public class OrderTracking
    {
        public int OrderId { get; set; }
        public decimal TotalSaleValue { get; set; }
        public decimal DeliveryCharge { get; set; }
        public decimal Discount { get; set; }

        public string OrderStatus { get; set; }
        public string OrderDate { get; set; }
        public List<OrderItems> OrderItems { get; set; }
    }
    public class OrderItems
    {
       // public int RecordId { get; set; }
        public int PackageId { get; set; }
        public string ProductName { get; set; }
        public string TechnicalName { get; set; }
        public string OrderDate { get; set; }
        public string DeliveryDate { get; set; }
        public int Quantity { get; set; }
        public string PackSize { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal SaleValue { get; set; }
        public string OrderStatus { get; set; }
        public string ImagePath { get; set; }
    }

}