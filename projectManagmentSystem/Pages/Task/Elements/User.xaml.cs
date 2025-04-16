using Microsoft.EntityFrameworkCore;
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

namespace projectManagmentSystem.Pages.Task.Elements
{
    /// <summary>
    /// Логика взаимодействия для User.xaml
    /// </summary>
    public partial class User : UserControl
    {
        Models.User user;
        public User(Models.User user)
        {
            InitializeComponent();
            this.user = user;
            if (user != null)
                FIO.Content = user.GetFIO();
        }

        private void Delete(object sender, RoutedEventArgs e)
        {
            using (var context = new ApplicationContext())
            {
                var user = context.Tasks.Include(t => t.Users).FirstOrDefault(t => t == MainWindow.OpenedTask).Users.FirstOrDefault(u => u == this.user);
                if(user!= null)
                    context.Tasks.Include(t => t.Users).FirstOrDefault(t => t.Users.Remove(user));
                context.SaveChanges();
            }
            MainWindow.Instance.OpenFrameInFrame(new Pages.Task.SaveTask(MainWindow.OpenedTask));
        }
    }
}
