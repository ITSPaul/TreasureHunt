using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TreasureHunt.Classes
{
    class Collectable : SimpleSprite
    {
        public int value;
        public Vector2 Target;
        public bool Captured = false;

        public Collectable(Game g, Texture2D tx, Vector2 startPos) :base(g,tx,startPos)
        {
            Random r = new Random();
            value = r.Next(10,20);
            Target = new Vector2(r.Next(g.GraphicsDevice.Viewport.Width), 
                r.Next(g.GraphicsDevice.Viewport.Height));

        }

        public override void Update(GameTime gameTime)
        {

            if (Vector2.Distance(Position, Target) > 0.1)
                Position = Vector2.Lerp(Position, Target, 0.1f);
            else
            {
                Position = Target;
                Random r = new Random();
                Target = new Vector2(r.Next(Game.GraphicsDevice.Viewport.Width),
                r.Next(Game.GraphicsDevice.Viewport.Height));
            }
            base.Update(gameTime);
        }
    }
}
