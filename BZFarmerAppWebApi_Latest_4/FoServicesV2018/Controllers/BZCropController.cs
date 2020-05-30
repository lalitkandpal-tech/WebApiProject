using FoServicesV2018.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;
using DataLayer;
using System.Reflection;

namespace FoServicesV2018.Controllers
{
    [RoutePrefix("api/BZCrop")]
    public class BZCropController : ApiController
    {
        [HttpGet]
        public IHttpActionResult BZCrop()
        {
            return Ok();
        }

        [HttpGet]
        [Route("GetCropStages")]
        public IHttpActionResult GetCropStages(int CropId, int? DistrictId, string version,int? FarmerId)
        {
            try
            {
                DataSet ds = new DataSet();
                ds = BZCrops.GetCropStages(CropId, DistrictId, version, FarmerId);
                ds.Tables[0].TableName = "CropStageDetails";
                ds.Tables[2].TableName = "CropData";
                ds.Tables[3].TableName = "FarmerPopData";
                //DataSet ds1 = new DataSet();
                //ds1 = LiveStocks.BZTrendsProducts("1");
                // ds1 = LiveStocks.BZLiveStockProducts("1");
                ds.Tables[1].TableName = "Products";
                //ds.Tables.Add(ds1.Tables[0].Copy());
                BZCropProp objBZCropProp = new BZCropProp();
                List<BZCropProp> ListBZCropProp = new List<BZCropProp>();
                var CropStageData = ds.Tables[0].AsEnumerable();
                var CropProduct = ds.Tables[1].AsEnumerable();
                var CropData = ds.Tables[2].AsEnumerable();
                BZCropProp objCrop = new BZCropProp();
                objCrop.CropID = Convert.ToInt32(ds.Tables["CropData"].Rows[0]["CropID"]);
                objCrop.CropName = ds.Tables["CropData"].Rows[0]["CropName"].ToString();
                objCrop.CropNameHindi = ds.Tables["CropData"].Rows[0]["CropNameHindi"].ToString();
                objCrop.CropType = ds.Tables["CropData"].Rows[0]["CropType"].ToString() == "" ? 0 : Convert.ToInt32(ds.Tables["CropData"].Rows[0]["CropType"]);
                objCrop.IsActive = Convert.ToBoolean(ds.Tables["CropData"].Rows[0]["IsActive"]);
                objCrop.ImageUrl = ds.Tables["CropData"].Rows[0]["ImageUrl"].ToString();
                objCrop.VideoUrl= ds.Tables["CropData"].Rows[0]["VideoUrl"].ToString();
                if (ds.Tables["FarmerPopData"].Rows.Count > 0)
                {
                    objCrop.FarmingDuration =Convert.ToDateTime(ds.Tables["FarmerPopData"].Rows[0]["FarmingDuration"].ToString()).ToString("dd/MMM/yyyy");
                    objCrop.FarmArea = ds.Tables["FarmerPopData"].Rows[0]["FarmArea"].ToString();
                }
                else { objCrop.FarmingDuration = ""; objCrop.FarmArea = ""; }
                objCrop.BZStageCrop = new List<BZStageCrop>();
                foreach (var item in CropStageData)
                {
                    objCrop.BZStageCrop.Add(new BZStageCrop
                    {
                        ID = item.Field<int?>("StageId")==null?0: item.Field<int>("StageId"),
                        CropID = item.Field<int?>("CropID")==null?0: item.Field<int>("CropID"),
                        StageName = item.Field<string>("StageName")==null?"": item.Field<string>("StageName"),
                        Name = item.Field<string>("NAME")==null?"": item.Field<string>("NAME"),
                        Description = item.Field<string>("Description")==null?"":item.Field<string>("Description"),
                        Extra = item.Field<int?>("Extra")==null?0: item.Field<int>("Extra"),
                        IsShow = item.Field<bool?>("IsShow")==null?false: item.Field<bool>("IsShow"),
                        VideoUrl = item.Field<string>("VideoUrl")==null?"": item.Field<string>("VideoUrl"),
                        ImageUrl = item.Field<string>("ImageUrl")==null?"": item.Field<string>("ImageUrl"),
                        Products = new List<Products>()
                    });
                }
                foreach (var ItemList in objCrop.BZStageCrop)
                {
                    foreach (var item1 in CropProduct)
                    {
                        if (item1.Field<int>("StageId") == ItemList.ID)
                        {
                            ItemList.Products.Add(new Products
                            {
                                RowNumber = item1.Field<long?>("RowNumber")==null?0: item1.Field<long>("RowNumber"),
                                ProductID = item1.Field<int?>("ProductID")==null?0: item1.Field<int>("ProductID"),
                                ProductName = item1.Field<string>("ProductName")==null?"": item1.Field<string>("ProductName"),
                                OrganisationName = item1.Field<string>("OrganisationName")==null?"": item1.Field<string>("OrganisationName"),
                                BrandName = item1.Field<string>("BrandName")==null?"": item1.Field<string>("BrandName"),
                                TechnicalName = item1.Field<string>("TechnicalName")==null?"": item1.Field<string>("TechnicalName"),
                                SubCategoryName = item1.Field<string>("SubCategoryName")==null?"": item1.Field<string>("SubCategoryName"),
                                CategoryName = item1.Field<string>("CategoryName")==null?"": item1.Field<string>("CategoryName"),
                                CategoryHindi = item1.Field<string>("CategoryHindi")==null?"": item1.Field<string>("CategoryHindi"),
                                CategoryID = item1.Field<byte?>("CategoryID"),
                                PackageID = item1.Field<int?>("PackageID"),
                                RN = item1.Field<Int64>("RN"),
                                OfferPrice_Qty = item1.Field<int?>("OfferPrice_Qty"),
                                Amount = item1.Field<decimal>("Amount"),
                                UnitName = item1.Field<string>("UnitName"),
                                OurPrice = item1.Field<decimal>("OurPrice"),
                                offerprice = item1.Field<decimal>("offerprice"),
                                RecordID = item1.Field<int>("RecordID"),
                                CreatedDate = item1.Field<DateTime>("CreatedDate"),
                                IsActive = item1.Field<bool>("IsActive"),
                                status = item1.Field<string>("status"),
                                CretedBy = item1.Field<string>("CretedBy"),
                                ProductHindiName = item1.Field<string>("ProductHindiName"),
                                IsDetails = item1.Field<bool?>("IsDetails")==null?false: item1.Field<bool>("IsDetails"),
                                ImagePath = item1.Field<string>("ImagePath"),
                                DistrictID = item1.Field<int>("DistrictID"),
                                DistrictName = item1.Field<string>("DistrictName"),
                                COD = item1.Field<decimal>("COD"),
                                OnlinePrice = item1.Field<decimal>("OnlinePrice"),
                                MRP = item1.Field<decimal>("MRP"),
                                OfferDiscount = item1.Field<string>("OfferDiscount")
                            });
                        }
                    }
                }
                return Ok(new { Results = objCrop, Status = true });
            }
            catch (Exception ex)
            {
                LogDal.ErrorLog(this.GetType().Name, MethodBase.GetCurrentMethod().Name, ex.Message, 0);
                return Ok(new { Results = "", Status = false });
            }
        }
        [HttpGet]
        [Route("GetBZCropList")]
        public IHttpActionResult GetBZCropList(string version)
        {
            try
            {
                DataSet ds = new DataSet();
                ds = BZCrops.GetBZCropList(version);
                ds.Tables[0].TableName = "CropList";
                return Ok(new { BZApiReponse = ds, Status = true });
            }
            catch (Exception ex)
            {
                LogDal.ErrorLog(this.GetType().Name, MethodBase.GetCurrentMethod().Name, ex.Message, 0);
                return Ok(new { Results = "", Status = false });
            }
        }


        [HttpPost]
        [Route("CropPOPPopup")]
        public IHttpActionResult CropPOPPopup(CropPopFarmDetail objFarmDetail)
        {
            PostResponse objResponse = new PostResponse();
            try
            {
                if (!string.IsNullOrWhiteSpace(objFarmDetail.FarmingDuration))
                {
                    objFarmDetail.FarmingDuration = objFarmDetail.FarmingDuration.Split('/')[1] + "/" + objFarmDetail.FarmingDuration.Split('/')[0] + "/" + objFarmDetail.FarmingDuration.Split('/')[2];
                }
                else {
                    objFarmDetail.FarmingDuration = System.DateTime.Now.ToString();
                }
                int value = 0;
                   DataSet ds = BZCrops.InsertFarmDetail(objFarmDetail);
                if (ds != null && ds.Tables.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        value = ds.Tables[0].Rows[0]["ReturnValue"] == DBNull.Value ? 0 : Convert.ToInt32(ds.Tables[0].Rows[i]["ReturnValue"]);
                    }
                }                 
                if (value > 0)
                {
                    objResponse.Success = true;
                    objResponse.Msg = "आपका विवरण सफलतापूर्वक दर्ज हो गया है।";
                }
                else {
                    objResponse.Success = false;
                    objResponse.Msg = "आपका विवरण दर्ज नहीं हो पाया, पुनः प्रयास करें!";
                }
                return Ok(new { BZApiReponse = objResponse, Status = true });
            }
            catch (Exception ex)
            {
                LogDal.ErrorLog(this.GetType().Name, MethodBase.GetCurrentMethod().Name, ex.Message, 0);
                objResponse.Msg = "Failed.";
            }
            return Ok(new { BZApiReponse = objResponse, Status = false });
        }
        [HttpGet]
        [Route("GetBZCropBreed")]
        public IHttpActionResult GetBZCropBreed(string version,int CropId)
        {
            try
            {
                DataSet ds = new DataSet();
                ds = BZCrops.GetBZCropBreedList(version,CropId);
                ds.Tables[0].TableName = "CropBreed";
                return Ok(new { BZApiReponse = ds, Status = true });
            }
            catch (Exception ex)
            {
                LogDal.ErrorLog(this.GetType().Name, MethodBase.GetCurrentMethod().Name, ex.Message, 0);
                return Ok(new { Results = "", Status = false });
            }
        }
    }
}
