using System;
using System.Collections.Generic;
using AgentPortal.Services;
using PortalLibrary.Models;

namespace AgentPortal.Menu
{
    public class TariffHandler : TariffService
    {
        private static List<Tarrif> availableTariff = new List<Tarrif>(GetAllTariffs());
        public static void PrintAllTariffPlans()
        {
            foreach (var tariff in availableTariff)
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

            for (int i = 0; i < availableTariff.Count; i++)
            {
                if (response == availableTariff[i].Id)
                {
                    Console.Clear();
                    decimal editedPricePerUnit = 0;
                    Console.Write($"Enter a new price per unit for {availableTariff[i].Name} (Current value : {availableTariff[i].PricePerUnit}) : ");
                    var newPricePerUnit = Console.ReadLine();

                    while (!decimal.TryParse(newPricePerUnit, out editedPricePerUnit))
                    {
                        Console.Write("Enter a valid input : ");
                        newPricePerUnit = Console.ReadLine();
                    }

                    availableTariff[i].PricePerUnit = editedPricePerUnit;
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