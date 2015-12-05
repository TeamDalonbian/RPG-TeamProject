using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WitchHunter.Models.Characters;
using WitchHunter.Models.Characters.Heroes;

namespace WitchHunter.Engine
{
    public interface IAttack
    {
        int Damage { get; }

        void Cast(Direction direction);

    }
}
