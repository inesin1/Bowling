using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Markup;

namespace BowlingTest2
{
    public class Match
    {
        public List<Frame> frames = new List<Frame>(9); //Фреймы
        public EndFrame endFrame = new EndFrame(); //Последний фрейм
        public int matchResult; //Результат матча

        public Match() {
            for (int i = 0; i < 9; i++)
                frames.Add(new Frame(i));
        }

        public void CreateUI(PlayerPage context) {
            CalculateResults();

            for (int i = 0; i < frames.Count; i++)
                context.scorePanel.Children.Add(frames[i].CreateFrameUI(context));

            context.scorePanel.Children.Add(endFrame.CreateFrameUI(context));

            //Результат
            CalculateMatchResult();
            Border b = Frame.CreateBorder(1);
            b.Width = 48;
            TextBlock tb = Frame.CreateTextBlock(matchResult.ToString());
            ((IAddChild)b).AddChild(tb);

            context.scorePanel.Children.Add(b);
        }

        public void CalculateResults() {
            Frame curFrame;
            Frame nextFrame;
            Frame prevFrame;

            for (int i = 0; i < frames.Count; i++) {
                curFrame = frames[i];
                if (i != 0) prevFrame = frames[i - 1]; else prevFrame = null;
                if (i < frames.Count - 1) nextFrame = frames[i + 1]; else nextFrame = null;

                if (curFrame.shot_2.Value == "") continue;

                curFrame.result = curFrame.BowlsCount();
                if (prevFrame != null) curFrame.result += prevFrame.result;

                //Strike
                if (curFrame.isStrike()) {
                    if (nextFrame != null) curFrame.result += nextFrame.BowlsCount();
                    continue;
                }

                //Spare
                if (curFrame.isSpare()) {
                    if (nextFrame != null) curFrame.result += nextFrame.shot_1.GetValue();
                    continue;
                }
            }

            curFrame = frames[frames.Count - 1];
            if (endFrame.shot_1.Value == "") return;
            endFrame.result = 0;
            endFrame.result += curFrame.BowlsCount() + endFrame.BowlsCount();
        }

        public void CalculateMatchResult() {
            foreach (Frame f in frames) {
                if (f.result != 0) matchResult = f.result;
            }
            if (endFrame.result != 0) matchResult = endFrame.result;
        }
    }
}
