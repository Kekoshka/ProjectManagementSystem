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

namespace projectManagmentSystem.Pages.CanbanSubtask.Elements
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
            if (subtask != null)
                LoadInterface();
        }
        void LoadInterface()
        {
            using (var context = new ApplicationContext())
            {
                var subtaskInclude = context.Subtasks.Include(s => s.User).FirstOrDefault(s => s == subtask);
                SubtaskName.Text = subtaskInclude.Name;
                if (subtaskInclude.UserId != default)
                    Charge.Text = subtaskInclude.User.GetFIO();
                Description.Text = subtaskInclude.Description;
            }
        }

        private void Edit(object sender, RoutedEventArgs e) => MainWindow.Instance.OpenFrameInFrame(new Pages.Subtask.SaveSubtask(subtask));

        private void Delete(object sender, RoutedEventArgs e)
        {
            using (var context = new ApplicationContext())
            {
                var subtask = context.Subtasks.FirstOrDefault(s => s == this.subtask);
                if (subtask != null)
                    context.Subtasks.Remove(subtask);
                context.SaveChanges();
            }
            MainWindow.Instance.OpenPage(new Pages.CanbanSubtask.CanbanSubtask(MainWindow.OpenedTask));
        }

        private void OpenSubtask(object sender, MouseButtonEventArgs e) => MainWindow.Instance.OpenFrameInFrame(new Pages.Subtask.Subtask(subtask));
    }
}
