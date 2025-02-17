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
    public static class OrderDetailRepository
    {
        public static string _connectionString {  get; set; } = @"Data Source=DESKTOP-3J635BH;Initial Catalog=Northwind;Integrated Security=True;Encrypt=False";

        public static List<OrderDetail> GetData()
        {
            string commandString = $"Select * from [Northwind].[dbo].[Order Details]";
            var connection = new SqlConnection(_connectionString);
            var command = new SqlCommand(commandString, connection);

            var dataAdapter = new SqlDataAdapter(command);
            var dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            var obj = new List<OrderDetail>();
            foreach (DataRow row in dataTable.Rows)
            {
                var ord = new OrderDetail()
                {
                    OrderID = (int)row["OrderID"],
                    ProductID = (int)row["ProductID"],
                    UnitPrice = (decimal)row["UnitPrice"],
                    Quantity = (Int16)row["Quantity"],
                    Discount = (float)row["Discount"],
                };
                obj.Add(ord);
            }
            return obj;
        }
    }
}
