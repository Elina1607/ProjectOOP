using System;
using ConsoleApplication1.TicTacToe;
using Newtonsoft.Json;

namespace ConsoleApplication1.Games
{
    [JsonObject]
    public class Match
    {
        [JsonRequired]
        private readonly int _gameId;
        [JsonRequired]
        private readonly string _opponentName;
        [JsonRequired]
        private readonly GameResult _result;
        [JsonRequired]
        private readonly int _rating;
        [JsonRequired]
        private readonly int _side;
        [JsonRequired]
        private readonly int[] _gameField;

        public Match(int gameId,string opponentName,GameResult result,int rating,int side, int[] gameField)
        {
            _gameId = gameId;
            _opponentName = opponentName;
            _result = result;
            _rating = rating;
            _side = side;
            _gameField = gameField;
        }

        public void PrintMatchInfo()
        {
            Console.Write("ID гри: (" + _gameId + ") Противник: " + _opponentName + "\nРейтинг: " + _rating);
            Console.WriteLine(_result == GameResult.Win ? " Виграв" : _result == GameResult.Lose ? " Програв" : " Нічия");
            Console.WriteLine("Сторона: " + Painter.GetString(_side));
            Console.WriteLine("Результат гри: ");
            Painter.DrawGrid(_gameField);
        }
    }
}