using FlightSimulator.Model.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlightSimulator.Model;
using FlightSimulator.Views;
using System.ComponentModel;

namespace FlightSimulator.ViewModels
{
    public class FlightBoardViewModel : BaseNotify
    {

        //private FlightBoard view;
        public FlightBoardViewModel()
        {
            //view = new FlightBoard();
            //PropertyChanged += Property;

            InfoChannel.Instance.PropertyChanged += Property;
        }

        private void Property(object sender, PropertyChangedEventArgs e)
        {
            NotifyPropertyChanged(e.PropertyName);
        }

        public double Lon
        {
            get { return InfoChannel.Instance.Lon; }

        }

        public double Lat
        {
            get { return InfoChannel.Instance.Lat; }

        }
    }
}

