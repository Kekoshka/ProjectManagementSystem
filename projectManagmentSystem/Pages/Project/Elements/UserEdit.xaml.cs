using Microsoft.EntityFrameworkCore;
using projectManagmentSystem.Context;
using projectManagmentSystem.Models;
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

namespace projectManagmentSystem.Pages.Project.Elements
{
    /// <summary>
    /// Логика взаимодействия для UserEdit.xaml
    /// </summary>
    public partial class UserEdit : UserControl
    {
        Models.Participation Participation;
        public UserEdit(Models.Participation participation)
        {
            InitializeComponent();
            Participation = participation;
            LoadRoles();
            LoadInterface();
        }
        void LoadInterface()
        {
            if (Participation != null)
            {
                Name.Content = Participation.User.GetFIO();
                RolesParent.SelectedValue = MainWindow.Roles.First(r => r.Id == Participation.Role.Id);
            }
        }
        void LoadRoles()
        {
            RolesParent.ItemsSource = MainWindow.Roles;
            RolesParent.DisplayMemberPath = "Name";
        }

        private void EditUserRole(object sender, SelectionChangedEventArgs e)
        {
            using (var context = new ApplicationContext())
            {
                var participation = context.Participations.FirstOrDefault(p => p.Id == Participation.Id);
                if (participation != null)
                    participation.RoleId = ((Role)RolesParent.SelectedValue).Id;
                context.SaveChanges();
            }
        }
    }
}
