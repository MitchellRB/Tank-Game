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
        public SceneObject turret = new SceneObject("Turret");
        SpriteObject turretSprite = new SpriteObject("TurretSprite");

        rl.Texture2D bulletTexture;

        private Vector2 topLeft = new Vector2();

        public Vector2 TopLeft { get => topLeft; }

        private Vector2 bottomRight = new Vector2();

        public Vector2 BottomRight { get => bottomRight; }

        public Controls controls = new Controls();

        public Tank() : base()
        {
            AddChildren();
        }

        public Tank(string _name) : base(_name)
        {
            AddChildren();
        }

        void AddChildren()
        {
            AddChild(sprite);
            AddChild(turret);
            turret.AddChild(turretSprite);
        }

        void UpdateCollider()
        {
            topLeft = globalPosition - sprite.origin;
            bottomRight = globalPosition + sprite.origin;
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
            if (IsKeyDown(controls.left))
            {
                Rotate(-2);
            }
            if (IsKeyDown(controls.right))
            {
                Rotate(2);
            }

            if (IsKeyDown(controls.foreward))
            {
                MoveForeward(2);
            }
            if (IsKeyDown(controls.back))
            {
                MoveForeward(-2);
            }

            if (IsKeyDown(controls.turretLeft))
            {
                turret.Rotate(-2);
            }
            if (IsKeyDown(controls.turretRight))
            {
                turret.Rotate(2);
            }

            if (IsKeyPressed(controls.shoot))
            {
                Bullet bullet = new Bullet(bulletTexture);
                bullet.SetPosition(globalPosition.x, globalPosition.y);
                bullet.SetRotate(turret.GlobalRotation);
                bullet.MoveForeward(40);
                parent.AddChild(bullet);
            }

            UpdateCollider();
        }

        public override void OnDraw()
        {
            base.OnDraw();
            if (Program.debug)
            {
                DrawRectangleLines((int)topLeft.x, (int)topLeft.y, (int)sprite.Width, (int)sprite.Height, rl.Color.RED);
            }
        }
    }
}
