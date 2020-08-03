using System;

namespace AzureDreamsDamageCalculator
{
    public class StatsCalculator
    {
        public static readonly uint ATK_DEF_DIVISOR = 64u;
        public static readonly uint MP_LUCK_DIVISOR = 1024u;
        public static readonly uint MAX_STAT = 255u;

        public static uint Attack(UnitTraits traits, uint level)
        { return CalculateStat(ref traits, level, traits.BaseAttack, traits.AttackGrowth, ATK_DEF_DIVISOR); }
        public static uint Defense(UnitTraits traits, uint level)
        { return CalculateStat(ref traits, level, traits.BaseDefense, traits.DefenseGrowth, ATK_DEF_DIVISOR); }
        public static uint HP(UnitTraits traits, uint level)
        {
            // TODO: Calculate HP correctly for evolved monsters
            uint calculatedHp = traits.BaseHp +
                (uint)Math.Floor(traits.HpGrowth * (level - 1) / 16.0f) +
                (uint)Math.Floor(2896 * traits.HpGrowth * Math.Sqrt(traits.HpGrowth * (level - 1)) / 32768);
            return Math.Min(calculatedHp, MAX_STAT);
        }
        public static uint MP(UnitTraits traits, uint level)
        { return CalculateStat(ref traits, level, traits.BaseMp, traits.MpGrowth, MP_LUCK_DIVISOR);  }
        private static uint CalculateStat(ref UnitTraits traits, uint level, uint baseStat, uint statGrowth, uint statDivisor)
        {
            if (traits.IsEvolved)
            { return CalculateEvolvedStat(level, baseStat, statGrowth, statDivisor); }
            else
            { return CalculateNonEvolvedStat(level, baseStat, statGrowth, statDivisor);  }
        }
        private static uint CalculateNonEvolvedStat(uint level, uint baseStat, uint statGrowth, uint statDivisor)
        { return (uint)Math.Min((baseStat + HelperCalculation(baseStat, statGrowth, level - 1, statDivisor)), MAX_STAT); }
        private static uint CalculateEvolvedStat(uint level, uint baseStat, uint statGrowth, uint statDivisor)
        {
            uint stat = baseStat;
            for (uint n = 1; n < level; ++n)
            {
                stat = (uint)Math.Min(
                    stat + HelperCalculation(baseStat, statGrowth, n, statDivisor) - HelperCalculation(baseStat, statGrowth, n - 1, statDivisor),
                    MAX_STAT);
            }
            return stat;
        }
        private static uint HelperCalculation(uint baseStat, uint statGrowth, uint n, uint statDivisor)
        { return (uint)Math.Floor((double)((baseStat * statGrowth * n) / statDivisor));  }
    }
}
