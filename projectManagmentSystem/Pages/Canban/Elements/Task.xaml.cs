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

namespace projectManagmentSystem.Pages.Canban.Elements
{
    /// <summary>
    /// Логика взаимодействия для Task.xaml
    /// </summary>
    public partial class Task : UserControl
    {
        Models.Task task;
        public Task(Models.Task task)
        {
            InitializeComponent();
            this.task = task;
            if (task != null)
                LoadInterface();
        }
        void LoadInterface()
        {
            TaskName.Text = task.Name;
            Description.Text = task.Description;
        }

        private void OpenCanbanSubtask(object sender, MouseButtonEventArgs e) 
        {
            MainWindow.OpenedTask = task;
            MainWindow.Instance.OpenPage(new Pages.CanbanSubtask.CanbanSubtask(task));
        }

        private void Delete(object sender, RoutedEventArgs e)
        {
            MainWindow.OpenedTask = task;
            using (var context = new ApplicationContext())
            {
                var task = context.Tasks.FirstOrDefault(t => t == this.task);
                context.Tasks.Remove(task);
                context.SaveChanges();
                MainWindow.Instance.OpenPage(new Pages.Canban.Canban(MainWindow.OpenedProject));
            }
        }

        private void Edit(object sender, RoutedEventArgs e)
        {
            MainWindow.OpenedTask = task;
            MainWindow.Instance.OpenFrameInFrame(new Pages.Task.SaveTask(task));
        }
    }
}
