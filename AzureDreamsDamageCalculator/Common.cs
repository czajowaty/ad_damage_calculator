using System;
using System.Collections.Generic;
using System.Drawing;

namespace AzureDreamsDamageCalculator
{
    public enum Genus
    { None, Fire, Wind, Water }

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

    public struct Talent : Named
    {
        public Talent(string name, uint flag)
        {
            Name = name;
            Flag = flag;
        }
        public string Name
        { get; private set; }
        public uint Flag
        { get; private set; }
    }

    public struct Talents
    {
        public static readonly Talent None = new Talent("", 0x0);
        public static readonly Talent HpIncreased = new Talent("HP increased", 0x2);
        public static readonly Talent StrengthIncreased = new Talent("Strength increased", 0x8);
        public static readonly Talent Hard = new Talent("Hard", 0x10);
        public static readonly Talent MagicAttackIncreased = new Talent("Magic Attack increased", 0x80);

        private uint talentFlags;

        public bool Has(Talent talent)
        { return (talentFlags & talent.Flag) == talent.Flag; }
        public void Add(Talent talent)
        { talentFlags |= talent.Flag; }
        public void Remove(Talent talent)
        { talentFlags &= ~talent.Flag; }
        public static implicit operator Talents(Talent talent)
        {
            Talents talents = new Talents();
            talents.talentFlags = talent.Flag;
            return talents;
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
        public delegate Weapon WeaponSelector(uint level);
        public WeaponSelector SelectNativeWeapon;
        public Genus NativeGenus;
        public SpellTraits NativeSpell;
        public Talents Talents;
        public bool IsEvolved;
        public bool Liftable;
        public bool Pushable;
        public Bitmap Portrait;

        public UnitTraits WithTalents(Talents newTalents)
        {
            UnitTraits newUnitTraits = new UnitTraits();
            newUnitTraits.Name = this.Name;
            newUnitTraits.BaseHp = this.BaseHp;
            newUnitTraits.HpGrowth = this.HpGrowth;
            newUnitTraits.BaseMp = this.BaseMp;
            newUnitTraits.MpGrowth = this.MpGrowth;
            newUnitTraits.BaseAttack = this.BaseAttack;
            newUnitTraits.AttackGrowth = this.AttackGrowth;
            newUnitTraits.BaseDefense = this.BaseDefense;
            newUnitTraits.DefenseGrowth = this.DefenseGrowth;
            newUnitTraits.BaseAgility = this.BaseAgility;
            newUnitTraits.AgilityGrowth = this.AgilityGrowth;
            newUnitTraits.BaseLuck = this.BaseLuck;
            newUnitTraits.LuckGrowth = this.LuckGrowth;
            newUnitTraits.BaseExpGiven = this.BaseExpGiven;
            newUnitTraits.ExpGivenGrowth = this.ExpGivenGrowth;
            newUnitTraits.NativeGenus = this.NativeGenus;
            newUnitTraits.NativeSpell = this.NativeSpell;
            newUnitTraits.Talents = newTalents;
            newUnitTraits.SelectNativeWeapon = this.SelectNativeWeapon;
            newUnitTraits.IsEvolved = this.IsEvolved;
            newUnitTraits.Liftable = this.Liftable;
            newUnitTraits.Pushable = this.Pushable;
            newUnitTraits.Portrait = this.Portrait;
            return newUnitTraits;
        }
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
        public uint Exp
        { get; set; }
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
            stats.Exp = Exp;
            return stats;
        }
    }

    public enum SpellDirectMagicType
    { None, Status, Damage }

    public enum SpellMixtureMagicType
    { None, Sword, Wave, Blade, Shoot, AOE }

    public struct SpellTraits : Named
    {
        public static readonly SpellTraits EMPTY = new SpellTraits(
            name: "", 
            genus: Genus.None, 
            directRawDamage: 0, 
            directMagicType: SpellDirectMagicType.None, 
            mixtureRawDamage: 0,
            mixtureMagicType: SpellMixtureMagicType.None);

        public SpellTraits(
            string name,
            Genus genus,
            uint directRawDamage = 0,
            SpellDirectMagicType directMagicType = SpellDirectMagicType.None,
            uint mixtureRawDamage = 0,
            SpellMixtureMagicType mixtureMagicType = SpellMixtureMagicType.None)
        {
            this.Name = name;
            this.Genus = genus;
            this.DirectRawDamage = directRawDamage;
            this.DirectMagicType = directRawDamage > 0 ? SpellDirectMagicType.Damage : directMagicType;
            this.MixtureRawDamage = mixtureMagicType != SpellMixtureMagicType.None && mixtureRawDamage == 0 ? directRawDamage : mixtureRawDamage;
            this.MixtureMagicType = mixtureMagicType;
        }
        public string Name
        { get; private set; }
        public Genus Genus
        { get; set; }
        public uint DirectRawDamage
        { get; private set; }
        public SpellDirectMagicType DirectMagicType
        { get; private set; }
        public uint MixtureRawDamage
        { get; private set; }
        public SpellMixtureMagicType MixtureMagicType
        { get; private set; }
        public SpellTraits Copy()
        { return Copy(Name); }
        public SpellTraits Copy(string newName)
        { return new SpellTraits(newName, Genus, DirectRawDamage, DirectMagicType, MixtureRawDamage, MixtureMagicType); }
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
        public uint DirectRawDamage
        { get { return traits.DirectRawDamage; } }
        public uint MixtureRawDamage
        { get { return traits.MixtureRawDamage; } }
        public SpellMixtureMagicType MixtureMagicType
        { get { return traits.MixtureMagicType; } }
        public bool IsDamagingDirectSpellType()
        { return traits.DirectMagicType == SpellDirectMagicType.Damage; }
        public bool IsDamagingMixtureMagic()
        { return MixtureMagicType != SpellMixtureMagicType.None; }
        public bool IsSwordTypeMixtureMagic()
        { return MixtureMagicType == SpellMixtureMagicType.Sword; }
        public Spell Copy()
        { return new Spell(traits, Level) { Genus = Genus }; }
        public override string ToString()
        { return traits.Name + "(" + traits.DirectRawDamage + ")"; }
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
        public Talents Talents;

        public Unit(UnitTraits traits, uint level = 1)
        {
            this.Traits = traits;
            this.Talents = new Talents();
            this.Level = level;
            this.Stats = new UnitStatistics(traits.NativeGenus);
            this.Weapon = Weapon.NO_WEAPON;
            this.Shield = Shield.NO_SHIELD;
            this.IsFrog = false;
        }
        public UnitTraits Traits
        { get; private set; }
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
            monster.Talents = Talents;
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

    public struct Egg
    {
        public Egg(string name, float probability)
        {
            Name = name;
            Probability = probability;
        }
        public string Name
        { get; private set; }
        public float Probability
        { get; private set; }
    }
}
