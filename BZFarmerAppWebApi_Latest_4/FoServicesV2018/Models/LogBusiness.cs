using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;

namespace FoServicesV2018.Models
{
    public class LogBusiness
    {
        static Database objDB;
        static LogBusiness()
        {
            objDB = new SqlDatabase(ConfigurationManager.ConnectionStrings["connection"].ToString());
        }
        public static void DownloadHistoryLog(string filter, string fileName, int downloadById)
        {
            LogData.DownloadHistoryLog(filter, fileName, downloadById);
        }
        public static DataSet GetFoPickUp(int mode, DateTime fromOrderDate, DateTime toOrderDate, int districtId)
        {
            var orderReportList = new FoPickupReport();
            DataSet ds = new LogData().GetFoPickUp(mode, fromOrderDate, toOrderDate, districtId);

            return ds;
        }
    }
}