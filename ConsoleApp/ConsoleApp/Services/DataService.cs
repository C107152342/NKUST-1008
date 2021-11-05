using ConsoleApp.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Services
{
    public class DataService
    {
        private string _connectionString = @"Server=.;Database=nkust;Trusted_Connection=True";

        public List<Camera> GetCamera()
        {
            var result = new List<Camera>();
            SqlConnection cn = new SqlConnection(_connectionString);
            cn.Open();
            SqlCommand command = new SqlCommand("Select * from condom", cn);
            var indexer = command.ExecuteReader();
            while (indexer.Read())
            {
                var id = indexer["Id"];
                var DistrictDistrict = indexer["Administrative_District"];
                var Pharmacyname = indexer["Pharmacy_name"];
                var addrress = indexer["address"];
                var phone = indexer["phone"];
                var item = new Camera()
                {
                    行政區 = DistrictDistrict.ToString(),
                    藥局名稱 = Pharmacyname.ToString(),
                    地址 = addrress.ToString(),
                    電話 = phone.ToString(),
                    編號 = id.ToString()
                };
                result.Add(item);
            }
            cn.Close();
            return result;
        }

        public void Insert(Camera camera) 
        {
            var commandString = @"INSERT INTO [dbo].[condom] ([Administrative_District],[Pharmacy_name],[address],[phone])
            VALUES(@Administrative_District,@Pharmacy_name,@address,@phone)";
           


            SqlConnection cn = new SqlConnection(_connectionString);
            cn.Open();
            SqlCommand command = new SqlCommand(commandString, cn);

            command.Parameters.Add(new SqlParameter("Administrative_District", camera.行政區));
            command.Parameters.Add(new SqlParameter("Pharmacy_name", camera.藥局名稱));
            command.Parameters.Add(new SqlParameter("address", camera.地址));
            command.Parameters.Add(new SqlParameter("phone", camera.電話));

            var count = command.ExecuteNonQuery();
            cn.Close();
        }
        public void Update(Camera camera) 
        {
            var commandString = @"UPDATE [dbo].[condom]
                                SET[Administrative_District]=''
                                ,[Pharmacy_name]=''
                                ,[address]=''
                                ,[phone])=''
                                 WHERE Id=1";
            SqlConnection cn = new SqlConnection(_connectionString);
            cn.Open();
            SqlCommand command = new SqlCommand(commandString, cn);
            var count = command.ExecuteNonQuery();
            cn.Close();
        }
        public void Delete(int id)
        {
            var commandString = @"DELETE FROM [dbo].[condom]
                                WHERE Id=0";
            SqlConnection cn = new SqlConnection(_connectionString);
            cn.Open();
            SqlCommand command = new SqlCommand(commandString, cn);
            var count = command.ExecuteNonQuery();
            cn.Close();
        }
    }
}
