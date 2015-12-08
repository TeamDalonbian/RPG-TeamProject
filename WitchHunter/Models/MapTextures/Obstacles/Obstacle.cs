using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WitchHunter.Models.Spells;

namespace WitchHunter.Models.MapTextures.Obstacles
{
    public abstract class Obstacle : GameObject
    {
        protected Obstacle(Texture2D objTexture, Rectangle rectangle)
            : base(objTexture, rectangle)
        {

        }

        public override void RespondToCollision(GameObject hitObject)
        {
            if (hitObject is Spell)
            {
                this.State = GameObjectStates.Destroyed;
            }
        }
    }

}
