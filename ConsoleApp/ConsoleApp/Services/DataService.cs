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

        public void GetCamera()
        {
            var cn = new SqlConnection(_connectionString);
            cn.Open();
            SqlCommand command = new SqlCommand("Select * from condom", cn);
            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                var id = reader["Id"];
                var DistrictDistrict = reader["Administrative District"];
                var Pharmacyname = reader["Pharmacy name"];
                var addrress = reader["address"];
                var phone = reader["phone"];

            }
            cn.Close();
        }
    }
}
