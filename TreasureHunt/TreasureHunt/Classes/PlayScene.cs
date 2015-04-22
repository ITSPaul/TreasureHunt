using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Classes;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprites;
using InputEngineNS;
using Microsoft.Xna.Framework.Input;
using TreasureHunt.Classes;

namespace Classes
{
    class PlayScene : Scene
    {
        List<Collectable> Collectables = new List<Collectable>();
        TreasureChest Tchest;
        

        public PlayScene(Game g, string name, Texture2D tx ) : base(g,name,tx)
        {
           
            
        }

        protected override void LoadContent()
        {

            Random r = new Random();
            for (int i = 0; i < 4; i++)
            {

                Collectables.Add(
                    new Collectable(Game,
                        Game.Content.Load<Texture2D>(@".\Assets\coin"),
                        new Vector2(r.Next(Game.GraphicsDevice.Viewport.Width),r.Next( Game.GraphicsDevice.Viewport.Height)))
                    );
            }

            Tchest = new TreasureChest(Game,
                Game.Content.Load<Texture2D>(@".\Assets\TreasureChest"),
                new Vector2(r.Next(Game.GraphicsDevice.Viewport.Width), 
                    r.Next(Game.GraphicsDevice.Viewport.Height)
                    ));

            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
           
        }
    }
}
