using FlightSimulator.Model.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlightSimulator.Views;

namespace FlightSimulator.ViewModels
{
    public class FlightBoardViewModel : BaseNotify
    {
        private double lon, lat;

        private static FlightBoardViewModel m_Instance = null;

        public static FlightBoardViewModel Instance
        {
            get
            {
                if (m_Instance == null)
                {
                    m_Instance = new FlightBoardViewModel();
                }
                return m_Instance;
            }
        }
        //private FlightBoard view;
        private FlightBoardViewModel() {}

        public double Lon
        {
            get { return lon; }
            set
            {
                lon = value;
                Console.WriteLine("lon: {0}", value);
                NotifyPropertyChanged("Lon");
            }
        }

        public double Lat
        {
            get { return lat; }
            set
            {
                lat = value;
                Console.WriteLine("lat: {0}", value);
                NotifyPropertyChanged("Lat");
            }
        }
    }
}
