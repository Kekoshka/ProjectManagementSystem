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

namespace projectManagmentSystem.Pages.Task
{
    /// <summary>
    /// Логика взаимодействия для SaveTask.xaml
    /// </summary>
    public partial class SaveTask : Page
    {
        Models.Task Task;
        public SaveTask(Models.Task task = null)
        {
            InitializeComponent();
            this.Task = task;
            if (task == null)
            {
                LabelResponsibles.Visibility = Visibility.Hidden;
                LabelSubtasks.Visibility = Visibility.Hidden;
                ResponsiblesParent.Visibility = Visibility.Hidden;
                SubtasksParent.Visibility = Visibility.Hidden;
            }
            else
            {
                LoadInterface();
            }
        }

        private void AddSubtask(object sender, RoutedEventArgs e)
        {
            MainWindow.Task = this;
            MainWindow.Instance.OpenFrameInFrame(new Pages.Subtask.SaveSubtask());
        }

        private void AddUser(object sender, RoutedEventArgs e)
        {
            ResponsiblesParent.Children.Remove(ResponsiblesParent.Children[0]);
            ComboBox cbAddUser = new ComboBox();
            cbAddUser.SelectionChanged += (sender, e) =>
            {
                using (var context = new ApplicationContext())
                {
                    var user = context.Users.FirstOrDefault(u => u.Id == ((Models.User)cbAddUser.SelectedValue).Id);
                    context.Tasks.Include(t => t.Users).FirstOrDefault(t => t == Task).Users.Add(user);
                    context.SaveChanges();
                }
                LoadInterface();
            };
            cbAddUser.DropDownOpened += (sender, e) =>
            {
                using (var context = new ApplicationContext())
                {
                    var projectUsers = context.Tasks.Include(t => t.Project).ThenInclude(t => t.Participations).ThenInclude(p => p.User)
                                                    .FirstOrDefault(t => t == Task).Project.Participations
                                                    .Select(p => p.User).ToList();
                    var taskUsers = context.Tasks.Include(t => t.Users).FirstOrDefault(t => t == Task).Users.ToList();
                    var users = projectUsers.Where(pu => !taskUsers.Exists(tu => tu == pu)).ToList();
                    cbAddUser.ItemsSource = users;

                }
            };
            ResponsiblesParent.Children.Insert(0, cbAddUser);
        }

        private void SaveAndCloseFrame(object sender, MouseButtonEventArgs e)
        {
            using (var context = new ApplicationContext())
            {
                Models.Task task = new Models.Task();
                task.ProjectStatusId = context.ProjectStatuses.FirstOrDefault(ps => ps.ProjectId == MainWindow.OpenedProject.Id && ps.Name == "Новые").Id;
                task.ProjectId = MainWindow.OpenedProject.Id;
                task.Name = Name.Text;
                task.Description = Description.Text;
                if (CommonValidator.Validate(task))

                    if (Task == null)
                        context.Tasks.Add(task);
                    else
                    {
                        var taskEdit = context.Tasks.FirstOrDefault(t => t == Task);
                        if (taskEdit != null)
                        {
                            taskEdit.Name = task.Name;
                            taskEdit.Description = task.Description;
                        }
                    }
                context.SaveChanges();
            }
            MainWindow.Instance.OpenFrameInFrame(null);
            MainWindow.Instance.OpenPage(new Pages.Canban.Canban(MainWindow.OpenedProject));
        }
        private void LoadInterface()
        {
            Name.Text = Task.Name;
            Description.Text = Task.Description;
            using (var context = new ApplicationContext())
            {
                var users = context.Tasks.Include(t => t.Users).FirstOrDefault(t => t == Task).Users.ToList();
                if (users != null)
                    foreach (var user in users)
                        ResponsiblesParent.Children.Add(new Elements.User(user));
                var subtasks = context.Tasks.Include(t => t.Subtasks).FirstOrDefault(t => t == Task).Subtasks.ToList();
                if (subtasks != null)
                    foreach (var subtask in subtasks)
                        SubtasksParent.Children.Add(new Elements.Subtask( subtask));
            }
        }

    }
}
