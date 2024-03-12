using BusStationInformationSystem.Data.Entity;
using NPOI.SS.Formula.Functions;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using NPOI.XWPF.UserModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
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
    /// Логика взаимодействия для TicketView.xaml
    /// </summary>
    public partial class TicketView : UserControl
    {
        ObservableCollection<Ways> collection = null;

        public TicketView()
        {
            InitializeComponent();
            

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string filePath = System.IO.Path.Combine(desktopPath, "ticket.docx");

            var Ticket = new Ticket
            {
                Id = Guid.NewGuid(),
                Date = DateTime.Now,
                PlaceOfDeparture = "New York",
                Destination = "Los Angeles",
                RouteNumber = 1241312,
                SeatNumber = 23
            };

            GenerateTicket(Ticket, filePath);
        }


        public void GenerateTicket(Ticket ticket, string filePath)
        {
            XWPFDocument doc = new XWPFDocument();
            XWPFTable table = doc.CreateTable(1, 6);
            table.GetRow(0).GetCell(1).SetText("Date");
            table.GetRow(0).GetCell(2).SetText("PlaceOfDeparture");
            table.GetRow(0).GetCell(3).SetText("Destination");
            table.GetRow(0).GetCell(4).SetText("RouteNumber");
            table.GetRow(0).GetCell(5).SetText("SeatNumber");


            XWPFTableRow row = table.CreateRow();
            row.GetCell(1).SetText(ticket.Date.ToString());
            row.GetCell(2).SetText(ticket.PlaceOfDeparture);
            row.GetCell(3).SetText(ticket.Destination);
            row.GetCell(4).SetText(ticket.RouteNumber.ToString());
            row.GetCell(5).SetText(ticket.SeatNumber.ToString());

            using (FileStream file = new FileStream(filePath, FileMode.Create, FileAccess.Write))
            {
                doc.Write(file);
            }

            if (collection == null)
            {
                collection = new ObservableCollection<Ways>();
                DataGridWays.ItemsSource = collection;
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

            MessageBox.Show("Билет не выбран");
        }


    }

    public class Ways
    {
        public int Number { get; set; }
        public int Code { get; set; }
        public string Otkuda { get; set; }
        public string Kuda { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string State { get; set; }
    }
}
