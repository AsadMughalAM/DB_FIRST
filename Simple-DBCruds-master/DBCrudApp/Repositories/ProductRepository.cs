﻿using DBCrudApp.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBCrudApp.Repositories
{
    public static class ProductRepository
    {
        public static string _connectionString = @"Data Source=DESKTOP-3J635BH;Initial Catalog=Northwind;Integrated Security=True;Encrypt=False";
        
        public static List<Product> GetData()
        {
            string connecion = "Select * from [Northwind].[dbo].[Products]";
            var sqlConnection=new SqlConnection(_connectionString);
            var command= new SqlCommand(connecion, sqlConnection);

            var dataAdapter = new SqlDataAdapter(command);
            var dataTable = new DataTable();
            dataAdapter.Fill(dataTable);

            var prods = new List<Product>();
            foreach (DataRow row in dataTable.Rows)
            {
                var prod = new Product()
                {
                    ProductID=(int)row["ProductID"],
                    ProductName = (string)row["ProductName"],
                    SupplierID = row["SupplierID"] as int?,
                    CategoryID= row["CategoryID"] as int?,
                    QuantityPerUnit = row["SupplierID"]?.ToString(),
                    UnitPrice = row["UnitPrice"] as decimal?,
                    UnitsInStock = row["UnitsInStock"] as int?,
                    UnitsOnOrder = row["UnitsOnOrder"] as int?,
                    ReorderLevel = row["ReorderLevel"] as int?,
                    Discontinued = (bool)row["Discontinued"],

                };
                prods.Add(prod);
            }
            return prods;


        }
    }
}
