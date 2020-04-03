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
                return;
            }

            //Check collision

            //Player 1
            Vector2 topLeft = Program.game.player1.TopLeft/* + Program.game.player1.GlobalPosition;*/;
            Vector2 bottomRight = Program.game.player1.BottomRight /*+ Program.game.player1.GlobalPosition;*/;

            if (!(globalPosition.x < topLeft.x || globalPosition.x > bottomRight.x || globalPosition.y < topLeft.y || globalPosition.y > bottomRight.y))
            {
                Program.game.state = Game.gameStates.player2Victory;
                parent.RemoveChild(this);
                return;
            }

            //Player 2
            topLeft = Program.game.player2.TopLeft/* + Program.game.player2.GlobalPosition;*/;
            bottomRight = Program.game.player2.BottomRight/* + Program.game.player2.GlobalPosition;*/;

            if (!(globalPosition.x < topLeft.x || globalPosition.x > bottomRight.x || globalPosition.y < topLeft.y || globalPosition.y > bottomRight.y))
            {
                Program.game.state = Game.gameStates.player1Victory;
                parent.RemoveChild(this);
                return;
            }
        }

    }
}
