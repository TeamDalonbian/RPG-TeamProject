using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WitchHunter.Models.MapTextures.Obstacles
{
    public abstract class Obstacle : GameObject
    {
        protected Obstacle(Texture2D objTexture, Rectangle rectangle)
            : base(objTexture, rectangle)
        {

        }
    }

}
