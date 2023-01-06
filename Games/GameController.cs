using ConsoleApplication1.Accounts;
using ConsoleApplication1.Games;

namespace ConsoleApplication1.Controllers
{
    public static class GameController
    {
        public static Game StartUnRatedGame(GameAccount player1, GameAccount player2)
        {
            Game game = new UnRatedGame(player1, player2);
            game.Play();
            return game;
        }
        
        public static Game StartRatedGame(GameAccount player1, GameAccount player2)
        {
            Game game = new RatedGame(player1, player2);
            game.Play();
            return game;
        }
         
        public static Game StartSoloUnRatedGame(GameAccount player)
        {
            Game game = new SoloUnRatedGame(player);
            game.Play();
            return game;
        }
        
        public static Game StartSoloRatedGame(GameAccount player)
        {
            Game game = new SoloRatedGame(player);
            game.Play();
            return game;
        }
       
    }
}