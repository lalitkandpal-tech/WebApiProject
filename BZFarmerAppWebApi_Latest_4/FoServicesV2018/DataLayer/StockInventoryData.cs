using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data;
using FoServicesV2018.Models;

namespace FoServicesV2018.DataLayer
{
    public class StockInventoryData
    {

        static Database objDB;
        static StockInventoryData()
        {
            objDB = new SqlDatabase(ConfigurationManager.ConnectionStrings["connection"].ToString());
        }
        public DataSet GetDealerProductList(string version, int? SubDealerId, string SearchCriteria, int PageIndex, int PageSize)
        {
            using (var objcmd = objDB.GetStoredProcCommand(Constant.uspGetDealerProductList, version, SubDealerId, SearchCriteria, PageIndex, PageSize))
            {
                var dataset = objDB.ExecuteDataSet(objcmd);
                return dataset;
            }
        }
        public DataSet GetSubDealerProductList(string version, int? SubDealerId, string SearchCriteria, int PageIndex, int PageSize)
        {
            using (var objcmd = objDB.GetStoredProcCommand(Constant.uspGetSubDealerProductList, version, SubDealerId, SearchCriteria, PageIndex, PageSize))
            {
                var dataset = objDB.ExecuteDataSet(objcmd);
                return dataset;
            }
        }
    }
}