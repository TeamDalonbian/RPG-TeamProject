﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WitchHunter.Interfaces
{
    public interface IMoveable
    {
        double Speed { get; }
        void Move();
    }
}
