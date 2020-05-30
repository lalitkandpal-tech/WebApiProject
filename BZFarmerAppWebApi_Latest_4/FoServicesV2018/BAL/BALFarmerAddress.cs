using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoServicesV2018.BAL
{
    public class BALFarmerAddress
    {
        public string Address { get; set; }
        public string NearByVillage { get; set; }
        public string VillageName { get; set; }
        public string BlockName { get; set; }
        public string DistrictName { get; set; }
        public string StateName { get; set; }
        public Int64 FarmerID { get; set; }
        public int VillageID { get; set; }
        public string FarmerName { get; set; }
        public string FatherName { get; set; }
        public decimal MobNo { get; set; }
        public int BlockID { get; set; }
        public int DistrictID { get; set; }
        public int StateID { get; set; }
        public string Landmark { get; set; }
        public string Pincode { get; set; }
        public string Email { get; set; }

    }
}