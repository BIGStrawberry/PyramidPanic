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
    public static class Input
    {
        //Fields
        private static KeyboardState ks, oks;
        private static MouseState ms, oms;
        private static Rectangle mouseRectangle;

        //Constructor
        static Input()
        {
            mouseRectangle = new Rectangle(0, 0, 1, 1);
            ks = Keyboard.GetState();
            ms = Mouse.GetState();
            oms = ms;
            oks = ks;
        }

        //Update methode
        public static void Update()
        {
            oks = ks;
            oms = ms;
            ks = Keyboard.GetState();
            ms = Mouse.GetState();
            
        }

        //LevelDetector voor het toetsenknoppen
        public static bool DetectKeyDown(Keys key)
        {
            return ks.IsKeyDown(key);
        }

        //Edgedetector voor de toestenbordknoppen
        public static bool EdgeDetectKeyDown (Keys key)
        {
            return (ks.IsKeyDown(key) && oks.IsKeyUp(key));
        }

        //EdgeDetecotr voor een linksklik van de muis.
        public static bool EdgeDetectPressLeft()
        {
            return (ms.LeftButton == ButtonState.Pressed && oms.LeftButton == ButtonState.Released);
        }
            
        public static bool EdgeDetectPressRight()
        {
            return (ms.RightButton == ButtonState.Pressed && oms.RightButton == ButtonState.Released);
        }

        public static Vector2 MousePosition()
        {
            return new Vector2(ms.X, ms.Y);

        }

        //Positie van de rectangle
        public static Rectangle MouseRectangle()
        {
            mouseRectangle.X = ms.X;
            mouseRectangle.Y = ms.Y;
            return mouseRectangle;

        }

    }
}
