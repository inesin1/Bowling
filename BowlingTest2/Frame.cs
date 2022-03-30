using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Windows.Media;

namespace BowlingTest2
{
    public class Frame
    {
        public Shot shot_1 = new Shot();
        public Shot shot_2 = new Shot();

        public int result;

        protected PlayerPage context;

        public int index; //Индекс фрейма

        public Frame(int index) {
            this.index = index;
        }

        public Frame() { }

        public virtual void SetShots(int _shot1, int _shot2) {
            ClearShots();

            //Strike
            if (_shot1 == 10) {
                shot_2 = new Shot("X");
                return;
            }

            shot_1 = new Shot(_shot1.ToString());
            shot_2 = new Shot(_shot2.ToString());

            //Spare
            if (_shot1 + _shot2 == 10) {
                shot_1 = new Shot(_shot1.ToString());
                shot_2 = new Shot("/");
                return;
            }

            //Нуль
            if (_shot1 == 0) shot_1 = new Shot("-");
            if (_shot2 == 0) shot_2 = new Shot("-");
        }

        protected void ClearShots() {
            shot_1 = new Shot();
            shot_2 = new Shot();
        }

        public virtual Grid CreateFrameUI(PlayerPage context) {
            Grid frame = new Grid();
            this.context = context;

            //Строки грида
            frame.RowDefinitions.Add(new RowDefinition());
            frame.RowDefinitions.Add(new RowDefinition());

            //Столбцы грида
            frame.ColumnDefinitions.Add(new ColumnDefinition());
            frame.ColumnDefinitions.Add(new ColumnDefinition());

            //Ячейки
            Border b_shot1 = CreateBorder(1);
            Border b_shot2 = CreateBorder(1);
            Border b_result = CreateBorder(2);

            //Кнопка
            Button frameButton = new Button();
            frameButton.MouseEnter += FrameButton_MouseEnter;
            frameButton.MouseLeave += FrameButton_MouseLeave;
            frameButton.Click += FrameButton_Click;
            frameButton.Opacity = 0;
            Grid.SetColumnSpan(frameButton, 2);
            Grid.SetRowSpan(frameButton, 2);

            //Добавляем в ячейки значения шотов
            ((IAddChild)b_shot1).AddChild(CreateTextBlock(shot_1.Value));
            ((IAddChild)b_shot2).AddChild(CreateTextBlock(shot_2.Value));
            ((IAddChild)b_result).AddChild(CreateTextBlock(result.ToString()));

            //Раскидываем по ячейкам
            Grid.SetColumn(b_shot2, 1);
            Grid.SetRow(b_result, 1);
            Grid.SetColumnSpan(b_result, 2);

            //Закидываем элементы в фрейм
            frame.Children.Add(b_shot1);
            frame.Children.Add(b_shot2);
            frame.Children.Add(b_result);
            frame.Children.Add(frameButton);

            return frame;
        }

        protected void FrameButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            new EditFrameWindow(context, this).ShowDialog();
        }

        protected void FrameButton_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            ((Button)sender).Opacity = 0;
        }

        protected void FrameButton_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            ((Button)sender).Opacity = 0.5;
        }

        public static Border CreateBorder(int colSpan) {
            Border b = new Border();

            b.Background = Brushes.WhiteSmoke;
            b.CornerRadius = new System.Windows.CornerRadius(3);
            b.BorderBrush = Brushes.Gray;
            b.BorderThickness = new System.Windows.Thickness(1);
            b.Margin = new System.Windows.Thickness(3);
            if (colSpan == 1) b.Width = 24;
            b.Height = 36;
            b.Padding = new System.Windows.Thickness(6);

            return b;
        }

        public static TextBlock CreateTextBlock(string text) {
            TextBlock tb = new TextBlock();

            tb.Text = text;

            return tb;
        }

        public bool isStrike() {
            return shot_2.Value.Equals("X");
        }

        public bool isSpare()
        {
            return shot_2.Value.Equals("/");
        }

        public int BowlsCount() {
            if (isStrike() || isSpare()) return 10;

            return shot_1.GetValue() + shot_2.GetValue();
        }
    }
}
