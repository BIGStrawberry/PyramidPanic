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
    public class MenuStartScene
    {
        private enum ButtonState { Start, Load, Help, Scores, Quit, Leveleditor } ;
        //Fields
        private PyramidPanic game;
        private ButtonState buttonState;
        private Color buttonColorActive = Color.Gold;
        private Image start, load, help, scores, quit, leveleditor;
        
        private int top, left, space;
        


        //Constructor
        public MenuStartScene(PyramidPanic game)
        {
            this.game = game;
            this.Initialize();
        }

        //Initialize
        private void Initialize()
        {
            this.buttonState = ButtonState.Start;
            this.top = 430;
            this.left = 4;
            this.space = 107;
            this.LoadContent();
        }

        //Update
        public void Update(GameTime gameTime)
        {
            if (Input.EdgeDetectKeyDown(Keys.Right))
            {
                this.buttonState++;
                if (this.buttonState > ButtonState.Leveleditor)
                {
                   this.buttonState = ButtonState.Start;
                }
            }
        

    
            if (Input.EdgeDetectKeyDown(Keys.Left))
            {
                this.buttonState--;
                if (this.buttonState < ButtonState.Start)
                {
                    this.buttonState = ButtonState.Leveleditor;
                }
            }

            if (Input.EdgeDetectKeyDown(Keys.Enter) && this.buttonState == ButtonState.Start)
            {
                this.game.GameState = new PlayScene(this.game);
            }
        }



        //LoadContent
        private void LoadContent()
        {
            this.start = new Image(this.game,
                                    @"StartSceneAssets\Button_Start", new Vector2(this.left, this.top));
            this.load = new Image(this.game,
                                    @"StartSceneAssets\Button_Load", new Vector2(this.left + this.space, this.top));
            this.help = new Image(this.game,
                                    @"StartSceneAssets\Button_Help", new Vector2(this.left + 2 * this.space, this.top));
            this.scores = new Image(this.game,
                                    @"StartSceneAssets\Button_Scores", new Vector2(this.left + 3 * this.space, this.top));
            this.quit = new Image(this.game,
                                    @"StartSceneAssets\Button_Quit", new Vector2(this.left + 4 * this.space, this.top));
            this.leveleditor = new Image(this.game,
                                    @"StartSceneAssets\Button_Leveleditor", new Vector2(this.left + 5 * this.space, this.top));
        }

       



        //Draw
        public void Draw(GameTime gameTime)
        {
            Color buttonColorStart = Color.White;
            Color buttonColorLoad = Color.White;
            Color buttonColorHelp = Color.White;
            Color buttonColorScores = Color.White;
            Color buttonColorQuit = Color.White;
            Color buttonColorLeveleditor = Color.White;

            switch ( this.buttonState )
            {
                case ButtonState.Start:
                       buttonColorStart = this.buttonColorActive;
                        break;
                case ButtonState.Load:
                        buttonColorLoad = this.buttonColorActive;
                         break;
                case ButtonState.Help:
                        buttonColorHelp = this.buttonColorActive;
                         break;
                case ButtonState.Scores:
                        buttonColorScores = this.buttonColorActive;
                         break;
                 case ButtonState.Quit:
                        buttonColorQuit = this.buttonColorActive;
                         break;
                 case ButtonState.Leveleditor:
                        buttonColorLeveleditor = this.buttonColorActive;
                         break;

            }
         
          
            this.start.Draw(this.game.SpriteBatch, buttonColorStart);
            this.load.Draw(this.game.SpriteBatch, buttonColorLoad);
            this.help.Draw(this.game.SpriteBatch, buttonColorHelp);
            this.scores.Draw(this.game.SpriteBatch, buttonColorScores);
            this.quit.Draw(this.game.SpriteBatch, buttonColorQuit);
            this.leveleditor.Draw(this.game.SpriteBatch, buttonColorLeveleditor);
        }

    }
}
