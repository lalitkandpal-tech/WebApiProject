using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoServicesV2018.Models
{
    public class Constant
    {
        public const string SPInsertDownloadHistory = "SP_InsertDownloadHistory";
        public const string SPReportFOPickup = "USP_FO_Pickup";
        public const string SPFOBYORDERLIST = "SP_FOBYORDERLIST";
        public const string SPDISTRIBUTORORDERLIST = "SP_DISTRIBUTORORDERLIST";
        public const string SPFoPodDetailv2 = "SP_PODDETAIL_v3";
        public const string INVOICE = "INVOICE";
        public const string spGetDealerFoPickedProductDetails = "Usp_GetDealerFoPickedProductDetails_new";
        public const string spGETLSTLiveStock = "SP_GETLST_LiveStock";
        public const string uspGETLiveStockStageAndProduct = "Usp_GetLivestockStageAnd_Products";//"SP_GETLST_LiveStock";
        public const string uspTblBzFarmerAppServices = "usp_Tbl_BzFarmerAppServices";
        public const string uspGetBZLiveStock = "usp_GetBZLiveStock";
        public const string uspGetBZLiveStockBreed = "usp_GetBZLiveStockBreed";
        public const string GetBZCategorySubCategory = "usp_GetBZCategorySubCategory";
        public const string uspTrendsProduct = "TrendsProduct";
        public const string UspGetBZProductBanner = "Usp_GetBZAppProductBanner"; //"Usp_GetBZProductBanner";
        public const string uspTblBzAppActiveBrands = "usp_Tbl_BzAppActiveBrands";
        public const string GetBZMainCategory = "usp_GetMainCategory";
        public const string GetBZMainCategoryObjects = "usp_GetMainCategoryObjects";
        public const string GetBZUspGetcropseasons = "usp_getcropseasons";
        public const string UspGetBzAppProductDetails = "Usp_GetBzAppProductDetails";
        public const string uspPaymentOption = "usp_PaymentOption";
        public const string uspGetAddress = "usp_BZAppGetAddress";
        public const string uspGetBzFAQ = "usp_GetBzFAQ";
        public const string uspGetBzTips = "usp_GetBzTips";
        public const string uspProductByCategory = "SP_GETBZ_Product_By_Category";
        public const string uspGetCropStages = "Usp_GetCropStagesAnd_Products";
        public const string SPBZPRODUCTLISTTodayOffer = "SP_BZ_PRODUCTLIST_TodayOffer";
        public const string USPBZPRODUCTLIST = "SP_BZ_PRODUCTLIST_V2";
        public const string SPGetCrops = "SP_GetCrops_BZFarmer";
        public const string USPGetSubCategory = "USP_GetSubCategory_BZApp";//"USP_GetSubCategory";
        public const string uspGetBZCropList = "usp_GetBZCropList";
        public const string usp_GetBZLeftMenu = "usp_GetBZLeftMenu";
        public const string uspTblCropPOPPopup = "usp_Tbl_Crop_POP_Popup";
        public const string uspGetCropBreed = "usp_GetCropBreed";
        public const string FAQCategoryList = "FAQCategoryList";
        public const string uspGetBzFAQData = "usp_GetBzFAQ_Data";
        public const string uspGetBzTipsData = "usp_GetBzTips_Data";
        public const string uspGetBzCategorySubCategory = "usp_GetKGPCategorySubCategory";
        public const string uspGetKGPProducts = "usp_KitchenGarden_ProductList";
        public const string UspGetLivestockandBread = "Usp_GetLivestockandBread";


        //Stock Inventory Stored Procedures
        public const string uspGetDealerProductList = "Usp_Get_DealerCategoryProductList";
        public const string uspGetSubDealerProductList = "Usp_Get_SubDealerCategoryProductList";


        //Bz Website Stored Procdures
        public const string uspBzWebsiteProducts = "uspBzWebsiteProducts";
        public const string uspBzWebsitePackages = "uspBzWebsitePackages";
        public const string uspBzGetCategoryforDetails = "GetCategorySubCategory";

        public const string uspGetCartITems = "usp_GetCartItems";

        public const string UspGetSathiAppProductDetails = "Usp_GetSathiAppProductDetails";

        public const string uspSaveUpdateCartHistory = "usp_SaveUpdateCartHistory";
        //// New Product Details sp//////////
        public const string UspGetBzAppProductDetailsNew = "Usp_GetBzAppProductDetailsNew";

        public const string uspDelightPushOrders = "usp_DelightPushOrders";
        public const string usp_GetProductsBySearch = "SP_BZ_PRODUCTLIST_V3";

        public const string uspBehtarBachatOffer= "usp_GetBehtarBachatOffer";
        public const string uspHumTumOffer = "usp_GetHumTumOffer";

        public const string usp_SaveTractorUsersDetail = "usp_SaveUpdateTractorUsersDetail";
        public const string usp_GetOrderTracking = "usp_GetOrderTracking";

        public const string usp_GetOrderTrackingStatus = "usp_GetOrderTrackingStatus";


        public const string usp_CheckValidityOfAgentCoupon = "usp_CheckValidityOfAgentCoupon";
        public const string usp_InsertAgentCoupon = "usp_InsertAgentCoupon";

    }
}