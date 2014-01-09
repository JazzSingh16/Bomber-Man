using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using xTile;
using xTile.Layers;

namespace BomberMan
{
    class Bomb : Sprite
    {
        double countdownTimer = 2000f;

        public Bomb(Vector2 location,
                    Texture2D texture,
                    Rectangle initialFrame,
                    Vector2 velocity)
                    : base(location, texture, initialFrame, velocity)
        {
            this.Dead = false;
            this.ReadyToExplode = false;
        }

        public bool Dead { get; set;  }
        public bool ReadyToExplode { get; set; }

        public bool IsIntersectingExplosion(Layer layer, MazeActor actor)
        {
            /*
            if (layer.Tiles[0, 0] == null)
            {
                // no tile here
            }
             */

            return false;
        }

        public override void Update(GameTime gameTime)
        {
            countdownTimer -= gameTime.ElapsedGameTime.TotalMilliseconds;

            if (countdownTimer < 0)
            {
                this.ReadyToExplode = true;
            }

            

            base.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }


    }

    class BombManager
    {
        public List<Bomb> bombs;
        private Texture2D texture;

        public BombManager(Texture2D texture)
        {
            bombs = new List<Bomb>();
            this.texture = texture;
        }

        public void AddBomb(Vector2 Location)
        {
            bombs.Add(new Bomb(Vector2.Zero, texture, new Rectangle(0, 0, 0, 0), Vector2.Zero));
        }

        public void Update(GameTime gametime)
        {
            for (int i = bombs.Count - 1; i >= 0; i--)
            {
                bombs[i].Update(gametime);

                if (bombs[i].Dead)
                {
                    bombs.RemoveAt(i);
                }
            }
        }

    }
}
