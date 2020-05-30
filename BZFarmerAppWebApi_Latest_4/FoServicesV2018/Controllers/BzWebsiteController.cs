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
using FoServicesV2018.Models;
using FoServicesV2018.Entity;

namespace FoServicesV2018.Controllers
{
    [RoutePrefix("api/BzWebsite")]
    public class BzWebsiteController : ApiController
    {
       
        [HttpGet]
        [Route("GetBzWebsiteProducts")]
        public IHttpActionResult GetBzWebsiteProducts(string version,int CategoryId)
        {
            try
            {
                DataSet ds = new DataSet();
                ds =BzWebsite.GetBzWebsiteProducts(version, CategoryId);
                
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
        [Route("GetBzPackages")]
        public IHttpActionResult GetBzPackages(string version, int ProductId)
        {
            try
            {
                DataSet ds = new DataSet();
                ds = BzWebsite.GetBzPackages(version, ProductId);

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

        [Route("GetBzCategoryForProductDetail")]
        public IHttpActionResult GetBzCategoryForProductDetail(int Id,string Type)
        {
            try
            {
                DataSet ds = new DataSet();
                ds = BzWebsite.GetBzCategoryForProductDetail(Id, Type);

                ds.Tables[0].TableName = "Category";
                return Ok(new { Category = ds, Status = true });
            }
            catch (Exception ex)
            {
                LogDal.ErrorLog(this.GetType().Name, MethodBase.GetCurrentMethod().Name, ex.Message, 0);
                return Ok(new { Category = "", Status = false });
            }
        }

        [HttpPost]
        [Route("AddToCartItems")]
        public IHttpActionResult AddToCartItems(BzCartItems obj)
        {
            BzWebsite _objBal = new BzWebsite();
            AddtoCartResult objAddToCart = new AddtoCartResult();
            int flag = 0;

            Dictionary<string, int> returndata = new Dictionary<string, int>();
            returndata.Add("status", 0);

            try
            {
                //System.Net.Http.Headers.HttpRequestHeaders headers = this.Request.Headers;
                //string x_StateName = string.Empty;
                //string x_DistrictName = string.Empty;
                //if (headers.Contains("state"))
                //{
                //    x_StateName = headers.GetValues("state").First().ToLower();
                //}
                //if (headers.Contains("district"))
                //{
                //    x_DistrictName = headers.GetValues("district").First().ToLower();
                //}
                objAddToCart = _objBal.AddToCart(obj);
                return Ok(new {Status = true });
            }
            catch (Exception ex)
            {
                LogDal.ErrorLog(this.GetType().Name, MethodBase.GetCurrentMethod().Name, ex.Message, objAddToCart.Status);
                return Ok(new { Status = false });
            }
        }

        [HttpGet]
        [Route("GetCartItems")]
        public IHttpActionResult GetCartItems(string version, string UserId)
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
                ds = BzWebsite.GetCartItems(version, x_StateName, x_DistrictName, UserId);

                ds.Tables[0].TableName = "Items";

                return Ok(new { CartApiReponse = ds, ItemCount = ds.Tables[1].Rows[0]["ItemCount"].ToString(), Status = true });
            }
            catch (Exception ex)
            {
                LogDal.ErrorLog(this.GetType().Name, MethodBase.GetCurrentMethod().Name, ex.Message, 0);
                return Ok(new { CartApiReponse = "", Status = false });
            }
        }

        [HttpGet]
        [Route("GetOrderTracking")]
        public IHttpActionResult GetOrderTracking(string version, int UserId)
        {
            try
            {
                List<OrderTracking> objOrderList = new List<OrderTracking>();
                DataSet ds = new DataSet();
                ds = BzWebsite.GetOrderTracking(version, UserId);
                ds.Tables[0].TableName = "Orders";
                ds.Tables[1].TableName = "OrderItems";

                var Orders = ds.Tables["Orders"].AsEnumerable();
                var OrderItems = ds.Tables["OrderItems"].AsEnumerable();
                //var kgpBrands = ds1.Tables["KGPBrands"].AsEnumerable();
                foreach (var item in Orders)
                {
                    OrderTracking objOrder = new OrderTracking();
                    objOrder.OrderId = item.Field<int>("OrderId");
                    objOrder.TotalSaleValue = item.Field<decimal>("TotalSaleValue");
                    objOrder.DeliveryCharge= item.Field<decimal>("DeliveryCharge");
                    objOrder.OrderStatus = item.Field<string>("OrderStatus");
                    objOrder.OrderDate = item.Field<string>("PurchasedDate");
                    List<OrderItems> objItems = new List<OrderItems>();

                    objOrder.OrderItems = objItems;
                    objOrderList.Add(objOrder);
                }
                foreach (var item1 in objOrderList)
                {
                    foreach (var item2 in OrderItems)
                    {
                        if (item2.Field<int>("OrderId") == item1.OrderId)
                        {
                            item1.OrderItems.Add(new OrderItems
                            {
                              // RecordId =item2.Field<long>("RecordId"),
                                PackageId = item2.Field<int>("PackageId"),
                                ProductName = item2.Field<string>("ProductName"),
                                TechnicalName = item2.Field<string>("TechnicalName"),
                                OrderStatus = item2.Field<string>("OrderStatus"),
                                OrderDate= item2.Field<string>("PurchasedDate"),
                                DeliveryDate= item2.Field<string>("DeilveredDate"),
                                Quantity = item2.Field<short>("Quantity"),
                                PackSize= item2.Field<string>("PackSize"),
                                UnitPrice = item2.Field<decimal>("UnitPrice"),
                                SaleValue = item2.Field<decimal>("SaleValue"),
                                ImagePath = item2.Field<string>("ImagePath")
                            });
                        }
                    }
                }
                return Ok(new { Orders = objOrderList, Status = true });
            }
            catch (Exception ex)
            {
                LogDal.ErrorLog(this.GetType().Name, MethodBase.GetCurrentMethod().Name, ex.Message, 0);
                return Ok(new { KGPApiReponse = "", Status = false });
            }
        }

        [HttpGet]
        [Route("GetOrderTrackingStatus")]
        public IHttpActionResult GetOrderTrackingStatus(string version, string OrderId)
        {
            try
            {
                DataSet ds = new DataSet();
                ds = BzWebsite.GetOrderTrackingStatus(version, OrderId);

                ds.Tables[0].TableName = "OrderTrack";

                return Ok(new { TrackingApiResponse = ds, ItemCount = ds.Tables[0].Rows.Count, Status = true });
            }
            catch (Exception ex)
            {
                LogDal.ErrorLog(this.GetType().Name, MethodBase.GetCurrentMethod().Name, ex.Message, 0);
                return Ok(new { CartApiReponse = "", Status = false });
            }
        }
    }
}
