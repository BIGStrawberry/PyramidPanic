using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace PyramidPanic
{
    public class StartScene : IStateGame
    {
        //Fields
        private PyramidPanic game;
        private Image background, title;
        private MenuStartScene menu;


        //Constructor
        public StartScene(PyramidPanic game)
        {
            this.game = game;
            this.background = new Image(game, @"StartSceneAssets\Background", new Vector2(0f, 0f));
            this.title = new Image(game, @"StartSceneAssets\Title", new Vector2(100f, 30f));
            this.menu = new MenuStartScene(game);
        }

        //Initialize
        public void Initialize()
        {

        }

        //LoadContent
        public void LoadContent()
        {

        }

        //Update
        public void Update(GameTime gameTime)
        {
            this.menu.Update(gameTime);
        }


        //Draw
        public void Draw(GameTime gameTime)
        {
            this.background.Draw(this.game.SpriteBatch);
            this.title.Draw(this.game.SpriteBatch);
            this.menu.Draw(gameTime);
        }
    }
}
