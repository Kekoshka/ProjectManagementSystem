using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using projectManagmentSystem.Common.DataValidation;
using projectManagmentSystem.Context;
using projectManagmentSystem.Models;
using projectManagmentSystem.Pages.Projects.Elements;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Color = System.Windows.Media.Color;

namespace projectManagmentSystem.Pages.Project
{
    /// <summary>
    /// Логика взаимодействия для SaveProject.xaml
    /// </summary>
    public partial class SaveProject : Page
    {
        List<Models.User> Users;
        List<Models.Participation> Participations;
        Models.Project Project;
        public SaveProject(Models.Project project = null)
        {
            InitializeComponent();
            Project = project;
            if (project == null)
            {
                LabelUsers.Visibility = Visibility.Hidden;
                UsersParent.Visibility = Visibility.Hidden;
            }
            else
            {
                LoadData();
                LoadInterface();
            }
        }

        private void AddUser(object sender, RoutedEventArgs e)
        {
            UsersParent.Children.Remove(UsersParent.Children[0]);
            ComboBox cbAddUser = new ComboBox();
            cbAddUser.ItemsSource = Users;
            cbAddUser.SelectionChanged += (sender, e) =>
                {
                    using (var context = new ApplicationContext())
                    {
                        context.Participations.Add(new Models.Participation
                        {
                            ProjectId = Project.Id,
                            UserId = ((Models.User)cbAddUser.SelectedValue).Id,
                            RoleId = 3
                        });
                        context.SaveChanges();
                    }
                    LoadInterface();
                };
            cbAddUser.DropDownOpened += (sender, e) =>
            {
                cbAddUser.ItemsSource = Users.Where(u => !Participations.Exists(p=> p.UserId == u.Id)).ToList();
            };
            UsersParent.Children.Insert(0,cbAddUser);
        }
        void LoadData()
        {
            using (var context = new ApplicationContext())
            {
                Users = context.Users.ToList();
                Participations = context.Participations.Where(p => p.ProjectId == Project.Id).ToList();
            }
        }
        void LoadInterface()
        {
            using (var context = new ApplicationContext())
            {
                Button btn = new Button();
                btn.Content = "+ Добавить участника";
                btn.Foreground = new SolidColorBrush(Color.FromRgb(39, 82, 236));
                btn.FontWeight = FontWeights.Medium; 
                btn.HorizontalAlignment = HorizontalAlignment.Left;
                btn.Background = new SolidColorBrush(Colors.Transparent);
                btn.BorderThickness = new Thickness(0);
                btn.FontSize = 14;
                btn.Click += AddUser;

                var participationsInclude = context.Participations.Include(p=> p.User).Include(p => p.Project).Include(p => p.Role).Where(p => p.ProjectId == Project.Id);
                Name.Text = Project.Name;
                Description.Text = Project.Description;
                Private.SelectedIndex = Convert.ToInt32(Project.Private);
                UsersParent.Children.Clear();
                UsersParent.Children.Add(btn);
                foreach (var participation in participationsInclude)
                    UsersParent.Children.Add(new Elements.UserEdit(participation));
            }
        }

        private void SaveAndCloseFrame()
        {
            Models.Project project = new Models.Project();
            if (Private.SelectedIndex == 0)
                project.Private = false;
            else
                project.Private = true;
            project.Name = Name.Text;
            project.Description = Description.Text;
            if (CommonValidator.Validate(project))
                using (var context = new ApplicationContext())
                {
                    if (Project == null)
                    {

                        context.Projects.Add(project);
                        context.SaveChanges();
                        context.Participations.Add(new Participation
                        {
                            ProjectId = project.Id,
                            UserId = MainWindow.CurrentUser.Id,
                            RoleId = 1
                        });
                        List<ProjectStatus> statuses = new List<ProjectStatus>
                        {
                            new ProjectStatus{Name = "Новые",ProjectId = project.Id},
                            new ProjectStatus{Name = "В процессе",ProjectId = project.Id},
                            new ProjectStatus{Name = "Можно проверять",ProjectId = project.Id},
                            new ProjectStatus{Name = "Готово",ProjectId = project.Id}
                        };
                        context.ProjectStatuses.AddRange(statuses);
                    }
                    else
                    {
                        var editProject = context.Projects.FirstOrDefault(p => p == Project);
                        if (editProject != null)
                        {
                            editProject.Name = project.Name;
                            editProject.Description = project.Description;
                            editProject.Private = project.Private;
                        }
                    }
                    context.SaveChanges();
                }
            MainWindow.Instance.FrameInFrame.Content = null;
            MainWindow.Instance.OpenPage(new Pages.Project.ListProjects());
        }
        private void SaveAndCloseFrame(object sender, MouseButtonEventArgs e) => SaveAndCloseFrame();
        private void SaveAndCloseFrame(object sender, RoutedEventArgs e) => SaveAndCloseFrame();
    }
}
