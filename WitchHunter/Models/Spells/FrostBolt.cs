using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WitchHunter.Engine;
using WitchHunter.Interfaces;
using WitchHunter.Models.Characters.Heroes;

namespace WitchHunter.Models.Spells
{
    public class FrostBolt : Spell
    {
        public FrostBolt(Texture2D objTexture, Rectangle rectangle, int damage,
           Direction direction)
            : base(objTexture, rectangle, damage, direction)
        {
        }
    }
}
