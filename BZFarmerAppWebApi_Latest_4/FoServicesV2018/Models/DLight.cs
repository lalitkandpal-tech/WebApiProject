using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoServicesV2018.Models
{
    public class DLight
    {
        public string BatchNumber { get; set; }
        public string BatchDate { get; set; }
        public string BranchID { get; set; }
        public string BranchName { get; set; }
        public string LoanApprovaldate { get; set; }
        public string LoanProposalID { get; set; }

        public string ProposalID { get; set; }
        public string ClientID { get; set; }

        public string ClientUniqueID { get; set; }

        public string ClientName { get; set; }

       public string ProductID { get; set; }

       public string Model { get; set; }

       public decimal MemberOfferPrice { get; set; }

       public string VendorId { get; set; }

       public string SupplierName { get; set; }

       public string AddressLine1 { get; set; }

       public string AddressLine2 { get; set; }

       public string Landmark { get; set; }

       public string Village { get; set; }

        public string DistrictName { get; set; }

        public string StateName { get; set; }

        public string Pincode { get; set; }

        public string MobileNumber { get; set; }

        public string MemberAlternateMobileNumber { get; set; }

        public string SpouseName { get; set; }

        public string FatherName { get; set; }

        public string SMName { get; set; }

        public string SMNumber { get; set; }

        public string BMName { get; set; }
        public string BMNumber { get; set; }

        public string Status { get; set; }

        public string Text1 { get; set; }

        public string Text2 { get; set; }

        public string Numeric1 { get; set; }

        public string Numeric2 { get; set; }
    }
    public class DlightPostResponse
    {
        public bool Success { get; set; }
        public string Msg { get; set; }
    }
}