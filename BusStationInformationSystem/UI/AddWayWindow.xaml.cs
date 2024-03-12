using BusStationInformationSystem.Data.Entity;
using NPOI.XWPF.UserModel;
using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace BusStationInformationSystem.UI
{
    /// <summary>
    /// Логика взаимодействия для AddWayWindow.xaml
    /// </summary>
    public partial class AddWayWindow : Window
    {
        public AddWayWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string filePath = System.IO.Path.Combine(desktopPath, "Way.docx");

            Way way = new Way
            {
                Id = Guid.NewGuid(),
                Code = 1231313,
                StartTime = "08:30",
                EndTime = "10:34",
                Otkuda = "Краснодар",
                Kuda = "Майкоп",
                State = "Прибытие"
            };

            GenerateWayWord(way, filePath);

        }

        private void MinButton_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void PlusButton_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void LogoContainer_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        private void ToolBar_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        public void GenerateWayWord(Way way, string filePath)
        {
            XWPFDocument doc = new XWPFDocument();
            XWPFTable table = doc.CreateTable(1, 2);
            XWPFTableRow row1 = table.CreateRow();
            XWPFTableRow row2 = table.CreateRow();
            XWPFTableRow row3 = table.CreateRow();
            XWPFTableRow row4 = table.CreateRow();
            XWPFTableRow row5 = table.CreateRow();
            XWPFTableRow row6 = table.CreateRow();


            table.GetRow(0).GetCell(0).SetText("Id");
            row1.GetCell(0).SetText("Code");
            row2.GetCell(0).SetText("StartTime");
            row3.GetCell(0).SetText("EndTime");
            row4.GetCell(0).SetText("Otkuda");
            row5.GetCell(0).SetText("Kuda");
            row6.GetCell(0).SetText("State");


            table.GetRow(0).GetCell(1).SetText(way.Id.ToString());
            row1.GetCell(1).SetText(way.Code.ToString());
            row2.GetCell(1).SetText(way.StartTime);
            row3.GetCell(1).SetText(way.EndTime);
            row4.GetCell(1).SetText(way.Otkuda);
            row5.GetCell(1).SetText(way.Kuda);
            row6.GetCell(1).SetText(way.State);

            using (FileStream file = new FileStream(filePath, FileMode.Create, FileAccess.Write))
            {
                doc.Write(file);
            }
        }
    }
}
