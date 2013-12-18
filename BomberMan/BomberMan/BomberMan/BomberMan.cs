﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BomberMan
{
    class BomberMan : Sprite
    {
        Keys UpKey, DownKey, LeftKey, RightKey;
        //Sprite sprite;

        public BomberMan(Keys UpKey, Keys DownKey, Keys LeftKey, Keys RightKey, 
                         Vector2 location,
                         Texture2D texture,
                         Rectangle initialFrame,
                         Vector2 velocity) : base (location, texture, initialFrame, velocity)
        {
            this.UpKey = UpKey;
            this.DownKey = DownKey;
            this.LeftKey = LeftKey;
            this.RightKey = RightKey;

            
        }



       
        public override void Update (GameTime gameTime)
        {
            KeyboardState kb = Keyboard.GetState();

            if (kb.IsKeyDown(DownKey))
            {
                
            }

            base.Update(gameTime);
        }

    }
}