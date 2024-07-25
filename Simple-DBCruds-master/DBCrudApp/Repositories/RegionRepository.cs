using DBCrudApp.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBCrudApp.Entities;

namespace DBCrudApp.Repositories
{
    public static class RegionRepository
    {
        public static string _connectionString { get; set; } = @"Data Source=DESKTOP-3J635BH;Initial Catalog=Northwind;Integrated Security=True;Encrypt=False";


        public static List<Region> GetData()
        {
            string commandString = "Select * FROM Northwind.dbo.Region";

            var connection = new SqlConnection(_connectionString);
            var command = new SqlCommand(commandString, connection);

            var dataAdapter = new SqlDataAdapter(command);
            var dataTable = new DataTable();
            dataAdapter.Fill(dataTable);

            var Reg = new List<Region>();

            foreach (DataRow row in dataTable.Rows)
            {
                var Regs = new Region()
                {
                    RegionID = (int)row["RegionID"],
                    RegionDescription = (string)row["RegionDescription"],   

                };

                Reg.Add(Regs);
            }

            return Reg;
        }

    }
}
