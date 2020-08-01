using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureDreamsDamageCalculator
{
    public class StatsCalculator
    {
        public static readonly uint ATK_DEF_DIVISOR = 64;
        public static readonly uint MP_LUCK_DIVISOR = 1024;
        public static readonly uint MAX_STAT = 255;

        public static uint calculateAttack(UnitTraits unitTraits, uint level)
        { return calculateStat(level, unitTraits.baseAttack, unitTraits.attackGrowth, ATK_DEF_DIVISOR); }
        public static uint calculateDefense(UnitTraits unitTraits, uint level)
        { return calculateStat(level, unitTraits.baseDefense, unitTraits.defenseGrowth, ATK_DEF_DIVISOR); }
        public static uint calculateHp(UnitTraits unitTraits, uint level)
        {
            uint calculatedHp = unitTraits.baseHp + 
                (uint)Math.Floor(unitTraits.hpGrowth * (level - 1) / 16.0f) + 
                (uint)Math.Floor(2896 * unitTraits.hpGrowth * Math.Sqrt(unitTraits.hpGrowth * (level - 1)) / 32768);
            return Math.Min(calculatedHp, MAX_STAT);
        }
        private static uint calculateStat(uint level, uint baseStat, uint statGrowth, uint statDivisor)
        { return Math.Min((uint)(baseStat + Math.Floor(baseStat * statGrowth * (level - 1) / (float)statDivisor)), MAX_STAT); }
    }
}
