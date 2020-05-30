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
    public class GetFoUserOrderListController : ApiController
    {
        Entities db = new Entities();
        public IHttpActionResult GetFoUserOrderList()
        {
            return Ok();
        }
        public IHttpActionResult GetFoUserOrderList(int QuestionId, int ans)
        {
            return Ok(db.Tbl_Questions.Where(x => x.QuetionId == QuestionId));
        }
        public IHttpActionResult GetFoUserOrderList(string date, string districtId, string dName, string foId, string foName, string UID)
        {
            try
            {
                var fromOrderDate = Convert.ToDateTime(Convert.ToDateTime(date).AddDays(1).ToString("yyyy-MM-dd 00:00:00.000"));
                var toOrderDate = Convert.ToDateTime(Convert.ToDateTime(fromOrderDate).ToString("yyyy-MM-dd 23:59:59.000"));
                try
                {
                    var filter = "From Date:- " + fromOrderDate.ToString() + " <br/>ToDate:- " + toOrderDate.ToString() + " <br/>DistrictName:- " + dName + "<br/> FoName:- " + foName;
                    var filename = "Download TripSheet By Fo";

                    LogBusiness.DownloadHistoryLog(filter, filename, Convert.ToInt32(UID));
                }
                catch
                { }
                dName = dName.Contains(' ') ? dName.Replace(' ', '_') : dName;
                foName = foName.Contains(' ') ? foName.Replace(' ', '_') : foName;
                var msg = string.Empty;

                // var list = ClsHelper.GetDistributorOrderList(fromOrderDate, toOrderDate, Convert.ToInt32(districtId), Convert.ToInt32(distributorId));
                var list = ReportBusiness.GetFoByOrderSheetDetails(fromOrderDate, toOrderDate, Convert.ToInt32(districtId), Convert.ToInt32(foId));
                var sp_poddetail_v2_result = ReportBusiness.GetPodFoDetailReport("0", 0, Convert.ToInt32(districtId), fromOrderDate, toOrderDate, Constant.INVOICE, Convert.ToInt32(foId));
                List<ListItem> objList = new List<ListItem>();
                ListItem obj = new ListItem();
                obj.FoOrderSheetDetail = list;
                obj.PodDetailReport = sp_poddetail_v2_result;
                objList.Add(obj);
                if (list.Count > 0)
                {
                    //var pasgeSize = Convert.ToString(ConfigurationManager.AppSettings["pageSize"]);
                    //string strPOD = RenderRazorViewToString(this.ControllerContext, "_TripSheetWithFo", list);
                }
                return Ok(new { results = objList, Status = true });
            }
            catch
            {
                return Ok(new { results = "", Status = false });
            }
        }

        public class ListItem
        {
            public List<CRMDocument.FoOrderSheetDetail> FoOrderSheetDetail { get; set; }
            public List<CRMDocument.PodDetailReport> PodDetailReport { get; set; }
        }
    }
}
