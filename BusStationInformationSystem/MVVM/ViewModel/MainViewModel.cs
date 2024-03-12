using BusStationInformationSystem.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusStationInformationSystem.MVVM.ViewModel
{
    public class MainViewModel : ObservableObject
    {
        public RelayComand AdministrationViewComand { get; set; }

        public RelayComand DocumentationViewCommand { get; set; }

        public RelayComand TicketsViewCommand { get; set; }

        public RelayComand HomeViewCommand { get; set; }

        public RelayComand WaysViewCommand { get; set; }

        public HomeViewModel HomeVM { get; set; }
        public WaysViewModel WaysVM { get; set; }
        public TicketsViewModel TicketsVM { get; set; }
        public DocumentationViewModel DocumentationVM { get; set; }
        public AdministrationViewModel AdministrationVM { get; set; }

        private object _currentView;

        public object CurrentView
        {
            get { return _currentView; }
            set 
            {
                _currentView = value;
                OnPropertyChanged();
            }
        }


        public MainViewModel() 
        {
            HomeVM = new HomeViewModel();
            WaysVM = new WaysViewModel();
            TicketsVM = new TicketsViewModel();
            DocumentationVM = new DocumentationViewModel();
            AdministrationVM = new AdministrationViewModel();

            HomeViewCommand = new RelayComand(o =>
            {
                CurrentView = HomeVM;
            });

            WaysViewCommand = new RelayComand(o =>
            {
                CurrentView = WaysVM;
            });

            TicketsViewCommand = new RelayComand(o =>
            {
                CurrentView = TicketsVM;
            });

            DocumentationViewCommand = new RelayComand(o => 
            {
                CurrentView = DocumentationVM;
            });

            AdministrationViewComand = new RelayComand(o =>
                {
                    CurrentView = AdministrationVM;
                });

        }
    }
}
