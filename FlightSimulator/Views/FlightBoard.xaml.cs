﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using FlightSimulator.Model;
using FlightSimulator.ViewModels;
using Microsoft.Research.DynamicDataDisplay;
using Microsoft.Research.DynamicDataDisplay.DataSources;

namespace FlightSimulator.Views
{


    /// <summary>
    /// Interaction logic for MazeBoard.xaml
    /// </summary>
    /// 
    public partial class FlightBoard : UserControl
    {
        FlightBoardViewModel flightBoardViewModel;
        ObservableDataSource<Point> planeLocations = null;
        public FlightBoard()
        {
            InitializeComponent();
            //this.DataContext = new FlightBoardViewModel();
            flightBoardViewModel = new FlightBoardViewModel();
            flightBoardViewModel.PropertyChanged += Vm_PropertyChanged;



        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            planeLocations = new ObservableDataSource<Point>();
            // Set identity mapping of point in collection to point on plot
            planeLocations.SetXYMapping(p => p);

            plotter.AddLineGraph(planeLocations, 2, "Route");
        }

        private void Vm_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {

            if (e.PropertyName.Equals("Lat") || e.PropertyName.Equals("Lon"))
            {
                //Console.WriteLine("hiiiiiii2");
                Point p1 = new Point(flightBoardViewModel.Lat, flightBoardViewModel.Lon);
                // Fill here!
                //Console.WriteLine("Lat: {0}, Lon: {1}", flightBoardViewModel.Lat, flightBoardViewModel.Lon);
                planeLocations.AppendAsync(Dispatcher, p1);
            }
        }

    }

}

