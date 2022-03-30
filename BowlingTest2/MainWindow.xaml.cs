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

namespace BowlingTest2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void NewPlayerButton_Click(object sender, RoutedEventArgs e)
        {
            CreatePlayerWindow cpw = new CreatePlayerWindow();
            cpw.ShowDialog();

            Match m = new Match();
            PlayerPage playerPage = new PlayerPage(cpw.PlayerName, m);

            System.Windows.Controls.Frame frame = new System.Windows.Controls.Frame();
            frame.Content = playerPage;

            playersPanel.Children.Add(frame);
        }
    }
}
