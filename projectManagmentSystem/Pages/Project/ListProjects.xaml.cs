using Microsoft.EntityFrameworkCore;
using projectManagmentSystem.Context;
using projectManagmentSystem.Pages.Projects.Elements;
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

namespace projectManagmentSystem.Pages.Project
{
    /// <summary>
    /// Логика взаимодействия для ListProjects.xaml
    /// </summary>
    public partial class ListProjects : Page
    {
        List<Models.Project> Projects;
        public ListProjects()
        {
            InitializeComponent();
            LoadInterface();
        }

        void CreateProject(object sender, RoutedEventArgs e) => MainWindow.Instance.OpenFrameInFrame(new Pages.Project.SaveProject());
        void LoadInterface()
        {
            using (var context = new ApplicationContext())
            {
                var Projects = context.Projects.Include(p => p.Participations).Where(p => p.Participations.Where(par => par.UserId == MainWindow.CurrentUser.Id).Count() > 0 || p.Private == false);
                foreach (var project in Projects)
                    ProjectsParent.Children.Add(new Projects.Elements.Project(project));
            }
        }

    }
}
