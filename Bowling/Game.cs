using System.Collections.Generic;

namespace Bowling
{
    public class Game
    {
        private int _scoreValue = 0;
        private readonly List<int> _rolls = new List<int>();

        #region Public Methods
        //List maitaining Scores of all played rolls..
        public void Roll(int pins)
        {
            _rolls.Add(pins);
        }

        public int GetScore()
        {
            int FrameIndex = 0;
            for (int Frame = 0; Frame < 10; Frame++)
            {
                if (_rolls.Count - 2 == FrameIndex && _rolls[FrameIndex - 1] == 10 && _rolls[FrameIndex] != 10)
                    break;
                else if (FrameIndex % 2 == 0 && _rolls.Count - 1 == FrameIndex && _rolls[FrameIndex] == 10)
                {
                    _scoreValue = _scoreValue + _rolls[FrameIndex];
                    Roll(10);
                    _scoreValue += _rolls[_rolls.Count - 1];
                    Roll(10);
                    _scoreValue += _rolls[_rolls.Count - 1];
                    break;
                }
                else if (FrameIndex % 2 == 0 && _rolls.Count - 2 == FrameIndex && _rolls[FrameIndex] == 10)
                {
                    Roll(10);
                    Roll(10);
                }
                else if (FrameIndex % 2 == 0 && _rolls.Count - 1 == FrameIndex && _rolls[FrameIndex - 1] == 10)
                {
                    _scoreValue = _scoreValue + _rolls[FrameIndex];
                    Roll(1);
                    _scoreValue += _rolls[_rolls.Count - 1];
                    break;
                }
                else if (FrameIndex % 2 != 0 && _rolls.Count - 1 == FrameIndex && _rolls[FrameIndex - 1] == 10)
                {
                    _scoreValue += _scoreValue + _rolls[FrameIndex];
                    Roll(1);
                    _scoreValue += _rolls[_rolls.Count - 1];
                    break;
                }
                else if (FrameIndex + 1 == _rolls.Count || FrameIndex == _rolls.Count)
                    break;

                //If strike then get next 2 roll's points as bonus...
                if (IsStrike(FrameIndex))
                {
                    _scoreValue += StrikeScore(FrameIndex);
                    FrameIndex++;
                }
                else
                {
                    //If Spare then get next frame's first roll's points as bonus...
                    if (IsSpare(FrameIndex))
                    {
                        _scoreValue += SpareScore(FrameIndex);
                    }
                    else
                    {
                        _scoreValue += FrameScore(FrameIndex);
                    }
                    FrameIndex += 2;
                }
            }
            return _scoreValue;
        }
        #endregion



        #region Private Methods
        //Check whether Strike...
        private bool IsStrike(int frameIndex) => _rolls[frameIndex] == 10;

        //Calculate Frame score...
        private int FrameScore(int frameIndex) => _rolls[frameIndex] + _rolls[frameIndex + 1];

        //If strike then get next 2 roll's points as bonus...
        private int StrikeScore(int frameIndex) => 10 + _rolls[frameIndex + 1] + _rolls[frameIndex + 2];

        //If Spare then get next frame's first roll's points as bonus...
        private int SpareScore(int frameIndex) => 10 + _rolls[frameIndex + 2];

        //Check whether Spare...
        private bool IsSpare(int frameIndex) => (_rolls[frameIndex] + _rolls[frameIndex + 1]) == 10;
        #endregion
    }
}
