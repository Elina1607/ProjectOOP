using System;
using Newtonsoft.Json;

namespace ConsoleApplication1.TicTacToe
{
    [JsonObject]
    public class MatchInfo
    {
        [JsonRequired]
        private readonly string _player1Name,_player2Name,_winnerName;
        [JsonRequired]
        private readonly int _rating;

        [JsonConstructor]
        public MatchInfo(string player1Name, string player2Name, int rating, string winnerName)
        {
            _player1Name = player1Name;
            _player2Name = player2Name;
            _rating = rating;
            _winnerName = winnerName;
        }

        public void PrintInfo()
        {
            Console.WriteLine(_player1Name + " проти " + _player2Name + " рейтинг: " + _rating +
                              (_winnerName == "" ? " Нiчия" : " Переможець: " + _winnerName));
        }
    }
}