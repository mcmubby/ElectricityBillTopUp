using System;
using AgentPortal.AppData;
using AgentPortal.Handler;
using PortalLibrary.Models;

namespace AgentPortal.Services
{

    public class ManageAgentService : AgentLibraryService
	{
		protected static string AgentName = AgentApplicationData.CurrentAgentName;
		protected static string AgentId = AgentApplicationData.CurrentAgentId;
        protected static Agent foundAgentDetail = service.GetAgentById(AgentId);


        protected static void ViewAgentDetail()
        {
            PrintAgentDetails();
            Console.Write($"\n> Press 1 to Update Details \n\n> Press 2 to go back \n\n> ");
            var response = Console.ReadLine();
            
            switch (response)
            {
                case "1":
                    Console.Clear();
                    UpdateAgentDetails();
                break;

                default:
                break;
            }
        }
        
        private static void UpdateAgentDetails()
        {
            
            bool editAnother = true;
            Console.Clear();

            while(editAnother)
            {
                Console.Write("What would you like to update? \n\n> Press 1 to Edit Firstname \n\n> Press 2 to Edit Lastname \n\n> Press 3 to Edit Email \n\n> Press 4 to Change Phone Number \n\n> Press 5 to Change Password \n\n> Press b to go back\n\n> ");
                var response = Console.ReadLine();

                switch (response)
                {
                    case "1":
                        Console.Write("Please enter your new First name : ");
                        foundAgentDetail.FirstName = Console.ReadLine();
                    break;

                    case "2":
                        Console.Write("Please enter your new Last name : ");
                        foundAgentDetail.LastName = Console.ReadLine();
                    break;

                    case "3":
                        Console.Write("Please enter your new Email : ");
                       foundAgentDetail.EmailAddress = Console.ReadLine();
                    break;

                    case "4":
                        Console.Write("Please enter your new Phone number : ");
                        foundAgentDetail.PhoneNumber = Console.ReadLine();
                    break;

                    case "5":
                        Console.Write("Please enter your new Password : ");
                        foundAgentDetail.Password = AuthenticationHandler.GetConsolePassword();
                    break;

                    case "b":
                        editAnother = false;
                    break;
                }

                Console.Clear();

                if (response != "b")
                {
                    Console.WriteLine("Would you like to update another information? (Y/N)");
                    var continueEditing = Console.ReadLine();

                    if (continueEditing.ToUpper() != "Y")
                    {
                        editAnother = false;
                    }
                }

                Console.Clear();
            }

           foundAgentDetail.ModifiedAt = DateTime.Now;

            service.UpdateAgent(foundAgentDetail);
        }


		private static void PrintAgentDetails()
        {
            Console.WriteLine($"\n> First Name : {foundAgentDetail.FirstName} \n\n> Last Name : {foundAgentDetail.LastName} \n\n> Email Address : {foundAgentDetail.EmailAddress}");
            Console.WriteLine($"\n> Phone Number : {foundAgentDetail.PhoneNumber} \n\n");
        }
	}
}
