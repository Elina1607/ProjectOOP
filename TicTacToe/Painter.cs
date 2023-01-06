using System;

namespace ConsoleApplication1.TicTacToe
{
    public static class Painter
    {
        public static void DrawGrid(int[] array)
        {
            if(array.Length != 9) return;
            for (int i = 0; i < 9; i+=3)
            {
                Console.WriteLine(" {0} | {1} | {2} ",GetString(array[i])
                    ,GetString(array[i+1]),
                    GetString(array[i+2]));
                if(i < 6) Console.WriteLine("___ ___ ___");
            }
        }
        
        public static string GetString(int num)
        {
            return num == 0 ? " " : num == 1 ? "X" : num == 2 ? "0" : "";
        }

        public static void PrintMenu(params string[] menu)
        {
            for (int i = 0; i < menu.Length; i++)
            {
                Console.WriteLine("(" + (i+1) + ") " + menu[i]);
            }
        }
    }
}