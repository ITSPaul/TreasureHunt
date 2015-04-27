using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TreasureHunt
{
    class TextEffect: DrawableGameComponent
    {

        string text;
        Vector2 position;
        float fontScale;
        SpriteFont spf;
        TimeSpan playTimer = TimeSpan.Zero;
        int countDown = 5;

        public TextEffect(Game g, string txt,Vector2 pos):base(g)
        {
            g.Components.Add(this);
            text = txt;
            position = pos;
        }

        protected override void LoadContent()
        {
            spf = Game.Content.Load<SpriteFont>("PlayMessages");
            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            playTimer += gameTime.ElapsedGameTime;
            if (playTimer > TimeSpan.FromSeconds(countDown))
            {
                Visible = false;
                this.Dispose();
            }
            fontScale += 0.01f;            
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            //Color textColor = new Color(255, 255, 255, 50);
            SpriteBatch sp = (SpriteBatch)Game.Services.GetService(typeof(SpriteBatch));
            sp.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend);
            sp.DrawString(spf, text, position, Color.White, 0f, Vector2.Zero, fontScale, SpriteEffects.None, 0);
            sp.End();
            base.Draw(gameTime);
        }
    }
}
