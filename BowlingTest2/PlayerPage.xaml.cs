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
    /// Логика взаимодействия для PlayerPage.xaml
    /// </summary>
    public partial class PlayerPage : Page
    {
        public Match match;

        public PlayerPage()
        {
            InitializeComponent();
        }

        public PlayerPage(string playerName, Match m) {
            InitializeComponent();

            match = m;
            nameTextBlock.Text = playerName;
            UpdateUI();
        }

        public void UpdateUI() {
            scorePanel.Children.Clear();
            match.CreateUI(this);
        }
    }
}
