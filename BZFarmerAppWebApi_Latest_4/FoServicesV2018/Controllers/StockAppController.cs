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
using FoServicesV2018.Entity;

namespace FoServicesV2018.Controllers
{
    [RoutePrefix("api/StockApp")]
    public class StockAppController : ApiController
    {

        [HttpGet]
        [Route("GetDealerProductList")]
        public IHttpActionResult GetDealerProductList(string version, int? SubDealerId, string SearchCriteria, int PageIndex, int PageSize)
        {            
            try
            {
                StockInventoryEntity objDealerProductList = new StockInventoryEntity();
                DataSet ds = new DataSet();
                ds = StockInventory.GetDealerProductList(version, SubDealerId, SearchCriteria, PageIndex, PageSize);
                ds.Tables[0].TableName = "Category";
                ds.Tables[1].TableName = "Products";
                var Category = ds.Tables["Category"].AsEnumerable();
                var Products = ds.Tables["Products"].AsEnumerable();

                if (ds != null && ds.Tables[0] != null)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        List<CategoryList> _catList = new List<CategoryList>();
                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            CategoryList _category = new CategoryList();
                            _category.CategoryId = Convert.ToInt32(ds.Tables[0].Rows[i]["CategoryID"].ToString());
                            _category.CategoryName = ds.Tables[0].Rows[i]["CategoryName"].ToString();
                            _catList.Add(_category);
                        }
                        objDealerProductList._CategoryList = _catList;
                    }
                }

                if (ds != null && ds.Tables[1] != null)
                {
                    if (ds.Tables[1].Rows.Count > 0)
                    {
                        List<DealerProductData> _prodList = new List<DealerProductData>();
                        for (int i = 0; i < ds.Tables[1].Rows.Count; i++)
                        {
                            DealerProductData _product = new DealerProductData();

                            _product.ProductId = Convert.ToInt32(ds.Tables[1].Rows[i]["ProductId"].ToString());
                            _product.ProductName = ds.Tables[1].Rows[i]["ProductName"].ToString();
                            _product.CompanyName= ds.Tables[1].Rows[i]["OrganisationName"].ToString();                          
                            _product.BrandName= ds.Tables[1].Rows[i]["BrandName"].ToString();
                            _product.TechnicalName= ds.Tables[1].Rows[i]["TechnicalName"].ToString();
                            _product.CategoryId= Convert.ToInt32(ds.Tables[1].Rows[i]["CategoryId"].ToString());
                            _product.CategoryName= ds.Tables[1].Rows[i]["CategoryName"].ToString();
                            _product.SubCategoryId= Convert.ToInt32(ds.Tables[1].Rows[i]["SubCategoryId"].ToString());
                            _product.SubCategoryName= ds.Tables[1].Rows[i]["SubCategoryName"].ToString();
                            _product.PackageId = Convert.ToInt32(ds.Tables[1].Rows[i]["PackageId"].ToString());
                            _product.PackSize = ds.Tables[1].Rows[i]["Amount"].ToString()+" "+ ds.Tables[1].Rows[i]["unitname"].ToString();
                            _product.DealerID = Convert.ToInt32(ds.Tables[1].Rows[i]["dealerId"].ToString());
                            _product.DealerName = ds.Tables[1].Rows[i]["DealerName"].ToString();
                            _product.DealerPrice= Convert.ToDecimal(ds.Tables[1].Rows[i]["DealerPrice"].ToString());
                            _product.RecordId= Convert.ToInt32(ds.Tables[1].Rows[i]["RecordId"].ToString());
                            _product.IsActive = Convert.ToBoolean(ds.Tables[1].Rows[i]["IsActive"].ToString());
                            _product.PackageName = ds.Tables[1].Rows[i]["ProductName"].ToString() + " - " + ds.Tables[1].Rows[i]["TechnicalName"].ToString();
                                //+ "(" + ds.Tables[1].Rows[i]["Amount"].ToString() + ds.Tables[1].Rows[i]["UnitName"].ToString()
                                //+ ds.Tables[1].Rows[i]["DealerPrice"].ToString() + ")";
                            _product.StockId = ds.Tables[1].Rows[i]["StockId"]==DBNull.Value?0: Convert.ToInt32(ds.Tables[1].Rows[i]["StockId"].ToString());
                            _product.StockQuantity = ds.Tables[1].Rows[i]["StockQuantity"] == DBNull.Value ? 0 : Convert.ToInt32(ds.Tables[1].Rows[i]["StockQuantity"].ToString());
                            _prodList.Add(_product);
                        }
                        objDealerProductList._DealerProductList = _prodList;
                    }
                }
               
                return Ok(new { KGPApiReponse = objDealerProductList, Status = true });
            }
            catch (Exception ex)
            {
                LogDal.ErrorLog(this.GetType().Name, MethodBase.GetCurrentMethod().Name, ex.Message, 0);
                return Ok(new { KGPApiReponse = "", Status = false });
            }
        }

        [HttpPost]
        [Route("SaveSubDealerProducts")]
        public SavedProductResult SaveSubDealerProducts(SubDealerProductCreate obj)
        {
            ReasonStatusBal _rsbal = new ReasonStatusBal();
            SavedProductResult objSavedData = new SavedProductResult();
            int flag = 0;
            Dictionary<string, int> returndata = new Dictionary<string, int>();
            returndata.Add("status", 0);

            try
            {

                objSavedData = _rsbal.SaveSubDealerProducts(obj);
            }
            catch (Exception ex)
            {
                LogDal.ErrorLog(this.GetType().Name, MethodBase.GetCurrentMethod().Name, ex.Message, obj.StockId);
            }
            
            return objSavedData;
        }

        [HttpGet]
        [Route("GetSubDealerProductList")]
        public IHttpActionResult GetSubDealerProductList(string version, int? SubDealerId, string SearchCriteria, int PageIndex, int PageSize)
        {
            try
            {
                StockInventoryEntity objSubDealerProductList = new StockInventoryEntity();
                DataSet ds = new DataSet();
                ds = StockInventory.GetSubDealerProductList(version, SubDealerId, SearchCriteria, PageIndex, PageSize);
                ds.Tables[0].TableName = "Category";
                ds.Tables[1].TableName = "Products";
                var Category = ds.Tables["Category"].AsEnumerable();
                var Products = ds.Tables["Products"].AsEnumerable();

                if (ds != null && ds.Tables[0] != null)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        List<CategoryList> _catList = new List<CategoryList>();
                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            CategoryList _category = new CategoryList();
                            _category.CategoryId = Convert.ToInt32(ds.Tables[0].Rows[i]["CategoryID"].ToString());
                            _category.CategoryName = ds.Tables[0].Rows[i]["CategoryName"].ToString();
                            _catList.Add(_category);
                        }
                        objSubDealerProductList._CategoryList = _catList;
                    }
                }

                if (ds != null && ds.Tables[1] != null)
                {
                    if (ds.Tables[1].Rows.Count > 0)
                    {
                        List<DealerProductData> _prodList = new List<DealerProductData>();
                        for (int i = 0; i < ds.Tables[1].Rows.Count; i++)
                        {
                            DealerProductData _product = new DealerProductData();

                            _product.ProductId = Convert.ToInt32(ds.Tables[1].Rows[i]["ProductId"].ToString());
                            _product.ProductName = ds.Tables[1].Rows[i]["ProductName"].ToString();
                            _product.CompanyName = ds.Tables[1].Rows[i]["OrganisationName"].ToString();
                            _product.BrandName = ds.Tables[1].Rows[i]["BrandName"].ToString();
                            _product.TechnicalName = ds.Tables[1].Rows[i]["TechnicalName"].ToString();
                            _product.CategoryId = Convert.ToInt32(ds.Tables[1].Rows[i]["CategoryId"].ToString());
                            _product.CategoryName = ds.Tables[1].Rows[i]["CategoryName"].ToString();
                            _product.SubCategoryId = Convert.ToInt32(ds.Tables[1].Rows[i]["SubCategoryId"].ToString());
                            _product.SubCategoryName = ds.Tables[1].Rows[i]["SubCategoryName"].ToString();
                            _product.PackageId = Convert.ToInt32(ds.Tables[1].Rows[i]["PackageId"].ToString());
                            _product.PackSize = ds.Tables[1].Rows[i]["Amount"].ToString() + " " + ds.Tables[1].Rows[i]["unitname"].ToString();
                            _product.DealerID = Convert.ToInt32(ds.Tables[1].Rows[i]["dealerId"].ToString());
                            _product.DealerName = ds.Tables[1].Rows[i]["DealerName"].ToString();
                            _product.DealerPrice = Convert.ToDecimal(ds.Tables[1].Rows[i]["DealerPrice"].ToString());
                            _product.RecordId = Convert.ToInt32(ds.Tables[1].Rows[i]["RecordId"].ToString());
                            _product.IsActive = Convert.ToBoolean(ds.Tables[1].Rows[i]["IsActive"].ToString());
                            _product.PackageName = ds.Tables[1].Rows[i]["ProductName"].ToString() + " - " + ds.Tables[1].Rows[i]["TechnicalName"].ToString();
                                //+ "(" + ds.Tables[1].Rows[i]["Amount"].ToString() + ds.Tables[1].Rows[i]["UnitName"].ToString()
                                //+ ds.Tables[1].Rows[i]["DealerPrice"].ToString() + ")";
                            _product.StockId = ds.Tables[1].Rows[i]["StockId"] == DBNull.Value ? 0 : Convert.ToInt32(ds.Tables[1].Rows[i]["StockId"].ToString());
                            _product.StockQuantity = ds.Tables[1].Rows[i]["StockQuantity"] == DBNull.Value ? 0 : Convert.ToInt32(ds.Tables[1].Rows[i]["StockQuantity"].ToString());
                            _prodList.Add(_product);
                        }
                        objSubDealerProductList._DealerProductList = _prodList;
                    }
                }

                return Ok(new { KGPApiReponse = objSubDealerProductList, Status = true });
            }
            catch (Exception ex)
            {
                LogDal.ErrorLog(this.GetType().Name, MethodBase.GetCurrentMethod().Name, ex.Message, 0);
                return Ok(new { KGPApiReponse = "", Status = false });
            }
        }

        [HttpPost]
        [Route("SaveTractorUsersDetail")]
        public ApiPostResponse SaveTractorUsersDetail(TractorUsers obj)
        {
            ReasonStatusBal _rsbal = new ReasonStatusBal();
            ApiPostResponse objSavedData = new ApiPostResponse();
            int flag = 0;
            Dictionary<string, int> returndata = new Dictionary<string, int>();
            returndata.Add("status", 0);

            try
            {
                objSavedData = _rsbal.SaveTractorUserDetail(obj);
            }
            catch (Exception ex)
            {
                LogDal.ErrorLog(this.GetType().Name, MethodBase.GetCurrentMethod().Name, ex.Message, 0);
            }

            return objSavedData;
        }

        [HttpPost]
        [Route("SaveTractorUsersDetailV2")]
        public ApiPostResponse SaveTractorUsersDetailV2(TractorUsers obj)
        {
            ReasonStatusBal _rsbal = new ReasonStatusBal();
            ApiPostResponse objSavedData = new ApiPostResponse();
            int flag = 0;
            Dictionary<string, int> returndata = new Dictionary<string, int>();
            returndata.Add("status", 0);

            try
            {
                objSavedData = _rsbal.SaveTractorUserDetailV2(obj);
            }
            catch (Exception ex)
            {
                LogDal.ErrorLog(this.GetType().Name, MethodBase.GetCurrentMethod().Name, ex.Message, 0);
            }

            return objSavedData;
        }

        




    }
}
