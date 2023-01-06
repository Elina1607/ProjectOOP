using System;
using System.Collections.Generic;
using ConsoleApplication1.Accounts;
using ConsoleApplication1.Controllers;
using ConsoleApplication1.Data;
using ConsoleApplication1.Games;
using ConsoleApplication1.TicTacToe;

namespace ConsoleApplication1
{
    public class Controller
    {
        public List<GameAccount> _players = new List<GameAccount>();
        public List<MatchInfo> _matches = new List<MatchInfo>();

        public void Start()
        {
            GetData();
            while (true)
            {
                SaveData();
                Painter.PrintMenu("Почати гру","Створити новий акаунт",
                    "Переглянути список акаунтiв","Переглянути iсторiю iгор",
                    "Переглянути iнформацiю про акаунт","Вийти з програми");
                var command = Console.ReadLine().Trim();
                switch (command.Trim())
                {
                    case "1" :
                        if (_players.Count == 0)
                        {
                            Console.WriteLine("Не створено жодного акаунту, почати гру неможливо");
                            continue;
                        }
                        while (true)
                        {
                            SaveData();
                            Painter.PrintMenu("Почату рейтингову гру 1х1", "Почати гру без рейтингу 1х1", 
                                "Почати рейтингову гру проти бота", "Почати гру без рейтингу проти бота",
                                "Повернутися назад");
                            var gameType = Console.ReadLine().Trim();
                            string player1;
                            string player2;
                            Game game = null;
                            switch (gameType)
                            {
                                case "1":
                                    if (_players.Count < 2)
                                    {
                                        Console.WriteLine("Неможливо почати гру, оскiльки iснує лише один акаунт");
                                        continue;
                                    }
                                    Console.WriteLine("Введiть iм'я першого гравця");
                                    player1 = Console.ReadLine().Trim();
                                    Console.WriteLine("Введiть iм'я другого гравця");
                                    player2 = Console.ReadLine().Trim();
                                    if (GetPlayer(player1) != null && GetPlayer(player2) != null)
                                    {
                                        game = GameController.StartRatedGame(GetPlayer(player1), GetPlayer(player2));
                                    } else
                                        Console.WriteLine("Введенний гравець не iснує");
                                    break;
                                case "2":
                                    if (_players.Count < 2)
                                    {
                                        Console.WriteLine("Неможливо почати гру, оскiльки iснує лише один акаунт");
                                        continue;
                                    }
                                    Console.WriteLine("Введiть iм'я першого гравця");
                                    player1 = Console.ReadLine().Trim();
                                    Console.WriteLine("Введiть iм'я другого гравця");
                                    player2 = Console.ReadLine().Trim();
                                    if (GetPlayer(player1) != null && GetPlayer(player2) != null)
                                    {
                                        game = GameController.StartUnRatedGame(GetPlayer(player1), GetPlayer(player2));
                                    } else
                                        Console.WriteLine("Введенний гравець не iснує");
                                    break;
                                case "3":
                                    Console.WriteLine("Введiть iм'я гравця");
                                    player1 = Console.ReadLine().Trim();
                                    if (GetPlayer(player1) != null)
                                    {
                                        game = GameController.StartSoloRatedGame(GetPlayer(player1));
                                    } else
                                        Console.WriteLine("Введенний гравець не iснує");
                                    break;
                                case "4":
                                    Console.WriteLine("Введiть iм'я гравця");
                                    player1 = Console.ReadLine().Trim();
                                    if (GetPlayer(player1) != null)
                                    {
                                        game = GameController.StartSoloUnRatedGame(GetPlayer(player1));
                                    } else
                                        Console.WriteLine("Введенний гравець не iснує");
                                    break;
                                default: if(gameType != "5") 
                                    Console.WriteLine("Введено неправильний тип гри"); 
                                    break;
                            }
                            if(gameType == "5") break;
                            if(game != null) {
                                _matches.Add(new MatchInfo(game.LastGame.P1.UserName,
                                game.LastGame.P2.UserName,game.Rating,
                                game.LastGame.GetWinner() == null ? "" : game.LastGame.GetWinner().UserName));
                                break;
                            }
                        }
                        break;
                    case "2" :
                        Console.WriteLine("Введiть iм'я користувача");
                        var userName = Console.ReadLine().Trim();
                        if (GetPlayer(userName) != null)
                        {
                            Console.WriteLine("Користувач з таким iменем вже iснує");
                            break;
                        }
                        while (true)
                        {
                            SaveData();
                            Painter.PrintMenu("Звичайний акаунт","ВIП-Акаунт","Премiум акаунт","Повернутися назад");
                            Console.WriteLine("Введiть тип акаунту користувача");
                            int accountType = 1;
                            int.TryParse(Console.ReadLine(),out accountType);
                            if(accountType == 4) break;
                            if(CreatePlayer(userName,accountType)) break;
                        }
                        break;
                    case "3" :
                        if (_players.Count == 0)
                        {
                            Console.WriteLine("Немає iгрових акаунтiв");
                            break;
                        }
                        Console.WriteLine("Зареєстрованi iгровi акаунти: ");
                        foreach (var gameAccount in _players)
                        {
                            Console.WriteLine(gameAccount.UserName + " рейтинг: " + gameAccount.CurrentRating + " кiлькiсть зiграних iгор: " + gameAccount.Matches.Count);
                        }
                        Console.WriteLine("Введiть повiдомленя щоб повернутись назад");
                        Console.ReadLine();
                        break;
                    case "4" :
                        if (_players.Count == 0)
                        {
                            Console.WriteLine("Iсторiя недавнiх iгор порожня!");
                            break;
                        }
                        Console.WriteLine("Iсторiя недавнiх iгор: ");
                        foreach (var match in _matches)
                        {
                            match.PrintInfo();
                        }
                        Console.WriteLine("Введiть повiдомленя щоб повернутись назад");
                        Console.ReadLine();
                        break;
                    case "5" :
                        if (_players.Count == 0)
                        {
                            Console.WriteLine("Не створено жодного акаунту, неможливо отримати iнформацiю");
                            break;
                        }
                        Console.WriteLine("Введiть iм'я акаунту");
                        var name = Console.ReadLine();
                        if (GetPlayer(name) != null)
                        {
                            var player = GetPlayer(name);
                            player.PrintStats();
                            break;
                        }
                        Console.WriteLine("Акаунт " + name + " не знайдено");
                        break;
                    case "6" :
                        return;
                }
            }
        }

        private bool CreatePlayer(string name, int type)
        {
            if (GetPlayer(name.Trim()) == null)
            {
                switch (type)
                {
                    case 1: 
                        _players.Add(new GameAccount(name));
                        Console.WriteLine("Новий акаунт створено!");
                        break;
                    case 2:
                        _players.Add(new VipAccount(name));
                        Console.WriteLine("ВIП-Акаунт створено!");
                        break;
                    case 3:
                        _players.Add(new PremiumAccount(name));
                        Console.WriteLine("Премiум акаунт створено!");
                        break;
                    default: 
                        Console.WriteLine("Неправильний тип акаунту!");
                        return false;
                }
                SaveData();
                return true;
            }
            Console.WriteLine("Акаунт з такии iменем вже iснує");
            return false;
        }
        
        private GameAccount GetPlayer(string name)
        {
            foreach (var gameAccount in _players)
            {
                if (gameAccount.UserName.Equals(name.Trim())) return gameAccount;
            }
            return null;
        }

        private void SaveData()
        {
            DBContext dbContext = new DBContext();
            dbContext.SaveData(_players,_matches);
        }

        public void GetData()
        {
            DBContext dbContext = new DBContext();
            dbContext.GetData(this);
        }
    }
}