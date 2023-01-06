using ConsoleApplication1.Accounts;
using ConsoleApplication1.TicTacToe;

namespace ConsoleApplication1
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Controller game = new Controller();
            game.Start();
        }
    }
}