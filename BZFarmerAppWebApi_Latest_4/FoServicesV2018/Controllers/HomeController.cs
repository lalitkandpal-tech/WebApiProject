using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FoServicesV2018.Models;
using FoServicesV2018.BAL;
using DataLayer;
using System.Reflection;
using FoServicesV2018.Entity;
using System.Runtime.Serialization.Formatters.Binary;
using Newtonsoft.Json;

namespace FoServicesV2018.Controllers
{
    [RoutePrefix("api/Home")]
    public class HomeController : ApiController
    {
        [HttpGet]
        [Route("Get_BZFarmerAppCatagory")]
        public IHttpActionResult Get_BZFarmerAppCatagory(string version,int KGP)
        {
            try
            {
                System.Net.Http.Headers.HttpRequestHeaders headers = this.Request.Headers;
                string x_StateName = string.Empty;
                string x_DistrictName = string.Empty;
                if (headers.Contains("state"))
                {
                    x_StateName = headers.GetValues("state").First().ToLower();
                }
                if (headers.Contains("district"))
                {
                    x_DistrictName = headers.GetValues("district").First().ToLower();
                }
                DataSet ds = new DataSet();
                ds = BzCatagory.AppCatagory(version, x_StateName, x_DistrictName,KGP);
                ds.Tables[0].TableName = "BZFarmerAppCatagory";
                return Ok(new { BZAppCatagory = ds, Status = true });
            }
            catch (Exception ex)
            {
                LogDal.ErrorLog(this.GetType().Name, MethodBase.GetCurrentMethod().Name, ex.Message, 0);
                return Ok(new { BZAppCatagory = "", Status = false });
            }
        }

        [HttpGet]
        [Route("GetBZProductBanner")]
        public IHttpActionResult GetBZProductBanner(string version)
        {
            try
            {
                System.Net.Http.Headers.HttpRequestHeaders headers = this.Request.Headers;
                string x_StateName = string.Empty;
                string x_DistrictName = string.Empty;
                if (headers.Contains("state"))
                {
                    x_StateName = headers.GetValues("state").First().ToLower();
                }
                if (headers.Contains("district"))
                {
                    x_DistrictName = headers.GetValues("district").First().ToLower();
                }
                DataSet ds = new DataSet();
                ds = BzCatagory.AppProductBanner(version, x_StateName, x_DistrictName);
                ds.Tables[0].TableName = "BZProductBanner";
                return Ok(new { BZAppBanner = ds, Status = true });
            }
            catch(Exception ex)
            {
                LogDal.ErrorLog(this.GetType().Name, MethodBase.GetCurrentMethod().Name, ex.Message, 0);
                return Ok(new { BZAppBanner = "", Status = false });
            }
        }

        [HttpGet]
        [Route("GetBzAppActiveBrands")]
        public IHttpActionResult GetBzAppActiveBrands(string version)
        {
            try
            {
                System.Net.Http.Headers.HttpRequestHeaders headers = this.Request.Headers;
                string x_StateName = string.Empty;
                string x_DistrictName = string.Empty;
                if (headers.Contains("state"))
                {
                    x_StateName = headers.GetValues("state").First().ToLower();
                }
                if (headers.Contains("district"))
                {
                    x_DistrictName = headers.GetValues("district").First().ToLower();
                }
                DataSet ds = new DataSet();
                ds = BzCatagory.ActiveBrands(version, x_StateName, x_DistrictName);
             
                    ds.Tables[0].TableName = "BZActiveBrands";
                    return Ok(new { BZBrands = ds, Status = true });
                              
            }
            catch (Exception ex)
            {
                LogDal.ErrorLog(this.GetType().Name, MethodBase.GetCurrentMethod().Name, ex.Message, 0);
                return Ok(new { BZBrands = "", Status = false });
            }
        }

        [HttpGet]
        [Route("Get_BZFarmerAppMainCategory")]
        public IHttpActionResult Get_BZFarmerAppMainCategory(string version)
        {
            try
            {
                DataSet ds = new DataSet();
                ds = BzCatagory.AppMainCategory(version);
                ds.Tables[0].TableName = "BZFarmerAppMainCategory";
                return Ok(new { BZAppCatagory = ds, Status = true });
            }
            catch (Exception ex)
            {
                LogDal.ErrorLog(this.GetType().Name, MethodBase.GetCurrentMethod().Name, ex.Message, 0);
                return Ok(new { BZAppCatagory = "", Status = false });
            }
        }

        [HttpGet]
        [Route("Get_BZFarmerAppMainCategoryObjects")]
        public IHttpActionResult Get_BZFarmerAppMainCategoryObjects(string version, int MainCategoryId, int SeasonId)
        {
            try
            {
                DataSet ds = new DataSet();
                ds = BzCatagory.AppMainCategoryObjects(version, MainCategoryId, SeasonId);
                //ds.Tables[0].TableName = "Title";
                ds.Tables[0].TableName = "Get_BZFarmerAppMainCategoryObjects";
                //ds.Tables[2].TableName = "Images";
                BALMainCategory objbal = new BALMainCategory();
                //objbal.Title = ds.Tables[0].Rows[0]["Title"].ToString();
                //objbal.Image = new List<Images>();
                objbal.MainCategoryObjects = new List<MainCategoryObjects>();
                var categoryObjects = ds.Tables["Get_BZFarmerAppMainCategoryObjects"].AsEnumerable();
                //var Images = ds.Tables["Images"].AsEnumerable();
                foreach (var item in categoryObjects)
                {
                    objbal.MainCategoryObjects.Add(new MainCategoryObjects
                    {
                        Id = item.Field<int>("Id"),
                        Name = item.Field<string>("Name"),
                        HindiName = item.Field<string>("HindiName"),
                        ImageUrl = item.Field<string>("ImageUrl"),
                    });
                }
                //foreach(var item1 in Images)
                //{
                //    objbal.Image.Add(new Images {
                //        Image=item1.Field<string>("Image")
                //    });
                //}
                return Ok(new { BZAppCatagory = objbal, Status = true });
            }
            catch (Exception ex)
            {
                LogDal.ErrorLog(this.GetType().Name, MethodBase.GetCurrentMethod().Name, ex.Message, 0);
                return Ok(new { BZAppCatagory = "", Status = false });
            }
        }

        [HttpGet]
        [Route("Get_BZSeasonCrop")]
        public IHttpActionResult Get_BZSeasonCrop(string version, int MainCategoryId)
        {
            try
            {
                DataSet ds = new DataSet();
                ds = BzCatagory.AppSeasonCrop(version, MainCategoryId);
                ds.Tables[0].TableName = "Titles";
                ds.Tables[1].TableName = "SeasonCrop";
                ds.Tables[2].TableName = "Images";
                GetCrop objCrop = new GetCrop();
                objCrop.Title = ds.Tables["Titles"].Rows[0]["Title"].ToString();
                objCrop.Banner = new List<Banner>();
                objCrop.CropSeason = new List<CropSeasons>();
                var seasonCrops = ds.Tables["SeasonCrop"].AsEnumerable();
                var img = ds.Tables["Images"].AsEnumerable();
                foreach (var item in seasonCrops)
                {
                    objCrop.CropSeason.Add(new CropSeasons
                    {
                        SeasonID = item.Field<int>("SeasonID"),
                        SeasonName = item.Field<string>("SeasonName")
                    });
                }
                foreach (var item1 in img)
                {
                    objCrop.Banner.Add(new Banner
                    {
                        BannerId = item1.Field<int>("BannerId"),
                        BannerName = item1.Field<string>("BannerName"),
                        BannerType = item1.Field<string>("BannerType"),
                        ImagePath = item1.Field<string>("Image"),
                        isActive = item1.Field<bool>("isActive"),
                        DisplayOrder = item1.Field<int>("DisplayOrder"),
                        IsClickable = item1.Field<bool>("IsClickable"),
                        PackageID = item1.Field<int?>("PackageID")
                    });

                }
                return Ok(new { SeasonCrop = objCrop, Status = true });
            }
            catch (Exception ex)
            {
                LogDal.ErrorLog(this.GetType().Name, MethodBase.GetCurrentMethod().Name, ex.Message, 0);
                return Ok(new { SeasonCrop = "", Status = false });
            }
        }

       
        [HttpGet]
        [Route("GetBzAppProductDetailsNew")]
        public IHttpActionResult GetBzAppProductDetailsNew(string version, int ProductId, int Districtid)//, int PackageId
        {
            try
            {
                DataSet ds = new DataSet();
                ds = LiveStocks.GetBzAppProductDetailsNew(version, ProductId, Districtid);

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {

                        ds.Tables[0].TableName = "ProductDetails";

                        DataTable dTImageUrl = new DataTable("ImageUrlPath");
                        DataTable dTVideoUrl = new DataTable("VideoUrlPath");
                        DataTable dTProductDetails = new DataTable("ProductDetails");
                        dTImageUrl.Columns.Add("ImagePath");
                        dTVideoUrl.Columns.Add("VideoUrl");
                        dTVideoUrl.Columns.Add("ImagePath");

                        string[] imageUrl = null;
                        string[] videoUrl = null;
                        string[] ThumbnailPath = null;
                        if (ds.Tables[0].Rows[0]["ImageUrl"].ToString() != null)
                        {
                            ds.Tables[0].Rows[0]["ImageUrl"] = ds.Tables[0].Rows[0]["ImageUrl"].ToString();
                            imageUrl = ds.Tables[0].Rows[0]["ImageUrl"].ToString().Split('#');
                            foreach (var item in imageUrl)
                            {
                                var values = new object[1];
                                values[0] = item;
                                dTImageUrl.Rows.Add(values);
                            }
                        }
                        if (ds.Tables[0].Rows[0]["VideoUrl"].ToString() != null)
                        {
                            videoUrl = ds.Tables[0].Rows[0]["VideoUrl"].ToString().Split('#');
                            ThumbnailPath = ds.Tables[0].Rows[0]["VideoThumbNail"].ToString().Split('#');
                            for (int i = 0; i < videoUrl.Length; i++)
                            {
                                DataRow dr = dTVideoUrl.NewRow();
                                dr["VideoUrl"] = videoUrl[i];
                                if (i < ThumbnailPath.Length)
                                {
                                    dr["ImagePath"] = ThumbnailPath[i];
                                }
                                else
                                {
                                    dr["ImagePath"] = null;
                                }
                                dTVideoUrl.Rows.Add(dr);
                            }
                        }
                        DataSet dsNew = new DataSet();
                        dsNew.Tables.Add(dTImageUrl);
                        dsNew.Tables.Add(dTVideoUrl);
                        dsNew.Tables.Add(ds.Tables[0].Copy());
                        // dsNew.Tables.Add(ds.Tables[2].Copy());
                        return Ok(new { BZApiReponse = dsNew, Status = true });
                    }
                    else
                    {
                        return Ok(new { BZApiReponse = "", Status = false });
                    }
                  
                }
                else { return Ok(new { BZApiReponse = "", Status = false }); }
            }
            catch (Exception ex)
            {
                LogDal.ErrorLog(this.GetType().Name, MethodBase.GetCurrentMethod().Name, ex.Message, 0);
                return Ok(new { BZApiReponse = "", Status = false });
            }
        }

        //if (ds.Tables.Count > 0)
        //{
        //    if (ds.Tables[0].Rows.Count > 0)
        //    {
        //        ds.Tables[0].TableName = "ProductDetails";

        //        DataTable dTProductDetails = new DataTable("ProductDetails");

        //        DataSet dsNew = new DataSet();

        //        dsNew.Tables.Add(ds.Tables[0].Copy());

        //        return Ok(new { BZApiReponse = dsNew, Status = true });
        //    }
        //    else
        //    {
        //        return Ok(new { BZApiReponse = "", Status = false });
        //    }
        //}
        //else { return Ok(new { BZApiReponse = "", Status = false }); }
        [HttpGet]
        [Route("GetBZAppProductDetails")]
        public IHttpActionResult GetBzAppProductDetails(string version, int CategoryId, int ProductId, int DistrictId)
        {            
            try
            {              
                DataSet ds = new DataSet();
                ds = LiveStocks.GetBzAppProductDetails(version, CategoryId, ProductId, DistrictId);
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        ds.Tables[0].TableName = "ImageAndVideo";
                        ds.Tables[1].TableName = "ProductDetails";
                        ds.Tables[2].TableName = "ProductDetailsHindi";
                        DataTable dTImageUrl = new DataTable("ImageUrlPath");
                        DataTable dTVideoUrl = new DataTable("VideoUrlPath");
                        DataTable dTProductDetails = new DataTable("ProductDetails");
                        dTImageUrl.Columns.Add("ImagePath");
                        dTVideoUrl.Columns.Add("VideoUrl");
                        dTVideoUrl.Columns.Add("ImagePath");

                        string[] imageUrl = null;
                        string[] videoUrl = null;
                        string[] ThumbnailPath = null;
                        if (ds.Tables[0].Rows[0]["ImageUrl"].ToString() != null)
                        {
                            ds.Tables[0].Rows[0]["ImageUrl"] = ds.Tables[0].Rows[0]["ImageUrl"].ToString();
                            imageUrl = ds.Tables[0].Rows[0]["ImageUrl"].ToString().Split('#');
                            foreach (var item in imageUrl)
                            {
                                var values = new object[1];
                                values[0] = item;
                                dTImageUrl.Rows.Add(values);
                            }
                        }
                        if (ds.Tables[0].Rows[0]["VideoUrl"].ToString() != null)
                        {
                            videoUrl = ds.Tables[0].Rows[0]["VideoUrl"].ToString().Split('#');
                            ThumbnailPath= ds.Tables[0].Rows[0]["VideoThumbnailPath"].ToString().Split('#');
                            for(int i = 0; i < videoUrl.Length; i++)
                            {
                                DataRow dr = dTVideoUrl.NewRow();
                                dr["VideoUrl"] = videoUrl[i];
                                if (i < ThumbnailPath.Length)
                                {
                                    dr["ImagePath"] = ThumbnailPath[i];
                                }
                                else
                                {
                                    dr["ImagePath"] = null;
                                }                               
                                dTVideoUrl.Rows.Add(dr);
                            }                            
                        }
                        DataSet dsNew = new DataSet();
                        dsNew.Tables.Add(dTImageUrl);
                        dsNew.Tables.Add(dTVideoUrl);
                        dsNew.Tables.Add(ds.Tables[1].Copy());
                        dsNew.Tables.Add(ds.Tables[2].Copy());
                        return Ok(new { BZApiReponse = dsNew, Status = true });
                    }
                    else
                    {
                        return Ok(new { BZApiReponse = "", Status = false });
                    }
                }
                else { return Ok(new { BZApiReponse = "", Status = false }); }
            }
            catch (Exception ex)
            {
                LogDal.ErrorLog(this.GetType().Name, MethodBase.GetCurrentMethod().Name, ex.Message, 0);
                return Ok(new { BZApiReponse = "", Status = false });
            }
        }

        [HttpGet]
        [Route("PaymentOption")]
        public IHttpActionResult PaymentOption(string version)
        {
            try
            {
                DataSet ds = new DataSet();
                ds = BzCatagory.GetPaymentOption(version);
                ds.Tables[0].TableName = "PaymentOption";
                return Ok(new { BZAppPaymentOption = ds, Status = true });
            }
            catch (Exception ex)
            {
                LogDal.ErrorLog(this.GetType().Name, MethodBase.GetCurrentMethod().Name, ex.Message, 0);
                return Ok(new { BZAppPaymentOption = "", Status = false });
            }
        }

        [HttpGet]
        [Route("GetFarmerAddress")]
        public IHttpActionResult GetFarmerAddress(string version, int FarmerID)
        {
            try
            {
                DataSet ds = new DataSet();
                ds = BzCatagory.GetFarmerAddress(version, FarmerID);
                ds.Tables[0].TableName = "FarmerAddress";
                BALFarmerAddress obj = new BALFarmerAddress();
                foreach (var item in ds.Tables[0].AsEnumerable())
                {
                    obj.Address = item.Field<string>("Address");
                    obj.NearByVillage = item.Field<string>("NearByVillage");
                    obj.VillageName = item.Field<string>("VillageName");
                    obj.BlockName = item.Field<string>("BlockName");
                    obj.DistrictName = item.Field<string>("DistrictName");
                    obj.StateName =item.Field<string>("StateName");
                    obj.FarmerID = item.Field<Int64>("FarmerID");
                    obj.FarmerName = item.Field<string>("FarmerName");
                    obj.FatherName= item.Field<string>("FatherName");
                    obj.MobNo = item.Field<decimal>("MobNo");
                    obj.VillageID =Convert.ToInt32(item.Field<Int64?>("VillageID"));
                    obj.BlockID = Convert.ToInt32(item.Field<int?>("BlockID"));
                    obj.DistrictID = Convert.ToInt32(item.Field<Int16?>("DistrictID"));
                    obj.StateID = Convert.ToInt32(item.Field<byte?>("StateID"));
                    obj.Landmark= item.Field<string>("LandMark");
                    obj.Pincode= item.Field<string>("pin");
                    obj.Email = item.Field<string>("Email");
                }
                return Ok(new { BZAppFarmerAddress = obj, Status = true });
            }
            catch (Exception ex)
            {
                LogDal.ErrorLog(this.GetType().Name, MethodBase.GetCurrentMethod().Name, ex.Message, 0);
                return Ok(new { BZAppFarmerAddress = "", Status = false });
            }
        }

        [HttpGet]
        [Route("GetBZFAQ")]
        public IHttpActionResult GetBZFAQ(string version, string SearchCriteria, int MainCategoryId, int Id, string OptionText)
        {
            try
            {
                DataSet ds = new DataSet();
                ds = BzCatagory.GetBZFAQ(version, SearchCriteria, MainCategoryId, Id, OptionText);
                ds.Tables[0].TableName = "BZFAQ";
                if (ds.Tables["BZFAQ"].Rows.Count > 0)
                {
                    return Ok(new { BZReponse = ds, Status = true });
                }
                else
                {
                    return Ok(new { BZReponse = "", Status = false });
                }
            }
            catch (Exception ex)
            {
                LogDal.ErrorLog(this.GetType().Name, MethodBase.GetCurrentMethod().Name, ex.Message, 0);
                return Ok(new { BZReponse = "", Status = false });
            }
        }
        
        [HttpGet]
        [Route("GetBZTips")]
        public IHttpActionResult GetBZTips(string version, string SearchCriteria, int MainCategoryId, int Id, string OptionText)
        {
            try
            {
                DataSet ds = new DataSet();
                ds = BzCatagory.GetBZTips(version, SearchCriteria, MainCategoryId, Id,OptionText);
                ds.Tables[0].TableName = "BZTips";
                if (ds.Tables["BZTips"].Rows.Count > 0)
                {
                    return Ok(new { BZReponse = ds, Status = true });
                }
                else
                {
                    return Ok(new { BZReponse = "", Status = false });
                }
            }
            catch (Exception ex)
            {
                LogDal.ErrorLog(this.GetType().Name, MethodBase.GetCurrentMethod().Name, ex.Message, 0);
                return Ok(new { BZReponse = "", Status = false });
            }
        }

        [HttpGet]
        [Route("GetBZLeftMenu")]
        public IHttpActionResult GetBZLeftMenu(string version)
        {
            try
            {
                System.Net.Http.Headers.HttpRequestHeaders headers = this.Request.Headers;
                string x_StateName = string.Empty;
                string x_DistrictName = string.Empty;
                if (headers.Contains("state"))
                {
                    x_StateName = headers.GetValues("state").First().ToLower();
                }
                if (headers.Contains("district"))
                {
                    x_DistrictName = headers.GetValues("district").First().ToLower();
                }
                DataSet ds = new DataSet();
                DataSet ds1 = new DataSet();
                ds = BzCatagory.BZLeftMenu(version, x_StateName, x_DistrictName);
                
                if (ds.Tables.Count > 0)
                {
                    
                    var weather = new
                    {
                        Temperature = "",//"26 °C",
                        Image = ""//"https://behtarzindagi.in/BZFarmerApp_Test/Images/partly_cloudy.PNG"
                        
                    };
                    //var BZLeftMenu = ds.Tables["BZLeftMenu"].AsEnumerable();
                    List<dynamic> objList = new List<dynamic>();
                    if (ds.Tables.Count > 3)
                    {
                        ds.Tables[0].TableName = "BZLeftMenu";
                        ds.Tables[1].TableName = "SarkariYojana";
                        ds.Tables[2].TableName = "Location";
                        ds.Tables[3].TableName = "AvailProduct";
                        ds1.Tables.Add(ds.Tables[0].Copy());
                        ds1.Tables.Add(ds.Tables[1].Copy());
                        ds1.Tables.Add(ds.Tables[2].Copy());
                        if (ds1.Tables["BZLeftMenu"].Rows.Count > 0)
                        {
                            objList.Add(ds1);
                            objList.Add(weather);
                            if (ds.Tables[3].Rows[0]["IsAvailable"].ToString() == "0") { return Ok(new { BZReponse = objList, Msg = "Jankari", Status = false }); }
                            else {
                                return Ok(new { BZReponse = objList, Status = true, ShareMsg = "अपने साथी किसान भाइयो को ये एप्प शेयर करे और जीते 770 रुपये की शर्ट बिल्कुल मुफ़्त! <br/> ऑफर पहली खरीद पर मान्य!" });
                            }
                        }
                        else
                        {
                            return Ok(new { BZReponse = "", Msg = "Jankari", Status = false, ShareMsg = "अपने साथी किसान भाइयो को ये एप्प शेयर करे और जीते 770 रुपये की शर्ट बिल्कुल मुफ़्त! <br/> ऑफर पहली खरीद पर मान्य!" });
                        }
                    }
                    else { 
                        ds.Tables[0].TableName = "SarkariYojana";
                        ds.Tables[1].TableName = "Location";
                        objList.Add(ds);
                        objList.Add(weather);
                        return Ok(new { BZReponse = objList, Msg = "Jankari", Status = true, ShareMsg = "अपने साथी किसान भाइयो को ये एप्प शेयर करे और जीते 770 रुपये की शर्ट बिल्कुल मुफ़्त! <br/> ऑफर पहली खरीद पर मान्य!" });
                    }
                }
                else { return Ok(new { BZReponse = "", Msg = "Jankari", Status = false, ShareMsg = "अपने साथी किसान भाइयो को ये एप्प शेयर करे और जीते 770 रुपये की शर्ट बिल्कुल मुफ़्त! <br/> ऑफर पहली खरीद पर मान्य!" }); }
            }
            catch (Exception ex)
            {
                LogDal.ErrorLog(this.GetType().Name, MethodBase.GetCurrentMethod().Name, ex.Message, 0);
                return Ok(new { BZReponse = "", Msg = "Jankari", Status = false, ShareMsg = "अपने साथी किसान भाइयो को ये एप्प शेयर करे और जीते 770 रुपये की शर्ट बिल्कुल मुफ़्त! <br/> ऑफर पहली खरीद पर मान्य!" });
            } 
        }

        [HttpGet]
        [Route("GetBZFAQCategoryList")]
        public IHttpActionResult GetBZFAQCategoryList(string version)
        {
            try
            {
                DataSet ds = new DataSet();
                ds = BzCatagory.GetBZFAQCategoryList(version);
                ds.Tables[0].TableName = "BZFarmerAppCatagory";
                if (ds.Tables["BZFarmerAppCatagory"].Rows.Count > 0)
                {
                    return Ok(new { BZAppCatagory = ds, Status = true });
                }
                else
                {
                    return Ok(new { BZAppCatagory = "", Status = false });
                }
            }
            catch (Exception ex)
            {
                LogDal.ErrorLog(this.GetType().Name, MethodBase.GetCurrentMethod().Name, ex.Message, 0);
                return Ok(new { BZAppCatagory = "", Status = false });
            }
        }
               
        [HttpPost]
        [Route("GetBZFAQList")]
        public IHttpActionResult GetBZFAQList(BZFAQ obj)
        {
            try
            {
                DataSet ds = new DataSet();
                ds = BzCatagory.GetBZFAQList(obj.version,obj.Name);
                ds.Tables[0].TableName = "BZFAQ";
                if (ds.Tables["BZFAQ"].Rows.Count > 0)
                {
                    return Ok(new { BZReponse = ds, Status = true });
                }
                else
                {
                    return Ok(new { BZReponse = "", Status = false });
                }
            }
            catch (Exception ex)
            {
                LogDal.ErrorLog(this.GetType().Name, MethodBase.GetCurrentMethod().Name, ex.Message, 0);
                return Ok(new { BZReponse = "", Status = false });
            }
        }
        
        
        //[HttpPost]
        //[Route("GetBzTipsData")]
        //public IHttpActionResult GetBzTipsData(BZFAQ obj)
        //{
        //    try
        //    {
        //        DataSet ds = new DataSet();
        //        ds = BzCatagory.GetBZTipsList(obj.version, obj.Name);
        //        ds.Tables[0].TableName = "BZTips";
        //        if (ds.Tables["BZTips"].Rows.Count > 0)
        //        {
        //            return Ok(new { BZReponse = ds, Status = true });
        //        }
        //        else
        //        {
        //            return Ok(new { BZReponse = "", Status = false });
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        LogDal.ErrorLog(this.GetType().Name, MethodBase.GetCurrentMethod().Name, ex.Message, 0);
        //        return Ok(new { BZReponse = "", Status = false });
        //    }
        //}


        [HttpGet]
        [Route("GetSathiAppProductDetails")]
        public IHttpActionResult GetSathiAppProductDetails(string version,int CategoryId, int BzProductId, int PackageId)
        {
            try
            {
                DataSet ds = new DataSet();
                ds = LiveStocks.GetSathiAppProductDetails(version, CategoryId, BzProductId, PackageId);
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        ds.Tables[0].TableName = "ImageAndVideo";
                        ds.Tables[1].TableName = "ProductDetails";
                        ds.Tables[2].TableName = "ProductDetailsHindi";
                        DataTable dTImageUrl = new DataTable("ImageUrlPath");
                        DataTable dTVideoUrl = new DataTable("VideoUrlPath");
                        DataTable dTProductDetails = new DataTable("ProductDetails");
                        dTImageUrl.Columns.Add("ImagePath");
                        dTVideoUrl.Columns.Add("VideoUrl");
                        dTVideoUrl.Columns.Add("ImagePath");

                        string[] imageUrl = null;
                        string[] videoUrl = null;
                        string[] ThumbnailPath = null;
                        if (ds.Tables[0].Rows[0]["ImageUrl"].ToString() != null)
                        {
                            ds.Tables[0].Rows[0]["ImageUrl"] = ds.Tables[0].Rows[0]["ImageUrl"].ToString();
                            imageUrl = ds.Tables[0].Rows[0]["ImageUrl"].ToString().Split('#');
                            foreach (var item in imageUrl)
                            {
                                var values = new object[1];
                                values[0] = item;
                                dTImageUrl.Rows.Add(values);
                            }
                        }
                        if (ds.Tables[0].Rows[0]["VideoUrl"].ToString() != null)
                        {
                            videoUrl = ds.Tables[0].Rows[0]["VideoUrl"].ToString().Split('#');
                            ThumbnailPath = ds.Tables[0].Rows[0]["VideoThumbnailPath"].ToString().Split('#');
                            for (int i = 0; i < videoUrl.Length; i++)
                            {
                                DataRow dr = dTVideoUrl.NewRow();
                                dr["VideoUrl"] = videoUrl[i];
                                if (i < ThumbnailPath.Length)
                                {
                                    dr["ImagePath"] = ThumbnailPath[i];
                                }
                                else
                                {
                                    dr["ImagePath"] = null;
                                }
                                dTVideoUrl.Rows.Add(dr);
                            }
                        }
                        DataSet dsNew = new DataSet();
                        dsNew.Tables.Add(dTImageUrl);
                        dsNew.Tables.Add(dTVideoUrl);
                        dsNew.Tables.Add(ds.Tables[1].Copy());
                        dsNew.Tables.Add(ds.Tables[2].Copy());
                        return Ok(new { BZApiReponse = dsNew, Status = true });
                    }
                    else
                    {
                        return Ok(new { BZApiReponse = "", Status = false });
                    }
                }
                else { return Ok(new { BZApiReponse = "", Status = false }); }
            }
            catch (Exception ex)
            {
                LogDal.ErrorLog(this.GetType().Name, MethodBase.GetCurrentMethod().Name, ex.Message, 0);
                return Ok(new { BZApiReponse = "", Status = false });
            }
        }

        [HttpPost]
        [Route("GetCouponValidity")]
        public IHttpActionResult GetCouponValidity(BZAgentCoupon obj)
        {
            try
            {
                DataSet ds = new DataSet();
                ds = BzCatagory.GetCouponValidity(obj.AgentId, obj.PackageId,obj.CouponCode,obj.quantity,obj.TxnValue);
                ds.Tables[0].TableName = "CouponDtl";
                if (ds.Tables["CouponDtl"].Rows.Count > 0)
                {
                    return Ok(new { BZReponse = ds, Status = true });
                }
                else
                {
                    return Ok(new { BZReponse = "", Status = false });
                }
            }
            catch (Exception ex)
            {
                LogDal.ErrorLog(this.GetType().Name, MethodBase.GetCurrentMethod().Name, ex.Message, 0);
                return Ok(new { BZReponse = "", Status = false });
            }
        }

        [HttpPost]
        [Route("InsertAgentCoupons")]
        public IHttpActionResult InsertAgentCoupons(BZAgentCoupon obj)
        {
            try
            {
                DataSet ds = new DataSet();
                ds = BzCatagory.InsertAgentCoupons(obj.OrderId, obj.CouponCode, obj.AgentId);
                ds.Tables[0].TableName = "AgentCoupon";
                if (ds.Tables["AgentCoupon"].Rows.Count > 0)
                {
                    return Ok(new { BZReponse = ds, Status = true });
                }
                else
                {
                    return Ok(new { BZReponse = "", Status = false });
                }
            }
            catch (Exception ex)
            {
                LogDal.ErrorLog(this.GetType().Name, MethodBase.GetCurrentMethod().Name, ex.Message, 0);
                return Ok(new { BZReponse = "", Status = false });
            }
        }
    }
}
