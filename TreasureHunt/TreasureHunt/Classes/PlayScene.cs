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
using TreasureHunt;
using Utilities;

namespace Classes
{
    class PlayScene : Scene
    {
        List<Collectable> Collectables = new List<Collectable>();
        List<Collectable> Moving = new List<Collectable>();
        TreasureChest Tchest;
        string message = "";
        SpriteFont spf;
        public PlayScene(Game g, string name, Texture2D tx ) : base(g,name,tx)
        {
            Game.IsMouseVisible = true;
        }

        protected override void LoadContent()
        {
            spf = Game.Content.Load<SpriteFont>("PlayMessages");
            //Random r = new Random();
            for (int i = 0; i < 14; i++)
            {

                Collectables.Add(
                    new Collectable(Game,
                        Game.Content.Load<Texture2D>(@".\Assets\coin"),
                        new Vector2(Utility.NextRandom(0,Game.GraphicsDevice.Viewport.Width), 
                            Utility.NextRandom(0,Game.GraphicsDevice.Viewport.Height)))
                    );
            }

            Tchest = new TreasureChest(Game,
                Game.Content.Load<Texture2D>(@".\Assets\TreasureChest"), Vector2.Zero);
            Tchest.Position = new Vector2(Utility.NextRandom(0,Game.GraphicsDevice.Viewport.Width - Tchest.Image.Width),
                    Utility.NextRandom(0, Game.GraphicsDevice.Viewport.Height - Tchest.Image.Height)
                    );
                

            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            // check and we if we have clicked a collectable
            Collectable found = null;
            foreach (var item in Collectables)
            {
                if (item.Captured)
                { 
                    found = item;
                    break;
                }
            }
            // if one found to be clicked then it's moving
            if (found != null)
            {
                Collectables.Remove(found);
                found.Target = Tchest.Position;
                Moving.Add(found);
            }
            // see if moving collectable has collided with Treasure chest
            found = null;
            foreach (var item in Moving)
                if(Tchest.BoundingRect.Intersects(item.BoundingRect))
                    found = item;
            // if collided then add found to treasure chest Collected collection
            if (found != null)
            {
                found.Visible = false;
                //Tchest.Collected.AddFirst(found);
                Tchest.insert(found);
                new TextEffect(Game, found.value.ToString(), 
                    Tchest.Position + new Vector2(Tchest.Image.Width/2,Tchest.Image.Height/2 ));
                Moving.Remove(found);
            }

            // if all moved and all collected then empty the chest and we are done
            if (Moving.Count == 0 && Collectables.Count == 0)
                Tchest.Empty();
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            if (Tchest.emptied)
            {
                //new TextEffect(Game, "Your Score is " + Tchest.score.ToString(),
                //    Tchest.Position + new Vector2(Tchest.Image.Width / 2, Tchest.Image.Height / 2));
                Tchest.emptied = false;
            }

            base.Draw(gameTime);
           
        }
    }
}
