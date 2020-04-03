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
    class Tank : SceneObject
    {
        SpriteObject sprite = new SpriteObject("TankSprite");
        SceneObject turret = new SceneObject("Turret");
        SpriteObject turretSprite = new SpriteObject("TurretSprite");

        rl.Texture2D bulletTexture;

        public Tank() : base()
        {
            AddChild(sprite);
            AddChild(turret);
            turret.AddChild(turretSprite);
        }

        public Tank(string _name) : base(_name)
        {
            AddChild(sprite);
            AddChild(turret);
            turret.AddChild(turretSprite);
        }

        public void Load(string tankPath, string turretPath, string bulletPath)
        {
            sprite.Load(tankPath);
            turretSprite.Load(turretPath);
            turretSprite.origin.y = 40;
            bulletTexture = LoadTexture(bulletPath);
        }

        public override void OnUpdate()
        {
            if (IsKeyDown(rl.KeyboardKey.KEY_A))
            {
                Rotate(-2);
            }
            if (IsKeyDown(rl.KeyboardKey.KEY_D))
            {
                Rotate(2);
            }

            if (IsKeyDown(rl.KeyboardKey.KEY_W))
            {
                MoveForeward(1);
            }
            if (IsKeyDown(rl.KeyboardKey.KEY_S))
            {
                MoveForeward(-1);
            }

            if (IsKeyDown(rl.KeyboardKey.KEY_Q))
            {
                turret.Rotate(-2);
            }
            if (IsKeyDown(rl.KeyboardKey.KEY_E))
            {
                turret.Rotate(2);
            }

            if (IsKeyPressed(rl.KeyboardKey.KEY_SPACE))
            {
                Bullet bullet = new Bullet(bulletTexture);
                bullet.SetPosition(globalPosition.x, globalPosition.y);
                bullet.SetRotate(turret.GlobalRotation);
                bullet.MoveForeward(40);
                parent.AddChild(bullet);
            }
        }
    }
}
