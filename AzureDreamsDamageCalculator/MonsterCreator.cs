namespace AzureDreamsDamageCalculator
{
    public class MonsterCreator
    {
        public MonsterCreator(UnitTraits traits, uint level)
        {
            this.Traits = traits;
            this.Level = level;
            this.Weapon = Weapon.NO_WEAPON;
        }
        private UnitTraits Traits
        { get; set; }
        private uint Level
        { get; set; }
        private Weapon Weapon
        { get; set; }
        public MonsterCreator GiveWeapon(Weapon weapon)
        {
            this.Weapon = weapon;
            return this;
        }
        public static implicit operator Monster(MonsterCreator monsterCreator)
        {
            SpecialTraits specialTraits = monsterCreator.Traits.SpecialTraits;
            Monster monster = new Monster(
                monsterCreator.Traits,
                monsterCreator.Level,
                StatsCalculator.HP(monsterCreator.Traits, monsterCreator.Level, specialTraits == SpecialTraits.DoubleHP),
                StatsCalculator.MP(monsterCreator.Traits, monsterCreator.Level));
            monster.Stats.Genus = monsterCreator.Traits.NativeGenus;
            monster.Stats.BaseAttack = StatsCalculator.Attack(monsterCreator.Traits, monsterCreator.Level, specialTraits == SpecialTraits.DoubleAttack);
            monster.Stats.BaseDefense = StatsCalculator.Defense(monsterCreator.Traits, monsterCreator.Level, specialTraits == SpecialTraits.DoubleDefense);
            monster.Weapon = monsterCreator.Weapon;
            return monster;
        }
    }
}
