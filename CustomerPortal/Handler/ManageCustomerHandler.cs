using System;
using CustomerPortal.Menu;
using CustomerPortal.Services;

namespace CustomerPortal.Handler
{
    public class ManageCustomerHandler : ManageCustomerService
    {

        public static void CustomerDashboard()
        {
            
            Console.WriteLine($"Welcome {customerName}! What would you like to do?\n");
            Console.Write("> Press 1 to Subscribe \n\n> Press 2 to View Personal Information \n\n> Press 3 to Unsubscribe \n\n> Press 4 to Sign Out\n\n> ");
            var response = Console.ReadLine();

            switch (response)
            {
                case "1":
                    Console.Clear();
                    SubscriptionHandler.SelectAction("subscribe");
                    NavigationMenu.inCustomerDashboard = true;
                break;

                case "2":
                    Console.Clear();
                    ViewCustomerDetail();
                    NavigationMenu.inCustomerDashboard = true;
                break;

                case "3":
                    Console.Clear();
                    SubscriptionHandler.SelectAction("unsubscribe");
                    NavigationMenu.inCustomerDashboard = true;
                break;

                case "4":
                    Console.Clear();
                    NavigationMenu.inCustomerDashboard = false;
                    customerId = "";
                break;
            }
        }
    }
}