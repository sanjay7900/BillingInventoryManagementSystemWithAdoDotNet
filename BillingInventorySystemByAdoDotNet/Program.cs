using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillingInventorySystemByAdoDotNet
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PerformActions performActions = new PerformActions();
            performActions.MainPortal();
            Console.ReadLine(); 
        }
    }
}
