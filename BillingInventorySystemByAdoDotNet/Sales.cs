using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace BillingInventorySystemByAdoDotNet
{
    public class Sales
    {
        private static string ConnectionString = @"Data Source=DESKTOP-AMR2CQS\MSSQLSERVER01;Initial Catalog=BillingInventory;Integrated Security=True";
        private SqlConnection _connection = new SqlConnection(ConnectionString);
        public void AddSales()
        {
        addmore:
            
            
                try
                {
                    Console.WriteLine("Enter the Product Id that is To be sale  ");
                    int productId=Convert.ToInt32(Console.ReadLine());
                    DataTable getdata = new DataTable();
                    getdata = ShowProductByProductId(productId);

                    if (getdata.Rows.Count >0)
                    {
                    Console.WriteLine("Enter the Quantity");
                    double quantity = Convert.ToDouble(Console.ReadLine());
                    double price= Convert.ToDouble(getdata.Rows[0][2]);
                    double totalPrice=price*quantity;
                    string salesdate=DateTime.Now.ToShortDateString();
                    Slip(Convert.ToString(getdata.Rows[0][1]),quantity,totalPrice,price);

                    
                    string sql = "insert into Sales values(" + productId + "," + quantity + "," + totalPrice + ",'" + salesdate + "')";
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sql, _connection);
                    DataTable dataTable = new DataTable();
                    if (sqlDataAdapter.Fill(dataTable) > 0)
                    {
                        Console.WriteLine("Sales Successfully Added");
                    }
                    Console.WriteLine("do you Want to Add more Sales");
                    Console.WriteLine("Press :1");
                    int takemore = Convert.ToInt32(Console.ReadLine());
                    if (takemore == 1)
                    {
                        goto addmore;
                    }



                }






            }
                catch (Exception ex)
                {
                    Console.WriteLine("Something Went Wrong" + ex.Message);
                }


           




        }
        public void DeleteProduct(int salesId)
        {
            try
            {
                string sql = "delete from Sales where SalesId=" + salesId + "";
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sql, _connection);
                DataTable dt = new DataTable();
                sqlDataAdapter.Fill(dt);
                Console.WriteLine("Sales Delete Successfully With Id " + salesId);

            }
            catch (Exception ex)
            {
                Console.WriteLine("SomeThing Gone Wrong" + ex.Message);
            }

        }
        public void ShowAllsales()
        {
            try
            {
                string sql = "select * from Sales";
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
                Console.WriteLine("SomeThing Gone Wrong" + ex.Message);
            }


        }
        public void UpdateSalesBySalesId(int salesId)
        {
            DataTable productinfo=new DataTable();  
            DataTable salesinfo=new DataTable();
            try
            {
                
                Console.WriteLine("-----------------------------------");
                #region 
                ERROR1:
                Console.WriteLine("Enter the Sales Id that is To be  Update sale  ");
                //int salesId = Convert.ToInt32(Console.ReadLine());
                DataTable getdata = new DataTable();
                getdata = SalesInformation(salesId);

                if (getdata.Rows.Count > 0)
                {
                    Console.WriteLine("Enter the new  Product Id to be Update");

                    int proId = Convert.ToInt32(Console.ReadLine());
                    productinfo=ShowProductByProductId(proId);
                    if(productinfo.Rows.Count == 0)
                    {
                        Console.WriteLine("There is No Product With This Id");
                        goto ERROR1;
                    }
                    Console.WriteLine("Enter the Quantity");
                    double quantity = Convert.ToDouble(Console.ReadLine());
                    double price = Convert.ToDouble(productinfo.Rows[0][2]);
                    double totalPrice = price * quantity;
                    string salesdate = DateTime.Now.ToShortDateString();
                    string sql = "update Sales set quantity="+quantity+",total_cost="+totalPrice+",productId="+proId+" where salesId="+salesId+"";
                    SqlDataAdapter adp = new SqlDataAdapter(sql, _connection);
                    DataTable dt = new DataTable();
                    adp.Fill(dt);
                    Console.WriteLine("UPDATE SUCCESSFULLY...");
                    Console.WriteLine();

                }
                else
                {
                    Console.WriteLine("There is no Product With This Id "+salesId);
                    goto ERROR1;
                }
                    #endregion



                

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
        public DataTable ShowProductByProductId(int ProductId)
        {
            DataTable dt = new DataTable();

            try
            {
                string sql = "select * from Products where productId=" + ProductId + "";
                SqlDataAdapter adp = new SqlDataAdapter(sql, _connection);
                adp.Fill(dt);
               
            }
            catch (Exception ex)
            {
                Console.WriteLine("SomeThing Gone Wrong" + ex.Message);
            }
            return dt;
        }
        private bool CheckProductExistOrNot(string ProductName)
        {
            string sql = "select * from Products where productName='" + ProductName + "'";
            SqlDataAdapter adapter = new SqlDataAdapter(sql, _connection);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            if (dataTable.Rows.Count > 0)
            {
                return true;
            }

            return false;
        }
        public void Slip(string item,double quantity,double totalprice,double price)
        {
            Console.WriteLine("***************************************************************************");
            Console.WriteLine("*                     Bill                                                *");
            Console.WriteLine("*             "+ item+"                                                   *");
            Console.WriteLine("*             "+quantity+"                                                *");
            Console.WriteLine("*            /"+price+"                                                   *");
            Console.WriteLine("*             "+totalprice+"                                              *");
            Console.WriteLine("***************************************************************************");
            Console.WriteLine();
            Console.WriteLine();


        }
        private DataTable SalesInformation(int salesId)
        {
            DataTable dt = new DataTable();
            try
            {
                string sql = "select * from Sales where salesId=" + salesId + "";
                SqlDataAdapter adp = new SqlDataAdapter(sql, _connection);
                adp.Fill(dt);

            }
            catch (Exception ex)
            {
                Console.WriteLine("SomeThing Gone Wrong" + ex.Message);
            }
            return dt;

        }

    }
}
