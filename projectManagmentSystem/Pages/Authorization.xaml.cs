using projectManagmentSystem.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
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

namespace projectManagmentSystem.Pages
{
    /// <summary>
    /// Логика взаимодействия для Authorization.xaml
    /// </summary>
    public partial class Authorization : Page
    {
        public Authorization()
        {
            InitializeComponent();
            MainWindow.Instance.Menu.Visibility = Visibility.Hidden;
        }

        private void OpenRegistration(object sender, RoutedEventArgs e) => MainWindow.Instance.OpenPage(new Pages.Registration());

        private void Auth(object sender, RoutedEventArgs e)
        {
            using (var context = new ApplicationContext())
            {
                var user = context.Users.FirstOrDefault(u => u.Mail == Mail.Text && u.Password == Password.Password);
                if (user != null)
                {
                    MainWindow.CurrentUser = user;
                    MainWindow.Instance.OpenPage(new Pages.Project.ListProjects());
                    MainWindow.Instance.Menu.Visibility = Visibility.Visible;
                    MainWindow.Instance.UserName.Content = user.getFI();
                }
                else
                    MessageBox.Show("Неверный логин или пароль");
            }
        }
    }
}
