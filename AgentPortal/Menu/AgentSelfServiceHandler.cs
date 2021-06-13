using System;
using AgentPortal.Services;

namespace AgentPortal.Menu
{
    internal class AgentSelfServiceHandler:ManageAgentService
    {
        internal static void AgentDashboard()
        {
              
            Console.WriteLine($"Welcome {AgentName}! What would you like to do?\n");
            Console.Write("> Press 1 to View Personal Information \n\n> Press 2 to Sign Out\n\n> ");
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
                    NavigationMenu.inAgentMainDashboard = false;
                    AgentId = "";
                break;
            }
        }
        }
    }
