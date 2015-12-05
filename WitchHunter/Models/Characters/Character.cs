using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WitchHunter.Engine;
using WitchHunter.Interfaces;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using WitchHunter.Models.Spells;
using WitchHunter.Models.Characters.Heroes;

namespace WitchHunter.Models.Characters
{
    public abstract class Character : GameObject, IAttack, IDestroyable
    {
        protected Character(Texture2D objTexture, Rectangle rectangle, int damage, int defense, int health)
            : base(objTexture, rectangle)
        {
            this.Damage = damage;
            this.Defense = defense;
            this.Health = health;
        }

        public int Damage { get; protected set; }
        public int Defense { get; protected set; }
        public int Health { get; protected set; }
        public bool HasAttacked { get; protected set; }
        public Vector2 PreviousPosition { get; set; }
        public Direction Direction { get; protected set; }

        public override void RespondToCollision(GameObject hitObject)
        {
            if (hitObject is Spell)
            {
                Spell spell = (Spell)hitObject;
                this.Health -= Math.Max(0, spell.Damage - this.Defense);
                this.State = GameObjectStates.Damaged;
            }

            if (this.Health <= 0)
            {
                this.State = GameObjectStates.Destroyed;
            }
        }

        public void Cast(Direction direction)
        {
            throw new NotImplementedException();
        }

      
     
    }
}
