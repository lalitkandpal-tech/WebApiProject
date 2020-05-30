using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Reflection;
using Entity;
using FoServicesV2018.Entity;
using System.Net;

namespace DataLayer
{
    public class ReasonStatusDal : BaseDal
    {
        public ReasonStatusDal()
        {


        }
        public CreatedOrderResult OrderCreate(int userid, int FarmerId, string FarmerName, string FatherName, long Mobile, int StateId, int DistrictId, int BlockId,
            int VillageId, string OtherVillageName, string Address, string DeliveryDate, string ModeOfPayment, DataTable DT, string x_StateName, string x_DistrictName)
        //(int OfferDiscount, int Pckgid, int Qty, int Amount, int FarmerId, long Mobile, int StateId, int DistrictId, int BlockId,
        //  int VillageId, string OtherVillageName, string Address, string DeliveryDate, string ModeOfPayment, int DiscountPrice, string DiscountCode) //, DataTable DT
        {
            SqlConnection connection;
            SqlCommand command = new SqlCommand();
            int flag = 0;
            //string flag = "";

            connection = new SqlConnection(connetionString);
            CreatedOrderResult objDataObject = new CreatedOrderResult();
            try
            {
                connection.Open();
                command.Connection = connection;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "Usp_OrderCreateByBZApp";

                command.Parameters.AddWithValue("@SathiId", 0);
                command.Parameters.AddWithValue("@farmerid", FarmerId);
                command.Parameters.AddWithValue("@name", FarmerName);
                command.Parameters.AddWithValue("@fathername", FatherName);
                command.Parameters.AddWithValue("@mobile", Mobile);
                command.Parameters.AddWithValue("@stateid", StateId);
                command.Parameters.AddWithValue("@districtid", DistrictId);
                command.Parameters.AddWithValue("@blockid", BlockId);
                command.Parameters.AddWithValue("@villageid", VillageId);
                command.Parameters.AddWithValue("@othervillagename", OtherVillageName);
                command.Parameters.AddWithValue("@Address", Address);
                command.Parameters.AddWithValue("@DeliveryDate", DeliveryDate);
                command.Parameters.AddWithValue("@ModeOfPayment", ModeOfPayment);
                command.Parameters.AddWithValue("@Product", DT);
                command.Parameters.AddWithValue("@x_StateName", x_StateName);
                command.Parameters.AddWithValue("@x_DistrictName", x_DistrictName);

                SqlParameter ErrorId = new SqlParameter();
                ErrorId.ParameterName = "@Error";
                ErrorId.DbType = DbType.Int32;
                ErrorId.Direction = ParameterDirection.Output;
                command.Parameters.Add(ErrorId);
                flag = command.ExecuteNonQuery();

                if (flag >= 1)
                {
                    flag = 1;

                    string Error = command.Parameters["@Error"].Value.ToString();
                    if (Convert.ToInt32(Error) > 2)
                    {
                        CreatedOrderResult objData = GetCreateOrderData(Convert.ToInt32(Error));
                        //objDataObject.OrderAmount = 1;
                        //objDataObject.OrderId = 329676;
                        //objDataObject.Status = 1;
                        objDataObject.OrderAmount = objData.OrderAmount;
                        objDataObject.OrderId = Convert.ToInt32(Error);
                        objDataObject.Status = 1;
                    }
                    else
                    {
                        objDataObject.OrderAmount = 0;
                        objDataObject.OrderId = 0;
                        objDataObject.Status = Convert.ToInt32(Error);
                    }
                }
                else
                {
                    flag = 0;
                    string Error = command.Parameters["@Error"].Value.ToString();
                    objDataObject.OrderAmount = 0;
                    objDataObject.OrderId = 0;
                    objDataObject.Status = 2;// Convert.ToInt32(2);
                }
                if (flag == 0)
                {
                    //string Error = command.Parameters["@Error"].Value.ToString();
                    //flag = int.Parse(Error);// flag =2 set by error means fo try to create new order to other district so flag =2 
                    objDataObject.OrderAmount = 0;
                    objDataObject.OrderId = 0;
                    objDataObject.Status = 2;
                }
                command.Parameters.Clear();

                LogDal.MethodCallLog(this.GetType().Name, MethodBase.GetCurrentMethod().Name);
            }
            catch (Exception ex) { LogDal.ErrorLog(this.GetType().Name, MethodBase.GetCurrentMethod().Name, ex.Message, FarmerId); }

            connection.Close();
            return objDataObject;
        }
        public CreatedOrderResult OrderCreateV2(int userid, int FarmerId, string FarmerName, string FatherName, long Mobile, int StateId, int DistrictId, int BlockId,
           int VillageId, string OtherVillageName, string Address, string DeliveryDate, string ModeOfPayment, DataTable DT, string x_StateName, string x_DistrictName)
        //(int OfferDiscount, int Pckgid, int Qty, int Amount, int FarmerId, long Mobile, int StateId, int DistrictId, int BlockId,
        //  int VillageId, string OtherVillageName, string Address, string DeliveryDate, string ModeOfPayment, int DiscountPrice, string DiscountCode) //, DataTable DT
        {
            SqlConnection connection;
            SqlCommand command = new SqlCommand();
            int flag = 0;
            //string flag = "";

            connection = new SqlConnection(connetionString);
            CreatedOrderResult objDataObject = new CreatedOrderResult();
            try
            {
                connection.Open();
                command.Connection = connection;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "Usp_OrderCreateByBZApp_V2";

                command.Parameters.AddWithValue("@SathiId", 0);
                command.Parameters.AddWithValue("@farmerid", FarmerId);
                command.Parameters.AddWithValue("@name", FarmerName);
                command.Parameters.AddWithValue("@fathername", FatherName);
                command.Parameters.AddWithValue("@mobile", Mobile);
                command.Parameters.AddWithValue("@stateid", StateId);
                command.Parameters.AddWithValue("@districtid", DistrictId);
                command.Parameters.AddWithValue("@blockid", BlockId);
                command.Parameters.AddWithValue("@villageid", VillageId);
                command.Parameters.AddWithValue("@othervillagename", OtherVillageName);
                command.Parameters.AddWithValue("@Address", Address);
                command.Parameters.AddWithValue("@DeliveryDate", DeliveryDate);
                command.Parameters.AddWithValue("@ModeOfPayment", ModeOfPayment);
                command.Parameters.AddWithValue("@Product", DT);
                command.Parameters.AddWithValue("@x_StateName", x_StateName);
                command.Parameters.AddWithValue("@x_DistrictName", x_DistrictName);

                SqlParameter ErrorId = new SqlParameter();
                ErrorId.ParameterName = "@Error";
                ErrorId.DbType = DbType.Int32;
                ErrorId.Direction = ParameterDirection.Output;
                command.Parameters.Add(ErrorId);
                flag = command.ExecuteNonQuery();

                if (flag >= 1)
                {
                    flag = 1;

                    string Error = command.Parameters["@Error"].Value.ToString();
                    if (Convert.ToInt32(Error) > 2)
                    {
                        CreatedOrderResult objData = GetCreateOrderData(Convert.ToInt32(Error));
                        //objDataObject.OrderAmount = 1;
                        //objDataObject.OrderId = 329676;
                        //objDataObject.Status = 1;
                        objDataObject.OrderAmount = objData.OrderAmount;
                        objDataObject.OrderId = Convert.ToInt32(Error);
                        objDataObject.Status = 1;
                    }
                    else
                    {
                        objDataObject.OrderAmount = 0;
                        objDataObject.OrderId = 0;
                        objDataObject.Status = Convert.ToInt32(Error);
                    }
                }
                else
                {
                    flag = 0;
                    string Error = command.Parameters["@Error"].Value.ToString();
                    objDataObject.OrderAmount = 0;
                    objDataObject.OrderId = 0;
                    objDataObject.Status = 2;// Convert.ToInt32(2);
                }
                if (flag == 0)
                {
                    //string Error = command.Parameters["@Error"].Value.ToString();
                    //flag = int.Parse(Error);// flag =2 set by error means fo try to create new order to other district so flag =2 
                    objDataObject.OrderAmount = 0;
                    objDataObject.OrderId = 0;
                    objDataObject.Status = 2;
                }
                command.Parameters.Clear();

                LogDal.MethodCallLog(this.GetType().Name, MethodBase.GetCurrentMethod().Name);
            }
            catch (Exception ex) { LogDal.ErrorLog(this.GetType().Name, MethodBase.GetCurrentMethod().Name, ex.Message, FarmerId); }

            connection.Close();
            return objDataObject;
        }
        public CreatedOrderResult GetCreateOrderData(int OrderId)
        {
            SqlConnection connection;
            SqlDataAdapter adapter;
            SqlCommand command = new SqlCommand();
            DataSet ds = new DataSet();

            connection = new SqlConnection(connetionString);
            CreatedOrderResult objData = new CreatedOrderResult();
            try
            {
                DataTable Dt = new DataTable();
                connection.Open();
                command.Connection = connection;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "GetSathiOrderAmount";
                command.Parameters.AddWithValue("@OrderId", OrderId);
                adapter = new SqlDataAdapter(command);
                adapter.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {


                    objData.OrderAmount = Convert.ToDecimal(ds.Tables[0].Rows[0]["OrderAmount"].ToString());
                    objData.OrderId = OrderId;
                    objData.Status = 1;
                }
            }
            catch (Exception ex) { LogDal.ErrorLog(this.GetType().Name, MethodBase.GetCurrentMethod().Name, ex.Message, OrderId); }


            connection.Close();
            return objData;
        }
        public DataSet GetFilterData(DataTable DTSubCategory, string version, string lang, string StateName, string DistrictName)
        {
            SqlConnection connection;
            SqlDataAdapter adapter;
            SqlCommand command = new SqlCommand();
            DataSet ds = new DataSet();
            connection = new SqlConnection(connetionString);
            CreatedOrderResult objData = new CreatedOrderResult();
            try
            {
                DataTable Dt = new DataTable();
                connection.Open();
                command.Connection = connection;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "[usp_KitchenGarden_ProductList]";
                // command.Parameters.AddWithValue("@DTCategory", DTCategory);
                command.Parameters.AddWithValue("@DTCategoryFilter", DTSubCategory);
                command.Parameters.AddWithValue("@version", version);
                command.Parameters.AddWithValue("@lang", lang);
                command.Parameters.AddWithValue("@StateName", StateName);
                command.Parameters.AddWithValue("@x_DistrictName", DistrictName);
                command.Parameters.AddWithValue("@PageIndex", 1);
                command.Parameters.AddWithValue("@PageSize", 1000);
                adapter = new SqlDataAdapter(command);
                adapter.Fill(ds);
            }
            catch (Exception ex) { LogDal.ErrorLog(this.GetType().Name, MethodBase.GetCurrentMethod().Name, ex.Message, 0); }
            connection.Close();
            return ds;
        }

        public DataSet GetCatSubCat(int? KGP_CategoryId = null)
        {
            SqlConnection connection;
            SqlDataAdapter adapter;
            SqlCommand command = new SqlCommand();
            DataSet ds = new DataSet();
            connection = new SqlConnection(connetionString);
            CreatedOrderResult objData = new CreatedOrderResult();
            try
            {
                DataTable Dt = new DataTable();
                connection.Open();
                command.Connection = connection;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "[usp_CatSubCat]";
                // command.Parameters.AddWithValue("@DTCategory", DTCategory);
                command.Parameters.AddWithValue("@KGP_CategoryId", KGP_CategoryId);

                adapter = new SqlDataAdapter(command);
                adapter.Fill(ds);
            }
            catch (Exception ex) { LogDal.ErrorLog(this.GetType().Name, MethodBase.GetCurrentMethod().Name, ex.Message, 0); }
            connection.Close();
            return ds;

        }

        public SavedProductResult SaveSubDealerProducts(int PackageId, int Quantity, int SubDealerId)
        {
            SqlConnection connection;
            SqlCommand command = new SqlCommand();
            int flag = 0;

            connection = new SqlConnection(connetionString);
            SavedProductResult objDataObject = new SavedProductResult();
            try
            {
                connection.Open();
                command.Connection = connection;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "Usp_SaveSubDealerProducts";

                command.Parameters.AddWithValue("@StockId", 0);
                command.Parameters.AddWithValue("@PackageId", PackageId);
                command.Parameters.AddWithValue("@Quantity", Quantity);
                command.Parameters.AddWithValue("@SubDealerId", SubDealerId);


                flag = (int)command.ExecuteScalar();
                if (flag > 0)
                {
                    objDataObject.Status = 1;
                    objDataObject.StockQty = flag;
                    objDataObject.Msg = "Products have been added successfully to stock.";
                }
                else
                {
                    objDataObject.Status = 0;
                    objDataObject.StockQty = 0;
                    objDataObject.Msg = "Issue Occurred, Please try again!!";
                }
                command.Parameters.Clear();

                LogDal.MethodCallLog(this.GetType().Name, MethodBase.GetCurrentMethod().Name);
            }
            catch (Exception ex) { LogDal.ErrorLog(this.GetType().Name, MethodBase.GetCurrentMethod().Name, ex.Message, SubDealerId); }

            connection.Close();
            return objDataObject;
        }

        public ApiPostResponse SaveTractorUserDetailV2(string FarmerName, int StateId, string MobileNo, int CategoryId, string ModelNo, decimal QuotationPrice)
        {
            SqlConnection connection;
            SqlCommand command = new SqlCommand();
            string Msg = "";

            connection = new SqlConnection(connetionString);
            ApiPostResponse objDataObject = new ApiPostResponse();
            try
            {
                connection.Open();
                command.Connection = connection;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "usp_SaveUpdateTractorUsersDetail_Test";

                command.Parameters.AddWithValue("@FarmerName", FarmerName);
                command.Parameters.AddWithValue("@StateId", StateId);
                command.Parameters.AddWithValue("@MobileNo", MobileNo);
                command.Parameters.AddWithValue("@CategoryId", CategoryId);
                command.Parameters.AddWithValue("@ModelNo", ModelNo);
                command.Parameters.AddWithValue("@QuotationPrice", QuotationPrice);

                Msg = Convert.ToString(command.ExecuteScalar());
                if (Msg != "")
                {
                    objDataObject.Success = true;
                    objDataObject.Msg = Msg;
                }
                else
                {
                    objDataObject.Success = false;
                    objDataObject.Msg = "Issue Occurred, Please try again!!";
                }
                command.Parameters.Clear();

                LogDal.MethodCallLog(this.GetType().Name, MethodBase.GetCurrentMethod().Name);
            }
            catch (Exception ex) { LogDal.ErrorLog(this.GetType().Name, MethodBase.GetCurrentMethod().Name, ex.Message, 0); }

            connection.Close();
            return objDataObject;
        }
        public ApiPostResponse SaveTractorUserDetail(string FarmerName, int StateId, string MobileNo, int CategoryId, int BzProductId, string ModelNo,
                                                     decimal QuotationPrice, string RequestSource, string DemoDate, string TimeSlot)
        {
            SqlConnection connection;
            SqlCommand command = new SqlCommand();
            System.Data.SqlTypes.SqlDateTime sqldatenul;
            string Msg = "";

            connection = new SqlConnection(connetionString);
            ApiPostResponse objDataObject = new ApiPostResponse();
            try
            {
                sqldatenul = System.Data.SqlTypes.SqlDateTime.Null;
                connection.Open();
                command.Connection = connection;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "usp_SaveUpdateTractorUsersDetail";

                command.Parameters.AddWithValue("@FarmerName", FarmerName);
                command.Parameters.AddWithValue("@StateId", StateId);
                command.Parameters.AddWithValue("@MobileNo", MobileNo);
                command.Parameters.AddWithValue("@CategoryId", CategoryId);
                command.Parameters.AddWithValue("@BzProductId", BzProductId);
                command.Parameters.AddWithValue("@ModelNo", ModelNo);
                command.Parameters.AddWithValue("@QuotationPrice", QuotationPrice);
                command.Parameters.AddWithValue("@RequestSource", RequestSource);
                if (string.IsNullOrEmpty(DemoDate))
                {
                    command.Parameters.AddWithValue("@DemoDate", sqldatenul);
                }
                else
                {
                    command.Parameters.AddWithValue("@DemoDate", Convert.ToDateTime(DemoDate));
                }
                command.Parameters.AddWithValue("@TimeSlot", TimeSlot);


                Msg = Convert.ToString(command.ExecuteScalar());
                if (Msg != "")
                {
                    objDataObject.Success = true;
                    objDataObject.Msg = Msg;
                    
                }
                else
                {
                    objDataObject.Success = false;
                    objDataObject.Msg = "Issue Occurred, Please try again!!";
                }
                command.Parameters.Clear();

                LogDal.MethodCallLog(this.GetType().Name, MethodBase.GetCurrentMethod().Name);
            }
            catch (Exception ex) { LogDal.ErrorLog(this.GetType().Name, MethodBase.GetCurrentMethod().Name, ex.Message, 0); }

            connection.Close();
            return objDataObject;
        }


        
    }
}