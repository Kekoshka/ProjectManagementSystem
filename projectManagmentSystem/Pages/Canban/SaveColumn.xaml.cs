using projectManagmentSystem.Common.DataValidation;
using projectManagmentSystem.Context;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace projectManagmentSystem.Pages.Canban
{
    /// <summary>
    /// Логика взаимодействия для SaveColumn.xaml
    /// </summary>
    public partial class SaveColumn : Page
    {
        Models.ProjectStatus ProjectStatus;
        public SaveColumn(Models.ProjectStatus projectStatus = null)
        {
            InitializeComponent();
            ProjectStatus = projectStatus;
            if(projectStatus!= null)
                Name.Text = projectStatus.Name;
        }

        private void SaveAndCloseFrame(object sender, RoutedEventArgs e) => SaveAndCloseFrame();

        private void SaveAndCloseFrame(object sender, MouseButtonEventArgs e) => SaveAndCloseFrame();
        private void SaveAndCloseFrame()
        {
            Models.ProjectStatus ps = new Models.ProjectStatus();
            ps.Name = Name.Text;
            ps.ProjectId = MainWindow.OpenedProject.Id;
            if (CommonValidator.Validate(ps))
                using (var context = new ApplicationContext())
                {
                    if (ProjectStatus == null)
                        context.ProjectStatuses.Add(ps);
                    else
                    {
                        var psEdit = context.ProjectStatuses.FirstOrDefault(ps => ps == ProjectStatus);
                        if (psEdit != null)
                            psEdit.Name = ps.Name;
                    }
                    context.SaveChanges();
                }
            MainWindow.Instance.OpenFrameInFrame(null);
            if (MainWindow.OpenedProject != null)
                MainWindow.Instance.OpenPage(new Pages.Canban.Canban(MainWindow.OpenedProject));
        }
    }
}
