using System;
using AgentPortal.Services;

namespace AgentPortal.Menu
{
    public class TariffHandler : TariffService
    {
        public static void PrintAllTariffPlans()
        {
            foreach (var tariff in tariffs)
            {
                Console.WriteLine($"Tariff ID : {tariff.Id} \nTariff Name : {tariff.Name} \nPrice Per Unit : {tariff.PricePerUnit}\n\n--------\t\t----------\n");
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
                    decimal editedPricePerUnit = 0;
                    Console.Write($"Enter a new price per unit for {tariffs[i].Name} (Current value : {tariffs[i].PricePerUnit}) : ");
                    var newPricePerUnit = Console.ReadLine();

                    while (!decimal.TryParse(newPricePerUnit, out editedPricePerUnit))
                    {
                        Console.Write("Enter a valid input : ");
                        newPricePerUnit = Console.ReadLine();
                    }

                    tariffs[i].PricePerUnit = editedPricePerUnit;

                    UpdateTariffPlan();
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
            throw new NotImplementedException();
        }

        private static void DeleteTariff()
        {
            throw new NotImplementedException();
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
    }
}