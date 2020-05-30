using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoServicesV2018.Models
{
    public class ClsDelight
    {
        public static int DelightPushOrderDetail(DLight objDlight)
        {
            int result = new LogData().DelightPushOrderDetail(objDlight.BatchNumber,objDlight.BatchDate,objDlight.BranchID,objDlight.BranchName,objDlight.LoanApprovaldate,
                                                            objDlight.LoanProposalID,objDlight.ProposalID,objDlight.ClientID,objDlight.ClientUniqueID,objDlight.ClientName,objDlight.ProductID,objDlight.Model,
                                                            objDlight.MemberOfferPrice,objDlight.VendorId,objDlight.SupplierName,objDlight.AddressLine1,objDlight.AddressLine2,objDlight.Landmark,
                                                            objDlight.Village,objDlight.DistrictName,objDlight.StateName,objDlight.Pincode,objDlight.MobileNumber,objDlight.MemberAlternateMobileNumber,
                                                            objDlight.SpouseName,objDlight.FatherName,objDlight.SMName,objDlight.SMNumber,objDlight.BMName,objDlight.BMNumber,objDlight.Status,objDlight.Text1,
                                                            objDlight.Text2,objDlight.Numeric1,objDlight.Numeric2);
            return result;
        }      
    }
}