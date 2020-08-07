using System;

namespace AzureDreamsDamageCalculator
{
    public class StatsCalculator
    {
        public static readonly uint ATK_DEF_DIVISOR = 64u;
        public static readonly uint MP_LUCK_DIVISOR = 1024u;
        public static readonly uint MAX_STAT = 255u;

        public static uint Attack(UnitTraits traits, uint level, bool doubleStat)
        { return CalculateStat(ref traits, level, traits.BaseAttack, traits.AttackGrowth, ATK_DEF_DIVISOR, doubleStat); }
        public static uint Defense(UnitTraits traits, uint level, bool doubleStat)
        { return CalculateStat(ref traits, level, traits.BaseDefense, traits.DefenseGrowth, ATK_DEF_DIVISOR, doubleStat); }
        public static uint HP(UnitTraits traits, uint level, bool doubleStat)
        {
            // TODO: Calculate HP correctly for evolved monsters
            uint calculatedHp = traits.BaseHp +
                (uint)Math.Floor(traits.HpGrowth * (level - 1) / 16.0f) +
                (uint)Math.Floor(2896 * traits.HpGrowth * Math.Sqrt(traits.HpGrowth * (level - 1)) / 32768);
            return CappedStat(calculatedHp, doubleStat);
        }
        public static uint MP(UnitTraits traits, uint level)
        { return CalculateStat(ref traits, level, traits.BaseMp, traits.MpGrowth, MP_LUCK_DIVISOR, false); }
        private static uint CalculateStat(ref UnitTraits traits, uint level, uint baseStat, uint statGrowth, uint statDivisor, bool doubleStat)
        {
            uint stat = traits.IsEvolved ?
                CalculateEvolvedStat(level, baseStat, statGrowth, statDivisor) :
                CalculateNonEvolvedStat(level, baseStat, statGrowth, statDivisor);
            return CappedStat(stat, doubleStat);
        }
        private static uint CalculateNonEvolvedStat(uint level, uint baseStat, uint statGrowth, uint statDivisor)
        { return baseStat + HelperCalculation(baseStat, statGrowth, level - 1, statDivisor); }
        private static uint CalculateEvolvedStat(uint level, uint baseStat, uint statGrowth, uint statDivisor)
        {
            uint stat = baseStat;
            for (uint n = 1; n < level; ++n)
            { stat = stat + HelperCalculation(baseStat, statGrowth, n, statDivisor) - HelperCalculation(baseStat, statGrowth, n - 1, statDivisor); }
            return stat;
        }
        private static uint HelperCalculation(uint baseStat, uint statGrowth, uint n, uint statDivisor)
        { return (uint)Math.Floor((double)((baseStat * statGrowth * n) / statDivisor));  }
        private static uint CappedStat(uint stat, bool doubleStat)
        {
            if (doubleStat)
            { stat *= 2; }
            return Math.Min(stat, MAX_STAT);
        }
    }
}
