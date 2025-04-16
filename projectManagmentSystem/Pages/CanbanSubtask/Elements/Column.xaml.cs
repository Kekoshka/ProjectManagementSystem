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

namespace projectManagmentSystem.Pages.CanbanSubtask.Elements
{
    /// <summary>
    /// Логика взаимодействия для Column.xaml
    /// </summary>
    public partial class Column : UserControl
    {
        Models.ProjectStatus ProjectStatus;
        public Column(Models.ProjectStatus projectStatus)
        {
            InitializeComponent();
            this.ProjectStatus = projectStatus;
            if (projectStatus != null)
            {
                LoadInterface();
                if (projectStatus.Name == "Новые")
                {
                    Del.Visibility = Visibility.Hidden;
                    Ed.Visibility = Visibility.Hidden;
                }
            }
        }

        private void Edit(object sender, RoutedEventArgs e) => MainWindow.Instance.OpenFrameInFrame(new Pages.Canban.SaveColumn(ProjectStatus));

        private void Delete(object sender, RoutedEventArgs e)
        {
            using (var context = new ApplicationContext())
            {
                var ps = context.ProjectStatuses.FirstOrDefault(ps => ps == ProjectStatus);
                if (ps != null)
                    context.ProjectStatuses.Remove(ps);
                context.SaveChanges();
            }
            MainWindow.Instance.OpenPage(new Pages.Canban.Canban(MainWindow.OpenedProject));
        }
        private void LoadInterface()
        {
            ColumnName.Content = ProjectStatus.Name;
            using (var context = new ApplicationContext())
            {
                var subtasks = context.Subtasks.Where(s => s.TaskId == MainWindow.OpenedTask.Id && s.ProjectStatusId == ProjectStatus.Id).ToList();
                foreach (var subtask in subtasks)
                    TasksParent.Children.Add(new Elements.Subtask(subtask));

            }
        }


    }
}
