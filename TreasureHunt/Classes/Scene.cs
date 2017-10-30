using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using InputEngineNS;

namespace Classes
{
    public enum STATE { ACTIVE, TRANSITION, BACKGROUNDED, QUITTING }       

    class Scene: DrawableGameComponent
    {
        Texture2D _backGround;
        
        public STATE SceneState;

        private string _sceneName;

        public string SceneName
        {
            get { return _sceneName; }
            set { _sceneName = value; }
        }

        private KeyboardState previous;        
        public Texture2D BackGround
        {
            get { return _backGround; }
            set { _backGround = value; }
        }
        
        public Scene(Game g, string sceneName, Texture2D txBack): base(g)
            {
                _sceneName = sceneName;
                g.Components.Add(this);
                _backGround = txBack;
            }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            if(SceneState == STATE.ACTIVE)
            {
                SpriteBatch sp = (SpriteBatch)Game.Services.GetService(typeof(SpriteBatch));
                sp.Begin(SpriteSortMode.BackToFront,BlendState.AlphaBlend);
                if (_backGround != null)
                    sp.Draw(_backGround, Game.GraphicsDevice.Viewport.Bounds, Color.White);
                sp.End();
            }
            base.Draw(gameTime);
        }
        

    }

}
