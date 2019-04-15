using FlightSimulator.Model.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlightSimulator.Model;
using FlightSimulator.Views;

namespace FlightSimulator.ViewModels
{
    public class FlightBoardViewModel : BaseNotify
    {
        //private FlightBoard view;
        public FlightBoardViewModel()
        {
            //view = new FlightBoard();
            //PropertyChanged += view.Vm_PropertyChanged;
        }

        public double Lon
        {
            get { return InfoChannel.Instance.Lon; }
            set
            {
                InfoChannel.Instance.Lon = value;
                NotifyPropertyChanged("Lon");
            }
        }

        public double Lat
        {
            get { return InfoChannel.Instance.Lat; }
            set
            {
                InfoChannel.Instance.Lon = value;
                NotifyPropertyChanged("Lat");
            }
        }
    }
}
