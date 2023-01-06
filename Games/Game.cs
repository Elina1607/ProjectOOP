using System;
using ConsoleApplication1.Accounts;
using ConsoleApplication1.TicTacToe;

namespace ConsoleApplication1.Games
{
    public abstract class Game
    {
        private int _rating;
        public TicTacToeGame LastGame;
        public int Rating
        {
            get => _rating;
            protected set
            {
                _rating = value;
                if (value < 0) throw new ArgumentOutOfRangeException(nameof(value));
            }
        }

        public static int GameId = 0;
        
        public readonly GameAccount Player1;
        public readonly GameAccount Player2;

        protected static readonly Random Rand = new Random();

        protected Game(GameAccount player1, GameAccount player2)
        {
            Player1 = player1;
            Player2 = player2;
        }
        
        public virtual void Play()
        {
            GameId++;
            if (LastGame.GetWinner() == Player1)
            {
                Player1.WinGame(this);
                Player2.LoseGame(this);
            }
            else if (LastGame.GetWinner() == Player2)
            {
                Player2.WinGame(this);
                Player1.LoseGame(this);
            }
            else
            {
                Player1.DrawGame(this);
                Player2.DrawGame(this);
            }
        }
        
    }
}