using projectManagmentSystem.Common.DataValidation;
using projectManagmentSystem.Context;
using System;
using System.Collections.Generic;
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

namespace projectManagmentSystem.Pages
{
    /// <summary>
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    public partial class Registration : Page
    {
        public Registration()
        {
            InitializeComponent();
            MainWindow.Instance.Menu.Visibility = Visibility.Hidden;
        }

        private void OpenAuthorization(object sender, RoutedEventArgs e) => MainWindow.Instance.OpenPage(new Pages.Authorization());

        private void Reg(object sender, RoutedEventArgs e)
        {
            Models.User user = new Models.User();
            user.Name = Name.Text;
            user.Surname = Surname.Text;
            user.Patronumic = Patronymic.Text;
            user.Mail = Mail.Text;
            user.Password = Password.Password;
            if (CommonValidator.Validate(user))
                using (var context = new ApplicationContext())
                {
                    context.Users.Add(user);
                    context.SaveChanges();
                    MainWindow.Instance.OpenPage(new Pages.Authorization());
                }
        }
    }
}
