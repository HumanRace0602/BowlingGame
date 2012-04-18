using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BowlingGame
{
    public class Game
    {
        private int[] rolls = new int[21];//用于记录每一次击中球的数目
        private int currentRoll = 0;//相当于指针，用于指示当前轮

        private bool IsSpare(int time)
        {
            return rolls[time] + rolls[time + 1] == 10;
        }


        private bool IsStrike(int time)
        {
            return rolls[time] == 10;
        }

        private int StrikeBonus(int time)
        {
            return 10 + rolls[time + 1] + rolls[time + 2];
        }

        private int SpareBonus(int time)
        {
            return 10 + rolls[time + 2];
        }

        private int SumOfBallsInFrame(int time)
        {
            return rolls[time] + rolls[time + 1];
        }

        public int Score()
        {
            int score = 0;
            int time = 0;
            for (int frame = 0; frame < 10; frame++)
            {
                if (IsStrike(time))
                {
                    score += StrikeBonus(time);
                    time++;
                }
                else if (IsSpare(time))
                {
                    score += SpareBonus(time);
                    time += 2;
                }
                else
                {
                    score += SumOfBallsInFrame(time);
                    time += 2;
                }
            }

            return score;
        }

        public void Roll(int pins)
        {
            rolls[currentRoll++] = pins;
        }
    }
}
