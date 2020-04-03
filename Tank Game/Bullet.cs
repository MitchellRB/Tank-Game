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
    class Bullet : SceneObject
    {
        SpriteObject sprite;

        public Bullet(rl.Texture2D _sprite) : base()
        {
            sprite = new SpriteObject(_sprite);
            sprite.origin = new Vector2(sprite.Width / 2, sprite.Height / 2);
            AddChild(sprite);
        }

        public override void OnUpdate()
        {
            MoveForeward(10);
            if (globalPosition.x < -50 || globalPosition.x > GetScreenWidth() + 50 || globalPosition.y < -50 || globalPosition.y > GetScreenHeight() + 50)
            {
                parent.RemoveChild(this);
            }
        }

    }
}
