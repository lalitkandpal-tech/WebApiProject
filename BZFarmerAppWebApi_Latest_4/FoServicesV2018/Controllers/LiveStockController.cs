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
using Entity;
using BAL;

namespace FoServicesV2018.Controllers
{
    [RoutePrefix("api/LiveStock")]
    public class LiveStockController : ApiController
    {
        [HttpGet]
        public IHttpActionResult LiveStock()
        {
            return Ok();
        }
        [HttpGet]
        public IHttpActionResult LiveStockMethod(int LiveStockID, int BreedId, int MilkAmount, string Mode, string version)
        {
            try
            {
                DataSet ds = new DataSet();
                ds = LiveStocks.GetLiveStock(LiveStockID, BreedId, MilkAmount, Mode, version);
                ds.Tables[0].TableName = "LiveStockDetails";
                ds.Tables[1].TableName = "AnimalDetails";
                DataSet ds1 = new DataSet();
                ds1 = LiveStocks.BZTrendsProducts("1", "", "");
                // ds1 = LiveStocks.BZLiveStockProducts("1");
                ds1.Tables[0].TableName = "Products";
                ds.Tables.Add(ds1.Tables[0].Copy());
                BALLiveStock objLiveStock = new BALLiveStock();
                List<BALLiveStock> ListLiveStock = new List<BALLiveStock>();
                var liveStockData = ds.Tables[0].AsEnumerable();
                var liveStockProduct = ds1.Tables[0].AsEnumerable();
                AnimalDetails objAnimal = new AnimalDetails();
                objAnimal.LiveStockId = Convert.ToInt32(ds.Tables["AnimalDetails"].Rows[0]["LiveStockId"]);
                objAnimal.LiveStockName = ds.Tables["AnimalDetails"].Rows[0]["LiveStockName"].ToString();
                objAnimal.LiveStockNameHindi = ds.Tables["AnimalDetails"].Rows[0]["LiveStockNameHindi"].ToString();
                objAnimal.LiveStockType = Convert.ToInt32(ds.Tables["AnimalDetails"].Rows[0]["LiveStockType"]);
                objAnimal.BreedId = Convert.ToInt32(ds.Tables["AnimalDetails"].Rows[0]["BreedId"]);
                objAnimal.BreedName = Convert.ToString(ds.Tables["AnimalDetails"].Rows[0]["BreedName"]);
                objAnimal.IsMilk = Convert.ToBoolean(ds.Tables["AnimalDetails"].Rows[0]["IsMilk"]);
                objAnimal.MilkQuantity = Convert.ToInt32(ds.Tables["AnimalDetails"].Rows[0]["MilkQuantity"]);
                objAnimal.IsActive = Convert.ToBoolean(ds.Tables["AnimalDetails"].Rows[0]["IsActive"]);
                objAnimal.ImageUrl = ds.Tables["AnimalDetails"].Rows[0]["ImageUrl"].ToString();
                objAnimal.BALLiveStock = new List<BALLiveStock>();
                foreach (var item in liveStockData)
                {
                    objAnimal.BALLiveStock.Add(new BALLiveStock
                    {
                        ID = item.Field<int>("ID"),
                        Name = item.Field<string>("Name"),
                        Description = item.Field<string>("Description"),
                        Extra = item.Field<int>("Extra"),
                        IsShow = item.Field<bool>("IsShow"),
                        VideoUrl = item.Field<string>("VideoUrl"),
                        ImageUrl = item.Field<string>("ImageUrl"),
                        Products = new List<Products>()
                    });
                }

                foreach (var ItemList in objAnimal.BALLiveStock)
                {
                    foreach (var item1 in liveStockProduct)
                    {
                        if (item1.Field<long>("RowNumber") > 1)
                        {
                            ItemList.Products.Add(new Products
                            {
                                RowNumber = item1.Field<long>("RowNumber"),
                                ProductID = item1.Field<int>("ProductID"),
                                ProductName = item1.Field<string>("ProductName"),
                                OrganisationName = item1.Field<string>("OrganisationName"),
                                BrandName = item1.Field<string>("BrandName"),
                                TechnicalName = item1.Field<string>("TechnicalName"),
                                SubCategoryName = item1.Field<string>("SubCategoryName"),
                                CategoryName = item1.Field<string>("CategoryName"),
                                CategoryHindi = item1.Field<string>("CategoryHindi"),
                                CategoryID = item1.Field<byte>("CategoryID"),
                                PackageID = item1.Field<int>("PackageID"),
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
                                IsDetails = item1.Field<bool>("IsDetails"),
                                ImagePath = item1.Field<string>("ImagePath"),
                                DistrictID = item1.Field<int>("DistrictID"),
                                DistrictName = item1.Field<string>("DistrictName"),
                                COD = item1.Field<decimal>("COD"),
                                OnlinePrice = item1.Field<decimal>("OnlinePrice"),
                                MRP = item1.Field<decimal>("MRP"),
                                OfferDiscount = item1.Field<string>("OfferDiscount") + " छूट"
                            });
                        }
                    }
                }
                return Ok(new { LiveStockResults = objAnimal, Status = true });
            }
            catch (Exception ex)
            {
                LogDal.ErrorLog(this.GetType().Name, MethodBase.GetCurrentMethod().Name, ex.Message, 0);
                return Ok(new { LiveStockResults = "", Status = false });
            }
        }

        [HttpGet]
        [Route("GetLivestockStageAndProducts")]
        public IHttpActionResult GetLivestockStageAndProducts(int LiveStockID, int? BreedId, int? MilkAmount, int? DistrictId, string version)
        {
            try
            {
                DataSet ds = new DataSet();
                ds = LiveStocks.GetStageAndProducts(LiveStockID, BreedId, MilkAmount, DistrictId, version);
                ds.Tables[1].TableName = "LiveStockDetails";
                ds.Tables[0].TableName = "AnimalDetails";
                ds.Tables[2].TableName = "Products";
                if (ds.Tables[0].Rows.Count > 0)
                {
                    BALLiveStock objLiveStock = new BALLiveStock();
                    List<BALLiveStock> ListLiveStock = new List<BALLiveStock>();
                    var liveStockData = ds.Tables[1].AsEnumerable();
                    var liveStockProduct = ds.Tables[2].AsEnumerable();
                    AnimalDetails objAnimal = new AnimalDetails();
                    objAnimal.LiveStockId = Convert.ToInt32(ds.Tables["AnimalDetails"].Rows[0]["LiveStockId"]);
                    objAnimal.LiveStockName = ds.Tables["AnimalDetails"].Rows[0]["LiveStockName"].ToString();
                    objAnimal.LiveStockNameHindi = ds.Tables["AnimalDetails"].Rows[0]["LiveStockNameHindi"].ToString();
                    objAnimal.LiveStockType = Convert.ToInt32(ds.Tables["AnimalDetails"].Rows[0]["LiveStockType"]);
                    objAnimal.BreedId = Convert.ToInt32(ds.Tables["AnimalDetails"].Rows[0]["BreedId"]);
                    objAnimal.BreedName = Convert.ToString(ds.Tables["AnimalDetails"].Rows[0]["BreedName"]);
                    objAnimal.IsMilk = Convert.ToBoolean(ds.Tables["AnimalDetails"].Rows[0]["IsMilk"] == DBNull.Value ? false : ds.Tables["AnimalDetails"].Rows[0]["IsMilk"]);
                    objAnimal.MilkQuantity = Convert.ToInt32(ds.Tables["AnimalDetails"].Rows[0]["MilkQuantity"] == DBNull.Value ? 0 : ds.Tables["AnimalDetails"].Rows[0]["MilkQuantity"]);
                    objAnimal.IsActive = Convert.ToBoolean(ds.Tables["AnimalDetails"].Rows[0]["IsActive"] == DBNull.Value ? 0 : ds.Tables["AnimalDetails"].Rows[0]["IsActive"]);
                    objAnimal.ImageUrl = ds.Tables["AnimalDetails"].Rows[0]["ImageUrl"].ToString();
                    objAnimal.BALLiveStock = new List<BALLiveStock>();
                    foreach (var item in liveStockData)
                    {
                        objAnimal.BALLiveStock.Add(new BALLiveStock
                        {
                            ID = item.Field<int>("StageId"),
                            Name = item.Field<string>("HindiName") == null ? "" : item.Field<string>("HindiName"),
                            Description = item.Field<string>("StageDescriptionHindi") == null ? "" : item.Field<string>("StageDescriptionHindi"),
                            Extra = item.Field<int?>("Extra") == null ? 0 : item.Field<int>("Extra"),
                            IsShow = item.Field<bool?>("IsShow") == null ? false : item.Field<bool>("IsShow"),
                            VideoUrl = item.Field<string>("VideoUrl") == null ? "" : item.Field<string>("VideoUrl"),
                            ImageUrl = item.Field<string>("ImageUrl") == null ? "" : item.Field<string>("ImageUrl"),
                            Products = new List<Products>()
                        });
                    }

                    foreach (var ItemList in objAnimal.BALLiveStock)
                    {
                        foreach (var item1 in liveStockProduct)
                        {
                            if (item1.Field<int>("StageId") == ItemList.ID)
                            {
                                ItemList.Products.Add(new Products
                                {
                                    RowNumber = item1.Field<long>("RowNumber"),
                                    ProductID = item1.Field<int>("ProductID"),
                                    ProductName = item1.Field<string>("ProductName"),
                                    OrganisationName = item1.Field<string>("OrganisationName"),
                                    BrandName = item1.Field<string>("BrandName"),
                                    TechnicalName = item1.Field<string>("TechnicalName"),
                                    SubCategoryName = item1.Field<string>("SubCategoryName"),
                                    CategoryName = item1.Field<string>("CategoryName"),
                                    CategoryHindi = item1.Field<string>("CategoryHindi"),
                                    CategoryID = item1.Field<byte>("CategoryID"),
                                    PackageID = item1.Field<int>("PackageID"),
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
                                    IsDetails = item1.Field<bool?>("IsDetails") == null ? false : true,
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
                    return Ok(new { LiveStockResults = objAnimal, Status = true });
                }
                else
                {
                    ds = LiveStocks.GetLiveStockAndBread(LiveStockID, BreedId, version);
                    ds.Tables[0].TableName = "AnimalDetails";
                    ds.Tables[1].TableName = "BreadDetails";
                    AnimalDetails objAnimal = new AnimalDetails();
                    objAnimal.LiveStockId = Convert.ToInt32(ds.Tables["AnimalDetails"].Rows[0]["LiveStockId"]);
                    objAnimal.LiveStockName = ds.Tables["AnimalDetails"].Rows[0]["LiveStockName"].ToString();
                    objAnimal.LiveStockNameHindi = ds.Tables["AnimalDetails"].Rows[0]["LiveStockNameHindi"].ToString();
                    objAnimal.LiveStockType = Convert.ToInt32(ds.Tables["AnimalDetails"].Rows[0]["LiveStockType"]);
                    objAnimal.BreedId = Convert.ToInt32(ds.Tables["BreadDetails"].Rows[0]["BreedId"]);
                    objAnimal.BreedName = Convert.ToString(ds.Tables["BreadDetails"].Rows[0]["BreedName"]);
                    objAnimal.IsMilk = Convert.ToBoolean(ds.Tables["BreadDetails"].Rows[0]["IsMilk"] == DBNull.Value ? false : ds.Tables["BreadDetails"].Rows[0]["IsMilk"]);
                    objAnimal.MilkQuantity = Convert.ToInt32(ds.Tables["BreadDetails"].Rows[0]["MilkQuantity"] == DBNull.Value ? 0 : ds.Tables["BreadDetails"].Rows[0]["MilkQuantity"]);
                    objAnimal.IsActive = Convert.ToBoolean(ds.Tables["AnimalDetails"].Rows[0]["IsActive"] == DBNull.Value ? 0 : ds.Tables["AnimalDetails"].Rows[0]["IsActive"]);
                    objAnimal.ImageUrl = ds.Tables["AnimalDetails"].Rows[0]["ImageUrl"].ToString();
                    objAnimal.BALLiveStock = new List<BALLiveStock>();
                    return Ok(new { LiveStockResults = objAnimal, Status = true });
                }
            }
            catch (Exception ex)
            {
                LogDal.ErrorLog(this.GetType().Name, MethodBase.GetCurrentMethod().Name, ex.Message, 0);
                return Ok(new { LiveStockResults = "", Status = false });
            }
        }

        [HttpGet]
        [Route("GetTrendsProducts")]
        public IHttpActionResult GetTrendsProducts(string version)
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
                ds = LiveStocks.BZTrendsProducts(version, x_StateName, x_DistrictName);

                //ds.Tables[0].TableName = "TrendsProducts";Product,ProductsApiReponse
                ds.Tables[0].TableName = "Product";
                //return Ok(new { TrendsProductsApiReponse = ds, Status = true }); 
                return Ok(new { ProductsApiReponse = ds, Status = true });
            }
            catch (Exception ex)
            {
                LogDal.ErrorLog(this.GetType().Name, MethodBase.GetCurrentMethod().Name, ex.Message, 0);
                return Ok(new { ProductsApiReponse = "", Status = false });
            }
        }


        [HttpGet]
        [Route("BZFarmerAppServices")]
        public IHttpActionResult BZFarmerAppServices(string version)
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
                ds = LiveStocks.AppServices(version, x_StateName, x_DistrictName);
                if (ds.Tables.Count > 0)
                {
                    List<dynamic> objlist = new List<dynamic>();
                    if (ds.Tables.Count > 2)
                    {
                        ds.Tables[0].TableName = "BZFarmerAppServices";
                        ds.Tables[1].TableName = "District";
                        ds.Tables[2].TableName = "State";
                        var Location = new
                        {
                            DistrictId = ds.Tables[1].Rows[0]["DistrictId"],
                            StateId = ds.Tables[2].Rows[0]["State"]
                        };
                        objlist.Add(Location);
                    }
                    else
                    {
                        var Location = new
                        {
                            DistrictId = "",
                            StateId = ""
                        };
                        objlist.Add(Location);
                    }
                    DataSet ds1 = new DataSet();
                    ds.Tables[0].TableName = "BZFarmerAppServices";
                    ds1.Tables.Add(ds.Tables[0].Copy());

                    return Ok(new { BZApiReponse = ds1, Location = objlist, Status = true });
                }
                else
                {
                    return Ok(new { BZApiReponse = "", Msg = "Jankari", Status = false });
                }
            }
            catch (Exception ex)
            {
                LogDal.ErrorLog(this.GetType().Name, MethodBase.GetCurrentMethod().Name, ex.Message, 0);
                return Ok(new { BZApiReponse = "", Msg = "Jankari", Status = false });
            }
        }

        [HttpGet]
        [Route("BZLiveStock")]
        public IHttpActionResult BZLiveStock(string version)
        {
            try
            {
                DataSet ds = new DataSet();
                ds = LiveStocks.BZLiveStock(version);
                ds.Tables[0].TableName = "GetBZLiveStock";
                return Ok(new { BZApiReponse = ds, Status = true });
            }
            catch (Exception ex)
            {
                LogDal.ErrorLog(this.GetType().Name, MethodBase.GetCurrentMethod().Name, ex.Message, 0);
                return Ok(new { BZApiReponse = "", Status = false });
            }
        }
        [HttpGet]
        public IHttpActionResult GetBZLiveStockBreed(int LiveStockId, string version)
        {
            try
            {
                DataSet ds = new DataSet();
                ds = LiveStocks.BZLiveStockBreed(LiveStockId, version);
                ds.Tables[0].TableName = "BZLiveStockBreed";
                return Ok(new { BZApiReponse = ds, Status = true });
            }
            catch (Exception ex)
            {
                LogDal.ErrorLog(this.GetType().Name, MethodBase.GetCurrentMethod().Name, ex.Message, 0);
                return Ok(new { BZApiReponse = "", Status = false });
            }
        }

        [HttpGet]
        [Route("GetTodayOfferProduct")]
        public IHttpActionResult GetTodayOfferProduct(string version, int? CategoryId)
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
                ds = LiveStocks.GetTodayOfferProducts(version, CategoryId, x_StateName, x_DistrictName);

                ds.Tables[0].TableName = "Product";
                return Ok(new { ProductsApiReponse = ds, Status = true });

            }
            catch (Exception ex)
            {
                LogDal.ErrorLog(this.GetType().Name, MethodBase.GetCurrentMethod().Name, ex.Message, 0);
                return Ok(new { ProductsApiReponse = "", Status = false });
            }
        }

        [HttpGet]
        [Route("GetCategoryWiseProducts")]
        public IHttpActionResult GetCategoryWiseProducts(string version, int? CategoryId, int? SubCategoryId, int DistrictId, int PageIndex, int PageSize)
        {
            try
            {
                DataSet ds = new DataSet();
                DataSet ds1 = new DataSet();
                ds = LiveStocks.GetCategoryWiseProduct(version, CategoryId, SubCategoryId, DistrictId, null, PageIndex, PageSize);
                //if (CategoryId == 2)
                //{
                //    ds1 = LiveStocks.GetCropDetails(version, CategoryId);
                //} 
                //else 
                //{
                //    ds1 = LiveStocks.GetSubCategories(version,CategoryId, true);
                //}
                //ds1.Tables[0].TableName = "SubCategory";
                ds.Tables[0].TableName = "Product";
                var productData = ds.Tables[0].AsEnumerable();
                var distinctData = productData.Select(x => x.Field<string>("ProductHindiName")).Distinct();
                DataSet ds2 = new DataSet();
                ds2.Tables.Add(ds.Tables[0].Copy());
                //ds2.Tables.Add(ds1.Tables[0].Copy());
                if (ds2.Tables[0].Rows.Count > 0)
                {
                    return Ok(new { ProductsApiReponse = ds2, Status = true });
                }
                else { return Ok(new { ProductsApiReponse = "", Status = false }); }
            }
            catch (Exception ex)
            {
                LogDal.ErrorLog(this.GetType().Name, MethodBase.GetCurrentMethod().Name, ex.Message, 0);
                return Ok(new { ProductsApiReponse = "", Status = false });
            }
        }

        [HttpGet]
        [Route("GetSubCategory")]
        public IHttpActionResult GetSubCategory(string version, int? CategoryId)
        {
            try
            {

                #region Authentication Token
                //System.Net.Http.Headers.HttpRequestHeaders headers = this.Request.Headers;
                //string token = string.Empty;
                //string pwd = string.Empty;
                //if (headers.Contains("username"))
                //{
                //    token = headers.GetValues("username").First();
                //}
                //if (headers.Contains("password"))
                //{
                //    pwd = headers.GetValues("password").First();
                //}
                #endregion

                System.Net.Http.Headers.HttpRequestHeaders headers = this.Request.Headers;
                string x_StateName = string.Empty;
                string x_DistrictName = string.Empty;
                if (headers.Contains("x_StateName"))
                {
                    x_StateName = headers.GetValues("x_StateName").First();
                }
                if (headers.Contains("x_DistrictName"))
                {
                    x_DistrictName = headers.GetValues("x_DistrictName").First();
                }
                DataSet ds1 = new DataSet();
                //if (CategoryId == 2)
                //{
                //    ds1 = LiveStocks.GetCropDetails(version, CategoryId);
                //}
                //else
                //{
                ds1 = LiveStocks.GetSubCategories(version, CategoryId, true, x_StateName, x_DistrictName);
                //}
                ds1.Tables[0].TableName = "SubCategory";
                return Ok(new { ProductsApiReponse = ds1, Status = true });
            }
            catch (Exception ex)
            {
                LogDal.ErrorLog(this.GetType().Name, MethodBase.GetCurrentMethod().Name, ex.Message, 0);
                return Ok(new { ProductsApiReponse = "", Status = false });
            }
        }

        [HttpGet]
        [Route("GetBrandWiseCategory")]
        public IHttpActionResult GetBrandWiseCategory(string version, int? CategoryId, int BrandId, int DistrictId, int PageIndex, int PageSize)
        {
            try
            {
                DataSet ds = new DataSet();
                DataSet ds1 = new DataSet();
                ds = LiveStocks.GetCategoryWiseProduct(version, CategoryId, null, DistrictId, BrandId, PageIndex, PageSize);
                ds.Tables[0].TableName = "Product";
                ds.Tables[1].TableName = "BrandCategory";
                var productData = ds.Tables[0].AsEnumerable();
                var distinctData = productData.Select(x => x.Field<string>("ProductHindiName")).Distinct();
                DataSet ds2 = new DataSet();
                ds2.Tables.Add(ds.Tables[1].Copy());
                if (ds.Tables[1].Rows.Count > 0)
                {
                    return Ok(new { ProductsApiReponse = ds2, Status = true });
                }
                else { return Ok(new { ProductsApiReponse = "", Status = false }); }
            }
            catch (Exception ex)
            {
                LogDal.ErrorLog(this.GetType().Name, MethodBase.GetCurrentMethod().Name, ex.Message, 0);
                return Ok(new { ProductsApiReponse = "", Status = false });
            }
        }
        [HttpGet]
        [Route("GetBrandWiseProduct")]
        public IHttpActionResult GetBrandWiseProduct(string version, int? CategoryId, int BrandId, int DistrictId, int PageIndex, int PageSize)
        {
            try
            {
                DataSet ds = new DataSet();
                DataSet ds1 = new DataSet();
                ds = LiveStocks.GetCategoryWiseProduct(version, CategoryId, null, DistrictId, BrandId, PageIndex, PageSize);
                ds.Tables[0].TableName = "Product";
                ds.Tables[1].TableName = "BrandCategory";
                ds1.Tables.Add(ds.Tables["Product"].Copy());
                var productData = ds.Tables[0].AsEnumerable();
                var distinctData = productData.Select(x => x.Field<string>("ProductHindiName")).Distinct();
                if (ds.Tables[0].Rows.Count > 0) { return Ok(new { ProductsApiReponse = ds1, Status = true }); }
                else { return Ok(new { ProductsApiReponse = "", Status = false }); }

            }
            catch (Exception ex)
            {
                LogDal.ErrorLog(this.GetType().Name, MethodBase.GetCurrentMethod().Name, ex.Message, 0);
                return Ok(new { ProductsApiReponse = "", Status = false });
            }
        }

        [HttpPost]
        [Route("OrderCreate")]
        public CreatedOrderResult OrderCreate(OrderCreateModel obj)
        {
            ReasonStatusBal _rsbal = new ReasonStatusBal();
            CreatedOrderResult objCreateOrderData = new CreatedOrderResult();
            int flag = 0;
            Dictionary<string, int> returndata = new Dictionary<string, int>();
            returndata.Add("status", 0);

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
                objCreateOrderData = _rsbal.OrderCreate(obj, x_StateName, x_DistrictName);
            }
            catch (Exception ex)
            {
                LogDal.ErrorLog(this.GetType().Name, MethodBase.GetCurrentMethod().Name, ex.Message, obj.userid);
            }

            // string json = JsonConvert.SerializeObject(returndata);
            //HttpContext.Current.Response.ContentType = "application/json; charset=utf-8";
            //HttpContext.Current.Response.Write(json);
            return objCreateOrderData;
        }

        [HttpPost]
        [Route("OrderCreateV2")]
        public CreatedOrderResult OrderCreateV2(OrderCreateModel obj)
        {
            ReasonStatusBal _rsbal = new ReasonStatusBal();
            CreatedOrderResult objCreateOrderData = new CreatedOrderResult();
            int flag = 0;
            Dictionary<string, int> returndata = new Dictionary<string, int>();
            returndata.Add("status", 0);

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
                objCreateOrderData = _rsbal.OrderCreateV2(obj, x_StateName, x_DistrictName);
            }
            catch (Exception ex)
            {
                LogDal.ErrorLog(this.GetType().Name, MethodBase.GetCurrentMethod().Name, ex.Message, obj.userid);
            }

            // string json = JsonConvert.SerializeObject(returndata);
            //HttpContext.Current.Response.ContentType = "application/json; charset=utf-8";
            //HttpContext.Current.Response.Write(json);
            return objCreateOrderData;
        }


        [HttpGet]
        [Route("GetProductsBySearch")]
        public IHttpActionResult GetProductsBySearch(string version, string SearchText)
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
                ds = LiveStocks.GetProductsBySearch(version, x_StateName, x_DistrictName,SearchText);
                
                ds.Tables[0].TableName = "Product";
                var productData = ds.Tables[0].AsEnumerable();
                var distinctData = productData.Select(x => x.Field<string>("ProductHindiName")).Distinct();
                DataSet ds2 = new DataSet();
                ds2.Tables.Add(ds.Tables[0].Copy());
                //ds2.Tables.Add(ds1.Tables[0].Copy());
                if (ds2.Tables[0].Rows.Count > 0)
                {
                    return Ok(new { ProductsApiReponse = ds2, Status = true });
                }
                else { return Ok(new { ProductsApiReponse = "", Status = false }); }
            }
            catch (Exception ex)
            {
                LogDal.ErrorLog(this.GetType().Name, MethodBase.GetCurrentMethod().Name, ex.Message, 0);
                return Ok(new { ProductsApiReponse = "", Status = false });
            }
        }

        [HttpGet]
        [Route("GetBehtarBachatOffer")]
        public IHttpActionResult GetBehtarBachatOffer(string version)
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
                ds = LiveStocks.GetBehtarBachatOffer(version, x_StateName, x_DistrictName);

                //ds.Tables[0].TableName = "TrendsProducts";Product,ProductsApiReponse
                ds.Tables[0].TableName = "Product";
                //return Ok(new { TrendsProductsApiReponse = ds, Status = true }); 
                return Ok(new { ProductsApiReponse = ds, Status = true });
            }
            catch (Exception ex)
            {
                LogDal.ErrorLog(this.GetType().Name, MethodBase.GetCurrentMethod().Name, ex.Message, 0);
                return Ok(new { ProductsApiReponse = "", Status = false });
            }
        }

        [HttpGet]
        [Route("GetHumTumOffer")]
        public IHttpActionResult GetHumTumOffer(string version)
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
                ds = LiveStocks.GetHumTumOffer(version, x_StateName, x_DistrictName);

                //ds.Tables[0].TableName = "TrendsProducts";Product,ProductsApiReponse
                ds.Tables[0].TableName = "Product";
                //return Ok(new { TrendsProductsApiReponse = ds, Status = true }); 
                return Ok(new { ProductsApiReponse = ds, Status = true });
            }
            catch (Exception ex)
            {
                LogDal.ErrorLog(this.GetType().Name, MethodBase.GetCurrentMethod().Name, ex.Message, 0);
                return Ok(new { ProductsApiReponse = "", Status = false });
            }
        }

        //[HttpGet]
        //[Route("GetOrderTracking")]
        //public IHttpActionResult GetOrderTracking(string version, int UserId)
        //{
        //    try
        //    {
        //        System.Net.Http.Headers.HttpRequestHeaders headers = this.Request.Headers;
        //        string x_StateName = string.Empty;
        //        string x_DistrictName = string.Empty;
        //        if (headers.Contains("state"))
        //        {
        //            x_StateName = headers.GetValues("state").First().ToLower();
        //        }
        //        if (headers.Contains("district"))
        //        {
        //            x_DistrictName = headers.GetValues("district").First().ToLower();
        //        }

        //        DataSet ds = new DataSet();
        //        DataSet ds1 = new DataSet();
        //        ds = LiveStocks.GetProductsBySearch(version, x_StateName, x_DistrictName, SearchText);

        //        ds.Tables[0].TableName = "Product";
        //        var productData = ds.Tables[0].AsEnumerable();
        //        var distinctData = productData.Select(x => x.Field<string>("ProductHindiName")).Distinct();
        //        DataSet ds2 = new DataSet();
        //        ds2.Tables.Add(ds.Tables[0].Copy());
        //        //ds2.Tables.Add(ds1.Tables[0].Copy());
        //        if (ds2.Tables[0].Rows.Count > 0)
        //        {
        //            return Ok(new { ProductsApiReponse = ds2, Status = true });
        //        }
        //        else { return Ok(new { ProductsApiReponse = "", Status = false }); }
        //    }
        //    catch (Exception ex)
        //    {
        //        LogDal.ErrorLog(this.GetType().Name, MethodBase.GetCurrentMethod().Name, ex.Message, 0);
        //        return Ok(new { ProductsApiReponse = "", Status = false });
        //    }
        //}
    }
}
