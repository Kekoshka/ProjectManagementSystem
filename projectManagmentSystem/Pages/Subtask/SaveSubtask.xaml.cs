using Microsoft.EntityFrameworkCore;
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

namespace projectManagmentSystem.Pages.Subtask
{
    /// <summary>
    /// Логика взаимодействия для SaveSubtask.xaml
    /// </summary>
    public partial class SaveSubtask : Page
    {
        Models.Subtask Subtask;
        List<Models.User> Users;
        public SaveSubtask( Models.Subtask subtask = null)
        {
            InitializeComponent();
            Subtask = subtask;
            if (subtask != null)
                LoadInterface();
        }



        private void SaveAndCloseFrame(object sender, MouseButtonEventArgs e)
        {
            using (var context = new ApplicationContext())
            {
                Models.Subtask subtask = new Models.Subtask();
                subtask.TaskId = MainWindow.OpenedTask.Id;
                subtask.Name = Name.Text;
                subtask.ProjectStatusId = context.ProjectStatuses.FirstOrDefault(ps => ps.ProjectId == MainWindow.OpenedProject.Id && ps.Name == "Новые").Id;
                subtask.Description = Description.Text;
                if (ResponsibleParent.SelectedValue is Models.User user)
                    subtask.UserId = user.Id;
                if (CommonValidator.Validate(subtask))


                    if (Subtask == null)
                        context.Subtasks.Add(subtask);
                    else
                    {
                        var subtaskEdit = context.Subtasks.FirstOrDefault(s => s == Subtask);
                        if (subtaskEdit != null)
                        {
                            subtaskEdit.Name = subtask.Name;
                            subtaskEdit.Description = subtask.Description;
                            subtaskEdit.UserId = subtask.UserId;
                        }
                    }
                context.SaveChanges();
            }
                MainWindow.Instance.OpenFrameInFrame(null);
            MainWindow.Instance.OpenPage(new Pages.CanbanSubtask.CanbanSubtask(MainWindow.OpenedTask));

        }
        void LoadInterface()
        {
            Name.Text = Subtask.Name;
            Description.Text = Subtask.Description;
            using (var context = new ApplicationContext())
            {
                Users = context.Tasks.Include(t => t.Users).FirstOrDefault(t => t == MainWindow.OpenedTask).Users.ToList();
                ResponsibleParent.ItemsSource = Users;
                if (Subtask.UserId != null)
                    ResponsibleParent.SelectedValue = Users.FirstOrDefault(u => u.Id == Subtask.UserId);
            }
        }
    }
}
