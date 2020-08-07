using System;
using System.Drawing;

namespace AzureDreamsDamageCalculator
{
    public enum Genus
    { None, Fire, Wind, Water }

    public enum SpecialTraits
    { None, DoubleHP, DoubleAttack, DoubleDefense, DoubleSpellGrowth }

    public interface Named
    { string Name { get; } }
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
    }

    public struct SpellTraits : Named
    {
        public static readonly SpellTraits EMPTY = new SpellTraits(name: "", genus: Genus.None);

        public SpellTraits(string name, Genus genus, uint rawDamage = 0)
        {
            this.Name = name;
            this.Genus = genus;
            this.RawDamage = rawDamage;
        }
        public string Name
        { get; private set; }
        public uint RawDamage
        { get; private set; }
        public Genus Genus
        { get; set; }
        public SpellTraits Copy()
        { return new SpellTraits(Name, Genus) { RawDamage = RawDamage }; }
    }

    public class Spell
    {
        public static Spell NO_SPELL = new Spell(SpellTraits.EMPTY);
        public static readonly uint MIN_SPELL_LEVEL = 1u;
        public static readonly uint MAX_SPELL_LEVEL = 99u;

        private SpellTraits traits;
        private uint baseLevel;
        private int levelModifier = 0;

        public Spell(SpellTraits traits) : this(traits: traits, baseLevel: 0)
        { }
        public Spell(SpellTraits traits, uint baseLevel)
        {
            this.traits = traits.Copy();
            this.BaseLevel = baseLevel;
        }
        public string Name
        { get { return IsValid() ? this.traits.Name : SpellTraits.EMPTY.Name; } }
        public uint BaseLevel
        {
            get
            { return this.baseLevel; }
            set
            {
                this.baseLevel = value;
                CalculateLevel();
            }
        }
        public int LevelModifier
        {
            get
            { return levelModifier; }
            set
            {
                this.levelModifier = value;
                CalculateLevel();
            }
        }
        public uint Level
        { get; private set; }
        public Genus Genus
        {
            get { return traits.Genus; }
            set { traits.Genus = value; }
        }
        public uint RawDamage
        { get { return traits.RawDamage; } }
        private void CalculateLevel()
        { Level = (uint)Math.Min(Math.Max(BaseLevel + levelModifier, MIN_SPELL_LEVEL), MAX_SPELL_LEVEL); }
        public bool IsValid()
        { return traits.RawDamage > 0; }
    }

    public class Unit
    {
        public Unit(UnitTraits traits, uint level = 1) : this(traits, SpellTraits.EMPTY, level)
        { }
        public Unit(UnitTraits traits, SpellTraits spellTraits, uint level = 1)
        {
            this.Traits = traits;
            this.SpecialTraits = SpecialTraits.None;
            this.Level = level;
            this.Stats = new UnitStatistics();
            this.Weapon = Weapon.NO_WEAPON;
            this.Shield = Shield.NO_SHIELD;
            this.IsFrog = false;
            this.Spell = new Spell(spellTraits, level);
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
            {
                Stats.Genus = Genus;
                Spell.Genus = Genus;
            }
        }
        public Weapon Weapon
        { get; set; }
        public Shield Shield
        { get; set; }
        public bool IsFrog
        { get; set; }
        public Spell Spell
        { get; set; }
        public bool HasSpell()
        { return Spell.IsValid(); }
        public void RemoveWeapon()
        { this.Weapon = Weapon.NO_WEAPON; }
        public void RemoveShield()
        { this.Shield = Shield.NO_SHIELD; }
        public bool IsNativeGenus
        { get { return Traits.NativeGenus == Genus; } }
    }

    public class Monster : Unit
    {
        public Monster(UnitTraits traits, uint level, uint hp, uint mp) : this(traits, level, hp, mp, SpellTraits.EMPTY)
        { }
        public Monster(UnitTraits traits, uint level, uint hp, uint mp, SpellTraits spellTraits) : base(traits, spellTraits, level)
        {
            this.HP = hp;
            this.MP = mp;
        }
        public uint HP
        { get; private set; }
        public uint MP
        { get; private set; }
        public Bitmap Portrait
        { get; private set; }
    }
}
