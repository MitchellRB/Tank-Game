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

        Tank tank = new Tank("Tank");

        public static List<SceneObject> sceneObjects = new List<SceneObject>();

        public void Init()
        {
            //Create player
            world.AddChild(tank);

            tank.Load(@"..\..\Sprites\PNG\Tanks\tankBlue.png", @"..\..\Sprites\PNG\Tanks\barrelBlue.png", @"..\..\Sprites\PNG\Bullets\bulletBlue.png");

            tank.SetPosition(350, 300);

            tank.controls.SetControls(rl.KeyboardKey.KEY_W, rl.KeyboardKey.KEY_S, rl.KeyboardKey.KEY_A, rl.KeyboardKey.KEY_D, rl.KeyboardKey.KEY_Q, rl.KeyboardKey.KEY_E, rl.KeyboardKey.KEY_SPACE);

        }

        public void Update()
        {
            world.Update();
        }

        public void Draw()
        {
            world.Draw();
        }
    }
}
