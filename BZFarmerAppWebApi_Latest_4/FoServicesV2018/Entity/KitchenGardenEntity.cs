using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Entity
{
    public class KitchenGardenEntity
    {
        public string version { get; set; }
        public int userid { get; set; }

        public string lang { get; set; }
        public List<KGPCategoryData> KGPCategory { set; get; }
        //public List<KGPSubCategoryData> KGPSubCategory { get; set; }
        public int? KGP_CategoryId { get; set; }
    }
    public class KGPCategoryData
    {
        public int KGP_CategoryId { get; set; }
        public List<KGPSubCategoryData> KGPSubCategory { get; set; }
    }
    public class KGPSubCategoryData
    {
        public int KGP_CategoryId { get; set; }
        public int KGP_SubCategoryId { get; set; }
        
    }
    public class KGPCategory
    {
        public int KGP_CategoryId { get; set; }
        public string KGP_CategoryName { get; set; }
        public string KGP_CategoryHindi { get; set; } 
        public List<KGPSubCategory> KGPSubCategory { get; set; }
    }

    public class KGPSubCategory
    {
        public int KGP_SubCategoryId { get; set; }
        public int KGP_CategoryId { get; set; }
        public string KGP_SubCategoryName { get; set; }
        public string KGP_SubCategoryHindi { get; set; } 
    }   
}