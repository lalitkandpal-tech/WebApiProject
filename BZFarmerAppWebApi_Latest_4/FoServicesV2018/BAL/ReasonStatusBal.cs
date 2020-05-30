using DataLayer;
using Entity;
using FoServicesV2018.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;


namespace BAL
{
    public class ReasonStatusBal
    {
        ReasonStatusDal _rsdal = new ReasonStatusDal();
        public CreatedOrderResult OrderCreate(OrderCreateModel obj, string x_StateName, string x_DistrictName)
        {
            //int id = _rsdal.GetFarmerIdByMobile(mobile);
            DataTable DT = Helper.Helper.ToDataTable(obj.Product);
            //CreatedOrderResult objCreateData = _rsdal.OrderCreate(obj.OfferDiscount, obj.Product.PackageId, obj.Product.Quantity, obj.Amount, obj.Farmer.FarmerId, obj.Farmer.Mobile,
            //    obj.Farmer.StateId, obj.Farmer.DistrictId, obj.Farmer.BlockId, obj.Farmer.VillageId, obj.Farmer.OtherVillageName, obj.Farmer.Address,
            //    obj.DeliveryDate, obj.ModeOfPayment, obj.DiscountPrice, obj.DiscountCode);
            CreatedOrderResult objCreateData = _rsdal.OrderCreate(obj.userid, obj.Farmer.FarmerId, obj.Farmer.FarmerName, obj.Farmer.FatherName, obj.Farmer.Mobile,
               obj.Farmer.StateId, obj.Farmer.DistrictId, obj.Farmer.BlockId, obj.Farmer.VillageId, obj.Farmer.OtherVillageName, obj.Farmer.Address,
               obj.DeliveryDate, obj.ModeOfPayment, DT, x_StateName, x_DistrictName);
            return objCreateData;
        }

        public CreatedOrderResult OrderCreateV2(OrderCreateModel obj, string x_StateName, string x_DistrictName)
        {
            //int id = _rsdal.GetFarmerIdByMobile(mobile);
            DataTable DT = Helper.Helper.ToDataTable(obj.Product);
            //CreatedOrderResult objCreateData = _rsdal.OrderCreate(obj.OfferDiscount, obj.Product.PackageId, obj.Product.Quantity, obj.Amount, obj.Farmer.FarmerId, obj.Farmer.Mobile,
            //    obj.Farmer.StateId, obj.Farmer.DistrictId, obj.Farmer.BlockId, obj.Farmer.VillageId, obj.Farmer.OtherVillageName, obj.Farmer.Address,
            //    obj.DeliveryDate, obj.ModeOfPayment, obj.DiscountPrice, obj.DiscountCode);
            CreatedOrderResult objCreateData = _rsdal.OrderCreateV2(obj.userid, obj.Farmer.FarmerId, obj.Farmer.FarmerName, obj.Farmer.FatherName, obj.Farmer.Mobile,
               obj.Farmer.StateId, obj.Farmer.DistrictId, obj.Farmer.BlockId, obj.Farmer.VillageId, obj.Farmer.OtherVillageName, obj.Farmer.Address,
               obj.DeliveryDate, obj.ModeOfPayment, DT, x_StateName, x_DistrictName);
            return objCreateData;
        }
        public DataSet GetKGPCategorySubCategoryWiseData(KitchenGardenEntity objkgpList,string StateName,string DistrictName)
        {
            List<KGPSubCategoryData> objlist = new List<KGPSubCategoryData>();
            DataTable DTSubCategory = new DataTable();
            DataSet ds1 = new DataSet();
            if (objkgpList.KGPCategory.Count == 0 && objkgpList.KGP_CategoryId != null)
            {
                ds1 = _rsdal.GetCatSubCat(objkgpList.KGP_CategoryId);
                if (ds1.Tables.Count > 0)
                {
                    if (ds1.Tables[0].Rows.Count > 0)
                    {
                        for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
                        {
                            objlist.Add(new KGPSubCategoryData
                            {
                                KGP_CategoryId = ds1.Tables[0].Rows[i]["KGP_CategoryId"] == DBNull.Value ? 0 : Convert.ToInt32(ds1.Tables[0].Rows[i]["KGP_CategoryId"]),
                                KGP_SubCategoryId = ds1.Tables[0].Rows[i]["KGP_SubCategoryId"] == DBNull.Value ? 0 : Convert.ToInt32(ds1.Tables[0].Rows[i]["KGP_SubCategoryId"]),
                            }
                            );
                        }
                        DTSubCategory = Helper.Helper.ToDataTable(objlist);
                    }
                    else
                    {
                        DTSubCategory.Columns.Add(new DataColumn("KGP_CategoryId", typeof(Int32)));
                        DTSubCategory.Columns.Add(new DataColumn("KGP_SubCategoryId", typeof(Int32)));
                        DataRow row = DTSubCategory.NewRow();
                        row["KGP_CategoryId"] = 0;
                        row["KGP_SubCategoryId"] = 0;
                        DTSubCategory.Rows.Add(row);
                    }
                }
            }

            else if (objkgpList.KGPCategory != null)
            {
                foreach (var item in objkgpList.KGPCategory)
                {
                    foreach (var item1 in item.KGPSubCategory)
                    {
                        KGPSubCategoryData obj = new KGPSubCategoryData();
                        obj.KGP_CategoryId = item1.KGP_CategoryId;
                        obj.KGP_SubCategoryId = item1.KGP_SubCategoryId;
                        objlist.Add(obj);
                    }
                }
                DTSubCategory = Helper.Helper.ToDataTable(objlist);
            }
            else
            {
                DTSubCategory.Columns.Add(new DataColumn("KGP_CategoryId", typeof(Int32)));
                DTSubCategory.Columns.Add(new DataColumn("KGP_SubCategoryId", typeof(Int32)));
                DataRow row = DTSubCategory.NewRow();
                row["KGP_CategoryId"] = 0;
                row["KGP_SubCategoryId"] = 0;
                DTSubCategory.Rows.Add(row);
            }
            //int id = _rsdal.GetFarmerIdByMobile(mobile);
            DataSet ds = new DataSet();
            // DataTable DTCategory = Helper.Helper.ToDataTable(objkgpList.KGPCategory);            
            ds = _rsdal.GetFilterData(DTSubCategory, objkgpList.version, objkgpList.lang,StateName,DistrictName);
            //ds.Tables.Add(DTSubCategory.Copy());
            return ds;
        }


        public SavedProductResult SaveSubDealerProducts(SubDealerProductCreate obj)
        {
            SavedProductResult objCreateData = _rsdal.SaveSubDealerProducts(obj.PackageId, obj.Quantity, obj.SubDealerId);
            return objCreateData;
        }
        public ApiPostResponse SaveTractorUserDetailV2(TractorUsers obj)
        {
            ApiPostResponse objCreateData = _rsdal.SaveTractorUserDetailV2(obj.FarmerName, obj.StateID, obj.MobileNo, obj.CategoryId, obj.ModelNo, obj.QuotationPrice);
            return objCreateData;
        }
        public ApiPostResponse SaveTractorUserDetail(TractorUsers obj)
        {
            ApiPostResponse objCreateData = _rsdal.SaveTractorUserDetail(obj.FarmerName, obj.StateID, obj.MobileNo, obj.CategoryId,obj.BzProductId, obj.ModelNo, obj.QuotationPrice,obj.RequestSource,obj.DemoDate,obj.TimeSlot);
            return objCreateData;
        }
    }
}