using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using xTile.Tiles;

namespace BomberMan
{


    class BomberMan : MazeActor
    {
        Keys UpKey, DownKey, LeftKey, RightKey;

        Direction direction;
        Vector2 target;
        private bool tagged;

        public bool Tagged 
        {
            get { return tagged; }
            set
            {
                if (value && !tagged)
                {
                    speed += 60;
                }
                else if (!value && tagged)
                {
                    speed -= 60;
                }

                tagged = value;
            }
        }

        public BomberMan(Keys UpKey, Keys DownKey, Keys LeftKey, Keys RightKey, 
                         Vector2 location,
                         Texture2D texture,
                         Rectangle initialFrame,
                         Vector2 velocity,
                         xTile.Layers.Layer map)
                        : base(location, texture, initialFrame, velocity, map)
        {
            this.UpKey = UpKey;
            this.DownKey = DownKey;
            this.LeftKey = LeftKey;
            this.RightKey = RightKey;

            Tile tile = map.Tiles[0, 0];

            if (tile != null && tile.TileIndex == 28)
                map.Tiles[0, 0] = null;

            this.Tagged = false;

        }


        public override void Update(GameTime gameTime)
        {
            KeyboardState keyboard = Keyboard.GetState();

            if (keyboard.IsKeyDown(RightKey))
            {

                newDirection = Direction.RIGHT;
            }

            if (keyboard.IsKeyDown(DownKey))
            {

                newDirection = Direction.DOWN;
            }

            if (keyboard.IsKeyDown(UpKey))
            {

                newDirection = Direction.UP;
            }

            if (keyboard.IsKeyDown(LeftKey))
            {

                newDirection = Direction.LEFT;
            }

            base.Update(gameTime);
        }


    }
}