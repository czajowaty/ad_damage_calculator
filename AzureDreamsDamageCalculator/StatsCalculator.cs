using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureDreamsDamageCalculator
{
    public class StatsCalculator
    {
        public static readonly uint ATK_DEF_DIVISOR = 64u;
        public static readonly uint MP_LUCK_DIVISOR = 1024u;
        public static readonly uint MAX_STAT = 255u;

        public static uint Attack(UnitTraits traits, uint level)
        { return CalculateStat(level, traits.BaseAttack, traits.AttackGrowth, ATK_DEF_DIVISOR); }
        public static uint Defense(UnitTraits traits, uint level)
        { return CalculateStat(level, traits.BaseDefense, traits.DefenseGrowth, ATK_DEF_DIVISOR); }
        public static uint HP(UnitTraits traits, uint level)
        {
            uint calculatedHp = traits.BaseHp + 
                (uint)Math.Floor(traits.HpGrowth * (level - 1) / 16.0f) + 
                (uint)Math.Floor(2896 * traits.HpGrowth * Math.Sqrt(traits.HpGrowth * (level - 1)) / 32768);
            return Math.Min(calculatedHp, MAX_STAT);
        }
        public static uint MP(UnitTraits traits, uint level)
        { return CalculateStat(level, traits.BaseMp, traits.MpGrowth, MP_LUCK_DIVISOR);  }
        private static uint CalculateStat(uint level, uint baseStat, uint statGrowth, uint statDivisor)
        { return Math.Min((uint)(baseStat + Math.Floor(baseStat * statGrowth * (level - 1) / (float)statDivisor)), MAX_STAT); }
    }
}
