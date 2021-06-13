using System.Collections.Generic;
using PortalLibrary.Models;

namespace AgentPortal.Services
{
    public class TariffService : AgentLibraryService
    {
        protected static List<Tarrif> tariffs = new List<Tarrif>(service.GetAllTarrif());

        protected static string AddNewTariffPlan(string id, string name, decimal pricePerUnit)
        {
            var existingTariffId = tariffs.Find(c => c.Id == id);

            if (existingTariffId == null)
            {
                Tarrif tarrif = new Tarrif
                {
                    Id = id,
                    Name = name,
                    PricePerUnit = pricePerUnit
                };

                tariffs.Add(tarrif);
                UpdateTariffPlan();

                return "Tariff added successfully.";
            }
            else
            {
                return "Tariff ID already exist";
            }
        }

        protected static void DeleteTariffPlan(Tarrif tarrif)
        {
            tariffs.Remove(tarrif);
            UpdateTariffPlan();
        }

        protected static void UpdateTariffPlan()
        {
            service.UpdateTariff(tariffs);
        }
    }
}