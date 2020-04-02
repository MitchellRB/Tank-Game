using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathClasses;
using rl = Raylib;
using static Raylib.Raylib;

namespace Tank_Game
{
    class Program
    {
        public static bool debug = true;

        static void Main(string[] args)
        {
            InitWindow(640 * 2, 480 * 2, "Tank game");

            Game game = new Game();

            game.Init();

            while (!WindowShouldClose())
            {
                game.Update();

                BeginDrawing();
                ClearBackground(rl.Color.WHITE);

                game.Draw();

                EndDrawing();
            }

            CloseWindow();
        }
    }
}
