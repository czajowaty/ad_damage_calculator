using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureDreamsDamageCalculator
{
    public class MonsterCreator
    {
        public MonsterCreator(UnitTraits traits, uint level)
        {
            this.Traits = traits;
            this.Level = level;
            this.Weapon = Weapon.NO_WEAPON;
            this.HpMultiplier = 1;
        }
        private UnitTraits Traits
        { get; set; }
        private uint Level
        { get; set; }
        private Weapon Weapon
        { get; set; }
        private uint HpMultiplier
        { get; set; }
        public MonsterCreator GiveWeapon(Weapon weapon)
        {
            this.Weapon = weapon;
            return this;
        }
        public MonsterCreator GiveDoubleHPTrait()
        {
            this.HpMultiplier = 2;
            return this;
        }
        public static implicit operator Monster(MonsterCreator monsterCreator)
        {
            Monster monster = new Monster(
                monsterCreator.Traits,
                monsterCreator.Level,
                StatsCalculator.HP(monsterCreator.Traits, monsterCreator.Level) * monsterCreator.HpMultiplier,
                StatsCalculator.MP(monsterCreator.Traits, monsterCreator.Level));
            monster.Stats.Genus = monsterCreator.Traits.NativeGenus;
            monster.Stats.BaseAttack = StatsCalculator.Attack(monsterCreator.Traits, monsterCreator.Level);
            monster.Stats.BaseDefense = StatsCalculator.Defense(monsterCreator.Traits, monsterCreator.Level);
            monster.Weapon = monsterCreator.Weapon;
            return monster;
        }
    }
}
