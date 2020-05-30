using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FoServicesV2018.Models;
using DataLayer;
using System.Reflection;

namespace FoServicesV2018.Controllers
{
    [RoutePrefix("api/BzCommonApi")]
    public class BzCommonApiController : ApiController
    {
        [HttpPost]
        [Route("PushOrders")]
        public IHttpActionResult DelightPushOrderDetail(DLight objDlight)
        {
            DlightPostResponse objResponse = new DlightPostResponse();
            try
            {
                
                int value = 0;
               value = ClsDelight.DelightPushOrderDetail(objDlight);                
                if (value > 0)
                {
                    objResponse.Success = true;
                    objResponse.Msg = "Submitted Successfully";
                }
                else
                {
                    objResponse.Success = false;
                    objResponse.Msg = "Failed, Try Again!";
                }
                return Ok(new { BZApiReponse = objResponse, Status = true });
            }
            catch (Exception ex)
            {
                LogDal.ErrorLog(this.GetType().Name, MethodBase.GetCurrentMethod().Name, ex.Message, 0);
                objResponse.Msg = "Failed.";
            }
            return Ok(new { BZApiReponse = objResponse, Status = false });
        }
    }
}
