using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoServicesV2018.BAL
{
    public class BZLeftMenu
    {
    }
    public class BzAppLeftMenu
    {
        public int MenuId { get; set; }
        public string MenuName { get; set; }
        public string ImageUrl { get; set; }
        public string MenuHindiName { get; set; }
    }
    public class BzLeftMenuList
    {
        public List<BzAppLeftMenu> BzLeftMenu { get; set; }
    }
}