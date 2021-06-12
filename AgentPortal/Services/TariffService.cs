using System;
using System.Collections.Generic;
using PortalLibrary.Models;

namespace AgentPortal.Services
{
    public class TariffService : AgentLibraryService
    {
        private static List<Tarrif> tariffs = new List<Tarrif>(service.GetAllTarrif());
        
        public static List<Tarrif> GetAllTariffs()
        {
            return tariffs;
        }

        public static void AddNewTariffPlan(Tarrif tarrif)
        {
            tariffs.Add(tarrif);
            UpdateTariffPlan();
        }

        public void DeleteTariffPlan(Tarrif tarrif)
        {
            tariffs.Remove(tarrif);
            UpdateTariffPlan();
        }

        public static void UpdateTariffPlan()
        {
            service.UpdateTariff(tariffs); //might be returning the intial fetched list
        }
    }
}