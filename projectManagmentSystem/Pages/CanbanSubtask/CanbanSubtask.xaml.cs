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

namespace projectManagmentSystem.Pages.CanbanSubtask
{
    /// <summary>
    /// Логика взаимодействия для CanbanSubtask.xaml
    /// </summary>
    public partial class CanbanSubtask : Page
    {
        Models.Task Task;
        

        public CanbanSubtask(Models.Task task)
        {
            InitializeComponent();
            MainWindow.OpenedTask = task;   
            this.Task = task;
            LoadInterface();
        }
        private void CreateColumn(object sender, RoutedEventArgs e)
        {
            MainWindow.Instance.OpenFrameInFrame(new Pages.Canban.SaveColumn());
        }
        private void LoadInterface()
        {
            using (var context = new ApplicationContext())
            {
                var statuses = context.ProjectStatuses.Where(ps => ps.ProjectId == MainWindow.OpenedProject.Id).ToList();
                foreach (var status in statuses)
                    ColumnsParent.Children.Add(new Elements.Column(status));
            }
        }

        private void CreateSubtask(object sender, RoutedEventArgs e) => MainWindow.Instance.OpenFrameInFrame(new Pages.Subtask.SaveSubtask());
    }
}
