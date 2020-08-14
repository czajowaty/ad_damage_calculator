using System;
using System.Collections.Generic;

namespace AzureDreamsDamageCalculator
{
    public class DamageCalculator
    {
        public static uint standardAttackDamage(Unit attacker, Unit defender, byte damageRoll, int highGround, bool isCriticalHit)
        { return mixtureAttackDamage(attacker, defender, damageRoll, highGround, isCriticalHit, Spell.NO_SPELL); }
        public static uint mixtureAttackDamage(Unit attacker, Unit defender, byte damageRoll, int highGround, bool isCriticalHit, Spell spell)
        {
            uint baseDamage = calculateBaseDamage(attacker, damageRoll, spell);
            uint baseDefense = calculateBaseDefense(attacker, defender);
            int combatAdvantage = calculateCombatAdvantage(attacker, defender, spell, highGround);
            int combatAdvantageDamage = (int)Math.Floor(baseDamage * combatAdvantage / 8.0f);
            int damage = (int)Math.Floor((baseDamage + combatAdvantageDamage - baseDefense) / 2.0f);
            float criticalHitMultiplier = calculateCriticalHitMultiplier(isCriticalHit);
            return (uint)Math.Max(damage * criticalHitMultiplier, 1);
        }
        public static uint spellAttackDamage(Unit attacker, Unit defender, Spell spell)
        {
            uint baseDamage = (spell.RawDamage + spell.Level) * 2;
            uint baseDefense = calculateBaseDefense(attacker, defender);
            int combatAdvantage = calculateSpellCombatAdvantage(spell, defender);
            int combatDamage = (int)(baseDamage * combatAdvantage);
            if (combatAdvantage < 0)
            { combatDamage = (int)Math.Floor((combatDamage + 3) / 4.0f); }
            return (uint)Math.Max(Math.Floor((baseDamage + combatDamage - baseDefense) / 2.0f), 1u);
        }
        private static uint calculateBaseDamage(Unit attacker, byte damageRoll, Spell spell)
        {
            uint unitDamage = 2 * attacker.Stats.Attack + damageRoll;
            uint weaponFactorDamage = 2 * attacker.Weapon.WeaponDamage();
            float spellMultiplier = calculateSpellMultiplier(attacker.Weapon, spell);
            uint spellFactorDamage = (uint)Math.Floor(
                (unitDamage + 2 * attacker.Weapon.WandDamage()) * Math.Floor(spellMultiplier * spell.Level) / (spell.Level + 1));
            return unitDamage + weaponFactorDamage + spellFactorDamage;
        }
        private static float calculateSpellMultiplier(Weapon weaponStatistics, Spell spell)
        {
            float spellMultiplier = 1.0f;
            if (weaponStatistics.IsWand)
            { spellMultiplier += 0.5f; }
            if (weaponStatistics.Genus != Genus.None && weaponStatistics.Genus == spell.Genus)
            { spellMultiplier += 0.5f; }
            return spellMultiplier;
        }
        private static uint calculateBaseDefense(Unit attacker, Unit defender)
        {
            uint frogPenalty = defender.IsFrog ? 2u : 1u;
            uint shieldDefense = attacker.Weapon.IgnoresShield ? 0 : defender.Shield.ShieldDefense();
            return (uint)Math.Max(Math.Floor((defender.Stats.Defense + shieldDefense) / (float)frogPenalty), 1);
        }
        private static int calculateCombatAdvantage(Unit attacker, Unit defender, Spell spell, int highGround)
        {
            Genus[] attackerElements = findAttackerElements(attacker, spell);
            Genus defenderElement = findDefenderElement(defender);
            int elementalAdvantages = (int)calculateElementalAdvantages(attackerElements, defenderElement);
            int elementalDisadvantages = (int)calculateElementalDisadvantages(attackerElements, defenderElement);
            return elementalAdvantages - 2 * elementalDisadvantages + highGround;
        }
        private static Genus[] findAttackerElements(Unit attacker, Spell spell)
        {
            HashSet<Genus> elements = new HashSet<Genus> { attacker.Stats.Genus, attacker.Weapon.Genus, spell.Genus };
            elements.Remove(Genus.None);
            Genus[] attackerElements = new Genus[elements.Count];
            elements.CopyTo(attackerElements);
            return attackerElements;
        }
        private static Genus findDefenderElement(Unit defender)
        {
            if (defender.Stats.Genus != Genus.None)
            { return defender.Stats.Genus; }
            else
            { return defender.Shield.Genus; }
        }
        private static int calculateSpellCombatAdvantage(Spell spell, Unit defender)
        {
            Genus[] attackerElements = { spell.Genus };
            Genus defenderElement = findDefenderElement(defender);
            int elementalAdvantages = (int)calculateElementalAdvantages(attackerElements, defenderElement);
            int elementalDisadvantages = (int)calculateElementalDisadvantages(attackerElements, defenderElement);
            return elementalAdvantages - elementalDisadvantages;
        }
        private static uint calculateElementalAdvantages(Genus[] attackerElements, Genus defenderElement)
        {
            uint elementalAdvantages = 0;
            foreach (Genus attackerElement in attackerElements)
            {
                if (hasElementalAdvantage(attackerElement, defenderElement))
                { ++elementalAdvantages; }
            }
            return elementalAdvantages;
        }
        private static bool hasElementalAdvantage(Genus attackerElement, Genus defenderElement)
        {
            return attackerElement == Genus.Fire && defenderElement == Genus.Wind ||
                attackerElement == Genus.Wind && defenderElement == Genus.Water ||
                attackerElement == Genus.Water && defenderElement == Genus.Fire;
        }
        private static uint calculateElementalDisadvantages(Genus[] attackerElements, Genus defenderElement)
        {
            uint elementalAdvantages = 0;
            foreach (Genus attackerElement in attackerElements)
            {
                if (hasElementalDisadvantage(attackerElement, defenderElement))
                { ++elementalAdvantages; }
            }
            return elementalAdvantages;
        }
        private static bool hasElementalDisadvantage(Genus attackerElement, Genus defenderElement)
        {
            return attackerElement == Genus.Fire && defenderElement == Genus.Water ||
                attackerElement == Genus.Wind && defenderElement == Genus.Fire ||
                attackerElement == Genus.Water && defenderElement == Genus.Wind;
        }
        private static float calculateCriticalHitMultiplier(bool isCriticalHit)
        { return isCriticalHit ? 1.5f : 1.0f; }
    }
}
