using System;
using System.Collections.Generic;

namespace AzureDreamsDamageCalculator
{
    public class DamageCalculator
    {
        static readonly Spell NO_SPELL = new Spell(level: 0, genus: Genus.None);

        public uint nonSpellAttackDamage(Unit attacker, Unit defender, byte damageRoll, int highGround, bool isCriticalHit)
        { return spellAttackDamage(attacker, defender, damageRoll, highGround, isCriticalHit, NO_SPELL); }
        public uint spellAttackDamage(Unit attacker, Unit defender, byte damageRoll, int highGround, bool isCriticalHit, Spell spell)
        {
            uint baseDamage = calculateBaseDamage(attacker, damageRoll, spell);
            uint baseDefense = calculateBaseDefense(attacker, defender);
            int combatAdvantage = calculateCombatAdvantage(attacker, defender, spell, highGround);
            int combatAdvantageDamage = (int)Math.Floor(baseDamage * combatAdvantage / 8.0f);
            int damage = (int)Math.Floor((baseDamage + combatAdvantageDamage - baseDefense) / 2.0f);
            float criticalHitMultiplier = calculateCriticalHitMultiplier(isCriticalHit);
            return (uint)Math.Max(damage * criticalHitMultiplier, 1);
        }
        private uint calculateBaseDamage(Unit attacker, byte damageRoll, Spell spell)
        {
            uint unitDamage = 2 * attacker.unitStatistics.attack + damageRoll;
            uint weaponFactorDamage = 2 * attacker.weapon.WeaponDamage();
            float spellMultiplier = calculateSpellMultiplier(attacker.weapon, spell);
            uint spellFactorDamage = (uint)Math.Floor((unitDamage + attacker.weapon.WandDamage()) * (spellMultiplier * spell.level) / (spell.level + 1));
            return unitDamage + weaponFactorDamage + spellFactorDamage;
        }
        private float calculateSpellMultiplier(Weapon weaponStatistics, Spell spell)
        {
            float spellMultiplier = 1.0f;
            if (weaponStatistics.isWand)
            { spellMultiplier += 0.5f; }
            if (weaponStatistics.genus != Genus.None && weaponStatistics.genus == spell.genus)
            { spellMultiplier += 0.5f; }
            return spellMultiplier;
        }
        private uint calculateBaseDefense(Unit attacker, Unit defender)
        {
            uint frogPenalty = defender.isFrog ? 2u : 1u;
            uint shieldDefense = attacker.weapon.ignoresShield ? 0 : defender.shield.ShieldDefense();
            return (uint)Math.Max(Math.Floor((defender.unitStatistics.defense + shieldDefense) / (float)frogPenalty), 1);
        }
        private int calculateCombatAdvantage(Unit attacker, Unit defender, Spell spell, int highGround)
        {
            Genus[] attackerElements = findAttackerElements(attacker, spell);
            Genus defenderElement = findDefenderElement(defender);
            int elementalAdvantages = (int)calculateElementalAdvantages(attackerElements, defenderElement);
            int elementalDisadvantages = (int)calculateElementalDisadvantages(attackerElements, defenderElement);
            return elementalAdvantages - 2 * elementalDisadvantages + highGround;
        }
        private Genus[] findAttackerElements(Unit attacker, Spell spell)
        {
            HashSet<Genus> elements = new HashSet<Genus> { attacker.unitStatistics.genus, attacker.weapon.genus, spell.genus };
            elements.Remove(Genus.None);
            Genus[] attackerElements = new Genus[elements.Count];
            elements.CopyTo(attackerElements);
            return attackerElements;
        }
        private Genus findDefenderElement(Unit defender)
        {
            if (defender.unitStatistics.genus != Genus.None)
            { return defender.unitStatistics.genus; }
            else
            { return defender.shield.genus; }
        }
        private uint calculateElementalAdvantages(Genus[] attackerElements, Genus defenderElement)
        {
            uint elementalAdvantages = 0;
            foreach (Genus attackerElement in attackerElements)
            {
                if (hasElementalAdvantage(attackerElement, defenderElement))
                { ++elementalAdvantages; }
            }
            return elementalAdvantages;
        }
        private bool hasElementalAdvantage(Genus attackerElement, Genus defenderElement)
        {
            return attackerElement == Genus.Fire && defenderElement == Genus.Wind ||
                attackerElement == Genus.Wind && defenderElement == Genus.Water ||
                attackerElement == Genus.Water && defenderElement == Genus.Fire;
        }
        private uint calculateElementalDisadvantages(Genus[] attackerElements, Genus defenderElement)
        {
            uint elementalAdvantages = 0;
            foreach (Genus attackerElement in attackerElements)
            {
                if (hasElementalDisadvantage(attackerElement, defenderElement))
                { ++elementalAdvantages; }
            }
            return elementalAdvantages;
        }
        private bool hasElementalDisadvantage(Genus attackerElement, Genus defenderElement)
        {
            return attackerElement == Genus.Fire && defenderElement == Genus.Water ||
                attackerElement == Genus.Wind && defenderElement == Genus.Fire ||
                attackerElement == Genus.Water && defenderElement == Genus.Wind;
        }
        private float calculateCriticalHitMultiplier(bool isCriticalHit)
        { return isCriticalHit ? 1.5f : 1.0f; }
    }
}
