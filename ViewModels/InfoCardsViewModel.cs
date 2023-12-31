﻿using Production_Analysis.DbServices;
using Production_Analysis.Models;
using System.Collections.Generic;
using System.Linq;

namespace Production_Analysis.ViewModels
{
    public class InfoCardsViewModel : BaseViewModel
    {       
        public decimal ProductionTotal { get; set; }
        public decimal ProductionDefectsPercent { get; set; }
        public decimal EnergyConsumption { get; set; }
        public decimal Emissions { get; set; }

        public InfoCardsViewModel(TimePeriod period)
        {
            IEnumerable<ProductionKPI> productionIndicators = LoadDbData.GetProductionIndicators(period);

            ProductionTotal = (productionIndicators.Select(p => p.ProductionOutput).Sum());
            ProductionDefectsPercent = (productionIndicators.Select(p => p.ProductionDefect).Sum()) / ProductionTotal;
            EnergyConsumption = (productionIndicators.Select(p => p.EnergyConsumption).Sum()) / ProductionTotal;
            Emissions = (productionIndicators.Select(p => p.Emissions).Sum()) / ProductionTotal;
        }
    }
}
