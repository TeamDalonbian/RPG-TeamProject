using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using WitchHunter.Models.MapTextures.Obstacles;

namespace WitchHunter.Models.Characters.Heroes
{
    public class Player : Mage
    {
        private const int DefaultPhysicalAttack = 50;
        private const int DefaultPhysicalDefense = 15;
        private const int DefaultHealthPoints = 800;
        private const double DefaultSpeed = 3;



        public Player(Texture2D objTexture, Rectangle rectangle)
            : base(objTexture, rectangle, DefaultPhysicalAttack, DefaultPhysicalDefense, DefaultHealthPoints, DefaultSpeed)
        {
            this.Direction = Direction.Down;
            this.BaseSpeed = DefaultSpeed;
            this.IsVisible = true;
        }

        public double BaseSpeed { get; set; }

        public bool IsVisible { get; set; }

        public override void Move()
        {
            KeyboardState state = Keyboard.GetState();

            if (state.IsKeyDown(Keys.Up))
            {
                this.Direction = Direction.Up;
                this.Speed = this.BaseSpeed;
            }
            else if (state.IsKeyDown(Keys.Down))
            {
                this.Direction = Direction.Down;
                this.Speed = this.BaseSpeed;
            }
            else if (state.IsKeyDown(Keys.Left))
            {
                this.Direction = Direction.Left;
                this.Speed = this.BaseSpeed;
            }
            else if (state.IsKeyDown(Keys.Right))
            {
                this.Direction = Direction.Right;
                this.Speed = this.BaseSpeed;
            }
            else
            {
                this.Speed = 0;
            }

        }
        public override void Update()
        {
            base.Update();

            KeyboardState state = Keyboard.GetState();
            if (state.IsKeyDown(Keys.Space) && !this.HasAttacked)
            {
                this.Cast(this.Direction);
                this.HasAttacked = true;
            }
            else if (state.IsKeyUp(Keys.Space))
            {
                this.HasAttacked = false;
            }
        }
        public override void RespondToCollision(GameObject hitObject)
        {
            base.RespondToCollision(hitObject);

            //if (hitObject is Obstacle)
            //{
            //    this.Speed = 0;
            //}

        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
            //spriteBatch.DrawString(GameEngine.Font, string.Format("HP: {0}", this.Health), new Vector2(10, GameEngine.WindowHeight - 50), Color.Red);
        }
    }
}
