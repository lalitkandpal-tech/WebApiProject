using System;
using System.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace FoServicesV2018.Models
{
    public class CommonClass
    {
      
    }
    public class FoPickupReport
    {
        public List<FoPickUpReportCount> lstFoPickUpReportCount { get; set; }
        public List<FoPickUpReportValue> lstFoPickUpReportValue { get; set; }

    }
    public class FoPickUpReportCount : FoPickUpReportbase
    {

        public int AssignedQty { get; set; }
        public int PickedQty { get; set; }
        public int ReturnQty { get; set; }
        public int DeliveredQty { get; set; }

    }
    public class FoPickUpReportValue : FoPickUpReportbase
    {
        public decimal AssignedValue { get; set; }
        public decimal PickedValue { get; set; }
        public decimal ReturnValue { get; set; }
        public decimal DeliveredValue { get; set; }

    }
    public class FoPickUpReportbase
    {
        public string DistrictName { get; set; }
        public string DealerName { get; set; }
        public string ProductName { get; set; }
        public string FoName { get; set; }
        public string Date { get; set; }
    }   

    
}