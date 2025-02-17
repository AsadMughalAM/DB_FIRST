﻿using DBCrudApp.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBCrudApp.Entities;
using System.Diagnostics.Metrics;
using System.Net;
using System.Numerics;

namespace DBCrudApp.Repositories
{
    public static class SupplierRepository
    {
        public static string _connectionString { get; set; } = @"Data Source=DESKTOP-3J635BH;Initial Catalog=Northwind;Integrated Security=True;Encrypt=False";


        public static List<Supplier> GetData()
        {
            string commandString = "Select * FROM Northwind.dbo.Suppliers";

            var connection = new SqlConnection(_connectionString);
            var command = new SqlCommand(commandString, connection);

            var dataAdapter = new SqlDataAdapter(command);
            var dataTable = new DataTable();
            dataAdapter.Fill(dataTable);

            var Sup = new List<Supplier>();

            foreach (DataRow row in dataTable.Rows)
            {
                var Sups = new Supplier()
                {
                    SupplierID=(int)row["SupplierID"],
CompanyName=(string)row["CompanyName"],
ContactName=row["ContactName"]?.ToString(),
ContactTitle=row["ContactTitle"]?.ToString(),
Address=row["Address"]?.ToString(),
City=row["City"]?.ToString(),
Region=row["Region"]?.ToString(),
PostalCode=row["PostalCode"]?.ToString(),
Country=row["Country"]?.ToString(),
Phone=row["Phone"]?.ToString(),
Fax=row["Fax"]?.ToString(),
HomePage=row["HomePage"]?.ToString(),


                };

                Sup.Add(Sups);
            }

            return Sup;
        }

    }
}
