using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillingInventorySystemByAdoDotNet
{
    public class PerformActions
    {
        public void MainPortal()
        {
            MainPortalAgain:
            Console.WriteLine("******************************************************");
            Console.WriteLine("             Manage  Products Press : 1              *");
            Console.WriteLine("             Manage  Sales    Press : 2              *");
            Console.WriteLine("             close     App    Press : 3              *");
            Console.WriteLine("******************************************************");
            Console.Write("                                        ");
            int switch_on = Convert.ToInt32(Console.ReadLine());
            switch (switch_on)
            {
                case 1:
                    ProductPortal();
                    goto MainPortalAgain;
                case 2:
                    ManageSales();
                    goto MainPortalAgain;
                case 3:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("wrong Choise");
                    goto MainPortalAgain;
            }




        }
        public void ProductPortal()
        {
            Products products = new Products(); 
            Oncemore:
            ManageProductMenu();
            Console.Write("                               ");
            int switch_on=Convert.ToInt32(Console.ReadLine());  
            switch (switch_on)
            {
                case 1:
                    products.AddProduct();
                    goto Oncemore;
                case 2:
                    products.ShowAllProduct();
                    goto Oncemore;
                case 3:
                    Console.WriteLine("enter the Product Id That You want To update");
                    int id=Convert.ToInt32(Console.ReadLine());
                    products.UpdateProductByProductId(id);
                     goto Oncemore;
                case 4:
                    Console.WriteLine("enter the Product Id That You want To Delete");
                    int ids = Convert.ToInt32(Console.ReadLine());
                    products.DeleteProduct(ids);
                    goto Oncemore;
                case 5:
                    break;
                default:
                    Console.WriteLine("wrong choise");
                    goto Oncemore;
            }
        }

        public void ManageSalesMenu()
        {
            Console.WriteLine("**************************************************************");
            Console.WriteLine("*    Add Sales Press    :1                                   *");
            Console.WriteLine("*    show Sales Press   :2                                   *");
            Console.WriteLine("*    Update Sales Press :3                                   *");
            Console.WriteLine("*    Delete Sales Press :4                                   *");
            Console.WriteLine("*     goto Uotside      :5                                   *");


            Console.WriteLine("**************************************************************");


        }
        public void ManageProductMenu()
        {
            Console.WriteLine("*****************************************************************");
            Console.WriteLine("*    Add Product Press     :1                                   *");
            Console.WriteLine("*    show Products Press   :2                                   *");
            Console.WriteLine("*    Update Products Press :3                                   *");
            Console.WriteLine("*    Delete Products Press :4                                   *");
            Console.WriteLine("*     goto Uotside         :5                                   *");


            Console.WriteLine("*****************************************************************");
        }
        public void ManageSales()
        {
            Sales sales = new Sales();  
        Oncemore:
            ManageProductMenu();
            Console.Write("                               ");
            int switch_on = Convert.ToInt32(Console.ReadLine());
            switch (switch_on)
            {
                case 1:
                    sales.AddSales();
                    goto Oncemore;
                case 2:
                    sales.ShowAllsales();
                    goto Oncemore;
                case 3:
                    Console.WriteLine("enter the Sales Id That You want To update");
                    int id = Convert.ToInt32(Console.ReadLine());
                    sales.UpdateSalesBySalesId(id);
                    
                    goto Oncemore;
                case 4:
                    Console.WriteLine("enter the Sales Id That You want To Delete");
                    int ids = Convert.ToInt32(Console.ReadLine());
                    sales.DeleteProduct(ids);
                   
                    goto Oncemore;
                case 5:
                    break;
                default:
                    Console.WriteLine("wrong choise");
                    goto Oncemore;
            }
        }
    }
}
