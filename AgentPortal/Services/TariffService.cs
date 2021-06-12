using System.Collections.Generic;
using PortalLibrary.Models;

namespace AgentPortal.Services
{
    public class TariffService : AgentLibraryService
    {
        protected static List<Tarrif> tariffs = new List<Tarrif>(service.GetAllTarrif());

        protected static void AddNewTariffPlan(string id, string name, decimal pricePerUnit)
        {
            Tarrif tarrif = new Tarrif
            {
                Id = id,
                Name = name,
                PricePerUnit = pricePerUnit
            };

            tariffs.Add(tarrif);
            UpdateTariffPlan();
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