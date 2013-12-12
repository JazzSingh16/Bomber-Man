using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;

namespace BomberMan
{
    class BomberMan
    {
        Keys UpKey, DownKey, LeftKey, RightKey;
        //Sprite sprite;

        public BomberMan(Keys UpKey, Keys DownKey, Keys LeftKey, Keys RightKey)
        {
            this.UpKey = UpKey;
            this.DownKey = DownKey;
            this.LeftKey = LeftKey;
            this.RightKey = RightKey;
        }
        
        /*
        public override void Update (GameTime gameTime)
        {
            KeyboardState kb = Keyboard.GetState();

            if (kb.IsKeyDown(DownKey))
            {
            }
        }
        */
    }
}
