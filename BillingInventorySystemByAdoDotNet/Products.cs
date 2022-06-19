using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;


namespace BillingInventorySystemByAdoDotNet
{
    public class Products
    {
        private static string ConnectionString = @"Data Source=DESKTOP-AMR2CQS\MSSQLSERVER01;Initial Catalog=BillingInventory;Integrated Security=True";
        private SqlConnection _connection=new SqlConnection(ConnectionString);
        public  void AddProduct()
        {
            addmore:
            Console.WriteLine("Enter the Product name ");
            string productName =Console.ReadLine();
            if (!CheckProductExistOrNot(productName))
            {
                try
                {
                    Console.WriteLine("Enter the Product Price");
                    double productPrice = Convert.ToDouble(Console.ReadLine());
                    string productAddingdate = DateTime.Now.ToShortDateString();
                    string sql = "insert into Products values('" + productName + "'," + productPrice + ",'" + productAddingdate + "')";
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sql, _connection);
                    DataTable dataTable = new DataTable();
                    if (sqlDataAdapter.Fill(dataTable)> 0)
                    {
                        Console.WriteLine("Product Successfully Added");
                    }
                    Console.WriteLine("do you Want to Add more Items");
                    Console.WriteLine("Press :1");
                    int takemore=Convert.ToInt32(Console.ReadLine());
                    if (takemore == 1)
                    {
                        goto addmore;
                    }


                   



                }
                catch (Exception ex)
                {
                    Console.WriteLine("Something Went Wrong"+ ex.Message);
                }


            }
            else
            {
                Console.WriteLine("Product Already Exist....");
            }




        }
        public void DeleteProduct(int productId)
        {
            try
            {
                string sql = "delete from Products where productId=" + productId + "";
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sql,_connection);
                DataTable dt = new DataTable();
                sqlDataAdapter.Fill(dt);
                Console.WriteLine("Product Delete Successfully With Id"+productId);

            }
            catch(Exception ex)
            {
                Console.WriteLine("SomeThing Gone Wrong"+ ex.Message);
            }

        }
        public void ShowAllProduct()
        {
            try
            {
                string sql = "select * from Products";
                SqlDataAdapter adp = new SqlDataAdapter(sql, _connection);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                for(int i = 0; i < dt.Columns.Count; i++)
                {
                    Console.Write(dt.Columns[i].ColumnName+" ");
                }
                Console.WriteLine();
                for(int i = 0; i < dt.Rows.Count; i++)
                {
                    for(int j = 0; j < dt.Columns.Count; j++)
                    {
                        Console.Write(dt.Rows[i][j]+"         ");
                    }
                    Console.WriteLine();
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("SomeThing Gone Wrong"+ex.Message);
            }


        }
        public void UpdateProductByProductId(int productId)
        {
            try
            {
                Console.WriteLine("Enter the New Name to Update  Product name");
                string updatename = Console.ReadLine();
                Console.WriteLine("Enter The New Price to Update Product Price");
                double updateprice = Convert.ToDouble(Console.ReadLine());

                string sql = "update Products set productName='" + updatename + "',productPrice=" + updateprice + "";
                SqlDataAdapter adp = new SqlDataAdapter(sql, _connection);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                Console.WriteLine("UPDATE SUCCESSFULLY...");
                Console.WriteLine();

            }
            catch (Exception ex)
            {
               Console.WriteLine(ex.Message);
            }

        }
        public void ShowProductByProductId(int ProductId)
        {
            try
            {
                string sql = "select * from Products where productId="+ProductId+"";
                SqlDataAdapter adp = new SqlDataAdapter(sql, _connection);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    Console.Write(dt.Columns[i].ColumnName + " ");
                }
                Console.WriteLine();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        Console.Write(dt.Rows[i][j] + "         ");
                    }
                    Console.WriteLine();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("SomeThing Gone Wrong"+ ex.Message);
            }
        }
        private bool CheckProductExistOrNot(string ProductName)
        {
            string sql = "select * from Products where productName='" + ProductName + "'";
            SqlDataAdapter adapter = new SqlDataAdapter(sql, _connection);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            if(dataTable.Rows.Count > 0)
            {
                return true;
            }

            return false;
        }

    }
}
