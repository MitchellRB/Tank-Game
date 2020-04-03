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
    class Game
    {
        public SceneObject world = new SceneObject("World");

        public Tank player1 = new Tank("Player1");

        public Tank player2 = new Tank("Player2");

        public enum gameStates
        {
            menu,
            play,
            player1Victory,
            player2Victory
        }

        public gameStates state;

        public void Init()
        {
            //Create player 1
            world.AddChild(player1);

            player1.Load(@"..\..\Sprites\PNG\Tanks\tankBlue.png", @"..\..\Sprites\PNG\Tanks\barrelBlue.png", @"..\..\Sprites\PNG\Bullets\bulletBlue.png");

            player1.SetPosition(350, 300);

            player1.SetRotate(0);

            player1.controls.SetControls(rl.KeyboardKey.KEY_W, rl.KeyboardKey.KEY_S, rl.KeyboardKey.KEY_A, rl.KeyboardKey.KEY_D, rl.KeyboardKey.KEY_Q, rl.KeyboardKey.KEY_E, rl.KeyboardKey.KEY_Z);

            //Create player 2
            world.AddChild(player2);

            player2.Load(@"..\..\Sprites\PNG\Tanks\tankRed.png", @"..\..\Sprites\PNG\Tanks\barrelRed.png", @"..\..\Sprites\PNG\Bullets\bulletRed.png");

            player2.SetPosition(950, 300);

            player2.SetRotate(0);

            player2.controls.SetControls(rl.KeyboardKey.KEY_I, rl.KeyboardKey.KEY_K, rl.KeyboardKey.KEY_J, rl.KeyboardKey.KEY_L, rl.KeyboardKey.KEY_U, rl.KeyboardKey.KEY_O, rl.KeyboardKey.KEY_M);

        }

        public void Reset()
        {
            world.AddChild(player1);

            player1.SetPosition(350, 300);

            player1.SetRotate(0);

            player1.turret.SetRotate(0);

            world.AddChild(player2);

            player2.SetPosition(950, 300);

            player2.SetRotate(0);

            player2.turret.SetRotate(0);
        }

        public void Update()
        {
            if (state == gameStates.menu)
            {
                if (IsKeyPressed(rl.KeyboardKey.KEY_SPACE)) state = gameStates.play;
            }
            if (state == gameStates.play)
            {
                world.Update();
            }
            if (state == gameStates.player1Victory || state == gameStates.player2Victory)
            {
                world.Children.RemoveRange(0, world.Children.Count);
                if (IsKeyPressed(rl.KeyboardKey.KEY_SPACE)) { state = gameStates.play; Reset(); }
            }
        }

        public void Draw()
        {
            if (state == gameStates.play)
            {
                world.Draw();
            }
        }
    }
}
