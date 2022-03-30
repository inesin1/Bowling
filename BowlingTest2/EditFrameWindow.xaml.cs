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
using System.Windows.Shapes;

namespace BowlingTest2
{
    /// <summary>
    /// Логика взаимодействия для EditFrameWindow.xaml
    /// </summary>
    public partial class EditFrameWindow : Window
    {
        PlayerPage context;

        public EditFrameWindow()
        {
            InitializeComponent();
        }

        public EditFrameWindow(PlayerPage context, Frame currentFrame) {
            InitializeComponent();

            this.context = context;
            EndFrame endFrame = currentFrame as EndFrame;
            if (endFrame == null)
                frameTextBox.Text = (currentFrame.index + 1).ToString();
            else
                frameTextBox.Text = 10.ToString();

            UpdateShots();

            if (shot1TextBox.Text == "" || shot2TextBox.Text == "" || shot3TextBox.Text == "")
                okButton.IsEnabled = false;
        }

        private void frameTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            int frame;
            try { frame = Convert.ToInt32(frameTextBox.Text); } catch { frameTextBox.Text = "1"; }
            UpdateShots();
        }

        private void shotTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            okButton.IsEnabled = true;

            if (shot1TextBox.Text == "" || shot2TextBox.Text == "")
                okButton.IsEnabled = false;

            if (shot3TextBox.Text == "")
                shot3TextBox.Text = "0";

            int shot = 0;
            int shot1 = 0;
            int shot2 = 0;

            //Символы
            try { shot = Convert.ToInt32(((TextBox)sender).Text); }
            catch {
                if (((TextBox)sender).Text == "")
                    okButton.IsEnabled = false;
                else {
                    //Spare
                    if (((TextBox)sender).Text == "/")
                    {
                        if (((TextBox)sender).Name == "shot2TextBox")
                            shot2TextBox.Text = (10 - shot1).ToString();
                        else
                            shot3TextBox.Text = (10 - shot2).ToString();
                    }
                    else
                    {
                        //Strike
                        if (((TextBox)sender).Text == "X")
                        {
                            shot1TextBox.Text = "10";
                            shot2TextBox.Text = "0";
                        }
                    }
                }
            }

            //Ограничение 0-10
            if (shot < 0) ((TextBox)sender).Text = "0";
            if (shot > 10) ((TextBox)sender).Text = "10";

            try
            {
                shot1 = Convert.ToInt32(shot1TextBox.Text);
                shot2 = Convert.ToInt32(shot2TextBox.Text);
            }
            catch { }

            //Макс очки
            if (shot1 + shot2 > 10) {
                if (((TextBox)sender).Name == "shot1TextBox")
                    shot1TextBox.Text = (10 - shot2).ToString();
                else
                    shot2TextBox.Text = (10 - shot1).ToString();
            }
        }

        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            int frameIndex = Convert.ToInt32(frameTextBox.Text) - 1;

            if (frameIndex < 9)
            {
                int shot1 = Convert.ToInt32(shot1TextBox.Text);
                int shot2 = Convert.ToInt32(shot2TextBox.Text);
                context.match.frames[frameIndex].SetShots(shot1, shot2);
            }
            else {
                int shot1 = Convert.ToInt32(shot1TextBox.Text);
                int shot2 = Convert.ToInt32(shot2TextBox.Text);
                int shot3 = Convert.ToInt32(shot3TextBox.Text);
                context.match.endFrame.SetShots(shot1, shot2);
                if (context.match.endFrame.CanEditShot3())
                    context.match.endFrame.SetShot3(shot3);
                else
                    context.match.endFrame.shot_3 = new Shot();
            }
            context.UpdateUI();

            Close();
        }

        private void UpdateShots() {
            int frameIndex = Convert.ToInt32(frameTextBox.Text) - 1;
            if (frameIndex < 0) frameIndex = 0;
            if (frameIndex > 9) frameIndex = 9;
            frameTextBox.Text = (frameIndex + 1).ToString();

            if (frameIndex < 9)
            {
                shot3TextBox.Visibility = Visibility.Collapsed;
                shot3TextBox.Visibility = Visibility.Collapsed;

                shot1TextBox.Text = context.match.frames[frameIndex].shot_1.Value;
                shot2TextBox.Text = context.match.frames[frameIndex].shot_2.Value;
            }
            else {
                shot3TextBox.Visibility = Visibility.Visible;
                shot3TextBox.Visibility = Visibility.Visible;

                shot1TextBox.Text = context.match.endFrame.shot_1.Value;
                shot2TextBox.Text = context.match.endFrame.shot_2.Value;
                shot3TextBox.Text = context.match.endFrame.shot_3.Value;
            }
        }
    }
}
