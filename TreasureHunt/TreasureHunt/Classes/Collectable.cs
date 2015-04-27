using InputEngineNS;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utilities;

namespace TreasureHunt.Classes
{
    class Collectable : SimpleSprite
    {
        public int value;
        public Vector2 Target;
        public bool Captured = false;

        public Collectable(Game g, Texture2D tx, Vector2 startPos) :base(g,tx,startPos)
        {
            //Random r = new Random();
            value = Utility.NextRandom(10,20);
            Target = new Vector2(Utility.NextRandom(0,g.GraphicsDevice.Viewport.Width),
                Utility.NextRandom(0, g.GraphicsDevice.Viewport.Height));

        }

        public override void Update(GameTime gameTime)
        {
                if (Vector2.Distance(Position, Target) > 0.1)
                    Position = Vector2.Lerp(Position, Target, 0.01f);
                else if(!Captured)

                {
                    Position = Target;
                    Random r = new Random();
                    Target = new Vector2(Utility.NextRandom(0, Game.GraphicsDevice.Viewport.Width),
                        Utility.NextRandom(0, Game.GraphicsDevice.Viewport.Height));
                }

                if (InputEngine.IsMouseLeftClick())
                {
                    if (BoundingRect.Contains(new Point((int)InputEngine.MousePosition.X,
                                        (int)InputEngine.MousePosition.Y)))
                    {
                        Captured = true;
                        new TextEffect(Game, this.value.ToString(), this.Position + new Vector2(this.Image.Width/2,this.Image.Width/2));
                    }
                }
            base.Update(gameTime);
        }
    }
}
