using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoServicesV2018.BAL
{
    public class BALMainCategory
    {
        //public string Title { get; set; }
        //public List<Images> Image { get; set; }
        public List<MainCategoryObjects> MainCategoryObjects { get; set; }
    }

    public class Banner
    {
        public int BannerId { get; set; }
        public string BannerName { get; set; }
        public string BannerType { get; set; }
        public string ImagePath { get; set; }
        public bool IsClickable { get; set; }
        public int? PackageID { get; set; }
        public bool isActive { get; set; }
        public int DisplayOrder { get; set; }
    }
    public class MainCategoryObjects
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string HindiName { get; set; }
        public string ImageUrl { get; set; }
    }

    public class GetCrop
    {
        public string Title { get; set; }
        public List<Banner> Banner { get; set; }
        public List<CropSeasons> CropSeason { get; set; }
    }
    public class CropSeasons
    {
        public int SeasonID { get; set; }
        public string SeasonName { get; set; }
    }
}