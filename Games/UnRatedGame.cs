using ConsoleApplication1.Accounts;
using ConsoleApplication1.TicTacToe;

namespace ConsoleApplication1.Games
{
    public class UnRatedGame : Game
    {
        public UnRatedGame(GameAccount player1, GameAccount player2) : base(player1, player2)
        {
        }

        public override void Play()
        {
            Rating = 0;
            LastGame = new TicTacToeGame().PlayGame(Player1,Player2);
            base.Play();
        }
    }
}