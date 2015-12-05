using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.Linq;
using WitchHunter.Engine;
using WitchHunter.Interfaces;
using WitchHunter.Models;
using WitchHunter.Models.Characters;
using WitchHunter.Models.Characters.Heroes;
using WitchHunter.Models.MapTextures;
using WitchHunter.Models.MapTextures.Obstacles;

namespace WitchHunter
{
    public class GameEngine : Game
    {
        public const int WindowWidth = 1024;
        public const int WindowHeight = 600;
        public const int Offset = 25;

        private Player player;
        public static Texture2D playerText;
        public static Texture2D grasText;
        public static Texture2D treeText;

        public static List<GameObject> gameObjects = new List<GameObject>();


        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        public GameEngine()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }
        protected override void Initialize()
        {

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(this.GraphicsDevice);

            this.graphics.PreferredBackBufferHeight = GameEngine.WindowHeight;
            this.graphics.PreferredBackBufferWidth = GameEngine.WindowWidth;
            this.graphics.ApplyChanges();

            GameEngine.playerText = this.Content.Load<Texture2D>("DownWalkingMage1");
            GameEngine.grasText = this.Content.Load<Texture2D>("gras");
            GameEngine.treeText = this.Content.Load<Texture2D>("Tree1");



            GameEngine.gameObjects = MapLoader.LoadMap(spriteBatch);
        }

        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            var objects = GameEngine.gameObjects.Where(gameObj => !(gameObj is Obstacle));
            foreach (var item in gameObjects)
            {
                item.Update();
            }
            foreach (var item in objects)
            {
                item.RespondToCollision(CollisionHandler.GetCollisionInfo(item));
            }
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            var backGround = GameEngine.gameObjects.Where(go => go is IBackGround);
            var character = GameEngine.gameObjects.Where(ch => ch is Character);
            var obstacles = GameEngine.gameObjects.Where(obs => obs is Tree);


            foreach (var bgItem in backGround)
            {
                bgItem.Draw(spriteBatch);
            }

            foreach (var item in character)
            {
                item.Draw(spriteBatch);
            }
            foreach (var item in obstacles)
            {
                item.Draw(spriteBatch);
            }
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
