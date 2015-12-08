using System.Collections.Generic;
using System.Linq;
using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using WitchHunter.Engine;
using WitchHunter.Interfaces;
using WitchHunter.Models;
using WitchHunter.Models.Characters;
using WitchHunter.Models.Characters.Heroes;
using WitchHunter.Models.MapTextures;
using WitchHunter.Models.MapTextures.Obstacles;
using WitchHunter.Models.Spells;

namespace WitchHunter
{
    public class GameEngine : Game
    {
        public const int WindowWidth = 1024;
        public const int WindowHeight = 600;
        //public const int Offset = 25;

        public static Texture2D playerText;
        public static Texture2D grasText;
        public static Texture2D treeText;
        public static Texture2D frostBolt;

        public static List<GameObject> gameObjects = new List<GameObject>();
        public static List<BackgroundObject> backgroundObjecst = new List<BackgroundObject>();


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
            GameEngine.frostBolt = this.Content.Load<Texture2D>("frostbolt");



            GameEngine.gameObjects = MapLoader.LoadMap(spriteBatch);
        }

        protected override void UnloadContent()
        {
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed
                || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            var characters = GameEngine.gameObjects
                .Where(gameObj => !(gameObj is Obstacle)).ToList();

            var obstacles = GameEngine.gameObjects
                .Where(gameObj => gameObj is Obstacle).ToList();

            for (int i = 0; i < gameObjects.Count; i++)
            {
                gameObjects[i].Update();
            }

            for (int i = 0; i < characters.Count; i++)
            {
                characters[i].RespondToCollision(CollisionHandler.GetCollisionInfo(characters[i]));
            }

            for (int i = 0; i < obstacles.Count; i++)
            {
                obstacles[i].RespondToCollision(CollisionHandler.GetCollisionInfo(obstacles[i]));
            }

            gameObjects.RemoveAll(x => x.State == GameObjectStates.Destroyed);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();

            var character = GameEngine.gameObjects.Where(ch => ch is Character);
            var obstacles = GameEngine.gameObjects.Where(obs => obs is Tree);
            var spells = GameEngine.gameObjects.Where(sp => sp is Spell);


            foreach (var bgItem in backgroundObjecst)
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

            foreach (var spell in spells)
            {
                spell.Draw(spriteBatch);
            }
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
