using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace FoServicesV2018.Models
{
    public class LiveStocks
    {
        public int Id { get; set; }
        public string NAME { get; set; }
        public int extra { get; set; }
        public static DataSet GetLiveStock(int LiveStockID,int BreedId,int MilkAmount, string Mode, string version)
        {
            DataSet ds = new LogData().GetLiveStock(LiveStockID,BreedId,MilkAmount, Mode,version);
            return ds;

        }
        public static DataSet GetStageAndProducts(int LiveStockID, int? BreedId, int? MilkAmount, int? DistrictId, string version)
        {
            DataSet ds = new LogData().GetStageAndProducts(LiveStockID, BreedId, MilkAmount, DistrictId, version);
            return ds;

        } 
        public static DataSet AppServices(string Version,string x_StateName,string x_DistrictName)
        {
            DataSet ds = new LogData().AppServices(Version, x_StateName, x_DistrictName);
            return ds;

        }
        public static DataSet BZLiveStock(string AppVersion)
        {
            DataSet ds = new LogData().GetBZLiveStock(AppVersion);
            return ds;
        }
        public static DataSet BZLiveStockBreed(int LiveStockId, string AppVersion)
        {
            DataSet ds = new LogData().BZLiveStockBreed(LiveStockId, AppVersion);
            return ds;
        }
        public static DataSet BZTrendsProducts(string version, string x_StateName, string x_DistrictName)
        {
            DataSet ds = new LogData().BZTrendsProducts(version, x_StateName, x_DistrictName);
            return ds;
        }
        
        public static DataSet BZCropProducts(int CropID, int StageID, int? DistrictId, string version)
        {
            DataSet ds = new LogData().CropProduct(CropID, StageID, DistrictId, version);
            return ds;
        }
        
        public static DataSet GetBzAppProductDetails(string version, int CategoryId, int ProductId, int DistrictId)
        {
            DataSet ds = new LogData().GetBzAppProductDetails(version, CategoryId, ProductId, DistrictId);
            return ds;
        }
        public static DataSet GetTodayOfferProducts(string version,int? CategoryId, string x_StateName,string x_DistrictName)
        {
            DataSet ds = new LogData().GetTodayOfferProducts(version, CategoryId, x_StateName, x_DistrictName);
            return ds;
        }
        public static DataSet GetCategoryWiseProduct(string version,int? CategoryId, int? SubCategoryId,int DistrictId, int? BrandId, int PageIndex, int PageSize)
        {
            DataSet ds = new LogData().GetCategoryWiseProduct(version, CategoryId,SubCategoryId, DistrictId, BrandId, PageIndex,PageSize);
            return ds;
        }
        public static DataSet GetCropDetails(string version, int? CategoryId)
        {
            DataSet ds = new LogData().GetCropDetails(version, CategoryId);
            return ds;
        }
        public static DataSet GetSubCategories(string version,int? CategoryId, bool IsActive, string x_StateName, string x_DistrictName)
        {
            DataSet ds = new LogData().GetSubCategories(version, CategoryId,IsActive, x_StateName, x_DistrictName);
            return ds;
           
        }
        public static DataSet GetLiveStockAndBread(int LiveStockID, int? BreedId, string version)
        {
            DataSet ds = new LogData().GetLiveStockAndBread(LiveStockID, BreedId, version);
            return ds;
        }
        public static DataSet GetSathiAppProductDetails(string version,int CategoryId, int BzProductId, int PackageId)
        {
            DataSet ds = new LogData().GetSathiAppProductDetails(version, CategoryId, BzProductId, PackageId);
            return ds;
        }
        public static DataSet GetBzAppProductDetailsNew(string version, int ProductId, int Districtid)// , int PackageId
        {
            DataSet ds = new LogData().GetBzAppProductDetailsNew(version, ProductId, Districtid);
            return ds;
        }

        public static DataSet GetProductsBySearch(string version,string x_StateName,string x_DistrictName, string SearchText)
        {
            DataSet ds = new LogData().GetProductsBySearch(version, x_StateName, x_DistrictName, SearchText);
            return ds;
        }

        public static DataSet GetBehtarBachatOffer(string version, string x_StateName, string x_DistrictName)
        {
            DataSet ds = new LogData().GetBehtarBachatOffer(version, x_StateName, x_DistrictName);
            return ds;
        }
        public static DataSet GetHumTumOffer(string version, string x_StateName, string x_DistrictName)
        {
            DataSet ds = new LogData().GetHumTumOffer(version, x_StateName, x_DistrictName);
            return ds;
        }
    }

    public class LiveStockDetails
    {
        public LiveStocksType LiveStocksType { get; set; }
    }
    public class LiveStocksType
    {
        public string Animal { get; set; }
        public string AnimalType { get; set; }
        public string Milk { get; set; }
    }




}