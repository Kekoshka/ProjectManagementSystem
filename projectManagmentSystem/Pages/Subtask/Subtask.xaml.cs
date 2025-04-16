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

namespace projectManagmentSystem.Pages.Subtask
{
    /// <summary>
    /// Логика взаимодействия для Subtask.xaml
    /// </summary>
    public partial class Subtask : Page
    {
        Models.Subtask subtask;
        public Subtask(Models.Subtask subtask)
        {
            InitializeComponent();
            this.subtask = subtask;
            if (subtask != null);
            LoadInterface();

        }
        private void CloseFrame(object sender, MouseButtonEventArgs e)
        {
            MainWindow.Instance.OpenFrameInFrame(null);
        }
        void LoadInterface()
        {
            Name.Text = subtask.Name;
            Description.Text = subtask.Description;
            using (var context = new ApplicationContext())
            {
                var user = context.Subtasks.Include(s => s.User).FirstOrDefault(s => s.Id == subtask.Id).User;
                ResponsibleParent.Children.Add(new Elements.User(user));
            }
        }
    }
}
