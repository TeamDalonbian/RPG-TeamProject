using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using WitchHunter.Engine;
using WitchHunter.Interfaces;
using WitchHunter.Models.Characters.Heroes;

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

        public void Cast(Direction direction)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Methods
        public void Move()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
