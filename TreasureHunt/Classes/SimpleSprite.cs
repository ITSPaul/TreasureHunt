using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Sprites
{
    public class SimpleSprite : DrawableGameComponent
    {
        public Texture2D Image;
        public Vector2 Position;
        Rectangle r;

       

        public Rectangle BoundingRect {get 
        {return 
            new Rectangle((int)Position.X, 
                (int)Position.Y, 
                Image.Width, 
                Image.Height);
            
             }
        }
        public bool Visible = true;

        public SimpleSprite(Game g, Texture2D spriteImage,
                            Vector2 startPosition) : base(g)
        {
            g.Components.Add(this);
            Image = spriteImage;
            Position = startPosition;
            

        }

        public override void Draw(GameTime gameTime)
        {
            if (Visible)
            {
                SpriteBatch sp = (SpriteBatch)Game.Services.GetService(typeof(SpriteBatch));
                sp.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend);
                sp.Draw(Image, BoundingRect, Color.White);
                sp.End();
            }

            base.Draw(gameTime);
        }

        
    }
}
