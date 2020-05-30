using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data;
using DataLayer;
using System.Reflection;
using Entity;
using BAL;
using FoServicesV2018.Models;

namespace FoServicesV2018.Controllers
{
    [RoutePrefix("api/KitchenGarden")]
    public class KitchenGardenController : ApiController
    {

        [HttpGet]
        [Route("GetKGPCategory")]
        public IHttpActionResult GetKGPCategory(string version, string Type, int Id)
        {
            try
            {
                DataSet ds1 = new DataSet();
                ds1 = KitchenGarden.GetKGPCategory(version, Type, Id);


                ds1.Tables[0].TableName = "KGPCategory";
                return Ok(new { KGPApiReponse = ds1, Status = true });
            }
            catch (Exception ex)
            {
                LogDal.ErrorLog(this.GetType().Name, MethodBase.GetCurrentMethod().Name, ex.Message, 0);
                return Ok(new { KGPApiReponse = "", Status = false });
            }
        }

        [HttpGet]
        [Route("GetKGPSubCategory")]
        public IHttpActionResult GetKGPSubCategory(string version, string Type, int Id)
        {
            try
            {
                DataSet ds1 = new DataSet();
                ds1 = KitchenGarden.GetKGPSubCategory(version, Type, Id);


                ds1.Tables[0].TableName = "KGPSubCategory";
                return Ok(new { KGPApiReponse = ds1, Status = true });
            }
            catch (Exception ex)
            {
                LogDal.ErrorLog(this.GetType().Name, MethodBase.GetCurrentMethod().Name, ex.Message, 0);
                return Ok(new { KGPApiReponse = "", Status = false });
            }
        }

        [HttpGet]
        [Route("GetKGP_Products")]
        public IHttpActionResult GetKGP_Products(string version, int KGP_CategoryId, int KGP_SubCategoryId, int DistrictId, string DistrictName, string PinCode, int PageIndex, int PageSize)
        {
            try
            {
                DataSet ds1 = new DataSet();
                ds1 = KitchenGarden.GetKGP_Products(version, KGP_CategoryId, KGP_SubCategoryId, DistrictId, DistrictName, PinCode, PageIndex, PageSize);


                ds1.Tables[0].TableName = "KGPCategory";
                return Ok(new { KGPApiReponse = ds1, Status = true });
            }
            catch (Exception ex)
            {
                LogDal.ErrorLog(this.GetType().Name, MethodBase.GetCurrentMethod().Name, ex.Message, 0);
                return Ok(new { KGPApiReponse = "", Status = false });
            }
        }

        [HttpGet]
        [Route("GetKGPCategoryFilters")]
        public IHttpActionResult GetKGPCategoryFilters(string version, string lang, int? KGP_CategoryId = null)
        {
            try
            {
                List<KGPCategory> objkgpList = new List<KGPCategory>();
                DataSet ds1 = new DataSet();
                ds1 = KitchenGarden.GetKGPCategoryFilters(version, lang, KGP_CategoryId);
                ds1.Tables[0].TableName = "KGPCategory";
                ds1.Tables[1].TableName = "KGPSubCategory";
                ds1.Tables[2].TableName = "KGPBrands";
                var kgpCat = ds1.Tables["KGPCategory"].AsEnumerable();
                var kgpSubCat = ds1.Tables["KGPSubCategory"].AsEnumerable();
                var kgpBrands = ds1.Tables["KGPBrands"].AsEnumerable();
                foreach (var item in kgpCat)
                {
                    KGPCategory objkgp = new KGPCategory();
                    objkgp.KGP_CategoryId = item.Field<int>("KGP_CategoryId");
                    objkgp.KGP_CategoryName = item.Field<string>("KGP_CategoryName");
                    objkgp.KGP_CategoryHindi = item.Field<string>("KGP_CategoryHindi");
                    List<KGPSubCategory> objKgpSubCategory = new List<KGPSubCategory>();

                    objkgp.KGPSubCategory = objKgpSubCategory;
                    objkgpList.Add(objkgp);
                }
                foreach (var item1 in objkgpList)
                {
                    foreach (var item2 in kgpSubCat)
                    {
                        if (item2.Field<int>("KGP_CategoryId") == item1.KGP_CategoryId)
                        {
                            item1.KGPSubCategory.Add(new KGPSubCategory
                            {
                                KGP_SubCategoryId = item2.Field<int>("KGP_SubCategoryId"),
                                KGP_CategoryId = item2.Field<int>("KGP_CategoryId"),
                                KGP_SubCategoryName = item2.Field<string>("KGP_SubCategoryName"),
                                KGP_SubCategoryHindi = item2.Field<string>("KGP_SubCategoryHindi")
                            });
                        }
                    }
                }

                foreach (var item in kgpCat)
                {
                    KGPCategory objkgp1 = new KGPCategory();
                    objkgp1.KGP_CategoryId = 1000;
                    objkgp1.KGP_CategoryName = "Brands";

                    List<KGPSubCategory> objBrands = new List<KGPSubCategory>();
                    objkgp1.KGPSubCategory = objBrands;
                    objkgpList.Add(objkgp1);
                }
                foreach (var item1 in objkgpList)
                {
                    foreach (var item2 in kgpBrands)
                    {
                        if (item2.Field<int>("KGP_CategoryId") == 1000)
                        {
                            item1.KGPSubCategory.Add(new KGPSubCategory
                            {
                                KGP_SubCategoryId = item2.Field<int>("BrandID"),
                                KGP_CategoryId = item2.Field<int>("KGP_CategoryId"),
                                KGP_SubCategoryName = item2.Field<string>("BrandName")
                            });
                        }
                    }
                }
                foreach (var item3 in objkgpList[0].KGPSubCategory.Where(x => x.KGP_CategoryId == 1000).ToList())
                {
                    objkgpList[0].KGPSubCategory.Remove(item3);
                }//1000 is hardcode id for Brands
               

             


                return Ok(new { KGPApiReponse = objkgpList, Status = true });
            }
            catch (Exception ex)
            {
                LogDal.ErrorLog(this.GetType().Name, MethodBase.GetCurrentMethod().Name, ex.Message, 0);
                return Ok(new { KGPApiReponse = "", Status = false });
            }
        }

        [HttpPost]
        [Route("GetKGPCategorySubCategoryWiseData")]
        public IHttpActionResult GetKGPCategorySubCategoryWiseData(KitchenGardenEntity objkgpList)
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


                ReasonStatusBal _rsbal = new ReasonStatusBal();
                // DataSet ds1 = new DataSet();
                var ds1 = _rsbal.GetKGPCategorySubCategoryWiseData(objkgpList,x_StateName,x_DistrictName);
                ds1.Tables[0].TableName = "KGPResponse";
                ds1.Tables[1].TableName = "Count";
                return Ok(new { KGPApiReponse = ds1, Status = true });
            }
            catch (Exception ex)
            {
                LogDal.ErrorLog(this.GetType().Name, MethodBase.GetCurrentMethod().Name, ex.Message, 0);
                return Ok(new { KGPApiReponse = "", Status = false });
            }
        }

        [HttpPost]
        [Route("GetKGPCategorySubCategoryWiseDataV2")]
        public IHttpActionResult GetKGPCategorySubCategoryWiseDataV2(KitchenGardenEntity objkgpList)
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

                ReasonStatusBal _rsbal = new ReasonStatusBal();
                // DataSet ds1 = new DataSet();
                var ds1 = _rsbal.GetKGPCategorySubCategoryWiseData(objkgpList, x_StateName, x_DistrictName);
                ds1.Tables[0].TableName = "Product";
                ds1.Tables[1].TableName = "Count";
                return Ok(new { ProductsApiReponse = ds1, Status = true });
            }
            catch (Exception ex)
            {
                LogDal.ErrorLog(this.GetType().Name, MethodBase.GetCurrentMethod().Name, ex.Message, 0);
                return Ok(new { ProductsApiReponse = "", Status = false });
            }
        }
    }
}
