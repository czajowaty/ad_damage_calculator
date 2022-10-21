namespace AzureDreamsDamageCalculator
{
    public class MonsterCreator
    {
        public MonsterCreator(UnitTraits traits, uint level)
        {
            this.Traits = traits;
            this.Level = level;
            this.Weapon = Weapon.NO_WEAPON;
            if (traits.SelectNativeWeapon != null)
            { GiveWeapon(traits.SelectNativeWeapon(level)); }
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
            Talents talents = monsterCreator.Traits.Talents;
            Monster monster = new Monster(
                monsterCreator.Traits,
                monsterCreator.Level,
                StatsCalculator.HP(monsterCreator.Traits, monsterCreator.Level, talents.Has(Talents.HpIncreased)),
                StatsCalculator.MP(monsterCreator.Traits, monsterCreator.Level));
            monster.Stats.Genus = monsterCreator.Traits.NativeGenus;
            monster.Stats.BaseAttack = StatsCalculator.Attack(monsterCreator.Traits, monsterCreator.Level, talents.Has(Talents.StrengthIncreased));
            monster.Stats.BaseDefense = StatsCalculator.Defense(monsterCreator.Traits, monsterCreator.Level, talents.Has(Talents.Hard));
            monster.Stats.Exp = StatsCalculator.Exp(monsterCreator.Traits, monsterCreator.Level);
            monster.Weapon = monsterCreator.Weapon;
            return monster;
        }
    }
}
