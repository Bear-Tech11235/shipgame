using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using Microsoft.CSharp;
using System.Diagnostics;
using System.Text;
using System.Collections.Generic;
namespace Game2
{
    /// <summary>
   
    /// </summary>
    /// This is the player class
    public class Player
    {
        public static Texture2D Sprite;
        public Vector2 Position;
        public static Vector2 Velocity;
        public static double PlayerVSpeed = 0, PlayerHSpeed = 0;
    }
 /// This is the main type for your game.
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        private Texture2D ship1;
        double playerXvalue, playerYvalue;
        //the reason there is playerX and playerXvalue is because draw needs to use an int for its x and y coords,
        //but the calculations needed a double
        int playerX;
        int playerY;
        public Game1()

        {
            graphics = new GraphicsDeviceManager(this);
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
            ship1 = Content.Load<Texture2D>("spaceship0");
            ship1 = Content.Load<Texture2D>("spaceship1");
            ship1 = Content.Load<Texture2D>("spaceship3");
            ship1 = Content.Load<Texture2D>("spaceship4");
            playerXvalue = 0;
            playerYvalue = 0;

            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
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
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            //so basically it changes the sprite the only way i know how, and also wont increase or decrease the speed 
            //past 10 in either direction
            if (Keyboard.GetState().IsKeyDown(Keys.Right)){
                ship1 = Content.Load<Texture2D>("spaceship4");
                if (Player.PlayerHSpeed < 10)
                    {
                    Player.PlayerHSpeed =+ 1;
                    }
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                ship1 = Content.Load<Texture2D>("spaceship3");
                if (Player.PlayerHSpeed > -10)
                {
                    Player.PlayerHSpeed =- 1;
                }
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Down))
            {
                playerYvalue = playerYvalue + 5;
                ship1 = Content.Load<Texture2D>("spaceship1");
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Up))
            {
                playerYvalue = playerYvalue - 5;
                ship1 = Content.Load<Texture2D>("spaceship1");
            }
            var keyboardState = Keyboard.GetState();
            var keys = keyboardState.GetPressedKeys();
            //here it checks if the keyboard is being pressed, and if it isnt itll slow the ship back down to 0 horizontal movement.
            //it will also print "still" to console so i know its working lol
            //i use += 1 instead of ++ because the 1 is subject to change, i want it lower.
            if (keyboardState == (new KeyboardState())) {
                ship1 = Content.Load<Texture2D>("spaceship0");
                Console.WriteLine("Still");
                if (Player.PlayerHSpeed > 0)
                {
                    Player.PlayerHSpeed =- 1;
                }
                if (Player.PlayerHSpeed < 0)
                {
                    Player.PlayerHSpeed=+ 1;
                }
            }
            //to make sure the speed isnt being dodgy
            if (Player.PlayerHSpeed < -10)
                Player.PlayerHSpeed = -10;
            if (Player.PlayerHSpeed > 10)
                Player.PlayerHSpeed = 10;
            //converting to ints so that draw can actually use the values.
            //note that at this time, y axis movement simply works on yvalue =+ 5
            playerXvalue = playerXvalue + Player.PlayerHSpeed;
            playerX = Convert.ToInt32(Math.Round(playerXvalue));
            playerYvalue = playerYvalue + Player.PlayerVSpeed;
            playerY = Convert.ToInt32(Math.Round(playerYvalue));
            //debug
            Console.WriteLine("PlayerX = "+ playerX + "      Player.PlayerHSpeed = " + Player.PlayerHSpeed);
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();

            spriteBatch.Draw(ship1, new Rectangle(playerX, playerY, 100, 148), Color.White);

            spriteBatch.End();
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
