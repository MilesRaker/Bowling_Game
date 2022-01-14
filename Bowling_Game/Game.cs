using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Bowling_Game
{
    public class Game
    {

        //initialize score card as a jagged array
        public int[][] _scoreCard = new int[][]
        {
            new int[2],
            new int[2],
            new int[2],
            new int[2],
            new int[2],
            new int[2],
            new int[2],
            new int[2],
            new int[2],
            new int[3]
        };
        private int _frame = 0; //zero through 9
        private int _turn = 0; //can be zero, one, or two

        public void Roll(int pins)
        {
            
            _scoreCard[_frame][_turn] = pins; //write score into score card

            //move to next score's position
            if (_turn == 0 & pins != 10) //not strike
            {
                _turn++;
            }
            else if(_turn == 0 & pins == 10) //strike in frames 0-8
            {
                _scoreCard[_frame][1] = 0;
                _turn = 0;
                _frame++;
            }
            else if(_turn == 1 & _frame != 9) //second turn, frames 0-8
            {
                _turn = 0;
                _frame++;
            }
            else if(_frame == 9 & _turn < 2 ) //9th frame, no more moving to new frames
            {
                _turn++;
            }
            else
            {
                //do nothing
            }


            

        }

        public int Score()
        {
            int _score = 0;

            for (int frame = 0; frame < 9; frame++)
            {

                if (IsStrikeFrame(frame))
                {
                    _score += 10 + _scoreCard[frame+1][0] + _scoreCard[frame + 1][1];
                    
                }
                else if (IsSpareFrame(frame))
                {
                    _score += 10 + _scoreCard[frame + 1][0];
                }
                else
                {
                    _score += _scoreCard[frame][0] + _scoreCard[frame][1];
                }
            }


            //last frame scoring//
            if (_scoreCard[9][0] == _scoreCard[9][1] & _scoreCard[9][1] == _scoreCard[9][2] & _scoreCard[9][2] == 10)
            {
                _score += 10 + 10 + 10; //first strike scoring
                _score += 10 + 10; //second strike scoring
                _score += 10; //third strike scoring
            }
            else if (IsSpareFrame(9))
            {
                _score += 10 + _scoreCard[9][2]; //score for spare
                _score += _scoreCard[9][2]; //score for bonus frame
            }
            else
            {
                _score += _scoreCard[9][0] + _scoreCard[9][1];
            }
            return _score;
        }

        private bool IsStrikeFrame(int frame)
        {
            return _scoreCard[frame][0] == 10;
        }

        private bool IsSpareFrame(int frame)
        {
            if (IsStrikeFrame(frame))
            {
                return false;
            }
            return _scoreCard[frame][0] + _scoreCard[frame][1] == 10;
        }



    }
}
