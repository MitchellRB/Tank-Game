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

        int timer;

        public Bullet(ref rl.Texture2D _sprite, string _name) : base(_name)
        {
            sprite = new SpriteObject(_sprite);
            sprite.origin = new Vector2(sprite.Width / 2, sprite.Height / 2);
            AddChild(sprite);
            localBox = new Box(new Vector2(-5, -5), new Vector2(5, 5));
            timer = 1;
        }

        public override void OnUpdate()
        {
            base.OnUpdate();
            MoveForeward(10);
            if (globalPosition.x < -50 || globalPosition.x > GetScreenWidth() + 50 || globalPosition.y < -50 || globalPosition.y > GetScreenHeight() + 50)
            {
                parent.RemoveChild(this);
                return;
            }

            //Check collision

            foreach (var item in parent.Children)
            {
                if (item != this && timer == 0 && globalBox.Overlaps(item.GlobalBox))
                {
                    if (item.name == "Player1")
                    {
                        Program.game.state = Game.gameStates.player2Victory;
                    }
                    else if (item.name == "Player2")
                    {
                        Program.game.state = Game.gameStates.player1Victory;
                    }
                }
            }

            if (timer > 0)
            {
                timer--;
            }

        }

    }
}
