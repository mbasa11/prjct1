using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
   
    public class DataAccessLayer
    {
       static string con = "Data Source=DESKTOP-TN2RMA6\\SQLEXPRESS;Initial Catalog=Cars;Integrated Security=True";
       SqlConnection conn = new SqlConnection(con);
        SqlCommand comm;
        SqlDataAdapter adp;
        DataTable dt;
        public int AddManufacturer(Manu man)
        {
            conn.Open();
            comm = new SqlCommand("sp_Manufacturer", conn);
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.AddWithValue("@ManufacturerDesc", man.ManuDesc);
            comm.Parameters.AddWithValue("@ManufactureLocation", man.ManuLoc);
            comm.Parameters.AddWithValue("@ContactPerson", man.contact);
            int x = comm.ExecuteNonQuery();
            conn.Close();
            return x;
        }
        public DataTable ListManufacturer(Manu man)
        {
            conn.Open();
            comm = new SqlCommand("sp_ListManufacturer", conn);
            comm.CommandType = CommandType.StoredProcedure;
            adp = new SqlDataAdapter(comm);
            dt = new DataTable();
            adp.Fill(dt);
            conn.Close();
            return dt;
        }
        public DataTable UpdateManufacturer(Manu man)
        {
            conn.Open();
            comm = new SqlCommand("sp_UpdateManufacturer", conn);
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.AddWithValue("@ManufacturerID", man.ManufacturerID);
            comm.Parameters.AddWithValue("@ManufacturerDesc", man.ManuDesc);
            comm.Parameters.AddWithValue("@ManufactureLocation", man.ManuLoc);
            comm.Parameters.AddWithValue("@ContactPerson", man.contact);
            adp = new SqlDataAdapter(comm);
            dt = new DataTable();
            adp.Fill(dt);
            conn.Close();
            return dt;
        }
        public int AddModel(Model mod)
        {
            conn.Open();
            comm = new SqlCommand("sp_AddModel", conn);
            comm.CommandType= CommandType.StoredProcedure;
            comm.Parameters.AddWithValue("@ManufactureID", mod.ManuID);
            comm.Parameters.AddWithValue("@ModelDesc", mod.ModelDesc);
            int x = comm.ExecuteNonQuery();
            conn.Close();
            return x;
        }
        public DataTable ListModel(Model mod)
        {
            conn.Open();
            comm = new SqlCommand("sp_ListModel",conn);
            comm.CommandType= CommandType.StoredProcedure;
            adp=new SqlDataAdapter(comm);
            dt = new DataTable();
            adp.Fill(dt);
            conn.Close();
            return dt;
        }
        public DataTable UpdateModel(Model mod)
        {
            conn.Open();
            comm = new SqlCommand("sp_ListModel", conn);
            comm.CommandType = CommandType.StoredProcedure;
          
            comm.Parameters.AddWithValue("@ManufactureID", mod.ManuID);
            comm.Parameters.AddWithValue("@ModelDesc", mod.ModelDesc);
            int x = comm.ExecuteNonQuery();
            conn.Close();
           
            return dt;
        }
        public int AddCars(Car car)
        {
            conn.Open();
            comm = new SqlCommand("sp_AddCars", conn);
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.AddWithValue("@ModelDesc", car.ModelID);
            comm.Parameters.AddWithValue("@CarDesc", car.CarDesc);
            comm.Parameters.AddWithValue("@CarYear", car.CarYear);
            comm.Parameters.AddWithValue("@CarPrice", car.Price);
            int x = comm.ExecuteNonQuery();
            return x;
        }
        public DataTable ListCars(Car car)
        {
            conn.Open();
            comm = new SqlCommand("sp_ListCar", conn);
            comm.CommandType = CommandType.StoredProcedure;
            adp = new SqlDataAdapter(comm);
            dt = new DataTable();
            adp.Fill(dt);
            conn.Close();
            return dt;
        }
        public DataTable UpdateCars(Car car)
            
        {
            conn.Open();
            comm = new SqlCommand("sp_updateCars", conn);
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.AddWithValue("@CarID", car.ManID);
            comm.Parameters.AddWithValue("@ModelID", car.ModelID);
            comm.Parameters.AddWithValue("@CarDesc", car.CarDesc);
            comm.Parameters.AddWithValue("@CarYear", car.CarYear);
            comm.Parameters.AddWithValue("@CarPrice", car.Price);
            adp = new SqlDataAdapter(comm);
            dt = new DataTable();
            adp.Fill(dt);
            conn.Close();
            return dt;
        }
        
    }
}
