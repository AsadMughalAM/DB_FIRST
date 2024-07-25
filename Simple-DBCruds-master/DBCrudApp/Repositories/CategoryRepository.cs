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
    public static class CategoryRepository
    {
        public static string _connectionString { get; set; } = @"Data Source=DESKTOP-3J635BH;Initial Catalog=Northwind;Integrated Security=True;Encrypt=False";


        public static List<Category> GetData()
        {
            string commandString = "Select * FROM Northwind.dbo.Categories;";

            var connection = new SqlConnection(_connectionString);
            var command = new SqlCommand(commandString, connection);

            var dataAdapter = new SqlDataAdapter(command);
            var dataTable = new DataTable();
            dataAdapter.Fill(dataTable);

            var cat = new List<Category>();

            foreach (DataRow row in dataTable.Rows)
            {
                var cate = new Category()
                {
                    CategoryID = (int)row["CategoryID"],
                    CategoryName = (string)row["CategoryName"],
                    Description = row["Description"]?.ToString(),

                };

                cat.Add(cate);
            }

            return cat;
        }

    }
}
