using RpgTextGame.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace RpgTextGame.Utilities
{
    public class DamageAlgo
    {
        public int NormalPlayerDamage(ICharacter character ,Enemy enemy)
        {
            if(enemy.Level == character.CurrentLevel)
            {
            int damage = (int)Math.Round(character.Strength * 1.5 - enemy.Defance * 0.5);
            return damage;
            }
           else if (enemy.Level > character.CurrentLevel)
            {
                int damage = (int)Math.Round(character.Strength * 1.5 - enemy.Defance * 0.5 * (enemy.Level - character.CurrentLevel) * 1.2);
                return damage;
            } else
            {
                int damage = (int)Math.Round(character.Strength * 1.5 - (enemy.Defance * 0.5 * 5 )/ ((character.CurrentLevel - enemy.Level)*6));
                return damage;
            }
        }

        public int NormalEnemyDamage(ICharacter character, Enemy enemy)
        {
            if (enemy.Level == character.CurrentLevel)
            {
                int damage = (enemy.Damage - Convert.ToInt32(character.Constitution / 2));
                return damage;
            }
            else if (character.CurrentLevel > enemy.Level)
            {
                int damage = (int)Math.Round(enemy.Damage - Convert.ToInt32(character.Constitution / 2) * (character.CurrentLevel - enemy.Level) * 1.2);
                return damage;
            }
            else
            {
                int damage = (int)Math.Round((double)(enemy.Damage - Convert.ToInt32(character.Constitution / 2)* 5 /((enemy.Level - character.CurrentLevel) * 6)));
                return damage;
            }
        }
    }
}
