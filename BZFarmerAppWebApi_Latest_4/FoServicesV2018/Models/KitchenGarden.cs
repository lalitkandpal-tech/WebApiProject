using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace FoServicesV2018.Models
{
    public class KitchenGarden
    {
        public static DataSet GetKGPCategory(string version,string Type,int Id)
        {
            DataSet ds = new LogData().GetKGPCategory(version,Type,Id);
            return ds;
        }
        public static DataSet GetKGPSubCategory(string version, string Type, int Id)
        {
            DataSet ds = new LogData().GetKGPSubCategory(version, Type, Id);
            return ds;
        }
        public static DataSet GetKGP_Products(string version, int KGP_CategoryId, int KGP_SubCategoryId, int DistrictId, string DistrictName, string PinCode, int PageIndex, int PageSize)
        {
            DataSet ds = new LogData().GetKGP_Products(version, KGP_CategoryId, KGP_SubCategoryId, DistrictId, DistrictName, PinCode, PageIndex, PageSize);
            return ds;
        }
        public static DataSet GetKGPCategoryFilters(string version,string lang,int? KGP_CategoryId)
        {
            DataSet ds = new LogData().GetKGPCategoryFilters(version,lang, KGP_CategoryId);
            return ds;
        }
        
    }
}