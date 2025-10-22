using candy_project.Models.Candies;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace candy_project.Models
{
    public class Game
    {
        private Candy[,] _candies;
        private readonly int _boardSize;
        private readonly int _winScore;
        private readonly int _minutesTime;
        private int _currentScore;
        public int CurrentScore => _currentScore;
        public int BoardSize => _boardSize;
        public int GameSecondsTime => _minutesTime * 60;

        public Candy this[int row, int col]
        {
            get { return _candies[row, col]; }
        }

        Player _player;
        public Game(int size, int winScore, int minutesTime, Player player)
        {
            if (size <= 0)
                throw new ArgumentOutOfRangeException("coulde not set negative size");
            if (winScore <= 0)
                throw new ArgumentOutOfRangeException("coulde not set negative win score");
            if (minutesTime <= 0)
                throw new ArgumentOutOfRangeException("coulde not set negative minutes Time");

            _boardSize = size;
            _candies = new Candy[_boardSize, _boardSize];
            _winScore = winScore;
            _minutesTime = minutesTime;
            _player = player;
            _currentScore = 0;
        }

        private bool InvalidRange(int r, int c)
        {
            return r < 0 || r >= _boardSize || c < 0 || c >= _boardSize;
        }

        public void Swap(int r1, int c1, int r2, int c2)
        {
            if (InvalidRange(r1, c1) || InvalidRange(r2, c2))
                throw new ArgumentOutOfRangeException("Out of range.");

            var temp_candy = _candies[r1, c1];
            _candies[c1, r1] = _candies[r2, c2];
            _candies[r2, c2] = temp_candy;
        }
        public bool isWin()
        {
            return _currentScore >= _winScore;
        }

        public bool isLose(int sec_time)
        {
            return _minutesTime * 60 < sec_time;
        }
        private List<Candy> Candies
        {
            get
            {
                return new List<Candy>
                {
                    new RedCandy(),
                    new BlueCandy(),
                    new GreenCandy(),
                    new CyanCandy(),
                    new MagentaCandy(),
                    new WhiteCandy(),
                    new OrangeCandy(),
                    new GoldenCandy(),
                    new EvilCandy(),
                };
            }
        }

        private Candy RandomCandy
        {
            get
            {
                Thread.Sleep(1);
                return Candies[new Random().Next(Candies.Count)];
            }
        }


        public void GenerateCandies()
        {
            for (int i = 0; i < BoardSize; i++)
            {
                for (int j = 0; j < BoardSize; j++)
                {
                    _candies[i, j] = RandomCandy;
                }
            }
        }

        private List<Candy> GetKRandomCandies(int k)
        {
            var candies = new List<Candy>();
            for (int i = 0; i < k; i++)
            {
                candies.Add(RandomCandy);
            }

            return candies;
        }

        private bool isGoldenCandy(int i, int j)
        {
            return _candies[i, j] is GoldenCandy;
        }

        private void ChangeKRows(int i, int j, int candies_count)
        {
            var randomCandies = GetKRandomCandies(candies_count);
            if (candies_count == 7)
            {
                for (int k = 0; k < candies_count; k++)
                {
                    _candies[i, k] = randomCandies[k];
                }
            }
            else
            {
                for (int k = 0; k < candies_count; k++)
                {
                    _candies[i, j + k] = randomCandies[k];
                }
            }
            
        }

        private void ChangeKCols(int i, int j, int candies_count)
        {
            var randomCandies = GetKRandomCandies(candies_count);
            if(candies_count == 7)
            {
                for (int k = 0; k < candies_count; k++)
                {
                    _candies[k, j] = randomCandies[k];
                }
            }
            else
            {
                for (int k = 0; k < candies_count; k++)
                {
                    _candies[i + k, j] = randomCandies[k];
                }
            }
            
        }

        private void CheckAllRows()
        {
            for (int i = 0; i < BoardSize; i++)
            {
                for (int j = 0; j < BoardSize - 2; j++)
                {
                    if (_candies[i, j].isEqual(_candies[i, j + 1]) &&
                        _candies[i, j + 1].isEqual(_candies[i, j + 2]))
                    {
                        int candies_count = isGoldenCandy(i, j) ? _boardSize : 3;
                        ChangeKRows(i, j, candies_count);
                        _currentScore += _candies[i, j].Point() * candies_count;

                        i = 0;
                        continue;
                    }
                }
            }
        }

        private void CheckAllColumns()
        {
            for (int j = 0; j < BoardSize; j++)
            {
                for (int i = 0; i < BoardSize - 2; i++)
                {
                    if (_candies[i, j].isEqual(_candies[i + 1, j]) &&
                        _candies[i + 1, j].isEqual(_candies[i + 2, j]))
                    {
                        int candies_count = isGoldenCandy(i, j) ? _boardSize : 3;
                        ChangeKCols(i, j, candies_count);
                        _currentScore += _candies[i, j].Point() * candies_count;

                        i = 0;
                        continue;
                    }
                }
            }

        }
        public void CheckAllCandies()
        {
            CheckAllRows();
            CheckAllColumns();
        }
    }
}