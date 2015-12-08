using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using WitchHunter.Interfaces;

namespace WitchHunter.Models.MapTextures
{
    class Grass : BackgroundObject
    {

        public Grass(Texture2D objTexture, Rectangle rectangle)
            : base(objTexture, rectangle)
        {
        }
    }
}
