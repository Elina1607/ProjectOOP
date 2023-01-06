using ConsoleApplication1.Accounts;
using ConsoleApplication1.TicTacToe;

namespace ConsoleApplication1.Games
{
    public class SoloRatedGame : Game
    {
        public SoloRatedGame(GameAccount player1) : base(player1, new GameAccount("БОТ"))
        {
        }

        public override void Play()
        {
            Rating = Rand.Next(1, 10);
            LastGame = new TicTacToeGame().PlaySoloGame(Player1,Player2);
            base.Play();
        }
    }
}