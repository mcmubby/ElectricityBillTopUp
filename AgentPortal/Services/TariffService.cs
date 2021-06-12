using System;
using System.Collections.Generic;
using PortalLibrary.Models;

namespace AgentPortal.Services
{
    public class TariffService : AgentLibraryService
    {
        protected static List<Tarrif> tariffs = new List<Tarrif>(service.GetAllTarrif());

        protected static void AddNewTariffPlan(Tarrif tarrif)
        {
            tariffs.Add(tarrif);
            UpdateTariffPlan();
        }

        protected void DeleteTariffPlan(Tarrif tarrif)
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