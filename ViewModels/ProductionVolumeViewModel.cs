﻿using LiveChartsCore.SkiaSharpView.Painting;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkiaSharp;
using Production_Analysis.Models;
using Production_Analysis.DbServices;
using System.Windows.Media.Media3D;

namespace Production_Analysis.ViewModels
{
    public class ProductionVolumeViewModel : BaseViewModel
    {        
        public ISeries[] ProductionChart{ get; set; }
        public string[]? Date { get; set; }
        public Axis[] XProductionChart { get; set; }
        public Axis YProductionChart { get; set; }

        public ProductionVolumeViewModel()
        {
            IEnumerable<Production> output = LoadDbData.ProductionVolume(new DateTime(2008, 1, 1), new DateTime(2008, 12, 31));

            ProductionChart = new ISeries[]
            {
                new LineSeries<decimal>
                {
                    Values = output.Select(w => w.Output),
                    Fill = null,
                    Stroke = new SolidColorPaint(new SKColor(90, 169, 230)){StrokeThickness = 3},
                    GeometrySize = 0,
                    LineSmoothness = 1
                }
            };

            XProductionChart = new[]
            {
                new Axis
                {
                    Labels = output.Select(c => (c.MonthYear).ToString("MMM yy")).ToArray()
                }
            };

            YProductionChart = new Axis
                {
                    SeparatorsPaint = null
                };
        } 
    }
}

