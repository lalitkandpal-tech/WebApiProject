using FoServicesV2018.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FoServicesV2018.Controllers
{
    public class FoPickUpReportController : ApiController
    {
      
        [HttpGet]
        public IHttpActionResult GetFoPickUpReport()
        {
            return Ok();
        }
        [HttpGet]
        public IHttpActionResult GetFoPickUpReport(int mode, int districtID, string date, string toDate,string UID)
        {
            var fromOrderDate = Convert.ToDateTime(date).ToString("yyyy-MM-dd 00:00:00.000");
            var toOrderDate = Convert.ToDateTime(toDate).ToString("yyyy-MM-dd 23:59:59.000");
            try
            {
                var modeName = mode == 1 ? "Order Creation Report" : "Order Delivery Report";
                var filter = "From Date:- " + fromOrderDate.ToString() + "<br/>ToDate:- " + toOrderDate.ToString() + "<br/> Mode:- " + modeName;
                var filename = "PickUp Sheet(Assigned/picked/Returned)";

                LogBusiness.DownloadHistoryLog(filter, filename, Convert.ToInt32(UID));
            }
            catch
            { }
            //var list = ClsHelper.Get_Orderdetail(mode,Convert.ToDateTime(fromOrderDate), Convert.ToDateTime(toOrderDate));
            try
            {
            DataSet ds = LogBusiness.GetFoPickUp(mode, Convert.ToDateTime(fromOrderDate), Convert.ToDateTime(toOrderDate), districtID);
            if (ds != null && ds.Tables.Count > 1 && ds.Tables[0].Rows.Count > 1)
            {
                ds.Tables[0].TableName = "FoPickUpCountWise";
                ds.Tables[1].TableName = "FoPickUpValueWise";
                string disrictname = Convert.ToString(ds.Tables[0].Rows[0]["DistrictName"]);
                    //new 
                    //using (XLWorkbook wb = new XLWorkbook())
                    //{
                    //    wb.Worksheets.Add(ds);
                    //    wb.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                    //    wb.Style.Font.Bold = true;
                    //    Response.Clear();
                    //    Response.Buffer = true;
                    //    Response.Charset = "";
                    //    Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                    //    Response.AddHeader("content-disposition", "attachment;filename=PickUp_" + disrictname + "_" + date.Replace('/', '_') + "_TO_" + toDate.Replace('/', '_') + ".xls");
                    //    using (MemoryStream MyMemoryStream = new MemoryStream())
                    //    {
                    //        wb.SaveAs(MyMemoryStream);
                    //        MyMemoryStream.WriteTo(Response.OutputStream);
                    //        Response.Flush();
                    //        Response.End();

                    //    }
                    //}
                }
                return Ok(new { results = ds, Status = true });
            }
            catch
            {
                return Ok(new { results = "", Status = false });
            }
           
        }
    }
}
