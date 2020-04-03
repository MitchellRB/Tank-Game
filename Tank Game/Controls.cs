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
    struct Controls
    {
        public rl.KeyboardKey foreward;
        public rl.KeyboardKey back;

        public rl.KeyboardKey left;
        public rl.KeyboardKey right;

        public rl.KeyboardKey turretLeft;
        public rl.KeyboardKey turretRight;

        public rl.KeyboardKey shoot;

        public void SetControls(rl.KeyboardKey f, rl.KeyboardKey b, rl.KeyboardKey l, rl.KeyboardKey r, rl.KeyboardKey tl, rl.KeyboardKey tr, rl.KeyboardKey sh)
        {
            foreward = f;
            back = b;
            left = l;
            right = r;
            turretLeft = tl;
            turretRight = tr;
            shoot = sh;
        }
    }
}
