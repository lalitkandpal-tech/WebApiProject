using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Common;
using System.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using Entity;
using DataLayer;
using System.Reflection;
using FoServicesV2018.Entity;

namespace FoServicesV2018.Models
{
    public class LogData
    {
        static Database objDB;
        static LogData()
        {
            objDB = new SqlDatabase(ConfigurationManager.ConnectionStrings["connection"].ToString());
        }
        public static void DownloadHistoryLog(string filter, string fileName, int downloadById)
        {
            using (var _obj = objDB.GetStoredProcCommand(Constant.SPInsertDownloadHistory, filter, fileName, downloadById))
            {
                var flag = objDB.ExecuteNonQuery(_obj);
            }
        }
        public DataSet GetFoPickUp(int mode, DateTime fromOrderDate, DateTime toOrderDate, int districtId)
        {
            using (var objcmd = objDB.GetStoredProcCommand(Constant.SPReportFOPickup, fromOrderDate, toOrderDate, districtId, null))
            {
                var dataset = objDB.ExecuteDataSet(objcmd);

                return dataset;
            }
        }
        public DataSet GetFoByOrderSheetDetails(DateTime fromOrderDate, DateTime toOrderDate, int districtId, int foId)
        {
            using (var objcmd = objDB.GetStoredProcCommand(Constant.SPFOBYORDERLIST, fromOrderDate, toOrderDate, districtId, foId))
            {
                objcmd.CommandTimeout = 300;
                var dataset = objDB.ExecuteDataSet(objcmd);

                return dataset;
            }
        }
        public DataSet GetDealerOrderSheetDetails(DateTime fromOrderDate, DateTime toOrderDate, int districtId, int dealerId)
        {
            using (var objcmd = objDB.GetStoredProcCommand(Constant.SPDISTRIBUTORORDERLIST, fromOrderDate, toOrderDate, districtId, dealerId))
            {
                var dataset = objDB.ExecuteDataSet(objcmd);

                return dataset;
            }
        }
        public DataSet GetPodDetailFoReport(string orderId, int tripId, int districtId, DateTime fromOrderDate, DateTime toOrderDate, int foId, string type)
        {
            using (var objcmd = objDB.GetStoredProcCommand(Constant.SPFoPodDetailv2, orderId, tripId, districtId, fromOrderDate, toOrderDate, foId, type))
            {
                var dataset = objDB.ExecuteDataSet(objcmd);
                return dataset;
            }
        }
        public DataSet FoPickedProductDetails(int stateid, int? districtid, int? dealerid, int? foId)
        {
            using (var objcmd = objDB.GetStoredProcCommand(Constant.spGetDealerFoPickedProductDetails, stateid, districtid, dealerid, foId))
            {
                var dataset = objDB.ExecuteDataSet(objcmd);
                return dataset;
            }
        }
        public DataSet GetLiveStock(int LiveStockID, int BreedId, int MilkAmount, string Mode, string version)
        {
            using (var objcmd = objDB.GetStoredProcCommand(Constant.spGETLSTLiveStock, LiveStockID, BreedId, MilkAmount, Mode))
            {
                var dataset = objDB.ExecuteDataSet(objcmd);
                return dataset;
            }
        }
        public DataSet GetStageAndProducts(int LiveStockId, int? BreedId, int? MilkAmount, int? DistrictId, string version)
        {
            using (var objcmd = objDB.GetStoredProcCommand(Constant.uspGETLiveStockStageAndProduct, LiveStockId, BreedId, MilkAmount, DistrictId))
            {
                var dataset = objDB.ExecuteDataSet(objcmd);
                return dataset;
            }
        }
        public DataSet GetLiveStockAndBread(int LiveStockId, int? BreedId, string version)
        {
            using (var objcmd = objDB.GetStoredProcCommand(Constant.UspGetLivestockandBread, LiveStockId, BreedId))
            {
                var dataset = objDB.ExecuteDataSet(objcmd);
                return dataset;
            }
        }
        public DataSet AppServices(string Version,string x_StateName,string x_DistrictName)
        {
            using (var objcmd = objDB.GetStoredProcCommand(Constant.uspTblBzFarmerAppServices, Version, x_StateName, x_DistrictName))
            {
                var dataset = objDB.ExecuteDataSet(objcmd);
                return dataset;
            }
        }
        public DataSet GetBZLiveStock(string AppVersion)
        {
            using (var objcmd = objDB.GetStoredProcCommand(Constant.uspGetBZLiveStock, AppVersion))
            {
                var dataset = objDB.ExecuteDataSet(objcmd);
                return dataset;
            }
        }
        public DataSet BZLiveStockBreed(int LiveStockId, string AppVersion)
        {
            using (var objcmd = objDB.GetStoredProcCommand(Constant.uspGetBZLiveStockBreed, AppVersion,LiveStockId))
            {
                var dataset = objDB.ExecuteDataSet(objcmd);
                return dataset;
            }
        }
        public DataSet AppCatagory( string Appversion, string x_StateName,string x_DistrictName,int KGP)
        {
            using (var objcmd = objDB.GetStoredProcCommand(Constant.GetBZCategorySubCategory, Appversion, x_StateName, x_DistrictName,KGP))
            {
                var dataset = objDB.ExecuteDataSet(objcmd);
                return dataset;
            }
        }

        public DataSet BZTrendsProducts(string version, string x_StateName, string x_DistrictName)
        {
            using (var objcmd = objDB.GetStoredProcCommand(Constant.uspTrendsProduct, x_StateName, x_DistrictName))
            {
                var dataset = objDB.ExecuteDataSet(objcmd);
                return dataset;
            }
        }
       
        
        public DataSet CropProduct(int CropID, int StageID, int? DistrictId, string version)
        {
            using (var objcmd = objDB.GetStoredProcCommand(Constant.uspProductByCategory, CropID, StageID, DistrictId))
            {
                var dataset = objDB.ExecuteDataSet(objcmd);
                return dataset;
            }
        }
        
        public DataSet AppProductBanner(string version, string x_StateName, string x_DistrictName)
        {
            using (var objcmd = objDB.GetStoredProcCommand(Constant.UspGetBZProductBanner, x_StateName, x_DistrictName))
            {
                var dataset = objDB.ExecuteDataSet(objcmd);
                return dataset;
            }
        }
        public DataSet ActiveBrands(string version,string x_StateName,string x_DistrictName)
        {
            using (var objcmd = objDB.GetStoredProcCommand(Constant.uspTblBzAppActiveBrands, x_StateName, x_DistrictName))
            {
                var dataset = objDB.ExecuteDataSet(objcmd);
                return dataset;
            }
        }
        public DataSet AppMainCategory(string version)
        {
            using (var objcmd = objDB.GetStoredProcCommand(Constant.GetBZMainCategory, version))
            {
                var dataset = objDB.ExecuteDataSet(objcmd);
                return dataset;
            }
        }
        public DataSet AppMainCategoryObjects(string version, int MainCategoryId, int SeasonId)
        {
            using (var objcmd = objDB.GetStoredProcCommand(Constant.GetBZMainCategoryObjects, version, MainCategoryId, SeasonId))
            {
                var dataset = objDB.ExecuteDataSet(objcmd);
                return dataset;
            }
        }
        public DataSet AppSeasonCrop(string version, int MainCategoryId)
        {
            using (var objcmd = objDB.GetStoredProcCommand(Constant.GetBZUspGetcropseasons, version, MainCategoryId))
            {
                var dataset = objDB.ExecuteDataSet(objcmd);
                return dataset;
            }
        }
        public DataSet GetBzAppProductDetails(string version, int CategoryId, int ProductId)
        {
            using (var objcmd = objDB.GetStoredProcCommand(Constant.UspGetBzAppProductDetails, CategoryId, ProductId))
            {
                var dataset = objDB.ExecuteDataSet(objcmd);
                return dataset;
            }
        }
        public DataSet GetPaymentOption(string version)
        {
            using (var objcmd = objDB.GetStoredProcCommand(Constant.uspPaymentOption, version))
            {
                var dataset = objDB.ExecuteDataSet(objcmd);
                return dataset;
            }
        }
        public DataSet GetFarmerAddress(string version, int FarmerID)
        {
            using (var objcmd = objDB.GetStoredProcCommand(Constant.uspGetAddress, version, FarmerID))
            {
                var dataset = objDB.ExecuteDataSet(objcmd);
                return dataset;
            }
        }
        public DataSet GetBzAppProductDetails(string version, int CategoryId, int ProductId, int DistrictId)
        {
            using (var objcmd = objDB.GetStoredProcCommand(Constant.UspGetBzAppProductDetails, CategoryId, ProductId, DistrictId))
            {
                var dataset = objDB.ExecuteDataSet(objcmd);
                return dataset;
            }
        }

        public DataSet GetBZFAQ(string version, string SearchCriteria, int MainCategoryId, int Id, string OptionText)
        {
            using (var objcmd = objDB.GetStoredProcCommand(Constant.uspGetBzFAQ, SearchCriteria, MainCategoryId, Id, OptionText))
            {
                var dataset = objDB.ExecuteDataSet(objcmd);
                return dataset;
            }
        }

        public DataSet GetBZTips(string version, string SearchCriteria, int MainCategoryId, int Id, string OptionText)
        {
            using (var objcmd = objDB.GetStoredProcCommand(Constant.uspGetBzTips, SearchCriteria, MainCategoryId, Id,OptionText))
            {
                var dataset = objDB.ExecuteDataSet(objcmd);
                return dataset;
            }
        }
        public DataSet GetCropStages(int CropId,int? DistrictId, string version,int? FarmerId)
        {
            using (var objcmd = objDB.GetStoredProcCommand(Constant.uspGetCropStages, CropId, DistrictId, FarmerId))
            {
                var dataset = objDB.ExecuteDataSet(objcmd);
                return dataset;
            }
        } 
        public DataSet GetTodayOfferProducts(string version,int? CategoryId, string x_StateName, string x_DistrictName)
        {
            using (var objcmd = objDB.GetStoredProcCommand(Constant.SPBZPRODUCTLISTTodayOffer, CategoryId, x_StateName, x_DistrictName))
            {
                var dataset = objDB.ExecuteDataSet(objcmd);
                return dataset;
            }
        }
        public DataSet GetCategoryWiseProduct(string version,int? CategoryId, int? SubCategoryId,int DistrictId, int? BrandID, int PageIndex, int PageSize)
        {
            using (var objcmd = objDB.GetStoredProcCommand(Constant.USPBZPRODUCTLIST, CategoryId,SubCategoryId, BrandID, DistrictId, PageIndex, PageSize))
            {
                var dataset = objDB.ExecuteDataSet(objcmd);
                return dataset;
            }
        }
        public DataSet GetCropDetails(string version, int? CategoryId)
        {
            using (var objcmd = objDB.GetStoredProcCommand(Constant.SPGetCrops, CategoryId))
            {
                var dataset = objDB.ExecuteDataSet(objcmd);
                return dataset;
            }
        }
        public DataSet GetSubCategories(string version, int? CategoryId, bool IsActive, string x_StateName, string x_DistrictName)
        {
            using (var objcmd = objDB.GetStoredProcCommand(Constant.USPGetSubCategory))
            {
                objDB.AddInParameter(objcmd, "x_StateName", DbType.String, x_StateName);
                objDB.AddInParameter(objcmd, "x_DistrictName", DbType.String, x_DistrictName);
                objDB.AddInParameter(objcmd, "CategoryId", DbType.Int32, CategoryId);
                objDB.AddInParameter(objcmd, "OnlyActive", DbType.Boolean, IsActive);
                DataSet ds = objDB.ExecuteDataSet(objcmd);
                return ds;
            }
        }
        public DataSet GetBZCropList(string version)
        {
            using (var objcmd = objDB.GetStoredProcCommand(Constant.uspGetBZCropList))
            {
                var dataset = objDB.ExecuteDataSet(objcmd);
                return dataset;
            }
        }
        public DataSet BZLeftMenu(string AppVersion, string x_StateName, string x_DistrictName)
        {
            using (var objcmd = objDB.GetStoredProcCommand(Constant.usp_GetBZLeftMenu, AppVersion, x_StateName, x_DistrictName))
            {
                var dataset = objDB.ExecuteDataSet(objcmd);
                return dataset;
            }
        }
        public DataSet InsertFarmDetail(int Id,int FarmerId,DateTime FarmingDuration,string FarmArea,bool IsStatus,int CropId)
        {
            using (var objcmd = objDB.GetStoredProcCommand(Constant.uspTblCropPOPPopup,Id, FarmerId, FarmingDuration, FarmArea,IsStatus, CropId))
            {
                var dataset = objDB.ExecuteDataSet(objcmd);
                return dataset;
            }
        }
        public DataSet GetBZCropBreedList(string AppVersion,int CropId)
        {
            using (var objcmd = objDB.GetStoredProcCommand(Constant.uspGetCropBreed, AppVersion, CropId))
            {
                var dataset = objDB.ExecuteDataSet(objcmd);
                return dataset;
            }
        }
        public DataSet GetBZFAQCategoryList(string AppVersion)
        {
            using (var objcmd = objDB.GetStoredProcCommand(Constant.FAQCategoryList))
            {
                var dataset = objDB.ExecuteDataSet(objcmd);
                return dataset;
            }
        }
        public DataSet GetBZFAQList(string version, string Name)
        {
            using (var objcmd = objDB.GetStoredProcCommand(Constant.uspGetBzFAQData, version,Name))
            {
                var dataset = objDB.ExecuteDataSet(objcmd);
                return dataset;
            }
        }
        public DataSet GetBZTipsList(string version, string Name)
        {
            using (var objcmd = objDB.GetStoredProcCommand(Constant.uspGetBzTipsData, version, Name))
            {
                var dataset = objDB.ExecuteDataSet(objcmd);
                return dataset;
            }
        }
        public DataSet GetKGPCategory(string version, string Type, int Id)
        {
            using (var objcmd = objDB.GetStoredProcCommand(Constant.uspGetBzCategorySubCategory, version, Type, Id))
            {
                var dataset = objDB.ExecuteDataSet(objcmd);
                return dataset;
            }
        }
        public DataSet GetKGPSubCategory(string version, string Type, int Id)
        {
            using (var objcmd = objDB.GetStoredProcCommand(Constant.uspGetBzCategorySubCategory, version, Type, Id))
            {
                var dataset = objDB.ExecuteDataSet(objcmd);
                return dataset;
            }
        }

        public DataSet GetKGP_Products(string version, int KGP_CategoryId, int KGP_SubCategoryId, int DistrictId, string DistrictName, string PinCode, int PageIndex, int PageSize)
        {
            using (var objcmd = objDB.GetStoredProcCommand(Constant.uspGetKGPProducts, version, KGP_CategoryId, KGP_SubCategoryId, DistrictId, DistrictName, PinCode, PageIndex, PageSize))
            {
                var dataset = objDB.ExecuteDataSet(objcmd);
                return dataset;
            }
        }
        public DataSet GetKGPCategoryFilters(string version,string lang,int? KGP_CategoryId)
        {
            using (var objcmd = objDB.GetStoredProcCommand(Constant.uspGetBzCategorySubCategory, version,lang, KGP_CategoryId))
            {
                var dataset = objDB.ExecuteDataSet(objcmd);
                return dataset;
            }
        }



        public DataSet GetBzWebsiteProducts(string version, int CategoryId)
        {
            using (var objcmd = objDB.GetStoredProcCommand(Constant.uspBzWebsiteProducts, CategoryId))
            {
                var dataset = objDB.ExecuteDataSet(objcmd);
                return dataset;
            }
        }
        public DataSet GetBzPackages(string version, int ProductId)
        {
            using (var objcmd = objDB.GetStoredProcCommand(Constant.uspBzWebsitePackages, ProductId))
            {
                var dataset = objDB.ExecuteDataSet(objcmd);
                return dataset;
            }
        }

        public DataSet GetBzCategoryForProductDetail(int Id, string Type)
        {
            using (var objcmd = objDB.GetStoredProcCommand(Constant.uspBzGetCategoryforDetails, Id,Type))
            {
                var dataset = objDB.ExecuteDataSet(objcmd);
                return dataset;
            }
        }

        public DataSet GetSathiAppProductDetails(string version,int CategoryId, int BzProductId, int PackageId)
        {
            using (var objcmd = objDB.GetStoredProcCommand(Constant.UspGetSathiAppProductDetails, CategoryId, BzProductId, PackageId))
            {
                var dataset = objDB.ExecuteDataSet(objcmd);
                return dataset;
            }
        }

        public AddtoCartResult AddToCart(string InType, int CartItemId, string UserId, int BzProductId, int quantity)
        {
            AddtoCartResult objDataObject = new AddtoCartResult();
            try
            {
                using (var objcmd = objDB.GetStoredProcCommand(Constant.uspSaveUpdateCartHistory, InType, CartItemId, UserId, BzProductId, quantity))
                {
                    int flag = 0;
                    flag = objDB.ExecuteNonQuery(objcmd);
                    if (flag >= 1)
                    {
                        objDataObject.Status = flag;
                    }
                    LogDal.MethodCallLog(this.GetType().Name, MethodBase.GetCurrentMethod().Name);
                }
            }
            catch (Exception ex)
            {
                LogDal.ErrorLog(this.GetType().Name, MethodBase.GetCurrentMethod().Name, ex.Message, CartItemId);
            }
            return objDataObject;
        }
        
        public DataSet GetBzAppProductDetailsNew(string version, int ProductId, int Districtid)//, int PackageId
        {

            using (var objcmd = objDB.GetStoredProcCommand(Constant.UspGetBzAppProductDetailsNew, ProductId, Districtid))
            {
                var dataset = objDB.ExecuteDataSet(objcmd);
                return dataset;
            }
        }
        public DataSet GetCartItems(string version, string x_StateName, string x_DistrictName, string UserId)
        {
            using (var objcmd = objDB.GetStoredProcCommand(Constant.uspGetCartITems, x_StateName, x_DistrictName, UserId))
            {
                var dataset = objDB.ExecuteDataSet(objcmd);
                return dataset;
            }
        }


        //Delight Functions
        public int DelightPushOrderDetail(string BatchNumber, string BatchDate, string BranchID, string BranchName, string LoanApprovaldate, string LoanProposalID,
                                          string ProposalID, string ClientID, string ClientUniqueID, string ClientName, string ProductID, string Model, decimal MemberOfferPrice,
                                          string VendorId, string SupplierName, string AddressLine1, string AddressLine2, string Landmark, string Village, string DistrictName,
                                          string StateName, string Pincode, string MobileNumber, string MemberAlternateMobileNumber, string SpouseName, string FatherName,
                                          string SMName, string SMNumber, string BMName, string BMNumber, string Status, string Text1, string Text2, string Numeric1, string Numeric2)
        {
            using (var objcmd = objDB.GetStoredProcCommand(Constant.uspDelightPushOrders, BatchNumber, BatchDate,
                                                            //DateTime.ParseExact(BatchDate, "dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("MM/dd/yyyy", CultureInfo.InvariantCulture),
                                                            BranchID, BranchName, LoanApprovaldate,
                                                            // DateTime.ParseExact(LoanApprovaldate, "dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("MM/dd/yyyy", CultureInfo.InvariantCulture),
                                                            LoanProposalID,
                                            ProposalID, ClientID, ClientUniqueID, ClientName, ProductID, Model, MemberOfferPrice, VendorId, SupplierName, AddressLine1,
                                            AddressLine2, Landmark, Village, DistrictName, StateName, Pincode, MobileNumber, MemberAlternateMobileNumber, SpouseName,
                                            FatherName, SMName, SMNumber, BMName, BMNumber, Status, Text1, Text2, Numeric1, Numeric2))
            {
                int result = objDB.ExecuteNonQuery(objcmd);
                return result;
            }
        }



        public DataSet GetProductsBySearch(string version,string x_StateName,string x_DistrictName, string SearchText)
        {
            using (var objcmd = objDB.GetStoredProcCommand(Constant.usp_GetProductsBySearch, x_StateName, x_DistrictName, SearchText))
            {
                var dataset = objDB.ExecuteDataSet(objcmd);
                return dataset;
            }
        }

        public DataSet GetBehtarBachatOffer(string version, string x_StateName, string x_DistrictName)
        {
            using (var objcmd = objDB.GetStoredProcCommand(Constant.uspBehtarBachatOffer, x_StateName, x_DistrictName))
            {
                var dataset = objDB.ExecuteDataSet(objcmd);
                return dataset;
            }
        }

        public DataSet GetHumTumOffer(string version, string x_StateName, string x_DistrictName)
        {
            using (var objcmd = objDB.GetStoredProcCommand(Constant.uspHumTumOffer, x_StateName, x_DistrictName))
            {
                var dataset = objDB.ExecuteDataSet(objcmd);
                return dataset;
            }
        }

        public DataSet GetOrderTracking(string version, int UserId)
        {
            using (var objcmd = objDB.GetStoredProcCommand(Constant.usp_GetOrderTracking, UserId))
            {
                var dataset = objDB.ExecuteDataSet(objcmd);
                return dataset;
            }
        }

        public DataSet GetOrderTrackingStatus(string version, string OrderId)
        {
            using (var objcmd = objDB.GetStoredProcCommand(Constant.usp_GetOrderTrackingStatus, OrderId))
            {
                var dataset = objDB.ExecuteDataSet(objcmd);
                return dataset;
            }
        }

        public DataSet GetCouponValidity(int AgentId, int PackageId,string CouponCode,int Quantity,int TxnValue)
        {
            using (var objcmd = objDB.GetStoredProcCommand(Constant.usp_CheckValidityOfAgentCoupon, AgentId, PackageId,CouponCode,Quantity,TxnValue))
            {
                var dataset = objDB.ExecuteDataSet(objcmd);
                return dataset;
            }
        }
        public DataSet InsertAgentCoupons(int OrderId, string CouponCode, int AgentId)
        {
            using (var objcmd = objDB.GetStoredProcCommand(Constant.usp_InsertAgentCoupon, OrderId, CouponCode, AgentId))
            {
                var dataset = objDB.ExecuteDataSet(objcmd);
                return dataset;
            }
        }
    }
}