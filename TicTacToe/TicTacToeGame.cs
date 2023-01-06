using System;
using System.Threading;
using ConsoleApplication1.Accounts;

namespace ConsoleApplication1.TicTacToe
{
    public class TicTacToeGame
    {
        public GameAccount P1,P2;
        public int P1Side, P2Side, WinSide;
        private readonly Logic _logic = new Logic();

        public TicTacToeGame PlayGame(GameAccount p1, GameAccount p2)
        {
            P1 = p1;
            P2 = p2;
            _logic.StartGame();
            ChooseSides();
            while (_logic.CheckWinner() == 0)
            {
                Painter.DrawGrid(_logic.GameField);
                var turn = _logic.GameTurn;
                if(turn == 1) Console.WriteLine("Ходить - X");
                else if(turn == 2) Console.WriteLine("Ходить - 0");
                int pos;
                try
                {
                    pos = int.Parse(Console.ReadLine() ?? string.Empty) - 1;
                    if (pos < 0 || pos > 8)
                    {
                        Console.WriteLine("Неможливий хiд, введiть число вiд 1 до 9");
                        continue;
                    }
                }
                catch (Exception)
                {
                    continue;
                }
                if (turn == 1)
                {
                    if(!_logic.MoveX(pos))
                        Console.WriteLine("Неможливий хiд");
                }
                else if (turn == 2)
                {
                    if(!_logic.Move0(pos))
                        Console.WriteLine("Неможливий хiд");
                }
            }
            Painter.DrawGrid(_logic.GameField);
            WinSide = _logic.CheckWinner();
            if (WinSide != 0)
            {
                Console.WriteLine(P1Side == WinSide ? "Виграв гравець " + P1.UserName : 
                    P2Side == WinSide ? "Виграв гравець " + P2.UserName : "Нiчия!");
            }
            return this;
        }

        public TicTacToeGame PlaySoloGame(GameAccount p1,GameAccount p2)
        {
            var bot = new Bot(this);
            P1 = p1;
            P2 = p2;
            _logic.StartGame();
            ChooseSides();
            bot.Side = P2Side;
            while (_logic.CheckWinner() == 0)
            {
                Painter.DrawGrid(_logic.GameField);
                var turn = _logic.GameTurn;
                Console.WriteLine("Введiть позицiю на сiтцi (1-9)");
                if(turn == 1) Console.WriteLine("Ходить - X");
                else if(turn == 2) Console.WriteLine("Ходить - 0");
                int pos;
                if (P2Side == turn)
                {
                    pos = bot.MakeMove();
                    Console.WriteLine(pos);
                    Thread.Sleep(1000);
                }
                else
                {
                    try
                    {
                        pos = int.Parse(Console.ReadLine() ?? string.Empty) - 1;
                        if (pos < 0 || pos > 8)
                        {
                            Console.WriteLine("Введена позицiя не вiрна");
                            continue;
                        }
                    }
                    catch (Exception)
                    {
                        continue;
                    }
                }
                if (turn == 1)
                {
                    if(!_logic.MoveX(pos))
                        Console.WriteLine("Неможливий хiд");
                }
                else if (turn == 2)
                {
                    if(!_logic.Move0(pos))
                        Console.WriteLine("Неможливий хiд");
                }
            }
            Painter.DrawGrid(_logic.GameField);
            WinSide = _logic.CheckWinner();
            if (WinSide != 0)
            {
                Console.WriteLine(P1Side == WinSide ? "Виграв гравець " + P1.UserName : 
                    P2Side == WinSide ? "Виграв гравець " + P2.UserName : "Нiчия!");
            }
            return this;
        }

        private void ChooseSides()
        {
            if (Logic.Random.Next(1, 3) == 2)
            {
                P1Side = _logic.GameTurn;
                P2Side = _logic.GameTurn == 1 ? 2 : 1;
            }
            else
            {
                P2Side = _logic.GameTurn;
                P1Side = _logic.GameTurn == 1 ? 2 : 1;
            }
            Console.WriteLine("Першим ходить гравець " + (P1Side == _logic.GameTurn ? 
            P1.UserName + " - " + Painter.GetString(P1Side) : P2.UserName + " - " +  Painter.GetString(P2Side)));
        }

        public GameAccount GetWinner()
        {
            return WinSide == P1Side ? P1 : WinSide == P2Side ? P2 : null;
        }

        public int[] GetField()
        {
            return _logic.GameField;
        }
    }
}