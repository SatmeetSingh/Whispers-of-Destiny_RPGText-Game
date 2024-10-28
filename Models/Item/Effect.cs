using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpgTextGame.Models.Item
{
    public enum EffectType
    {
        Heal,
        Damage,
        Buff
    }
    public abstract class Effect
    {
        public int Duration { get; set; }
        public abstract EffectType Type { get; }
    }

    public class HealEffect : Effect
    {
        public override EffectType Type => EffectType.Heal;
        public int HealAmount { get; set; }
    }

    public class DamageEffect : Effect
    {
        public override EffectType Type => EffectType.Damage;
        public int DamageAmount { get; set; }
    }

    public class BuffEffect : Effect
    {
        public override EffectType Type => EffectType.Buff;
        public int BuffAmount { get; set; }
        public string BuffType { get; set; } // e.g., strength, agility, etc.
    }
}
