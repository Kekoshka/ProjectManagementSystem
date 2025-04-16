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

namespace projectManagmentSystem.Pages.Projects.Elements
{
    /// <summary>
    /// Логика взаимодействия для Project.xaml
    /// </summary>
    public partial class Project : UserControl
    {
        Models.Project project;
        public Project(Models.Project project)
        {
            InitializeComponent();
            this.project = project;
            if(project!= null)
            {
                LoadInterface();
                MainWindow.OpenedProject = project;
            }
        }

        void OpenProjectCanban(object sender, MouseButtonEventArgs e) => MainWindow.Instance.OpenPage(new Pages.Canban.Canban(project));
        void LoadInterface()
        {
            using (var context = new ApplicationContext())
            {
                var projectInclude = context.Projects.Include(p => p.Participations).ThenInclude(p => p.User).FirstOrDefault(p => p == project);
                if(projectInclude != null)
                {
                    Name.Text = projectInclude.Name;
                    Owner.Text = projectInclude.Participations.Single(p => p.RoleId == 1).User.GetFIO();
                }
            }
        }

        private void Edit(object sender, RoutedEventArgs e) 
        {
            MainWindow.OpenedProject = project;
            MainWindow.Instance.OpenFrameInFrame(new Pages.Project.SaveProject(project));
        }

        private void Delete(object sender, RoutedEventArgs e)
        {
            MainWindow.OpenedProject = project;
            using (var context = new ApplicationContext())
            {
                var project = context.Projects.FirstOrDefault(p => p == this.project);
                if(project!= null)
                    context.Projects.Remove(project);
                context.SaveChanges();
                MainWindow.Instance.OpenPage(new Pages.Project.ListProjects());
            }
        }
    }
}
