using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using WitchHunter.Engine;
using WitchHunter.Interfaces;
using WitchHunter.Models.Characters.Heroes;
using WitchHunter.Models.Characters;
using WitchHunter.Models.MapTextures.Obstacles;

namespace WitchHunter.Models.Spells
{
    public abstract class Spell : GameObject, IAttack, IMoveable
    {
        private const double DefaultSpeed = 6;
        protected Spell(Texture2D objTexture, Rectangle rectangle, int damage,
            Direction direction)
            : base(objTexture, rectangle)
        {
            this.Damage = damage;
            this.Direction = direction;
            this.Speed = Spell.DefaultSpeed;
        }
        #region Properties
        public double Speed { get; protected set; }

        public Direction Direction { get; protected set; }

        public int Damage { get; protected set; }


        #endregion

        #region Methods

        public void Cast(Direction direction)
        {
            throw new NotImplementedException();
        }
        public void Move()
        {

            switch (this.Direction)
            {
                case Direction.Up:
                    this.Rectangle = new Rectangle(
                        this.Rectangle.X,
                        (int)(this.Rectangle.Y - this.Speed),
                        this.Rectangle.Width,
                        this.Rectangle.Height);
                    break;
                case Direction.Down:
                    this.Rectangle = new Rectangle(
                        this.Rectangle.X,
                        (int)(this.Rectangle.Y + this.Speed),
                        this.Rectangle.Width,
                        this.Rectangle.Height);
                    break;
                case Direction.Left:
                    this.Rectangle = new Rectangle(
                        (int)(this.Rectangle.X - this.Speed),
                        this.Rectangle.Y,
                        this.Rectangle.Width,
                        this.Rectangle.Height);
                    break;
                case Direction.Right:
                    this.Rectangle = new Rectangle(
                        (int)(this.Rectangle.X + this.Speed),
                        this.Rectangle.Y,
                        this.Rectangle.Width,
                        this.Rectangle.Height);
                    break;
            }
        }

        public override void Update()
        {
            this.Move();
            this.CheckOutOfBounds();
        }

        public override void RespondToCollision(GameObject hitObject)
        {
            if (hitObject is Character  || hitObject is Obstacle)
            {
                this.State = GameObjectStates.Destroyed;
              
            }
        }
        private void CheckOutOfBounds()
        {
            if (this.Rectangle.X < 0 ||
                           this.Rectangle.X > GameEngine.WindowWidth ||
                           this.Rectangle.Y < 0 ||
                           this.Rectangle.Y > GameEngine.WindowHeight)
            {
                this.State = GameObjectStates.Destroyed;
            }
        }
        #endregion
    }
}
