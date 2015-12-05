using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WitchHunter.Models;

namespace WitchHunter.Interfaces
{
    public interface IColliadable
    {
        void RespondToCollision(GameObject hitObject);

    }
}
