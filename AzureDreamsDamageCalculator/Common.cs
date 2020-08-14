using System;
using System.Collections.Generic;
using System.Drawing;

namespace AzureDreamsDamageCalculator
{
    public enum Genus
    { None, Fire, Wind, Water }

    public enum SpecialTraits
    { None, DoubleHP, DoubleAttack, DoubleDefense, DoubleSpellGrowth }

    public interface Named
    { string Name { get; } }

    public class Helpers
    {
        public static SortedDictionary<string, T> CreateNamedDictionary<T>(T[] namedEntities) where T : Named
        {
            SortedDictionary<string, T> namedDictionary = new SortedDictionary<string, T>();
            foreach (T namedEntity in namedEntities)
            { namedDictionary[namedEntity.Name] = namedEntity; }
            return namedDictionary;
        }
    }

    public abstract class Weapon : Named
    {
        public static readonly Weapon NO_WEAPON = new ConstantDamageWeapon(name: "", damage: 0);

        public Weapon(string name, bool isWand = false, bool ignoresShield = false, Genus genus = Genus.None)
        {
            this.Name = name;
            this.IsWand = isWand;
            this.IgnoresShield = ignoresShield;
            this.Genus = genus;
        }
        public string Name
        { get; private set; }
        public bool IsWand
        { get; private set; }
        public bool IgnoresShield
        { get; private set; }
        public Genus Genus
        { get; private set; }
        public abstract int Quality
        { set; }


        public abstract uint WeaponDamage();
        public uint WandDamage()
        { return IsWand ? WeaponDamage() : 0; }
    }

    public class ConstantDamageWeapon : Weapon
    {
        public ConstantDamageWeapon(string name, uint damage, bool isWand = false, bool ignoresShield = false, Genus genus = Genus.None) 
            : base(name, isWand, ignoresShield, genus)
        { this.Damage = damage; }
        public uint Damage
        { get; private set; }
        public override int Quality
        { set { } }
        public override uint WeaponDamage()
        { return Damage; }
    }

    public class QualityBasedDamageWeapon : Weapon
    {
        public static readonly uint MIN_ATTACK = 0u;
        public static readonly uint MAX_WEAPON_DAMAGE = 99u;
        private int quality;

        public QualityBasedDamageWeapon(string name, uint baseAttack, bool isWand = false, bool ignoresShield = false, Genus genus = Genus.None)
            : base(name, isWand, ignoresShield, genus)
        {
            this.BaseAttack = baseAttack;
            this.quality = 0;
        }
        public uint BaseAttack
        { get; private set; }
        public override int Quality
        { set { this.quality = value; } }
        public override uint WeaponDamage()
        {  return Math.Min((uint)Math.Max(BaseAttack + quality, MIN_ATTACK), MAX_WEAPON_DAMAGE); }
    }

    public class Sword : QualityBasedDamageWeapon
    {
        public Sword(string name, uint baseAttack, Genus genus = Genus.None) : base(name, baseAttack: baseAttack, genus: genus)
        { }
    }

    public class Wand : QualityBasedDamageWeapon
    {
        public Wand(string name, Genus genus = Genus.None) : base(name, baseAttack: 1, isWand: true, genus: genus)
        { }
    }

    public class Shield : Named
    {
        public static readonly Shield NO_SHIELD = new Shield(name: "", baseDefense: 0);
        public static readonly uint MIN_DEFENSE = 0u;
        public static readonly uint MAX_SHIELD_DEFENSE = 99u;

        public Shield(string name, uint baseDefense = 0, Genus genus = Genus.None)
        {
            this.Name = name;
            this.BaseDefense = baseDefense;
            this.Quality = 0;
            this.Genus = genus;
        }
        public string Name
        { get; private set; }
        public uint BaseDefense
        { get; private set; }
        public int Quality
        { get; set; }
        public Genus Genus
        { get; set; }
        public uint ShieldDefense()
        { return Math.Min((uint)Math.Max(BaseDefense + Quality, MIN_DEFENSE), MAX_SHIELD_DEFENSE); }
    }

    public struct UnitTraits : Named
    {
        public string Name
        { get; set; }
        public uint BaseHp;
        public uint HpGrowth;
        public uint BaseMp;
        public uint MpGrowth;
        public uint BaseAttack;
        public uint AttackGrowth;
        public uint BaseDefense;
        public uint DefenseGrowth;
        public uint BaseAgility;
        public uint AgilityGrowth;
        public uint BaseLuck;
        public uint LuckGrowth;
        public uint BaseExpGiven;
        public uint ExpGivenGrowth;
        public Genus NativeGenus;
        public SpellTraits NativeSpell;
        public SpecialTraits SpecialTraits;
        public bool IsEvolved;
        public bool Liftable;
        public bool Pushable;
        public Bitmap Portrait;
    }

    public class UnitStatistics
    {
        public static readonly uint MIN_STAT = 1u;

        private uint baseAttack = 0;
        private uint baseDefense = 0;
        private int attackModifier = 0;
        private int defenseModifier = 0;

        public UnitStatistics(Genus genus = Genus.None)
        { this.Genus = genus; }
        public uint BaseAttack
        {
            get
            { return baseAttack; }
            set
            {
                this.baseAttack = value;
                CalculateAttack();
            }
        }
        public uint BaseDefense
        {
            get
            { return baseDefense; }
            set
            {
                this.baseDefense = value;
                CalculateDefense();
            }
        }
        public int AttackModifier
        {
            get
            { return attackModifier; }
            set
            {
                this.attackModifier = value;
                CalculateAttack();
            }
        }
        public int DefenseModifier
        {
            get
            { return defenseModifier; }
            set
            {
                this.defenseModifier = value;
                CalculateDefense();
            }
        }
        public Genus Genus
        { get; set; }
        public uint Attack
        { get; private set; }
        public uint Defense
        { get; private set; }
        private void CalculateAttack()
        { Attack = ModifiedStat(BaseAttack, AttackModifier); }
        private void CalculateDefense()
        { Defense = ModifiedStat(BaseDefense, DefenseModifier); }
        private uint ModifiedStat(uint baseStat, int modifier)
        { return (uint)Math.Max(baseStat + modifier, MIN_STAT); }
        public UnitStatistics Copy()
        {
            UnitStatistics stats = new UnitStatistics(Genus);
            stats.BaseAttack = BaseAttack;
            stats.BaseDefense = BaseDefense;
            stats.AttackModifier = AttackModifier;
            stats.DefenseModifier = DefenseModifier;
            stats.Attack = Attack;
            stats.Defense = Defense;
            return stats;
        }
    }

    public enum SpellDirectMagicType
    { None, Status, Damage }

    public enum SpellMixtureMagicType
    { None, Sword, Wave }

    public struct SpellTraits : Named
    {
        public static readonly SpellTraits EMPTY = new SpellTraits(
            name: "", 
            genus: Genus.None, 
            rawDamage: 0, 
            directMagicType: SpellDirectMagicType.None, 
            mixtureMagicType: SpellMixtureMagicType.None);

        public SpellTraits(
            string name, 
            Genus genus, 
            uint rawDamage, 
            SpellMixtureMagicType mixtureMagicType, 
            SpellDirectMagicType directMagicType = SpellDirectMagicType.Damage)
        {
            this.Name = name;
            this.Genus = genus;
            this.RawDamage = rawDamage;
            this.DirectMagicType = directMagicType;
            this.MixtureMagicType = mixtureMagicType;
        }
        public string Name
        { get; private set; }
        public Genus Genus
        { get; set; }
        public uint RawDamage
        { get; private set; }
        public SpellDirectMagicType DirectMagicType
        { get; private set; }
        public SpellMixtureMagicType MixtureMagicType
        { get; private set; }
        public SpellTraits Copy()
        { return new SpellTraits(Name, Genus, RawDamage, MixtureMagicType, DirectMagicType); }
        public SpellTraits Copy(string newName)
        { return new SpellTraits(newName, Genus, RawDamage, MixtureMagicType, DirectMagicType); }
    }

    public class Spell
    {
        public static readonly Spell NO_SPELL = new Spell(SpellTraits.EMPTY) { Level = 0 };
        public static readonly uint MIN_SPELL_LEVEL = 1u;
        public static readonly uint MAX_SPELL_LEVEL = 99u;

        private SpellTraits traits;

        public Spell(SpellTraits traits) : this(traits: traits, level: 1)
        { }
        public Spell(SpellTraits traits, uint level)
        {
            this.traits = traits.Copy();
            this.Level = level;
            this.Genus = traits.Genus;
        }
        public string Name
        { get { return this.traits.Name; } }
        public uint Level
        { get; set; }
        public Genus Genus
        { get; set; }
        public bool HasNativeGenus()
        { return Genus == traits.Genus; }
        public uint RawDamage
        { get { return traits.RawDamage; } }
        public bool IsDamagingDirectSpellType()
        { return traits.DirectMagicType == SpellDirectMagicType.Damage; }
        public bool IsDamagingMixtureMagic()
        { return traits.MixtureMagicType != SpellMixtureMagicType.None; }
        public bool IsSwordTypeMixtureMagic()
        { return traits.MixtureMagicType == SpellMixtureMagicType.Sword; }
        public bool IsWaveTypeMixtureMagic()
        { return traits.MixtureMagicType == SpellMixtureMagicType.Wave; }
        public Spell Copy()
        { return new Spell(traits, Level) { Genus = Genus }; }
        public override string ToString()
        { return traits.Name + "(" + traits.RawDamage + ")"; }
    }

    public class BallSpell : Spell
    {
        public static readonly BallSpell NO_BALL_SPELL = new BallSpell(SpellTraits.EMPTY, minCharges: 0, maxCharges: 0);
        public static readonly uint DEFAULT_MIN_CHARGES = 4;
        public static readonly uint DEFAULT_MAX_CHARGES = 7;

        public BallSpell(SpellTraits traits) : this(traits, minCharges: DEFAULT_MIN_CHARGES, maxCharges: DEFAULT_MAX_CHARGES)
        { }
        public BallSpell(SpellTraits traits, uint minCharges, uint maxCharges) : base(traits)
        {
            MinCharges = minCharges;
            MaxCharges = maxCharges;
        }
        public void AddCharge()
        {
            MinCharges += 1;
            MaxCharges += 1;
        }
        public void RemoveCharge()
        {
            if (MinCharges > 0)
            { MinCharges -= 1; }
            if (MaxCharges > 0)
            { MaxCharges -= 1; }
        }
        public bool IsIdentified()
        { return MinCharges == MaxCharges; }
        public void Identify(uint charges)
        {
            MinCharges = charges;
            MaxCharges = charges;
        }
        public uint MinCharges
        { get; private set; }
        public uint MaxCharges
        { get; private set; }
        public override string ToString()
        {
            string spellName = base.ToString();
            string chargesString = "[" + MinCharges.ToString();
            if (!IsIdentified())
            { chargesString += "-" + MaxCharges; }
            chargesString += "]";
            return spellName + chargesString;
        }
    }

    public class Unit
    {
        public Unit(UnitTraits traits, uint level = 1)
        {
            this.Traits = traits;
            this.SpecialTraits = SpecialTraits.None;
            this.Level = level;
            this.Stats = new UnitStatistics(traits.NativeGenus);
            this.Weapon = Weapon.NO_WEAPON;
            this.Shield = Shield.NO_SHIELD;
            this.IsFrog = false;
        }
        public UnitTraits Traits
        { get; private set; }
        public SpecialTraits SpecialTraits
        { get; set; }
        public bool HasDoubleHP()
        { return SpecialTraits == SpecialTraits.DoubleHP; }
        public bool HasDoubleAttack()
        { return SpecialTraits == SpecialTraits.DoubleAttack; }
        public bool HasDoubleDefense()
        { return SpecialTraits == SpecialTraits.DoubleDefense; }
        public bool HasDoubleSpellGrowth()
        { return SpecialTraits == SpecialTraits.DoubleSpellGrowth; }
        public virtual uint Level
        { get; set; }
        public UnitStatistics Stats
        { get; set; }
        public Genus Genus
        {
            get
            { return Stats.Genus; }
            set
            { Stats.Genus = value; }
        }
        public Weapon Weapon
        { get; set; }
        public Shield Shield
        { get; set; }
        public bool IsFrog
        { get; set; }
        public void RemoveWeapon()
        { this.Weapon = Weapon.NO_WEAPON; }
        public void RemoveShield()
        { this.Shield = Shield.NO_SHIELD; }
        public bool IsNativeGenus
        { get { return Traits.NativeGenus == Genus; } }
    }

    public class Monster : Unit
    {
        public Monster(UnitTraits traits, uint level, uint hp, uint mp) : base(traits, level)
        {
            this.HP = hp;
            this.MP = mp;
            this.Spell = new Spell(traits.NativeSpell, level);
            this.Genus = traits.NativeGenus;
        }
        public new Genus Genus
        {
            get
            { return base.Genus; }
            set
            {
                base.Genus = value;
                Spell.Genus = value;
            }
        }
        public uint HP
        { get; private set; }
        public uint MP
        { get; private set; }
        public Bitmap Portrait
        { get; private set; }
        public Spell Spell
        { get; set; }
        public Monster Copy()
        {
            Monster monster = new Monster(Traits, Level, HP, MP);
            monster.SpecialTraits = SpecialTraits;
            monster.Stats = Stats.Copy();
            monster.Weapon = Weapon;
            monster.Portrait = Portrait;
            monster.Spell = Spell.Copy();
            return monster;
        }
    }

    public class Familiar : Monster
    {
        public Familiar(UnitTraits traits) : base(traits, level:1, hp: 0, mp: 0)
        {
            this.Spell2 = Spell.NO_SPELL.Copy();
            this.Genus = traits.NativeGenus;
        }
        public new Genus Genus
        {
            get
            { return base.Genus; }
            set
            {
                base.Genus = value;
                Spell2.Genus = value;
            }
        }
        public Spell Spell2
        { get; set; }
    }
}
