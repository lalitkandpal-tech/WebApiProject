using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace FoServicesV2018.Models
{
    public class BZCrops
    {
        public static DataSet GetCropStages(int CropId,int? DistrictId, string version,int? FarmerId)
        {
            DataSet ds = new LogData().GetCropStages(CropId,DistrictId, version, FarmerId);
            return ds;

        }
        public static DataSet GetBZCropList(string version)
        {
            DataSet ds = new LogData().GetBZCropList(version);
            return ds;

        }
        public static DataSet InsertFarmDetail(CropPopFarmDetail objFarmDetail)
        {
            DateTime StartDATE = new DateTime();
            StartDATE= Convert.ToDateTime(objFarmDetail.FarmingDuration);
            DataSet ds= new LogData().InsertFarmDetail(objFarmDetail.Id,objFarmDetail.FarmerId, StartDATE, objFarmDetail.FarmArea,objFarmDetail.IsStatus,objFarmDetail.CropId);          
            return ds;
        }
        public static DataSet GetBZCropBreedList(string version,int CropId)
        {
            DataSet ds = new LogData().GetBZCropBreedList(version,CropId);
            return ds;

        }
        

    }
}