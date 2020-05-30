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
    public class DealerFoPickedProductDetailsController : ApiController
    {
        [HttpGet]
        public IHttpActionResult DealerFoPickedProductDetails()
        {
            return Ok();
        }
        [HttpGet]
        public IHttpActionResult DealerFoPickedProductDetails(int stateid, int? districtid, int? dealerid, int? foId)
        {
            try
            {
                DataSet ds = new DataSet();
                ds = ReportBusiness.FoPickedProductDetails(stateid, districtid, dealerid, foId);
                return Ok(new { results = ds, Status = false });
            }
            catch { return Ok(new { results = "", Status = false }); }
        }
    }
}
