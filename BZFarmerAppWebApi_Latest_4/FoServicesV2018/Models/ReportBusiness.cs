using CRMDocument;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;

namespace FoServicesV2018.Models
{
    public class ReportBusiness
    {
        static Database objDB;
        static ReportBusiness()
        {
            objDB = new SqlDatabase(ConfigurationManager.ConnectionStrings["connection"].ToString());
        }
        public static List<FoOrderSheetDetail> GetFoByOrderSheetDetails(DateTime fromOrderDate, DateTime toOrderDate, int districtId, int foId)
        {
            var foOrderSheetList = new List<FoOrderSheetDetail>();
            DataSet ds = new LogData().GetFoByOrderSheetDetails(fromOrderDate, toOrderDate, districtId, foId);
            if (ds != null && ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        foOrderSheetList.Add(new FoOrderSheetDetail
                        {
                            OrderId = ds.Tables[0].Rows[i]["OrderId"] == DBNull.Value ? 0 : Convert.ToInt32(ds.Tables[0].Rows[i]["OrderId"]),
                            OrderRefNo = ds.Tables[0].Rows[i]["OrderRefNo"] == DBNull.Value ? string.Empty : Convert.ToString(ds.Tables[0].Rows[i]["OrderRefNo"]),
                            Product = ds.Tables[0].Rows[i]["Product"] == DBNull.Value ? string.Empty : Convert.ToString(ds.Tables[0].Rows[i]["Product"]),
                            //  Company = ds.Tables[0].Rows[i]["Company"] == DBNull.Value ? string.Empty : Convert.ToString(ds.Tables[0].Rows[i]["Company"]),
                            Amount = ds.Tables[0].Rows[i]["Amount"] == DBNull.Value ? string.Empty : Convert.ToString(ds.Tables[0].Rows[i]["Amount"]),
                            Quantity = ds.Tables[0].Rows[i]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(ds.Tables[0].Rows[i]["Quantity"]),
                            Price_Per_Qty_ = ds.Tables[0].Rows[i]["Price(Per Qty)"] == DBNull.Value ? 0 : Convert.ToDecimal(ds.Tables[0].Rows[i]["Price(Per Qty)"]),
                            Dealer_Price = ds.Tables[0].Rows[i]["Dealer Price"] == DBNull.Value ? 0 : Convert.ToDecimal(ds.Tables[0].Rows[i]["Dealer Price"]),
                            Other_Charges__Per_Qty_ = ds.Tables[0].Rows[i]["Other Charges (Per Qty)"] == DBNull.Value ? 0 : Convert.ToDecimal(ds.Tables[0].Rows[i]["Other Charges (Per Qty)"]),
                            Discount = ds.Tables[0].Rows[i]["Discount"] == DBNull.Value ? string.Empty : Convert.ToString(ds.Tables[0].Rows[i]["Discount"]),
                            Total = ds.Tables[0].Rows[i]["Total"] == DBNull.Value ? 0 : Convert.ToDecimal(ds.Tables[0].Rows[i]["Total"]),
                            // Total_Dealer_Price = ds.Tables[0].Rows[i]["Total Dealer Price"] == DBNull.Value ? 0 : Convert.ToDecimal(ds.Tables[0].Rows[i]["Total Dealer Price"]),
                            Delivery_Date = ds.Tables[0].Rows[i]["Delivery Date"] == DBNull.Value ? string.Empty : Convert.ToString(ds.Tables[0].Rows[i]["Delivery Date"]),
                            //Date_Created = ds.Tables[0].Rows[i]["Date Created"] == DBNull.Value ? string.Empty : Convert.ToString(ds.Tables[0].Rows[i]["Date Created"]),
                            farmer = ds.Tables[0].Rows[i]["farmer"] == DBNull.Value ? string.Empty : Convert.ToString(ds.Tables[0].Rows[i]["farmer"]),
                            Mobile = ds.Tables[0].Rows[i]["Mobile"] == DBNull.Value ? 0 : Convert.ToDecimal(ds.Tables[0].Rows[i]["Mobile"]),
                            Address = ds.Tables[0].Rows[i]["Address"] == DBNull.Value ? string.Empty : Convert.ToString(ds.Tables[0].Rows[i]["Address"]),
                            Land_Mark = ds.Tables[0].Rows[i]["Land Mark"] == DBNull.Value ? string.Empty : Convert.ToString(ds.Tables[0].Rows[i]["Land Mark"]),
                            District = ds.Tables[0].Rows[i]["District"] == DBNull.Value ? string.Empty : Convert.ToString(ds.Tables[0].Rows[i]["District"]),
                            Block = ds.Tables[0].Rows[i]["Block"] == DBNull.Value ? string.Empty : Convert.ToString(ds.Tables[0].Rows[i]["Block"]),
                            Village = ds.Tables[0].Rows[i]["Village"] == DBNull.Value ? string.Empty : Convert.ToString(ds.Tables[0].Rows[i]["Village"]),
                            Dealer = ds.Tables[0].Rows[i]["Amount"] == DBNull.Value ? string.Empty : Convert.ToString(ds.Tables[0].Rows[i]["Dealer"]),
                            // RefernceSource = ds.Tables[0].Rows[i]["RefernceSource"] == DBNull.Value ? string.Empty : Convert.ToString(ds.Tables[0].Rows[i]["RefernceSource"]),
                            // PaymentType = ds.Tables[0].Rows[i]["PaymentType"] == DBNull.Value ? string.Empty : Convert.ToString(ds.Tables[0].Rows[i]["PaymentType"]),
                            // CSCName = ds.Tables[0].Rows[i]["CSCName"] == DBNull.Value ? string.Empty : Convert.ToString(ds.Tables[0].Rows[i]["CSCName"]),
                            // CSCMobileNo = ds.Tables[0].Rows[i]["CSCMobileNo"] == DBNull.Value ? string.Empty : Convert.ToString(ds.Tables[0].Rows[i]["CSCMobileNo"]),
                            // IsPrime = ds.Tables[0].Rows[i]["IsPrime"] == DBNull.Value ? false : Convert.ToBoolean(ds.Tables[0].Rows[i]["IsPrime"])
                            FoUserId = ds.Tables[0].Rows[i]["FoUserid"] == DBNull.Value ? 0 : Convert.ToInt32(ds.Tables[0].Rows[i]["FoUserid"]),
                            FoName = ds.Tables[0].Rows[i]["FoName"] == DBNull.Value ? string.Empty : Convert.ToString(ds.Tables[0].Rows[i]["FoName"])
                        });
                    }
                }
            }
            return foOrderSheetList;
        }
        public static List<PodDetailReport> GetPodFoDetailReport(string orderId, int tripId, int districtId, DateTime fromOrderDate, DateTime toOrderDate, string type, int foid = -1)
        {
            var podDetailReportList = new List<PodDetailReport>();
            DataSet ds = new LogData().GetPodDetailFoReport(orderId, tripId, districtId, fromOrderDate, toOrderDate, foid, type);
            if (ds != null && ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        podDetailReportList.Add(new PodDetailReport
                        {
                            FarmerID = ds.Tables[0].Rows[i]["FarmerID"] == DBNull.Value ? 0 : Convert.ToInt64(ds.Tables[0].Rows[i]["FarmerID"]),
                            OrderID = ds.Tables[0].Rows[i]["OrderID"] == DBNull.Value ? 0 : Convert.ToInt32(ds.Tables[0].Rows[i]["OrderID"]),
                            OrderRefNo = ds.Tables[0].Rows[i]["OrderRefNo"] == DBNull.Value ? string.Empty : Convert.ToString(ds.Tables[0].Rows[i]["OrderRefNo"]),
                            FarmerRefNo = ds.Tables[0].Rows[i]["FarmerRefNo"] == DBNull.Value ? string.Empty : Convert.ToString(ds.Tables[0].Rows[i]["FarmerRefNo"]),
                            FName = ds.Tables[0].Rows[i]["FName"] == DBNull.Value ? string.Empty : Convert.ToString(ds.Tables[0].Rows[i]["FName"]),
                            LName = ds.Tables[0].Rows[i]["LName"] == DBNull.Value ? string.Empty : Convert.ToString(ds.Tables[0].Rows[i]["LName"]),
                            Quantity = ds.Tables[0].Rows[i]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(ds.Tables[0].Rows[i]["Quantity"]),
                            NickName = ds.Tables[0].Rows[i]["NickName"] == DBNull.Value ? string.Empty : Convert.ToString(ds.Tables[0].Rows[i]["NickName"]),
                            FatherName = ds.Tables[0].Rows[i]["FatherName"] == DBNull.Value ? string.Empty : Convert.ToString(ds.Tables[0].Rows[i]["FatherName"]),
                            StateID = ds.Tables[0].Rows[i]["StateID"] == DBNull.Value ? 0 : Convert.ToInt32(ds.Tables[0].Rows[i]["StateID"]),
                            StateName = ds.Tables[0].Rows[i]["StateName"] == DBNull.Value ? string.Empty : Convert.ToString(ds.Tables[0].Rows[i]["StateName"]),
                            DistrictID = ds.Tables[0].Rows[i]["DistrictID"] == DBNull.Value ? 0 : Convert.ToInt32(ds.Tables[0].Rows[i]["DistrictID"]),
                            DistrictName = ds.Tables[0].Rows[i]["DistrictName"] == DBNull.Value ? string.Empty : Convert.ToString(ds.Tables[0].Rows[i]["DistrictName"]),
                            BLockID = ds.Tables[0].Rows[i]["BLockID"] == DBNull.Value ? 0 : Convert.ToInt32(ds.Tables[0].Rows[i]["BLockID"]),
                            BlockName = ds.Tables[0].Rows[i]["BlockName"] == DBNull.Value ? string.Empty : Convert.ToString(ds.Tables[0].Rows[i]["BlockName"]),
                            VillageID = ds.Tables[0].Rows[i]["VillageID"] == DBNull.Value ? 0 : Convert.ToInt32(ds.Tables[0].Rows[i]["VillageID"]),
                            VillageName = ds.Tables[0].Rows[i]["VillageName"] == DBNull.Value ? string.Empty : Convert.ToString(ds.Tables[0].Rows[i]["VillageName"]),
                            NearByVillage = ds.Tables[0].Rows[i]["NearByVillage"] == DBNull.Value ? string.Empty : Convert.ToString(ds.Tables[0].Rows[i]["NearByVillage"]),
                            Chaupal = ds.Tables[0].Rows[i]["Chaupal"] == DBNull.Value ? string.Empty : Convert.ToString(ds.Tables[0].Rows[i]["Chaupal"]),
                            ShippingAddress = ds.Tables[0].Rows[i]["ShippingAddress"] == DBNull.Value ? string.Empty : Convert.ToString(ds.Tables[0].Rows[i]["ShippingAddress"]),
                            MobNo = ds.Tables[0].Rows[i]["MobNo"] == DBNull.Value ? 0 : Convert.ToDecimal(ds.Tables[0].Rows[i]["MobNo"]),
                            ProductID = ds.Tables[0].Rows[i]["ProductID"] == DBNull.Value ? 0 : Convert.ToInt32(ds.Tables[0].Rows[i]["ProductID"]),
                            BrandName = ds.Tables[0].Rows[i]["BrandName"] == DBNull.Value ? string.Empty : Convert.ToString(ds.Tables[0].Rows[i]["BrandName"]),
                            OrganisationName = ds.Tables[0].Rows[i]["OrganisationName"] == DBNull.Value ? string.Empty : Convert.ToString(ds.Tables[0].Rows[i]["OrganisationName"]),
                            TechnicalName = ds.Tables[0].Rows[i]["TechnicalName"] == DBNull.Value ? string.Empty : Convert.ToString(ds.Tables[0].Rows[i]["TechnicalName"]),
                            ProductName = ds.Tables[0].Rows[i]["ProductName"] == DBNull.Value ? string.Empty : Convert.ToString(ds.Tables[0].Rows[i]["ProductName"]),
                            Amount = ds.Tables[0].Rows[i]["Amount"] == DBNull.Value ? 0 : Convert.ToDecimal(ds.Tables[0].Rows[i]["Amount"]),
                            UnitName = ds.Tables[0].Rows[i]["UnitName"] == DBNull.Value ? string.Empty : Convert.ToString(ds.Tables[0].Rows[i]["UnitName"]),
                            OurPrice = ds.Tables[0].Rows[i]["OurPrice"] == DBNull.Value ? 0 : Convert.ToDecimal(ds.Tables[0].Rows[i]["OurPrice"]),
                            OtherCharges = ds.Tables[0].Rows[i]["OtherCharges"] == DBNull.Value ? 0 : Convert.ToDecimal(ds.Tables[0].Rows[i]["OtherCharges"]),
                            DiscType = ds.Tables[0].Rows[i]["DiscType"] == DBNull.Value ? string.Empty : Convert.ToString(ds.Tables[0].Rows[i]["DiscType"]),
                            DiscAmt = ds.Tables[0].Rows[i]["DiscAmt"] == DBNull.Value ? 0 : Convert.ToDecimal(ds.Tables[0].Rows[i]["DiscAmt"]),
                            Subtotal = ds.Tables[0].Rows[i]["Subtotal"] == DBNull.Value ? 0 : Convert.ToDecimal(ds.Tables[0].Rows[i]["Subtotal"]),
                            HandleChages = ds.Tables[0].Rows[i]["HandleChages"] == DBNull.Value ? 0 : Convert.ToDecimal(ds.Tables[0].Rows[i]["HandleChages"]),
                            DiscountedAmount = ds.Tables[0].Rows[i]["DiscountedAmount"] == DBNull.Value ? 0 : Convert.ToDecimal(ds.Tables[0].Rows[i]["DiscountedAmount"]),
                            DealerID = ds.Tables[0].Rows[i]["DealerID"] == DBNull.Value ? 0 : Convert.ToInt32(ds.Tables[0].Rows[i]["DealerID"]),
                            DealerName = ds.Tables[0].Rows[i]["DealerName"] == DBNull.Value ? string.Empty : Convert.ToString(ds.Tables[0].Rows[i]["DealerName"]),
                            DiscText = ds.Tables[0].Rows[i]["DiscText"] == DBNull.Value ? string.Empty : Convert.ToString(ds.Tables[0].Rows[i]["DiscText"]),
                            TotalPayableAmount_In_Word = ds.Tables[0].Rows[i]["TotalPayableAmount_In_Word"] == DBNull.Value ? string.Empty : Convert.ToString(ds.Tables[0].Rows[i]["TotalPayableAmount_In_Word"]),
                            TotalPayableAmount = ds.Tables[0].Rows[i]["TotalPayableAmount"] == DBNull.Value ? 0 : Convert.ToDecimal(ds.Tables[0].Rows[i]["TotalPayableAmount"]),
                            CreatedDate = ds.Tables[0].Rows[i]["CreatedDate"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(ds.Tables[0].Rows[i]["CreatedDate"]),
                            DeliveryInstruction = ds.Tables[0].Rows[i]["DeliveryInstruction"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(ds.Tables[0].Rows[i]["DeliveryInstruction"]),
                            ProcessedDate = ds.Tables[0].Rows[i]["ProcessedDate"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(ds.Tables[0].Rows[i]["ProcessedDate"]),
                            SubCategoryId = ds.Tables[0].Rows[i]["SubCategoryId"] == DBNull.Value ? 0 : Convert.ToInt32(ds.Tables[0].Rows[i]["SubCategoryId"]),
                            PanNo = ds.Tables[0].Rows[i]["PanNo"] == DBNull.Value ? string.Empty : Convert.ToString(ds.Tables[0].Rows[i]["PanNo"]),
                            GstNumber = ds.Tables[0].Rows[i]["GstNumber"] == DBNull.Value ? string.Empty : Convert.ToString(ds.Tables[0].Rows[i]["GstNumber"]),
                            DealerStateName = ds.Tables[0].Rows[i]["DealerStateName"] == DBNull.Value ? string.Empty : Convert.ToString(ds.Tables[0].Rows[i]["DealerStateName"]),
                            DealerDistrictName = ds.Tables[0].Rows[i]["DealerDistrictName"] == DBNull.Value ? string.Empty : Convert.ToString(ds.Tables[0].Rows[i]["DealerDistrictName"]),
                            DealerBlockName = ds.Tables[0].Rows[i]["DealerBlockName"] == DBNull.Value ? string.Empty : Convert.ToString(ds.Tables[0].Rows[i]["DealerBlockName"]),
                            DealerVillageName = ds.Tables[0].Rows[i]["DealerVillageName"] == DBNull.Value ? string.Empty : Convert.ToString(ds.Tables[0].Rows[i]["DealerVillageName"]),
                            DealerAddress = ds.Tables[0].Rows[i]["DealerAddress"] == DBNull.Value ? string.Empty : Convert.ToString(ds.Tables[0].Rows[i]["DealerAddress"]),
                            HsnCode = ds.Tables[0].Rows[i]["HsnCode"] == DBNull.Value ? string.Empty : Convert.ToString(ds.Tables[0].Rows[i]["HsnCode"]),
                            Cgst = ds.Tables[0].Rows[i]["Cgst"] == DBNull.Value ? 0 : Convert.ToDecimal(ds.Tables[0].Rows[i]["Cgst"]),
                            Igst = ds.Tables[0].Rows[i]["Igst"] == DBNull.Value ? 0 : Convert.ToDecimal(ds.Tables[0].Rows[i]["Igst"]),
                            Sgst = ds.Tables[0].Rows[i]["Sgst"] == DBNull.Value ? 0 : Convert.ToDecimal(ds.Tables[0].Rows[i]["Sgst"]),
                            Invoice_No = ds.Tables[0].Rows[i]["Invoice_No"] == DBNull.Value ? string.Empty : Convert.ToString(ds.Tables[0].Rows[i]["Invoice_No"]),
                            RecordId = ds.Tables[0].Rows[i]["RecordId"] == DBNull.Value ? 0 : Convert.ToInt64(ds.Tables[0].Rows[i]["RecordId"])
                        });
                    }
                }
            }
            return podDetailReportList;
        }
        public static DataSet FoPickedProductDetails(int stateid, int? districtid, int? dealerid, int? foId)
        { 
            DataSet ds = new LogData().FoPickedProductDetails(stateid, districtid, dealerid, foId);
            return ds;

        }
    }
}