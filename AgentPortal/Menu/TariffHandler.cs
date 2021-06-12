using System;
using AgentPortal.Services;

namespace AgentPortal.Menu
{
    public class TariffHandler : TariffService
    {
        public static void PrintAllTariffPlans()
        {
            Console.WriteLine($"Tariff ID \t\t\t Tariff Name \t\t\t\t Price Per Unit");

            foreach (var tariff in tariffs)
            {
                Console.WriteLine($"\n{tariff.Id} \t\t\t\t  {tariff.Name} \t\t\t\t\t\t {tariff.PricePerUnit}");
            }
        }

        private static void UpdateExistingTariffPlan()
        {
            Console.Clear();
            PrintAllTariffPlans();

            Console.Write("Enter the ID of the tariff you want to edit : ");
            var response = Console.ReadLine();

            for (int i = 0; i < tariffs.Count; i++)
            {
                if (response == tariffs[i].Id)
                {
                    Console.Clear();
                    Console.Write($"Enter a new price per unit for {tariffs[i].Name} (Current value : {tariffs[i].PricePerUnit}) : ");
                    var newPricePerUnit = Console.ReadLine();

                    tariffs[i].PricePerUnit = ValidatePricePerUnit(newPricePerUnit);

                    UpdateTariffPlan();
                    Console.Clear();
                    Console.WriteLine("Tariff updated. \n\nPress any key to go back...");
                    Console.ReadKey();
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Tariff not found. \n\nPress any key to go back...");
                    Console.ReadKey();
                }
            }
        }

        private static void AddTariffPlan()
        {
            Console.Clear();

            Console.Write("Enter Tariff ID : ");
            var tariffId = Console.ReadLine();
            var id = AuthenticationHandler.ValidateUserInput(tariffId, "Tariff ID");

            Console.Write("\nEnter Tariff Name : ");
            var tariffName = Console.ReadLine();
            var name = AuthenticationHandler.ValidateUserInput(tariffName, "Tariff Name");

            Console.Write("\nEnter Tariff Price Per Unit : ");
            var tariffPricePerUnit = Console.ReadLine();
            var pricePerUnit = ValidatePricePerUnit(tariffPricePerUnit);

            AddNewTariffPlan(id,name,pricePerUnit);

            Console.Clear();
            PrintAllTariffPlans();
            Console.WriteLine("\n\nTariff added successfully. \n\nPress any key to go back...");
            Console.ReadKey();
        }

        private static void DeleteTariff()
        {
            Console.Clear();
            PrintAllTariffPlans();

            Console.Write("Enter the Tariff ID of the tariff you want to delete : ");
            var response = Console.ReadLine();

            var tariff = tariffs.Find(c => c.Id == response);

            if (tariff != null)
            {
                DeleteTariffPlan(tariff);
                Console.Clear();
                Console.WriteLine("Tariff deleted. \n\nPress any key to go back...");
                Console.ReadKey();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Tariff not found. \n\nPress any key to go back...");
                Console.ReadKey();
            }
        }

        private static void SelectAction()
        {
            Console.Write("\n> Press 1 to Edit A Tariff Plan \n\n> Press 2 to Add A New Tariff Plan \n\n> Press 3 to Delete A Tariff Plan \n\n> ");
            var response = Console.ReadLine();

            switch (response)
            {
                case "1":
                    UpdateExistingTariffPlan();
                break;

                case "2":
                    AddTariffPlan();
                break;

                case "3":
                    DeleteTariff();
                break;

                default:
                break;
            }
        }

        private static decimal ValidatePricePerUnit(string userValue)
        {
            decimal checkedPricePerUnit = 0;

            while (!decimal.TryParse(userValue, out checkedPricePerUnit))
            {
                Console.Write("Enter a valid input : ");
                userValue = Console.ReadLine();
            }

            return checkedPricePerUnit;
        }
    }
}