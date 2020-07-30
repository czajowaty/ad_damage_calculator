using System;
using System.Drawing;

public enum Genus
{ None, Fire, Wind, Water }

public abstract class Weapon
{
    public readonly bool isWand;
    public readonly bool ignoresShield;
    public readonly Genus genus;

    public Weapon(bool isWand = false, bool ignoresShield = false, Genus genus = Genus.None)
    {
        this.isWand = isWand;
        this.ignoresShield = ignoresShield;
        this.genus = genus;
    }

    public abstract void SetQuality(int quality);
    public abstract uint WeaponDamage();
    public uint WandDamage()
    {
        if (isWand)
        { return WeaponDamage(); }
        else
        { return 0; }
    }
}

public class ConstantDamageWeapon : Weapon
{
    public readonly uint damage;

    public ConstantDamageWeapon(uint damage, bool isWand = false, bool ignoresShield = false, Genus genus = Genus.None) 
        : base(isWand, ignoresShield, genus)
    { this.damage = damage; }

    public override void SetQuality(int quality)
    { }
    public override uint WeaponDamage()
    { return damage; }
}

public class QualityBasedDamageWeapon : Weapon
{
    private readonly uint attack;
    public int quality;

    public QualityBasedDamageWeapon(uint attack, bool isWand = false, bool ignoresShield = false, Genus genus = Genus.None)
        : base(isWand, ignoresShield, genus)
    {
        this.attack = attack;
        this.quality = 0;
    }

    public override void SetQuality(int quality)
    { this.quality = quality; }
    public override uint WeaponDamage()
    {  return Math.Min(Math.Max((uint)(attack + quality), 0u), 99u); }
}

public class Sword : QualityBasedDamageWeapon
{
    public Sword(uint attack, Genus genus = Genus.None) : base(attack: attack, genus: genus)
    { }
}

public class Wand : QualityBasedDamageWeapon
{
    public Wand(Genus genus = Genus.None) : base(attack: 1, isWand: true, genus: genus)
    { }
}

public struct Shield
{
    public readonly uint defense;
    public int quality;
    public readonly Genus genus;

    public Shield(uint defense = 0, Genus genus = Genus.None)
    {
        this.defense = defense;
        this.quality = 0;
        this.genus = genus;
    }

    public uint ShieldDefense()
    { return Math.Min(Math.Max((uint)(defense + quality), 0u), 99u); }
}

public class UnitStatistics
{
    public uint attack;
    public uint defense;
    public Genus genus;

    public UnitStatistics(uint attack, uint defense, Genus genus = Genus.None)
    {
        this.attack = attack;
        this.defense = defense;
        this.genus = genus;
    }
}

public class Unit
{
    public static readonly Weapon NO_WEAPON = new ConstantDamageWeapon(damage: 0);
    public static readonly Shield NO_SHIELD = new Shield(defense: 0);

    public UnitStatistics unitStatistics;
    public Weapon weapon;
    public Shield shield;
    public bool isFrog;

    public Unit() : this(new UnitStatistics(attack: 0, defense: 0), NO_WEAPON)
    { }
    public Unit(UnitStatistics unitStatistics, Weapon weapon)
    {
        this.unitStatistics = unitStatistics;
        this.weapon = weapon;
        this.shield = NO_SHIELD;
        this.isFrog = false;
    }

    public void RemoveWeapon()
    { this.weapon = NO_WEAPON; }
    public void RemoveShield()
    { this.shield = NO_SHIELD; }
}

public class Familiar : Unit
{
    public uint spellLevel;

    public Familiar() : base(new UnitStatistics(attack: 0, defense: 0), NO_WEAPON)
    { this.spellLevel = 0; }

    public Spell Spell()
    { return new Spell(this.spellLevel, unitStatistics.genus); }
}

public class Monster : Unit
{
    public readonly string name;
    public readonly uint hp;
    public readonly uint mp;
    public readonly Bitmap image;

    public Monster(string name, UnitStatistics unitStatistics, uint hp, uint mp, Bitmap image) : this(name, unitStatistics, hp, mp, image, NO_WEAPON)
    { }
    public Monster(string name, UnitStatistics unitStatistics, uint hp, uint mp, Bitmap image, Weapon weapon) : base(unitStatistics, weapon)
    {
        this.name = name;
        this.hp = hp;
        this.mp = mp;
        this.image = image;
    }
}

public struct Spell
{
    public readonly uint level;
    public readonly Genus genus;

    public Spell(uint level, Genus genus)
    {
        this.level = level;
        this.genus = genus;
    }
}
