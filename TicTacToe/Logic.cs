using System;

namespace ConsoleApplication1.TicTacToe
{
    public class Logic
    {
        public readonly int[] GameField = new int[9];
        public static readonly Random Random = new Random();
        public int GameTurn { get; private set; }

        public void StartGame()
        {
            for (int i = 0; i < 9; i++)
            {
                GameField[i] = 0;
            }
            GameTurn = Random.Next(1, 3);
        }
        
        public bool MoveX(int pos)
        {
            if (GameTurn != 1) return false;
            if (GameField[pos] != 0) return false;
            GameField[pos] = 1;
            GameTurn = 2;
            return true;
        } 
        
        public bool Move0(int pos)
        {
            if (GameTurn != 2) return false;
            if (GameField[pos] != 0) return false;
            GameField[pos] = 2;
            GameTurn = 1;
            return true;
        }

        public int CheckWinner()
        {
            for (int i = 0; i < 9; i+=3)
            {
                if (GameField[i] != 0 && GameField[i + 1] == GameField[i] && GameField[i + 2] == GameField[i]) return GameField[i];
            }
            for (int i = 0; i < 3; i++)
            {
                if (GameField[i] != 0 && GameField[i + 3] == GameField[i] && GameField[i + 6] == GameField[i]) return GameField[i];
            }
            if (GameField[0] != 0 && GameField[4] == GameField[0] && GameField[8] == GameField[0]) return GameField[0];
            if (GameField[6] != 0 && GameField[4] == GameField[6] && GameField[2] == GameField[6]) return GameField[6];
            return CheckDraw() ? 3 : 0;
        }

        private bool CheckDraw()
        {
            for (int i = 0; i < 9; i++)
            {
                if (GameField[i] == 0) return false;
            }
            return true;
        }
    }
}