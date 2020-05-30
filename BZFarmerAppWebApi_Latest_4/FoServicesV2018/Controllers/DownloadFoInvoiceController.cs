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
    public class DownloadFoInvoiceController : ApiController
    {
        Entities db = new Entities();
        [HttpGet]
        public IHttpActionResult DownloadFoInvoice()
        {
            return Ok();
        }
        [HttpGet]
        public IHttpActionResult DownloadFoInvoice(string date, string districtId, string dName, string foId, string foName, string UID)
        {
            var fromOrderDate = Convert.ToDateTime(Convert.ToDateTime(date).AddDays(1).ToString("yyyy-MM-dd 00:00:00.000"));
            var toOrderDate = Convert.ToDateTime(Convert.ToDateTime(fromOrderDate).ToString("yyyy-MM-dd 23:59:59.000"));
            try
            {

                var filter = "From Date:- " + fromOrderDate.ToString() + " <br/>ToDate:- " + toOrderDate.ToString() + " <br/>DistrictName:- " + dName + "<br/> FoName:- " + foName;
                var filename = "Download Invoice By FO";

                LogBusiness.DownloadHistoryLog(filter, filename, Convert.ToInt32(UID));
            }
            catch
            { }
            //  List<SP_PODDETAIL_v2_Result> sp_poddetail_v2_result = ClsHelper.GetPodData_V2("0", Convert.ToInt32(districtId), fromOrderDate, toOrderDate);
            var sp_poddetail_v2_result = ReportBusiness.GetPodFoDetailReport("0", 0, Convert.ToInt32(districtId), fromOrderDate, toOrderDate, Constant.INVOICE, Convert.ToInt32(foId));

            foName = foName.Contains(' ') ? foName.Replace(' ', '_') : foName;
            return Ok(sp_poddetail_v2_result);
        }
    }
}
