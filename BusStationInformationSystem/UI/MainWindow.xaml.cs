using BusStationInformationSystem.Data.Entity;
using BusStationInformationSystem.UI;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BusStationInformationSystem
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void PlusButton_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void MinButton_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void ToolBar_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        private void LogoContainer_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }


        private void ButtonRegistration_Click(object sender, RoutedEventArgs e)
        {
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string filePath = System.IO.Path.Combine(desktopPath, "UserLogin.docx");

            var UserLogin = new UserLogin
            {
                Username = "Pavel",
                Password = "qwer1rewr2rt21"
            };

            GenerateLoginTemplate(UserLogin, filePath);

            RegistrationWindow registrationWindow = new RegistrationWindow();
            registrationWindow.Show();
        }


        public void GenerateLoginTemplate(UserLogin userLogin, string filePath)
        {
            XWPFDocument doc = new XWPFDocument();
            XWPFTable table = doc.CreateTable(1, 2);
            XWPFTableRow row1 = table.CreateRow();


            table.GetRow(0).GetCell(0).SetText("Username");
            row1.GetCell(0).SetText("Password");


            table.GetRow(0).GetCell(1).SetText(userLogin.Username.ToString());
            row1.GetCell(1).SetText(userLogin.Password.ToString());


            using (FileStream file = new FileStream(filePath, FileMode.Create, FileAccess.Write))
            {
                doc.Write(file);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Пароли не совпадают!!!")  ;
        }
    }
}
