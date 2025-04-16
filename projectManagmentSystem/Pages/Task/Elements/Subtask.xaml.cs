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
    /// Логика взаимодействия для Subtask.xaml
    /// </summary>
    public partial class Subtask : UserControl
    {
        Models.Subtask subtask;
        public Subtask(Models.Subtask subtask)
        {
            InitializeComponent();
            this.subtask = subtask;
            if(subtask!= null)
                Name.Content = subtask.Name;
        }

        private void OpenSubtask(object sender, MouseButtonEventArgs e)
        {
            MainWindow.Instance.OpenFrameInFrame(null);
            MainWindow.Instance.OpenPage(new Pages.CanbanSubtask.CanbanSubtask(MainWindow.OpenedTask));
        }
        private void DeleteSubtask(object sender, RoutedEventArgs e)
        {
            using (var context = new ApplicationContext())
            {
                var subtask = context.Subtasks.FirstOrDefault(s => s == this.subtask);
                if (subtask != null)
                    context.Subtasks.Remove(subtask);
                context.SaveChanges();
            }
        }
    }
}
