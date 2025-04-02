using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace projectManagmentSystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window

    {
        public static MainWindow Instance;
        public static Task OpenedTask;
        public MainWindow()
        {
            InitializeComponent();
            Instance = this;
            OpenPage(new Pages.Canban.Canban());
            OpenFrameInFrame(new Pages.Subtask.SaveSubtask());
        }
        public void OpenPage(Page page)
        {
            MainWindow.Instance.Frame.Navigate(page);
        }

        private void OpenTasks(object sender, RoutedEventArgs e)
        {

        }

        private void OpenProjects(object sender, RoutedEventArgs e) => MainWindow.Instance.OpenPage(new Pages.Projects.ListProjects());

        private void OpenUsers(object sender, RoutedEventArgs e) => MainWindow.Instance.OpenPage(new Pages.Users.ListUsers());

        private void OpenMenu(object sender, RoutedEventArgs e)
        {
            if(Menu.Width == 200)
            {
                Menu.Width = 50;
                Frame.Margin = new Thickness(50,0,0,0);
                FrameInFrame.Margin = new Thickness(50, 0, 0, 0);
            }
            else
            {
                FrameInFrame.Margin = new Thickness(200, 0, 0, 0);
                Frame.Margin = new Thickness(200, 0, 0, 0);
                Menu.Width = 200;
            }
        }
        public void OpenFrameInFrame(Page page)
        {
            MainWindow.Instance.FrameInFrame.Navigate(page);
        }
    }
}