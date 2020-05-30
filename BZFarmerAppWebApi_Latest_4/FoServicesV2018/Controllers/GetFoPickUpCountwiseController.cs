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
    public class GetFoPickUpCountwiseController : ApiController
    {

        Entities db = new Entities();
        public IHttpActionResult GetFoPickUpCountwise()
        {
            return Ok(db.Tbl_Questions);
        }
        public IHttpActionResult GetFoPickUpCountwise(int QuestionId,int ans)
        {
            return Ok(db.Tbl_Questions.Where(x=>x.QuetionId==QuestionId));
        }
        [HttpGet]
        public IHttpActionResult GetFoPickUpCountwise(int mode, int districtID, string date, string toDate, string UID)
        {
            //return Ok(db.Tbl_Questions.Where(x => x.QuetionId == mode));
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
            DataSet ds = LogBusiness.GetFoPickUp(mode, Convert.ToDateTime(fromOrderDate), Convert.ToDateTime(toOrderDate), districtID);

            if (ds != null && ds.Tables.Count > 1 && ds.Tables[0].Rows.Count > 1)
            {
                ds.Tables[0].TableName = "FoPickUpCountWise";
                ds.Tables[1].TableName = "FoPickUpValueWise";
                string disrictname = Convert.ToString(ds.Tables[0].Rows[0]["DistrictName"]); 
            }

            return Ok(ds);//View("OrderReport");

        }
    }
}
