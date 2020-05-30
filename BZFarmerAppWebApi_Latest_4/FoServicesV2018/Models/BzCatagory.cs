using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace FoServicesV2018.Models
{
    public class BzCatagory
    {
        public static DataSet AppCatagory(string version,string x_StateName,string x_DistrictName,int KGP)
        {
            DataSet ds = new LogData().AppCatagory( version, x_StateName, x_DistrictName,KGP);
            return ds;

        }
        public static DataSet AppProductBanner(string version, string x_StateName, string x_DistrictName)
        {
            DataSet ds = new LogData().AppProductBanner(version, x_StateName, x_DistrictName);
            return ds;

        }
        public static DataSet ActiveBrands(string version, string x_StateName, string x_DistrictName)
        {
            DataSet ds = new LogData().ActiveBrands(version, x_StateName, x_DistrictName);
            return ds;
        }

        public static DataSet AppMainCategory(string version)
        {
            DataSet ds = new LogData().AppMainCategory(version);
            return ds;

        }
        public static DataSet AppMainCategoryObjects(string version, int MainCategoryId, int SeasonId)
        {
            DataSet ds = new LogData().AppMainCategoryObjects(version, MainCategoryId, SeasonId);
            return ds;

        }
        public static DataSet AppSeasonCrop(string version, int MainCategoryId)
        {
            DataSet ds = new LogData().AppSeasonCrop(version, MainCategoryId);
            return ds;

        }
        public static DataSet GetPaymentOption(string version)
        {
            DataSet ds = new LogData().GetPaymentOption(version);
            return ds;
        }
        public static DataSet GetFarmerAddress(string version, int FarmerID)
        {
            DataSet ds = new LogData().GetFarmerAddress(version, FarmerID);
            return ds;
        }
        public static DataSet GetBZFAQ(string version, string SearchCriteria, int MainCategoryId, int Id, string OptionText)
        {
            DataSet ds = new LogData().GetBZFAQ(version, SearchCriteria, MainCategoryId, Id, OptionText);
            return ds;
        }

        public static DataSet GetBZTips(string version, string SearchCriteria, int MainCategoryId, int Id, string OptionText)
        {
            DataSet ds = new LogData().GetBZTips(version, SearchCriteria, MainCategoryId, Id,OptionText);
            return ds;
        }
        public static DataSet BZLeftMenu(string version, string x_StateName, string x_DistrictName)
        {
            DataSet ds = new LogData().BZLeftMenu(version, x_StateName, x_DistrictName);
            return ds;
        }
        public static DataSet GetBZFAQCategoryList(string version)
        {
            DataSet ds = new LogData().GetBZFAQCategoryList(version);
            return ds;
        }
        public static DataSet GetBZFAQList(string version,string Name)
        {
            DataSet ds = new LogData().GetBZFAQList(version, Name);
            return ds;
        }
        public static DataSet GetCouponValidity(int AgentId, int PackageId,string CouponCode,int Quantity,int TxnValue)
        {
            DataSet ds = new LogData().GetCouponValidity(AgentId, PackageId,CouponCode,Quantity,TxnValue);
            return ds;
        }
        public static DataSet InsertAgentCoupons(int OrderId,string CouponCode, int AgentId)
        {
            DataSet ds = new LogData().InsertAgentCoupons(OrderId, CouponCode, AgentId);
            return ds;
        }
    }
}