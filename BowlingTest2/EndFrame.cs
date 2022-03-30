using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;

namespace BowlingTest2
{
    public class EndFrame : Frame
    {
        public Shot shot_3 = new Shot();

        public override void SetShots(int _shot1, int _shot2)
        {
            ClearShots();

            shot_1 = new Shot(_shot1.ToString());
            shot_2 = new Shot(_shot2.ToString());

            //Spare
            if (_shot1 + _shot2 == 10)
            {
                shot_1 = new Shot(_shot1.ToString());
                shot_2 = new Shot("/");
            }

            //Strike
            if (_shot1 == 10)
            {
                shot_1 = new Shot("X");
            }

            if (_shot2 == 10)
            {
                shot_2 = new Shot("X");
            }

            //Нуль
            if (_shot1 == 0) shot_1 = new Shot("-");
            if (_shot2 == 0) shot_2 = new Shot("-");
        }

        public void SetShot3(int _shot3) {
            //Strike
            if (_shot3 == 10) {
                shot_3 = new Shot("X");
                return;
            }

            shot_3 = new Shot(_shot3.ToString());

            if (_shot3 == 0) shot_3 = new Shot("-");
        }

        public bool CanEditShot3() {
            if (shot_1.Value == "X" || shot_2.Value == "X" || shot_2.Value == "/") return true;

            return false;
        }

        public override Grid CreateFrameUI(PlayerPage context)
        {
            Grid endFrame = new Grid();
            this.context = context;

            //Строки грида
            endFrame.RowDefinitions.Add(new RowDefinition());
            endFrame.RowDefinitions.Add(new RowDefinition());

            //Столбцы грида
            endFrame.ColumnDefinitions.Add(new ColumnDefinition());
            endFrame.ColumnDefinitions.Add(new ColumnDefinition());
            endFrame.ColumnDefinitions.Add(new ColumnDefinition());

            //Ячейки
            Border b_shot1 = CreateBorder(1);
            Border b_shot2 = CreateBorder(1);
            Border b_shot3 = CreateBorder(1);
            Border b_result = CreateBorder(2);

            //Кнопка
            Button frameButton = new Button();
            frameButton.MouseEnter += FrameButton_MouseEnter;
            frameButton.MouseLeave += FrameButton_MouseLeave;
            frameButton.Click += FrameButton_Click;
            frameButton.Opacity = 0;
            Grid.SetColumnSpan(frameButton, 3);
            Grid.SetRowSpan(frameButton, 2);

            //Добавляем в ячейки значения шотов
            ((IAddChild)b_shot1).AddChild(CreateTextBlock(shot_1.Value));
            ((IAddChild)b_shot2).AddChild(CreateTextBlock(shot_2.Value));
            ((IAddChild)b_shot3).AddChild(CreateTextBlock(shot_3.Value));
            ((IAddChild)b_result).AddChild(CreateTextBlock(result.ToString()));

            //Раскидываем по ячейкам
            Grid.SetColumn(b_shot2, 1);
            Grid.SetColumn(b_shot3, 2);
            Grid.SetRow(b_result, 1);
            Grid.SetColumnSpan(b_result, 3);

            //Закидываем элементы в фрейм
            endFrame.Children.Add(b_shot1);
            endFrame.Children.Add(b_shot2);
            endFrame.Children.Add(b_shot3);
            endFrame.Children.Add(b_result);
            endFrame.Children.Add(frameButton);

            return endFrame;
        }

        public new int BowlsCount() {
            int _shot1 = shot_1.GetValue();
            int _shot2;
            int _shot3;

            if (shot_2.Value == "/")
                _shot2 = 10 - _shot1;
            else
                _shot2 = shot_2.GetValue();

            if (shot_3.Value == "/")
                _shot3 = 10 - _shot2;
            else
                _shot3 = shot_3.GetValue();

            return _shot1 + _shot2 + _shot3;
        }
    }
}
