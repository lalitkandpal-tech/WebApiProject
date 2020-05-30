using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMDocument
{
    public class FoOrderSheetDetail
    {
        public long OrderId { get; set; }
        public string OrderRefNo { get; set; }
        public string Product { get; set; }
        public string CategoryName { get; set; }
        public string Company { get; set; }
        public string Amount { get; set; }
        public int Quantity { get; set; }
        public decimal Price_Per_Qty_ { get; set; }
        public decimal Dealer_Price { get; set; }
        public decimal Other_Charges__Per_Qty_ { get; set; }
        public string Discount { get; set; }
        public decimal Total { get; set; }
        public decimal Total_Dealer_Price { get; set; }
        public string Delivery_Date { get; set; }
        public string Date_Created { get; set; }
        public string farmer { get; set; }
        public decimal Mobile { get; set; }
        public string Address { get; set; }
        public string Land_Mark { get; set; }
        public string District { get; set; }
        public string Block { get; set; }
        public string Village { get; set; }
        public string Dealer { get; set; }
        public string RefernceSource { get; set; }
        public int DistrictID { get; set; }
        public string PaymentType { get; set; }
        public string CSCName { get; set; }
        public string CSCMobileNo { get; set; }
        public bool IsPrime { get; set; }
        public int FoUserId { get; set; }
        public string FoName { get; set; }
        public string Product_Type { get; set; }
        public int DealerID { get; set; }
        public string DealerEmail { get; set; }
        public int DealerDistrictId { get; set; }
        public string DealerDistrict { get; set; }
        public string HsnCode { get; set; }
        public decimal Cgst { get; set; }
        public decimal Sgst { get; set; }
        public decimal Igst { get; set; }
        public decimal BasePrice { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal CgstAmount { get; set; }
        public decimal SgstAmount { get; set; }
        public decimal IgstAmount { get; set; }
        public decimal Profit { get; set; }
        public string OrderStatus { get; set; }
        public string InvoiceNo { get; set; }
        public string ItemStatus { get; set; }
    }

    public class FoLocation
    {
        public string Lat { get; set; }
        public string Longitude { get; set; }
        public string Username { get; set; }
        public string MobileNo { get; set; }
        public string CreatedDate { get; set; }
        public string DistrictName { get; set; }
    }

    public class FoDistance
    {
        public string DistrictName { get; set; }
        public string FoName { get; set; }
        public string MobileNo { get; set; }
        public string Date { get; set; }
        public string DistanceTravelled { get; set; }

    }

    public class MarginReport
    {
        public string Date { get; set; }
        public string CategoryName { get; set; }
        public string FarmerAmount { get; set; }
        public string DealerAmount { get; set; }
        public string Margin { get; set; }
        public string MarginPercent { get; set; }
        public string NoOfOrder { get; set; }
        public string OrderStatus { get; set; }




    }

    public class DealerTransaction
    {
        public string Date { get; set; }
        public string DealerName { get; set; }
        public string FoName { get; set; }
        public string DealerPickedQty { get; set; }
        public string DealerReturnQty { get; set; }
        public string DealerAmount { get; set; }
        public string DealerAmountReturned { get; set; }
        public string RemainingAmount { get; set; }

    }
    public class FoTransaction : DealerTransaction
    {

        public string FoAmount { get; set; }
        public string FoAmountReturned { get; set; }
    }
}
