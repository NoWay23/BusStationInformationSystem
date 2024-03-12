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
    /// Логика взаимодействия для RegistrationWindow.xaml
    /// </summary>
    public partial class RegistrationWindow : Window
    {
        public RegistrationWindow()
        {
            InitializeComponent();
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

        private void Button_Click(object sender, RoutedEventArgs e) 
        {
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string filePath = System.IO.Path.Combine(desktopPath, "User.docx");


            MessageBox.Show("Заполните все поля!!!");

            User user = new User
            {
                Id = Guid.NewGuid(),
                Name = textBoxName.Text,
                Surname = textBoxSurname.Text,
                Patronymic = textBoxPatranomic.Text,
                Birthday = textBoxDate.Text,
                Password = textBoxPassword.Text,
            };

            GenerateUserWord(user, filePath);

            AppWindow app = new AppWindow();
            app.Show();
            this.Close();
        }




        public void GenerateUserWord(User user, string filePath)
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
            row1.GetCell(0).SetText("Name");
            row2.GetCell(0).SetText("Surname");
            row3.GetCell(0).SetText("Patranomic");
            row4.GetCell(0).SetText("Birthday");
            row5.GetCell(0).SetText("Password");


            table.GetRow(0).GetCell(1).SetText(user.Id.ToString());
            row1.GetCell(1).SetText(user.Name);
            row2.GetCell(1).SetText(user.Surname);
            row3.GetCell(1).SetText(user.Patronymic);
            row4.GetCell(1).SetText(user.Birthday.ToString());
            row5.GetCell(1).SetText(user.Password);

            using (FileStream file = new FileStream(filePath, FileMode.Create, FileAccess.Write))
            {
                doc.Write(file);
            }
        }
    }
}
