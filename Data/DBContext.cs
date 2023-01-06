using System;
using System.Collections.Generic;
using System.IO;
using ConsoleApplication1.Accounts;
using ConsoleApplication1.Games;
using ConsoleApplication1.TicTacToe;
using Newtonsoft.Json;

namespace ConsoleApplication1.Data
{
    [JsonObject]
    public class DBContext
    {
        
        [JsonRequired]
        private List<GameAccount> _gameAccounts { get; set; }
        
        [JsonRequired]
        private List<MatchInfo> _matchHistory { get; set; }

        public void SaveData(List<GameAccount> gameAccounts, List<MatchInfo> matchHistory)
        {
            _gameAccounts = gameAccounts;
            _matchHistory = matchHistory;
            var gameData = JsonConvert.SerializeObject(this, Formatting.Indented, 
                new JsonSerializerSettings
                {
                    TypeNameHandling = TypeNameHandling.Auto
                }
                );
            File.WriteAllText("gameData.json", gameData);
        }

        public void GetData(Controller gameController)
        {
            try
            {
                var gameData = File.ReadAllText("gameData.json");
                var objects = JsonConvert.DeserializeObject<DBContext>(gameData, new JsonSerializerSettings
                {
                    TypeNameHandling = TypeNameHandling.Auto
                });
                _gameAccounts = objects._gameAccounts;
                _matchHistory = objects._matchHistory;
                gameController._players = _gameAccounts;
                gameController._matches = _matchHistory;
            }
            catch (Exception)
            {
                gameController._players = new List<GameAccount>();
                gameController._matches = new List<MatchInfo>();
            }
        }
        
    }
}