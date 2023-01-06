using ConsoleApplication1.Accounts;
using ConsoleApplication1.TicTacToe;

namespace ConsoleApplication1.Games
{
    public class SoloUnRatedGame : Game
    {
        public SoloUnRatedGame(GameAccount player1) : base(player1,  new GameAccount("SYSTEM"))
        {
        }

        public override void Play()
        {
            Rating = 0;
            LastGame = new TicTacToeGame().PlaySoloGame(Player1,Player2);
            base.Play();
        }
    }
}