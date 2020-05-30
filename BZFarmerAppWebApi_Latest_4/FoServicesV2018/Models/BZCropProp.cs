using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoServicesV2018.Models
{
    public class BZCropProp
    {
       public int CropID { get; set; }
        public string CropName { get; set; }
        public string CropNameHindi { get; set; }
        public int CropType { get; set; }
        public bool IsActive { get; set; }
        public string ImageUrl { get; set; }
        public string FarmingDuration { get; set; }
        public string FarmArea { get; set; }
        public string VideoUrl { get; set; }
        public List<BZStageCrop> BZStageCrop { get; set; }
    }
    public class BZStageCrop
    {
        public int ID { get; set; }
        public int CropID { get; set; }
        public string StageName { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string VideoUrl { get; set; }
        public string ImageUrl { get; set; }
        public bool IsShow { get; set; }
        public int Extra { get; set; }
        public List<Products> Products { get; set; }
    }
    public class CropPopFarmDetail
    {
        public int Id { get; set; }
        public string version { get; set; }
        public int FarmerId { get; set; }
        public string FarmingDuration { get; set; }
        public string FarmArea { get; set; }
        public int CropId { get; set; }
        public bool IsStatus { get; set; }
    }
    public class PostResponse
    {
        public bool Success { get; set; }
        public string Msg { get; set; }
    }
    public class BZFAQ
    {
        public string version { get; set; }
        public string Name { get; set; }
    }


    public class BZAgentCoupon
    {
        public int AgentId { get; set; }
        public int PackageId { get; set; }
        public string CouponCode { get; set; }
        public int quantity { get; set; }
        public int TxnValue { get; set; }

        public int OrderId { get; set; }
    }
}