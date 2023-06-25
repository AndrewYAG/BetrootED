using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Xml.Linq;

namespace DelegateHw
{
    public class Snake
    {
        private List<SnakeCell> _cells = new List<SnakeCell>();
        private bool _isDirectionUp;
        private bool _isDirectionDown;
        private bool _isDirectionLeft;
        private bool _isDirectionRight;
        public int Count { get { return _cells.Count; } }
        public int SnakeLength { get; set; }
        public System.Timers.Timer autoMoveTimer;

        public SnakeCell this[int index]
        {
            get { return _cells[index]; }
            set { _cells[index] = value; }
        }

        public Snake()
        {
            _cells.Add(new SnakeCell(5, 5));
            _cells.Add(new SnakeCell(6, 5));
            _cells.Add(new SnakeCell(7, 5));

            _isDirectionLeft = true;
            _isDirectionUp = false;
            _isDirectionDown = false;
            _isDirectionRight = false;

            SnakeLength = _cells.Count;
        }

        //public void AddCell(SnakeCell cell) => _cells.Add(cell);

        public void Move(ConsoleKey key, bool isAutoMoveType = false)
        {
            SnakeCell newCell = new SnakeCell(_cells[0]);
            bool wasMovedSuccessfully = false;

            if (!isAutoMoveType)
            {
                switch (key)
                {
                    case ConsoleKey.UpArrow:
                    case ConsoleKey.W:
                        if (!_isDirectionDown && !_isDirectionUp)
                        {
                            newCell.Y--;
                            _isDirectionLeft = false;
                            _isDirectionRight = false;
                            _isDirectionUp = true;
                            _isDirectionDown = false;

                            wasMovedSuccessfully = true;
                        }
                        break;

                    case ConsoleKey.DownArrow:
                    case ConsoleKey.S:
                        if (!_isDirectionUp && !_isDirectionDown)
                        {
                            newCell.Y++;
                            _isDirectionLeft = false;
                            _isDirectionRight = false;
                            _isDirectionUp = false;
                            _isDirectionDown = true;

                            wasMovedSuccessfully = true;
                        }
                        break;

                    case ConsoleKey.LeftArrow:
                    case ConsoleKey.A:
                        if (!_isDirectionRight && !_isDirectionLeft)
                        {
                            newCell.X--;
                            _isDirectionLeft = true;
                            _isDirectionRight = false;
                            _isDirectionUp = false;
                            _isDirectionDown = false;

                            wasMovedSuccessfully = true;
                        }
                        break;

                    case ConsoleKey.RightArrow:
                    case ConsoleKey.D:
                        if (!_isDirectionLeft && !_isDirectionRight)
                        {
                            newCell.X++;
                            _isDirectionLeft = false;
                            _isDirectionRight = true;
                            _isDirectionUp = false;
                            _isDirectionDown = false;

                            wasMovedSuccessfully = true;
                        }
                        break;

                    default:
                        throw new Exception("Wrong movement key.");
                }
            }
            else
            {
                switch (key)
                {
                    case ConsoleKey.UpArrow:
                    case ConsoleKey.W:
                            newCell.Y--;
                            wasMovedSuccessfully = true;
                        break;

                    case ConsoleKey.DownArrow:
                    case ConsoleKey.S:
                            newCell.Y++;
                            wasMovedSuccessfully = true;
                        break;

                    case ConsoleKey.LeftArrow:
                    case ConsoleKey.A:
                            newCell.X--;
                            wasMovedSuccessfully = true;
                        break;

                    case ConsoleKey.RightArrow:
                    case ConsoleKey.D:
                            newCell.X++;
                            wasMovedSuccessfully = true;
                        break;

                    default:
                        throw new Exception("Wrong movement key in AutoMove process.");
                }
            }
       
            if (wasMovedSuccessfully)
                _cells.Insert(0, newCell);

            if (_cells.Count > SnakeLength)
            {
                _cells.RemoveAt(_cells.Count - 1);
            }
        }

        public void FeedSnakeAndMakeLonger()
        {
            SnakeLength++;
        }

        public void AutoMoveInCurrentDirection(object? sender, ElapsedEventArgs e)
        {
            if (_isDirectionLeft)
                Move(ConsoleKey.LeftArrow, true);
            else if (_isDirectionDown)
                Move(ConsoleKey.DownArrow, true);
            else if (_isDirectionRight)
                Move(ConsoleKey.RightArrow, true);
            else if (_isDirectionUp)
                Move(ConsoleKey.UpArrow, true);
        }
    }
}
