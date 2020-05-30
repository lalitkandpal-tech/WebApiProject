using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using FoServicesV2018.DataLayer;

namespace FoServicesV2018.Models
{
    public class StockInventory
    {
        public static DataSet GetDealerProductList(string version, int? SubDealerId, string SearchCriteria, int PageIndex, int PageSize)
        {
            DataSet ds = new StockInventoryData().GetDealerProductList(version, SubDealerId, SearchCriteria, PageIndex, PageSize);
            return ds;
        }

        public static DataSet GetSubDealerProductList(string version, int? SubDealerId, string SearchCriteria, int PageIndex, int PageSize)
        {
            DataSet ds = new StockInventoryData().GetSubDealerProductList(version, SubDealerId, SearchCriteria, PageIndex, PageSize);
            return ds;
        }
    }
}