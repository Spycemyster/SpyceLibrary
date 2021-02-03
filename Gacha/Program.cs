using System;

namespace Gacha
{
    public static class Program
    {
        [STAThread]
        static void Main()
        {
            using (var game = new Game1())
                game.Run();
        }
    }

    public struct TestStruct
    {
        public int val;
    }
}
