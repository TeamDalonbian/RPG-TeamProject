using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WitchHunter.Items;

namespace WitchHunter.Interfaces
{
    public interface ICollect
    {
        void AddItemToInventory(Item item);

        void ApplyItemEffect(Item item);
    }
}
