using RpgTextGame.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpgTextGame.Utilities
{
    internal class DamageAlgo
    {
        public int NormalPlayerDamage(ICharacter character)
        {
            int damage = (int)Math.Round(character.Strength * 1.5);
            return damage;
        }
    }
}
