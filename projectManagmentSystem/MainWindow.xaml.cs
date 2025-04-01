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

        public MainWindow()
        {
            InitializeComponent();
            Instance = this;
            OpenPage(new Pages.Authorization());
        }
        public void OpenPage(Page page)
        {
            MainWindow.Instance.Frame.Navigate(page);
        }

        private void OpenTasks(object sender, RoutedEventArgs e)
        {

        }

        private void OpenProjects(object sender, RoutedEventArgs e)
        {

        }

        private void OpenUsers(object sender, RoutedEventArgs e)
        {

        }

        private void OpenMenu(object sender, RoutedEventArgs e)
        {
            if(Menu.Width == 200)
            {
                Menu.Width = 50;
                Frame.Margin = new Thickness(50,0,0,0);
            }
            else
            {
                Frame.Margin = new Thickness(200, 0, 0, 0);
                Menu.Width = 200;
            }
        }
    }
}