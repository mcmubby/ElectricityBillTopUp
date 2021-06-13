using System;
using AgentPortal.Menu;
using AgentPortal.Services;

namespace AgentPortal.Handler
{
    internal class AgentSelfServiceHandler : ManageAgentService
    {
        internal static void AgentDashboard()
        {
            Console.Clear();
            Console.WriteLine($"Welcome {AgentName}! What would you like to do?\n");
            Console.Write("> Press 1 to View Personal Information \n\n> Press 2 to View Tariff Information \n\n> Press 3 to go to Main Dashboard\n\n> ");
            var response = Console.ReadLine();

            switch (response)
            {
                
                case "1":
                    Console.Clear();
                    ViewAgentDetail();
                    NavigationMenu.inAgentMainDashboard = true;
                break;

                case "2":
                    Console.Clear();
                    TariffHandler.SelectAction();
                    NavigationMenu.inAgentMainDashboard = true;
                break;

                case "3":
                    Console.Clear();
                    NavigationMenu.inAgentMainDashboard = false;
                    AgentId = "";
                break;
            }
        }
        }
    }
