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
using xTile;
using xTile.Display;
using xTile.Tiles;
using xTile.Layers;

namespace BomberMan
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        public Texture2D P1Sheet;
        public Texture2D P2Sheet;
        Map map;
        BomberMan bomberman1;
        BomberMan bomberman2;
        IDisplayDevice xnaDisplayDevice;
        xTile.Dimensions.Rectangle viewport;

        public Game1()
        {


            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferHeight = 800;
            graphics.PreferredBackBufferWidth = 800;
            graphics.ApplyChanges();

            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            xnaDisplayDevice = new xTile.Display.XnaDisplayDevice(Content, GraphicsDevice);
            viewport = new xTile.Dimensions.Rectangle(new xTile.Dimensions.Size(this.Window.ClientBounds.Width, this.Window.ClientBounds.Height));
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            P1Sheet = Content.Load<Texture2D>(@"P1");
            P2Sheet = Content.Load<Texture2D>(@"P2");
            map = Content.Load<Map>("Map1");
            map.LoadTileSheets(xnaDisplayDevice);
            // TODO: use this.Content to load your game content here
           
            bomberman1 = new BomberMan(Keys.Up, Keys.Down, Keys.Left, Keys.Right, new Vector2(32, 32), P1Sheet, new Rectangle(0, 0, 32, 32), Vector2.Zero, map.Layers[0]);
            bomberman2 = new BomberMan(Keys.W, Keys.S, Keys.A, Keys.D, new Vector2(22 * 32, 23 * 32), P2Sheet, new Rectangle(0, 0, 32, 32), Vector2.Zero, map.Layers[0]);

            bomberman1.Tagged = true;
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();


            bomberman1.Update(gameTime);
            bomberman2.Update(gameTime);

            if (bomberman1.IsBoxColliding(bomberman2.BoundingBoxRect))
            {
                // The two are colliding
                bomberman1.Tagged = !bomberman1.Tagged;
                bomberman2.Tagged = !bomberman2.Tagged;

                if (bomberman1.Tagged)
                    
                {
                    // Relocate bomberman2
                    bomberman2.location = new Vector2(23 * 32, 23 * 32);
                }
                else
                {
                    // Relocate bomberman1
                    bomberman1.location = new Vector2(32,32);
                }
            }

         

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.DarkGreen);
            map.Draw(xnaDisplayDevice, viewport);
            // TODO: Add your drawing code here

            spriteBatch.Begin();
            bomberman1.Draw(spriteBatch);
            bomberman2.Draw(spriteBatch);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
