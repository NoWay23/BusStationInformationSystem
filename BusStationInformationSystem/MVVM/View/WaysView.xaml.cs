using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace BusStationInformationSystem.MVVM.View
{
    /// <summary>
    /// Логика взаимодействия для WaysView.xaml
    /// </summary>
    public partial class WaysView : UserControl
    {

        ObservableCollection<Ways> collection = null;

        public WaysView()
        {
            InitializeComponent();

            if (collection == null)
            {
                collection = new ObservableCollection<Ways>();
                DataGrid.ItemsSource = collection;
            }
            collection.Add(new Ways()
            {
                Code = 3131231,
                Number = 1,
                Otkuda = "Краснодар",
                Kuda = "Майкоп",
                StartDate = "23.12.2023 14:56",
                EndDate = "23.12.2023 16:56",
                State = "Ожидание"
            });
            collection.Add(new Ways()
            {
                Code = 3131411,
                Number = 2,
                Otkuda = "Краснодар",
                Kuda = "Москва",
                StartDate = "23.12.2023 11:56",
                EndDate = "24.12.2023 15:23",
                State = "На вокзале"
            });
            collection.Add(new Ways()
            {
                Code = 2341231,
                Number = 3,
                Otkuda = "Краснодар",
                Kuda = "Ростов-на-Дону",
                StartDate = "23.12.2023 14:56",
                EndDate = "23.12.2023 18:56",
                State = "Ожидание"
            });
            collection.Add(new Ways()
            {
                Code = 31312379,
                Number = 4,
                Otkuda = "Краснодар",
                Kuda = "Ставрополь",
                StartDate = "23.12.2023 14:56",
                EndDate = "23.12.2023 16:56",
                State = "Ожидание"
            });
            collection.Add(new Ways()
            {
                Code = 3633231,
                Number = 5,
                Otkuda = "Краснодар",
                Kuda = "Горячий ключ",
                StartDate = "23.12.2023 13:56",
                EndDate = "23.12.2023 16:56",
                State = "Ожидание"
            });

        }
    }
}
