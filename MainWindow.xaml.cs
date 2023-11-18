﻿using System.Printing;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media.Imaging;
using System.Windows.Media;
using Production_Analysis.ViewModels;
using Microsoft.Win32;
using System.IO;
using System.Reflection.Metadata;

namespace Production_Analysis
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {   
        public MainWindow()
        {
            InitializeComponent();

            DataContext = new MainViewModel();
            //DataContext = new ProductionChartViewModel(new DateTime(2018, 01, 01), new DateTime(2018, 03, 08));
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

    }
}