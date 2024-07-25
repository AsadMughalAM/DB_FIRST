﻿using DBCrudApp.Models;
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
    public static class TerritoryRepository
    {
        public static string _connectionString { get; set; } = @"Data Source=DESKTOP-3J635BH;Initial Catalog=Northwind;Integrated Security=True;Encrypt=False";


        public static List<Territory> GetData()
        {
            string commandString = "Select * FROM Northwind.dbo.Territories";

            var connection = new SqlConnection(_connectionString);
            var command = new SqlCommand(commandString, connection);

            var dataAdapter = new SqlDataAdapter(command);
            var dataTable = new DataTable();
            dataAdapter.Fill(dataTable);

            var Tery = new List<Territory>();

            foreach (DataRow row in dataTable.Rows)
            {
                var Terys = new Territory()
                {
                    TerritoryID = (string)row["TerritoryID"],
                    TerritoryDescription = (string)row["TerritoryDescription"],
                    RegionID = (int)row["RegionID"],

                };

                Tery.Add(Terys);
            }

            return Tery;
        }

    }
}
