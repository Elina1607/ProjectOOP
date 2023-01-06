using System;
using System.Collections.Generic;
using ConsoleApplication1.Games;
using Newtonsoft.Json;

namespace ConsoleApplication1.Accounts
{
    [JsonObject]
    public class GameAccount
    {
        public string UserName { get; }

        [JsonRequired]
        private int _currentRating = 1;

        public int CurrentRating
        {
            get => _currentRating;
            set
            {
                _currentRating = value;
                if (_currentRating < 1) _currentRating = 1;
            }
        }

        public readonly List<Match> Matches = new List<Match>(); 

        public GameAccount(string userName)
        {
            UserName = userName;
        }
        
        public virtual void WinGame(Game game)
        {
            CurrentRating += CalculateRating(game.Rating);
            Matches.Add(new Match(Game.GameId, 
                game.Player1.UserName != UserName ? game.Player1.UserName : game.Player2.UserName,
                GameResult.Win, 
                CalculateRating(game.Rating),
                game.LastGame.P1 == this ? game.LastGame.P1Side : game.LastGame.P2Side,
                game.LastGame.GetField()));
        }
        public virtual void LoseGame(Game game)
        {
            CurrentRating -= game.Rating;
            Matches.Add(new Match(Game.GameId,
                game.Player1.UserName != UserName ? game.Player1.UserName : game.Player2.UserName,
                GameResult.Lose,game.Rating,
                game.LastGame.P1 == this ? game.LastGame.P1Side : game.LastGame.P2Side,
                game.LastGame.GetField()));
        }

        public void DrawGame(Game game)
        {
            Matches.Add(new Match(Game.GameId, 
                game.Player1.UserName != UserName ? game.Player1.UserName : game.Player2.UserName,
                GameResult.Draw,
                game.Rating,
                game.LastGame.P1 == this ? game.LastGame.P1Side : game.LastGame.P2Side,
                game.LastGame.GetField()));
        }
        protected virtual string GetAccountType()
        {
            return "Звичайний";
        }
        protected virtual int CalculateRating(int inputRating)
        {
            return inputRating;
        }
        public void PrintStats()
        {
            Console.WriteLine("==============================");
            Console.WriteLine("Акаунт гравця " + UserName);
            Console.Write("Рейтинг: " + _currentRating);
            Console.WriteLine(" Тип акаунту: " + GetAccountType());
            Console.WriteLine("===============================");
            foreach (var match in Matches)
            {
                match.PrintMatchInfo();
                Console.WriteLine("-------------------------------");
            }
        }

    }
}