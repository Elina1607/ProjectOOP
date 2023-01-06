using System;
using System.Collections.Generic;
using ConsoleApplication1.Accounts;

namespace ConsoleApplication1.TicTacToe
{
    public class Bot
    {
        private TicTacToeGame _game;
        private static Random _random = new Random();
        public int Side { get; set; }
        public Bot(TicTacToeGame game)
        {
            _game = game;
        }

        public int MakeMove()
        {
            if (CheckForWin() > -1) return CheckForWin();
            return CheckCorners() > -1 ? CheckCorners() : RandomMove();
        }

        private int CheckForWin()
        {
            var gameField = _game.GetField();
            int[] line;
            int count, pos, res = -1;
            for (int i = 0; i < 9; i+=3)
            {
                line = new [] {gameField[i],gameField[i+1],gameField[i+2]};
                count = 0;
                pos = 0;
                for(int j = 0; j < line.Length; j++)
                {
                    if (line[j] == Side) count++;
                    else if (line[j] != 0) count--;
                    else pos = i + j;
                }
                if (count == 2) return pos;
                if (count == -2) res = pos;
            }
            for (int i = 0; i < 3; i++)
            {
                line = new [] {gameField[i],gameField[i+3],gameField[i+6]};
                count = 0;
                pos = 0;
                for(int j = 0; j < line.Length; j++)
                {
                    if (line[j] == Side) count++;
                    else if (line[j] != 0) count--;
                    else pos = i + j * 3;
                }
                if (count == 2) return pos;
                if (count == -2) res = pos;
            }
            line = new [] {gameField[0],gameField[4],gameField[8]};
            count = 0;
            pos = 0;
            for(int j = 0; j < line.Length; j++)
            {
                if (line[j] == Side) count++;
                else if (line[j] != 0) count--;
                else pos = j * 4;
            }
            if (count == 2) return pos;
            if (count == -2) res = pos;
            line = new [] {gameField[2],gameField[4],gameField[6]};
            count = 0;
            pos = 0;
            for(int j = 0; j < line.Length; j++)
            {
                if (line[j] == Side) count++;
                else if (line[j] != 0) count--;
                else pos = j * 2 + 2;
            }
            if (count == 2) return pos;
            if (count == -2) res = pos;
            return res > -1 ? res : -1;
        }
        
        private int CheckCorners()
        {
            var game = _game.GetField();
            for (int i = 0; i <= 6; i+=6)
            {
                for (int j = 0; j <= 2; j+=2)
                {
                    if (game[i + j] == 0) return i + j;
                }
            }
            return game[4] == 0 ? 4 : -1;
        }

        private int RandomMove()
        {
            var game = _game.GetField();
            var emptyList = new List<int>();
            for (int i = 0; i < game.Length; i++)
            {
                if(game[i] == 0) emptyList.Add(i);
            }
            return emptyList[_random.Next(0, emptyList.Count)];
        }
    }
}