using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Entity;

namespace FoServicesV2018.Models
{
    public class BzWebsite
    {

        public static DataSet GetBzWebsiteProducts(string version, int CategoryId)
        {
            DataSet ds = new LogData().GetBzWebsiteProducts(version,CategoryId);
            return ds;
        }

        public static DataSet GetBzPackages(string version, int ProductId)
        {
            DataSet ds = new LogData().GetBzPackages(version, ProductId);
            return ds;
        }
        public static DataSet GetBzCategoryForProductDetail(int Id, string Type)
        {
            DataSet ds = new LogData().GetBzCategoryForProductDetail(Id, Type);
            return ds;
        }

        public AddtoCartResult AddToCart(BzCartItems obj)
        {
            AddtoCartResult objCreateData = new LogData().AddToCart(obj.InType, obj.CartItemId, obj.UserId, obj.BzProductId, obj.Quantity);
            return objCreateData;
        }
        public static DataSet GetCartItems(string version, string x_StateName, string x_DistrictName, string UserId)
        {
            DataSet ds = new LogData().GetCartItems(version, x_StateName, x_DistrictName, UserId);
            return ds;
        }

        public static DataSet GetOrderTracking(string version, int UserId)
        {
            DataSet ds = new LogData().GetOrderTracking(version, UserId);
            return ds;
        }

        public static DataSet GetOrderTrackingStatus(string version, string OrderId)
        {
            DataSet ds = new LogData().GetOrderTrackingStatus(version, OrderId);
            return ds;
        }
    }
}