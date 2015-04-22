using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TreasureHunt.Classes
{
    class TreasureChest :SimpleSprite
    {
        LinkedList<Collectable> Collected = new LinkedList<Collectable>();

        public TreasureChest(Game g, Texture2D tx, Vector2 startPos) :base(g,tx,startPos)
        {


        }
    }
}
